namespace PlanetZooApp

open FSharp.Json
open FsHttp.DslCE
open System.IO
open System.Net

open PlanetZooApp.ZooAnimal
open PlanetZooApp.Types

module FilterFunctions =

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

    let filterRegion (animalList: ZooAnimal List) (regionList: Region List) : ZooAnimal List =
        animalList
        |> List.filter
            (fun animal ->
                match animal.region with
                | Some animalRegions ->
                    animalRegions
                    |> List.exists (fun region -> List.contains region regionList)
                | None -> false)

    let filterVivarium (animalList: ZooAnimal list) : ZooAnimal list =
        animalList
        |> List.filter (fun animal -> animal.exhibit)

    let filterNotVivarium (animalList: ZooAnimal list) : ZooAnimal list =
        animalList
        |> List.filter (fun animal -> not animal.exhibit)

    let isFilterSet = Option.isSome

    let isAnimalListFiltered (state: State) : bool =
        [
            state.biomeListFilter |> isFilterSet
            state.continentListFilter |> isFilterSet
            state.dlcListFilter |> isFilterSet
            state.regionListFilter |> isFilterSet
            state.notVivariumFilter
            state.vivariumFilter
        ]
        |> List.exists id
