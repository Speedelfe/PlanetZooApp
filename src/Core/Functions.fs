namespace PlanetZooApp

open FSharp.Json
open FsHttp.DslCE
open System.IO
open System.Net
open PlanetZooApp.ZooAnimal

open Types

module Functions =
    let mainDataUrl =
        "https://raw.githubusercontent.com/olmobuining/zoopedia-data/master/mixed-data.json"

    let additionalDataUrl =
        "https://raw.githubusercontent.com/Speedelfe/PlanetZooApp/main/more_animals.json"


    let animalDataPath = "./animal-data.json"
    let animalDataAdditionalPath = "./more_animals.json"

    let downloadFile (fileUrl: string) (filePath: string) =
        let wc = new WebClient()

        wc.DownloadFileTaskAsync(fileUrl, filePath)
        |> Async.AwaitTask

    let loadFile dataPath =
        match File.Exists dataPath with
        | false -> []
        | true ->
            File.ReadAllText dataPath
            |> Json.deserialize<ZooAnimalJson list>

    let loadAnimalData () =
        async {
            if not (File.Exists animalDataPath) then
                do! downloadFile mainDataUrl animalDataPath

            if not (File.Exists animalDataAdditionalPath) then
                do! downloadFile additionalDataUrl animalDataAdditionalPath

            return
                [
                    animalDataPath
                    animalDataAdditionalPath
                ]
                |> List.map loadFile
                |> List.concat
                |> List.fold
                    (fun map animalJson ->
                        let animal = (createZooAnimalFromJson animalJson)
                        Map.add (AnimalKey animalJson.key) animal map)
                    Map.empty
        }

    let loadAnimalRegionList (animalList: ZooAnimal list) =
        animalList
        |> List.choose (fun animal -> animal.region)
        |> List.concat
        |> Set.ofList

    type ImageDownloadResult =
        | AlreadyDownloaded of string
        | HasToBeDownloaded of (unit -> Async<string>)

    let downloadImage (AnimalKey key) url =
        let imgPath =
            $"{Path.GetTempPath()}/planetzooapp/img/%s{key}.jpg"

        if File.Exists imgPath then
            AlreadyDownloaded imgPath
        else
            let job () =
                async {
                    do! Async.Sleep 100

                    let response =
                        http {
                            GET url
                            CacheControl "no-cache"
                        }

                    let! imgData =
                        response.content.ReadAsByteArrayAsync()
                        |> Async.AwaitTask

                    // Wir legen den Ordner an
                    imgPath
                    |> Path.GetDirectoryName
                    |> Directory.CreateDirectory
                    |> ignore

                    File.WriteAllBytes(imgPath, imgData)

                    return imgPath
                }

            HasToBeDownloaded job

    let regionsFromAnimalList (animalList: ZooAnimal list) =
        let folder (set: Set<Region>) (animal: ZooAnimal) : Set<Region> =
            match animal.region with
            | None -> set
            | Some region -> region |> Set.ofList |> Set.union set

        List.fold folder Set.empty animalList
