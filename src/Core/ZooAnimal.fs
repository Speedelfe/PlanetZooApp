namespace PlanetZooApp

open PlanetZooApp.Types

module ZooAnimal =

    let nacharbeiten (animal: ZooAnimal) =
        match animal.name with
        // A
        | "Aardvark" ->
            { animal with
                region = Some [ "Subsahara-Afrika" ]
                dlc = None
                nameGerman = "Erdferkel"
            }
        | "African Buffalo" ->
            { animal with
                region = Some [ "Subsahara-Afrika" ]
                dlc = None
                nameGerman = "Kaffernbüffel"
            }
        | "African Elephant" ->
            { animal with
                region =
                    Some [
                        "Subsahara-Afrika: Kenia, Tansania, Botswana, Simbabw, Namibia, Angola"
                    ]
                dlc = None
                nameGerman = "Afrikanischer Elefant"
            }
        | "African Wild Dog" ->
            { animal with
                region = Some [ "Subsahara-Afrika " ]
                dlc = None
                nameGerman = "Afrikanischer Wildhund"
            }
        | "Aldabra Giant Tortoise" ->
            { animal with
                region = Some [ "Sechellen" ]
                dlc = None
                nameGerman = "Aldabra-Riesenschildkröte"
            }
        | "Amazonian Giant Centipede" ->
            { animal with
                region =
                    Some [
                        "Überall in Südamerika und der Karibik"
                    ]
                dlc = None
                nameGerman = "Brasilianischer Riesenläufer"
            }
        | "American Bison" ->
            { animal with
                region = Some [ "Kanada, USA" ]
                dlc = None
                nameGerman = "Amerikanischer Bison"
            }
        | "Arctic Wolf" ->
            { animal with
                region = Some [ "Kanada, Grönland" ]
                dlc = Some Arctic
                nameGerman = "Polarwolf"
            }
        // B
        | "Babirusa" -> //TODO: muss komplett gesetzt werden
            { animal with
                region = Some [ "Indonesien" ]
                dlc = Some SoutheastAsia
                nameGerman = "Babirusa"
            }
        | "Bactrian Camel" ->
            { animal with
                region =
                    Some [
                        "Mongolei, China, Himalaya und Sibirien"
                    ]
                dlc = None
                nameGerman = "Trampeltier"
            }
        | "Baird's Tapir" ->
            { animal with
                region =
                    Some [
                        "Belize, Kolmbien, Costa Rica, Guatemala, Honduras, Mexiko, Nicaragua, Panama"
                    ]
                dlc = None
                nameGerman = "Mittelamerikanischer Tapir"
            }
        | "Bengal Tiger" ->
            { animal with
                region =
                    Some [
                        "Indien, Bangladesch, Nepal, Bhutan, China, Myanmar"
                    ]
                dlc = None
                nameGerman = "Königstiger"
            }
        | "Binturong" -> //TODO: muss komplett gesetzt werden
            { animal with
                region =
                    Some [
                        "Philippinen, Bhutan, Thailand, Malaysia, Indonesien, Brunei, Singapur, Laos, Vietnam, Myanmar, Kambodscha, Bangladesch, China, Indien, Nepal"
                    ]
                dlc = Some SoutheastAsia
                nameGerman = "Binturong"
            }
        | "Black Wildebeest" ->
            { animal with
                region =
                    Some [
                        "Südafrika, Swasiland, Lesotho, Namibia"
                    ]
                dlc = None
                nameGerman = "Weißschwanzgnu"
            }
        | "Boa Constrictor" ->
            { animal with
                region = Some [ "Kanada,Grönland" ]
                dlc = None
                nameGerman = "Abgottschlange"
            }
        | "Bongo" ->
            { animal with
                region =
                    Some [
                        "Kamerun, Zentralafrikanische Republik, Republik Kongo, Demokratische Republik Kongo, Elfenbeinküste, Äquatorialguinea, Gabun, Ghana, Liberia, Sierra Leone, Südsudan"
                    ]
                dlc = None
                nameGerman = "Bongo"
            }
        | "Bonobo" ->
            { animal with
                region = Some [ "Demokratische Republik Kongo" ]
                dlc = None
                nameGerman = "Bonobo"
            }
        | "Bornean Orangutan" ->
            { animal with
                region = Some [ "Borneo, Malaysia, Indonesien" ]
                dlc = None
                nameGerman = "Borneo-Orang-Utan"
            }
        | "Brazilian Wandering Spider" ->
            { animal with
                region =
                    Some [
                        "Brasilien, Kolumbien, Venezuela, Ecuador, Peru, Bolivien, Paraguay, Argentinien"
                    ]
                dlc = None
                nameGerman = "Brasilianische Wanderspinne"
            }
        | "Brazilien Salmon Pink Tarantula" ->
            { animal with
                region = Some [ "Brasilien" ]
                dlc = None
                nameGerman = "Brasilianische Riesenvogelspinne"
            }
        | _ -> animal

    let createZooAnimalFromJson (json: ZooAnimalJson) =
        {
            name = json.name
            nameGerman = ""
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
