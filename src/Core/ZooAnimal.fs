namespace PlanetZooApp

open PlanetZooApp.Types

module ZooAnimal =
    type MoreZooAnimal =
        {
            name: string
            dlc: Dlc option
            region: Region List
        }

    let nacharbeiten (animal: ZooAnimal) =
        match animal.name with
        | "Aardvark" ->
            { animal with
                region = Some [ "Subsahara-Afrika" ]
                dlc = None
            }
        | "African Buffalo" ->
            { animal with
                region = Some [ "Subsahara-Afrika" ]
                dlc = None
            }
        | "African Elephant" ->
            { animal with
                region =
                    Some [
                        "Subsahara-Afrika: Kenia, Tansania, Botswana, Simbabw, Namibia, Angola"
                    ]
                dlc = None
            }
        | "African Wild Dog" ->
            { animal with
                region = Some [ "Subsahara-Afrika " ]
                dlc = None
            }
        | "Aldabra Giant Tortoise" ->
            { animal with
                region = Some [ "Sechellen" ]
                dlc = None
            }
        | "Amazonian Giant Centipede" ->
            { animal with
                region =
                    Some [
                        "Überall in Südamerika und der Karibik"
                    ]
                dlc = None
            }
        | "American Bison" ->
            { animal with
                region = Some [ "Kanada, USA" ]
                dlc = None
            }
        | "Arctic Wolf" ->
            { animal with
                region = Some [ "Kanada, Grönland" ]
                dlc = Some Arctic
            }
        | _ -> animal

    let createZooAnimalFromJson (json: ZooAnimalJson) =
        {
            name = json.name
            continent = json.continent
            biome = json.biome
            region = None
            dlc = None
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
        |> nacharbeiten
