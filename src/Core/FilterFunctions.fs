namespace PlanetZooApp

open FSharp.Json
open FsHttp.DslCE
open System.IO
open System.Net

open PlanetZooApp.ZooAnimal
open PlanetZooApp.Types

module FilterFunctions =
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
