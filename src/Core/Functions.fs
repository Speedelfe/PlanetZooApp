namespace PlanetZooApp

open FSharp.Json
open FsHttp.DslCE
open System.IO
open PlanetZooApp.ZooAnimal

open Types

module Functions =
    let animalDataPath = "./mixed-data.json"

    let loadFile () =
        match File.Exists animalDataPath with
        | false -> []
        | true ->
            File.ReadAllText animalDataPath
            |> Json.deserialize<ZooAnimalJson list>

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


    let filtercontinent (animalList: ZooAnimal List) (continentList: Continent List) : ZooAnimal List =
        let mutable resultList : ZooAnimal list = []

        for animal in animalList do
            for continent in animal.continent do
                for wantedContinent in continentList do
                    if continent = wantedContinent then
                        resultList <- animal :: resultList

        List.rev resultList

(*let doIWantThisAnimal (animal: ZooAnimal) =
            List.exists (fun continent -> List.contains continent continentList) animal.continent

        List.filter doIWantThisAnimal animalList*)
