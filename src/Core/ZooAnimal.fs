namespace PlanetZooApp

open PlanetZooApp.Types

module ZooAnimal =

    let addMoreAnimals () = []

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
        | "African Penguin" -> //TODO: muss komplett gesetzt werden
            { animal with
                region = Some [ "Namibia und Südafrika" ]
                dlc = Some Africa
                nameGerman = "Brillenpinguin"
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
        | "Brazilian Salmon Pink Tarantula" ->
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
        | "Fennec Fox" -> // TODO: muss noch komplett gesetzt werden
            { animal with
                region =
                    Some [
                        "Morocco, Algeria, Tunisia, Libya, Egypt, Western Sahara, Mauritania, Mali, Niger, Chad, Sudan"
                    ]
                dlc = Some Africa
                nameGerman = "Fennek"
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
        // I
        | "Indian Elephant" ->
            { animal with
                region =
                    Some [
                        "Indien,Nepal,Bangladesch, Bhutan, Myanmar, Thailand, Malaysia, Laos, China, Kambodscha, Vietnam"
                    ]
                dlc = None
                nameGerman = "Indischer Elefant"
            }
        | "Indian Peafowl" ->
            { animal with
                region = Some [ "Indischer Subkontinent" ]
                dlc = None
                nameGerman = "Blauer Pfau"
            }
        | "Indian Rhinoceros" ->
            { animal with
                region = Some [ "Nepal, Indien, Bhutan" ]
                dlc = None
                nameGerman = "Panzernashorn"
            }
        // J
        | "Jaguar" ->
            { animal with
                region =
                    Some [
                        "Mexiko, Kolumbien, Venezuela, Ecuador, Peru, Bolivien, Paraguay, Uruguay, Brasilien, Guyana, Suriname, Panama, Costa, Rica, Französisch-Guyana,Nicaragua, Honduras, El Salvador, Guatemala, Belize"
                    ]
                dlc = Some SouthAmerica
                nameGerman = "Jaguar"
            }
        | "Japanese Macaque" ->
            { animal with
                region = Some [ "Japan" ]
                dlc = None
                nameGerman = "Japanmakak"
            }
        // K
        | "King Penguin" -> // TODO: muss noch komplett gesetzt werden
            { animal with
                region =
                    Some [
                        "Falklandinseln, Südgeogien und Südliche Sandwichinseln, Prinz-Edward-Inseln, Crozetinseln, Marion-Insel, Heard- und McDonaldinseln, Macquarieinsel, Argentinien, Chile"
                    ]
                dlc = Some Aquatic
                nameGerman = "Königspinguin"
            }
        | "Koala" ->
            { animal with
                region = Some [ "Australien" ]
                dlc = Some Australia
                nameGerman = "Koala"
            }
        | "Komodo Dragon" ->
            { animal with
                region =
                    Some [
                        "Kleine Sudaninsel (Komodo, Rinca, Flores, Gili, Motang)"
                    ]
                dlc = Some Deluxe
                nameGerman = "Komodowaran"
            }
        // L
        | "Lehmann's Poison Frog" ->
            { animal with
                region = Some [ "Kolumbien" ]
                dlc = None
                nameGerman = "Lehmanns Pfeilgiftfrosch"
            }
        | "Lesser Antillean Iguana" ->
            { animal with
                region = Some [ "Kleine Antillen" ]
                dlc = None
                nameGerman = "Grüner Inselleguan"
            }
        | "Llama" ->
            { animal with
                region =
                    Some [
                        "Ecuador, Peru, Bolivien, CHile, Argentinien"
                    ]
                dlc = Some SouthAmerica
                nameGerman = "Lama"
            }
        // M
        | "Malayan Tapir" ->
            { animal with
                region =
                    Some [
                        "Malaysia, Indonesien, Thailand"
                    ]
                dlc = Some SoutheastAsia
                nameGerman = "Malaysischer Tapir"
            }
        | "Mandrill" ->
            { animal with
                region =
                    Some [
                        "Kamerun, Gabun, Äquatorialguinea, Republik Kongo"
                    ]
                dlc = None
                nameGerman = "Mandrill"
            }
        | "Mexican Red Knee Tarantula" ->
            { animal with
                region = Some [ "Mexiko" ]
                dlc = None
                nameGerman = "Mexikanische Rotknie-Vogelspinne"
            }
        | "Meerkat" -> // TODO: muss noch komplett gesetzt werden
            { animal with
                region =
                    Some [
                        "Angola, Namibia, Botswana, South Africa, Lesotho"
                    ]
                dlc = Some Africa
                nameGerman = "Erdmännchen"
            }
        // N
        | "Nile Monitor" ->
            { animal with
                region = Some [ "Subsahara-Afrika" ]
                dlc = None
                nameGerman = "Nilwaran"
            }
        | "Nyala" ->
            { animal with
                region =
                    Some [
                        "Malawi, Mosambik, Südafrika, Königreich Eswatini, Simbabwe, Botswana, Namibia"
                    ]
                dlc = None
                nameGerman = "Nyala"
            }
        // O
        | "Okapi" ->
            { animal with
                region = Some [ "" ]
                dlc = None
                nameGerman = "Okapi"
            }
        // P
        | "Plains Zebra" ->
            { animal with
                region = Some [ "Osten und Süden von Afrika" ]
                dlc = None
                nameGerman = "Steppenzebra"
            }
        | "Polar Bear" ->
            { animal with
                region =
                    Some [
                        "Kanada, USA (Alaska), Grönland, Norwegen (Svalbard), Russland, Island"
                    ]
                dlc = Some Arctic
                nameGerman = "Eisbär"
            }
        | "Proboscis Monkey" -> // TODO: muss noch komplett gesetzt werden
            { animal with
                region =
                    Some [
                        "Borneo (Indonesien, Malaysia, Brunei)"
                    ]
                dlc = Some SoutheastAsia
                nameGerman = "Nasenaffe"
            }
        | "Pronghorn Antelope" ->
            { animal with
                region = Some [ "Usa, Kanada, Mexiko" ]
                dlc = None
                nameGerman = "Gabelbock"
            }
        | "Puff Adder" ->
            { animal with
                region =
                    Some [
                        "Subsahara-Afrika und Süden des Mittleren Ostens"
                    ]
                dlc = None
                nameGerman = "Puffotter"
            }
        | "Pygmy Hippo" ->
            { animal with
                region =
                    Some [
                        "Sierra Leona, Liberia, Guinea, Elfenbeinküste"
                    ]
                dlc = Some Deluxe
                nameGerman = "Zwergflusspferd"
            }
        // R
        | "Red Kangaroo" ->
            { animal with
                region = Some [ "Australien" ]
                dlc = Some Australia
                nameGerman = "Rotes Riesenkänguru"
            }
        | "Red Panda" ->
            { animal with
                region = Some [ "Ost-Himalaya, Südwestchina" ]
                dlc = None
                nameGerman = "Kleiner Panda"
            }
        | "Red Ruffed Lemur" ->
            { animal with
                region = Some [ "Madagaskar" ]
                dlc = None
                nameGerman = "Roter Vari"
            }
        | "Red-Eyed Tree Frog" ->
            { animal with
                region =
                    Some [
                        "Mexiko, Guatemala, Honduras, Nicaragua, Costa Rica, Panama, Kolumbien"
                    ]
                dlc = Some SouthAmerica
                nameGerman = "Rotaugenlaubfrosch"
            }
        | "Reindeer" ->
            { animal with
                region =
                    Some [
                        "Russland (Sibirien), Kanada, USA (Alsaka), Norwegen, Dänemark, Finnland, Grönland"
                    ]
                dlc = Some Arctic
                nameGerman = "Rentier"
            }
        | "Reticulated Giraffe" ->
            { animal with
                region = Some [ "Somalia, Äthiopien, Kenia" ]
                dlc = None
                nameGerman = "Netzgiraffe"
            }
        | "Ring Tailed Lemur" ->
            { animal with
                region = Some [ "Madagaskar" ]
                dlc = None
                nameGerman = "Katta"
            }
        // S
        | "Sable Antelope" ->
            { animal with
                region =
                    Some [
                        "Mosambik, Simbabwe, Königreich Eswatini, Lesotho, Malawi, Südafrika, Botswana"
                    ]
                dlc = None
                nameGerman = "Rappenantilope"
            }
        | "Saltwater Crocodile" ->
            { animal with
                region =
                    Some [
                        "Südostasien, Ostindien, Norden von Australien"
                    ]
                dlc = None
                nameGerman = "Leistenkrokodil"
            }
        | "Siberian Tiger" ->
            { animal with
                region =
                    Some [
                        "Osten von China, Osten von Russland, Nordkorea, Mongolei"
                    ]
                dlc = None
                nameGerman = "Siribrischer Tiger"
            }
        | "Snow Leopard" ->
            { animal with
                region =
                    Some [
                        "China, Sudsibirien, Himalaya, Mongolei"
                    ]
                dlc = None
                nameGerman = "Schneeleopard"
            }
        | "Southern Cassowary" ->
            { animal with
                region =
                    Some [
                        "Australien, Papua-Neuguinea, Indonesien"
                    ]
                dlc = Some Australia
                nameGerman = "Helmkasuar"
            }
        | "Spotted Hyena" ->
            { animal with
                region = Some [ "Subsahara-Afrika" ]
                dlc = None
                nameGerman = "Tüpfelhyäne"
            }
        | "Springbok" ->
            { animal with
                region = Some [ "Namibia, Botswana, Südafrika" ]
                dlc = None
                nameGerman = "Springbock"
            }
        | "Sun Bear" -> // TODO: muss noch komplett gesetzt werden
            { animal with
                region =
                    Some [
                        "Malaysia, Indonesien, Brunei, Thailand, Kambodscha, Vietnam, Myanmar, Laos, Bangladesch, Indien"
                    ]
                dlc = Some SoutheastAsia
                nameGerman = "Sonnenbär"
            }
        | "Southern White Rhinoceros" -> // TODO: muss noch komplett gesetzt werden
            { animal with
                region =
                    Some [
                        "Südafrika, Angola, Sambia, Zimbabwe, Malawi, Mosambik, Namibia, Botswana, Lesotho, Königreich Eswatini"
                    ]
                dlc = Some Africa
                nameGerman = "Breitmaulnashorn"
            }
        | "Sacred Scarab Beetle" -> // TODO: muss noch komplett gesetzt werden
            { animal with
                region =
                    Some [
                        "Morocco, Western Sahara, Algeria, Tunisia, Libya, Egypt, Saudi Arabia, Israel, Lebanon, Syria, Italy, France"
                    ]
                dlc = Some Africa
                nameGerman = "Heiliger Pillendreher"
            }
        // T
        | "Thomson's Gazelle" ->
            { animal with
                region = Some [ "Tansania, Kenia" ]
                dlc = Some Deluxe
                nameGerman = "Thomson-Gazelle"
            }
        | "Timber Wolf" ->
            { animal with
                region =
                    Some [
                        "Großteil der nördlichen Hemisphäre"
                    ]
                dlc = None
                nameGerman = "Timberwolf"
            }
        | "Titan Beetle" ->
            { animal with
                region =
                    Some [
                        "Venezuela, Kolumbien, Ecuador, Peru, Guyanas, Brasilien"
                    ]
                dlc = None
                nameGerman = "Riesenbockkäfer"
            }
        // W
        | "West African Lion" ->
            { animal with
                region = Some [ "Senegal, Mali, Niger" ]
                dlc = None
                nameGerman = "Westafrikanischer Löwe"
            }
        | "Western Chimpanzee" ->
            { animal with
                region =
                    Some [
                        "Guinea, Senegal, Liberia, Sierra Leona, Elfenbeinküste"
                    ]
                dlc = None
                nameGerman = "Westlicher Simpanse"
            }
        | "Western Diamondback Rattlesnake" ->
            { animal with
                region = Some [ "USA, Mexiko" ]
                dlc = None
                nameGerman = "Texas-Klapperschlange"
            }
        | "Western Lowland Gorilla" ->
            { animal with
                region =
                    Some [
                        "Angola, Kamerun, Zentralafrikanische Republik, Äquatorialguinea, Gabun, Demokratische Republik Kongo"
                    ]
                dlc = None
                nameGerman = "Westlicher Flachlandgorilla"
            }
        // Y
        | "Yellow Anaconda" ->
            { animal with
                region =
                    Some [
                        "Paraguay, Bolivien, Argentinien, Brasilien"
                    ]
                dlc = None
                nameGerman = "Gelbe Anakonda"
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
