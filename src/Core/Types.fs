namespace PlanetZooApp

open FSharp.Json


module Types =
    type AnimalKey = AnimalKey of string

    type Continent =
        | Africa
        | Asia
        | [<JsonUnionCase(Case = "Central America")>] CentralAmerica
        | Europe
        | [<JsonUnionCase(Case = "North America")>] NorthAmerica
        | Oceania
        | [<JsonUnionCase(Case = "South America")>] SouthAmerica

    type Biome =
        | Aquatic
        | Desert
        | Grassland
        | Taiga
        | Temperate
        | Tropical
        | Tundra

    type Region = string

    type Dlc =
        | Africa
        | Aquatic
        | Arctic
        | Australia
        | Deluxe
        | [<JsonUnionCase(Case = "South America")>] SouthAmerica
        | [<JsonUnionCase(Case = "Southeast Asia")>] SoutheastAsia


    type LifeExpectancy = { male: int; female: int }

    type Humidity = { min: int; max: int }

    type Temperature = { min: int; max: int }

    type Fence =
        {
            grade: int
            height: float
            climbproof: bool
        }

    type Size = { min: int; max: int }
    type GroupBachelor = { size: Size }
    type GroupMixed = { size: Size; male: int; female: int }

    type HabitatRequirements =
        {
            guest_enter: bool option
            exhibit: bool
            [<JsonField("land")>]
            land_: int option
            land_additional: int option
            water_additional: int option
            climbable_additional: int option
            water: int option
            climbable: int option
            humidity: Humidity
            temperature: Temperature
            fence: Fence Option
            group_male: GroupBachelor option
            group_female: GroupBachelor option
            group_mixed: GroupMixed option
        }

    type ZooAnimalJson =
        {
            name: string
            continent: Continent list
            biome: Biome list
            can_swim: bool option
            status: string
            exhibit: bool
            dominance: string
            relationship_human: string option
            mating_system: string
            life_expectancy: LifeExpectancy
            habitat_requirements: HabitatRequirements
            latin_name: string
            category: string
            description: string
            image_url: string option
            slug: string
            key: string
        }

    type ZooAnimal =
        {
            name: string
            nameGerman: string
            continent: Continent list
            region: Region list option
            biome: Biome list
            dlc: Dlc option
            can_swim: bool
            status: string
            exhibit: bool
            dominance: string
            relationship_human: string option
            mating_system: string
            life_expectancy: LifeExpectancy
            habitat_requirements: HabitatRequirements
            latin_name: string
            category: string
            description: string
            image_url: string option
            image_path: string option
            slug: string
        }

    //type ZooAnimal = NormalAnimal of NormalAnimal
    (*| VAnimal of VAnimal*)

    type ViewMode =
        | ListView
        | DetailView of ZooAnimal
        | FilterView

    type State =
        {
            animalMap: Map<AnimalKey, ZooAnimal>
            continentListFilter: Continent List option
            dlcListFilter: Dlc List Option
            biomeListFilter: Biome List Option
            vivariumFilter: bool
            notVivariumFilter: bool
            viewMode: ViewMode
        }

    type Msg =
        | SaveAnimalData of Map<AnimalKey, ZooAnimal>
        | ChooseAnimal of ZooAnimal
        | LookForImageJob
        | DownloadImage of (AnimalKey * string)
        | SaveImage of (AnimalKey * string)
        | AsyncError of exn
        | ShowAnimalList
        | FilterAnimalListByContinent of Continent List
        | RemoveContinentFromFilterList of Continent
        | FilterAnimalListByDLC of Dlc List
        | RemoveDlcFromFilterList of Dlc
        | FilterAnimalListByBiome of Biome List
        | RemoveBiomeFromFilterList of Biome
        | FilterAnimalListByVivarium of bool
        | FilterAnimalListByNotVivarium of bool
        | ShowFilterView
