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
    type GroupMale = { size: Size }
    type GroupFemale = { size: Size }

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
            group_male: GroupMale option
            group_female: GroupFemale option
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
            image_url: string
            slug: string
            key: string
        }

    // TODO: Nutzen oder weg damit
    type ZooAnimal =
        {
            name: string
            continent: Continent list
            biome: Biome list
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
            image_url: string
            image_path: string option
            slug: string
        }

    module ZooAnimal =
        let createFromJson (json: ZooAnimalJson) =
            {
                name = json.name
                continent = json.continent
                biome = json.biome
                can_swim = json.can_swim |> Option.defaultValue false
                status = json.status
                exhibit = json.exhibit
                dominance = json.dominance
                relationship_human = json.relationship_human
                mating_system = json.mating_system
                life_expectancy = json.life_expectancy
                habitat_requirements = json.habitat_requirements
                latin_name = json.latin_name
                category = json.category
                description = json.description
                image_url = json.image_url
                image_path = None
                slug = json.slug
            }

//type ZooAnimal = NormalAnimal of NormalAnimal
(*| VAnimal of VAnimal*)
