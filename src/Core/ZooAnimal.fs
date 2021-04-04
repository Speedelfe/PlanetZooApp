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
                        "Mongolei, China, Himalaya, Sibirien"
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
        // C
        | "Cheetah" ->
            { animal with
                region =
                    Some [
                        "Niger, Sudan, Äthiopien, Kenia, Tansania, Namibia, Botswana"
                    ]
                dlc = None
                nameGerman = "Gepard"
            }
        | "Chinese Pangolin" ->
            { animal with
                region =
                    Some [
                        "Indien, Nepal, Bhutan, Bangladesch, Myanmar, Süden von China, Hainan, Taiwan"
                    ]
                dlc = None
                nameGerman = "Chinesisches Schuppentier"
            }
        | "Clouded Leopard" -> // TODO: muss noch komplett gesetzt werden
            { animal with
                region =
                    Some [
                        "Malaysia, Thailand, Kambodscha, Vietnam, Laos, Myanmar, China, Nepal, Bhutan, Bangladesch, Indien"
                    ]
                dlc = Some SoutheastAsia
                nameGerman = "Nebelparder"
            }
        | "Colombian White-Faced Capuchin Monkey" ->
            { animal with
                region = Some [ "Panama, Kolumbien, Ecuador" ]
                dlc = Some Dlc.SouthAmerica
                nameGerman = "Weißschulter-Kapuzineraffe"
            }
        | "Common Death Adder" ->
            { animal with
                region = Some [ "Australien" ]
                dlc = None
                nameGerman = "Todesotter"
            }
        | "Common Ostrich" ->
            { animal with
                region =
                    Some [
                        "Ganz Afrika, mit Ausnahme der Wüsten und Regenwälder"
                    ]
                dlc = None
                nameGerman = "Afrikanischer Strauß"
            }
        | "Common Warthog" ->
            { animal with
                region = Some [ "Subsahara-Afrika" ]
                dlc = None
                nameGerman = "Warzenschwein"
            }
        | "Crey Seal" ->
            { animal with
                region =
                    Some [
                        "Großbritanien, Irland, Island, Norwegen, Dändemark, Frankreich, Niederlande, Berlgien, Deutschland, Schweden, Finnland, Estland, Lettland, Litauen, Polen, Russland, Kanada, USA"
                    ]
                dlc = Some Aquatic
                nameGerman = "Kegelrobbe"
            }
        | "Cuvier's Dwarf Caiman" ->
            { animal with
                region =
                    Some [
                        "Bolivien, Brasilien, Ecuador, Französisch-Guyana, Guyana, Kolumbien, Paraguay, Peru, Suriname, Venezuela"
                    ]
                dlc = Some Aquatic
                nameGerman = "Brauen-Glattstirnkaiman"
            }
        // D
        | "Dall Sheep" ->
            { animal with
                region = Some [ "Usa (Alaska), Kanada" ]
                dlc = Some Arctic
                nameGerman = "Dall-Schaf"
            }
        | "Dhole" -> //TODO: muss komplett gesetzt werden
            { animal with
                region =
                    Some [
                        "China, Indien, Malaysia, Thailand, Mongolai, Russland,Vietnam, Kambodscha, Laos, Myanmar, Bangladesch, Bhutan, Nepal"
                    ]
                dlc = Some SoutheastAsia
                nameGerman = "Rothund"
            }
        | "Diamondback Terrapin" -> //TODO: muss komplett gesetzt werden
            { animal with
                region = Some [ "Osten der USA" ]
                dlc = Some Aquatic
                nameGerman = "Diamantschildkröte"
            }
        | "Dingo" ->
            { animal with
                region = Some [ "Australien" ]
                dlc = Some Australia
                nameGerman = "Dingo"
            }
        // E
        | "Eastern Blue Tongued Lizard" ->
            { animal with
                region = Some [ "Australien" ]
                dlc = Some Australia
                nameGerman = "Blauzungenskink"
            }
        | "Eastern Brown Snake" ->
            { animal with
                region = Some [ "Australien, Neuguinea" ]
                dlc = None
                nameGerman = "Östliche Braunschlange"
            }
        | "Formosan Black Bear" ->
            { animal with
                region = Some [ "Taiwan" ]
                dlc = None
                nameGerman = "Taiwanischer Schwarzbär"
            }
        // G
        | "Galapagos Giant Tortoise" ->
            { animal with
                region = Some [ "Galapagos-Inseln" ]
                dlc = None
                nameGerman = "Galapagos-Riesenschildkröte"
            }
        | "Gemsbok" ->
            { animal with
                region = Some [ "Namibia, Botswana, Südafrika" ]
                dlc = None
                nameGerman = "Spießbock"
            }
        | "Gharial" ->
            { animal with
                region = Some [ "Bangladesch, Nepal, Indien" ]
                dlc = None
                nameGerman = "Gangesgavial"
            }
        | "Giant Anteater" ->
            { animal with
                region =
                    Some [
                        "Honduras, Nicaragua, Costa Rica, Panama, Kolumbien, Venezuela, Ecuador, Guyana, Suriname, Französisch-Guyana, Brasilien, Argentinien, Peru, Bolivien, Paraguay"
                    ]
                dlc = Some SouthAmerica
                nameGerman = "Großer Ameisenbär"
            }
        | "Giant Burrowing Cockroach" ->
            { animal with
                region = Some [ "Australien" ]
                dlc = None
                nameGerman = "Australische Großschabe"
            }
        | "Giant Desert Hairy Scorpion" ->
            { animal with
                region = Some [ "Süden der USA, Mexiko" ]
                dlc = None
                nameGerman = "Haariger Wüstenskorpion"
            }
        | "Giant Forest Scorpion" ->
            { animal with
                region = Some [ "Sri Lanka, Indien" ]
                dlc = None
                nameGerman = "Indischer Riesenskorpion"
            }
        | "Giant Leaf Insect" -> // TODO: muss komplett gesetzt werden
            { animal with
                region = Some [ "Westmalaysia" ]
                dlc = Some SoutheastAsia
                nameGerman = "Großes Wandelndes Blatt"
            }
        | "Giant Otter" -> // TODO: muss komplett gesetzt werden
            { animal with
                region =
                    Some [
                        "Bolivien, Brasilien, Ecuador, Französisch-Guyana, Guyana, Kolumbien, Paraguay, Peru, Suriname, Venezuela"
                    ]
                dlc = Some Aquatic
                nameGerman = "Riesenotter"
            }
        | "Giant Panda" ->
            { animal with
                region = Some [ "Zentralchina" ]
                dlc = None
                nameGerman = "Großer Panda"
            }
        | "Giant Tiger Land Snail" ->
            { animal with
                region =
                    Some [
                        "Sierra Leona, Liberia, Elfenbeinküste, Togo, Benin, Ghana, Nigeria"
                    ]
                dlc = None
                nameGerman = "Echte Achatschnecke"
            }
        | "Gila Monster" ->
            { animal with
                region = Some [ "Süden der USA, Norden Mexikos" ]
                dlc = None
                nameGerman = "Gila-Krustenechse"
            }
        | "Golden Poison Frog" ->
            { animal with
                region = Some [ "Kolumbien" ]
                dlc = None
                nameGerman = "Schrecklicher Pfeilgiftfrosch"
            }
        | "Goliath Beetle" ->
            { animal with
                region =
                    Some [
                        "Kamerun, Zentralafrikanische Republik, Demokratische Republik Kongo, Gabun,  Kenia, Nigeria, Tansania, Uganda"
                    ]
                dlc = None
                nameGerman = "Goliathkäfer"
            }
        | "Goliath Birdeater" ->
            { animal with
                region =
                    Some [
                        "Suriname, Guyana, Französisch-Guyana, Brasilien, Venezuela"
                    ]
                dlc = None
                nameGerman = "Goliath-Vogelspinne"
            }
        | "Goliath Frog" ->
            { animal with
                region = Some [ "Kamerun, Äquatorialguinea" ]
                dlc = None
                nameGerman = "Goliathfrosch"
            }
        | "Greater Flamingo" ->
            { animal with
                region =
                    Some [
                        "Bangladesch, Pakistan, Indien, Sri Lanka, Türkei, Israel, Libanon, Vereinigen Arabische Emirate, Kuwait, Bahrain, Spanien, Albanien, Mazedonien, Griechenland, Zypern, Portugal, Italien "
                    ]
                dlc = None
                nameGerman = "Rosaflamingo"
            }
        | "Green Iguana" ->
            { animal with
                region =
                    Some [
                        "Mexiko, Brasilien, Ecuador, Kribik, Süden der USA"
                    ]
                dlc = None
                nameGerman = "Grüner Leguan"
            }
        | "Grizzly Bear" ->
            { animal with
                region =
                    Some [
                        "Kanada, Norden der USA (haupsächlich Alaska)"
                    ]
                dlc = None
                nameGerman = "Grizzlybär"
            }
        // H
        | "Himalayan Brown Bear" ->
            { animal with
                region =
                    Some [
                        "Norden von Afghanistan, Norden von Pakistan, Norden von Indien, Westchina, Nepal, Kasachstan"
                    ]
                dlc = None
                nameGerman = "Isabellbär"
            }
        | "Hippopotamus" ->
            { animal with
                region = Some [ "Subsahara-Afrika, alle Länder" ]
                dlc = None
                nameGerman = "Flusspferd"
            }
        | "" ->
            { animal with
                region = Some [ "" ]
                dlc = None
                nameGerman = ""
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
