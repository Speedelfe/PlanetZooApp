namespace PlanetZooApp

open FSharp.Json
open FsHttp.DslCE
open System.IO
open System.Net

open PlanetZooApp.ZooAnimal
open PlanetZooApp.Types

module FilterFunctions =
    // let filtercontinent (animalList: ZooAnimal List) (continentList: Continent List) : ZooAnimal List =
    //     let mutable resultList : ZooAnimal list = []

    //     for animal in animalList do
    //         for continent in animal.continent do
    //             for wantedContinent in continentList do
    //                 if continent = wantedContinent then
    //                     resultList <- animal :: resultList

    //     List.rev resultList

    let filtercontinent (animalList: ZooAnimal List) (continentList: Continent List) : ZooAnimal List =
        animalList
        |> List.filter
            (fun animal ->
                animal.continent
                |> List.exists (fun continent -> List.contains continent continentList))

    let filterDLC (animalList: ZooAnimal list) (dlcList: Dlc list) : ZooAnimal List =
        let mutable resultList : ZooAnimal list = []

        for animal in animalList do
            match animal.dlc with
            | None -> ()
            | Some dlc ->
                for wantedDLC in dlcList do
                    if dlc = wantedDLC then
                        resultList <- animal :: resultList

        List.rev resultList

    let filterBiome (animalList: ZooAnimal list) (biomeList: Biome List) : ZooAnimal List =
        let mutable resultList : ZooAnimal list = []

        for animal in animalList do
            for biome in animal.biome do
                for wantedBiome in biomeList do
                    if biome = wantedBiome then
                        resultList <- animal :: resultList

        List.rev resultList

    let filterVivarium (animalList: ZooAnimal list) : ZooAnimal list =
        animalList
        |> List.filter (fun animal -> animal.exhibit = true)

    let filterNotVivarium (animalList: ZooAnimal list) : ZooAnimal list =
        animalList
        |> List.filter (fun animal -> animal.exhibit = false)


(*let doIWantThisAnimal (animal: ZooAnimal) =
                List.exists (fun continent -> List.contains continent continentList) animal.continent

        List.filter doIWantThisAnimal animalList*)
