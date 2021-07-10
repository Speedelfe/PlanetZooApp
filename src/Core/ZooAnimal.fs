namespace PlanetZooApp

open PlanetZooApp.Types

module ZooAnimal =

    let addMoreAnimals () = []

    let nacharbeiten (animal: ZooAnimal) =
        match animal.name with
        // A
        | "Aardvark" ->
            { animal with
                region = Some [ "Sub-Saharan Africa" ]
                dlc = None
                nameGerman = "Erdferkel"
            }
        | "African Buffalo" ->
            { animal with
                region = Some [ "Sub-Saharan Africa" ]
                dlc = None
                nameGerman = "Kaffernbüffel"
            }
        | "African Elephant" ->
            { animal with
                region =
                    Some [
                        "Sub-Saharan Africa" //Original Sub-Saharan Africa: Kenia, Tansania, Botswana, Simbabw, Namibia, Angola
                    ]
                dlc = None
                nameGerman = "Afrikanischer Elefant"
            }
        | "African Penguin" ->
            { animal with
                region = Some [ "Namibia, South Africa" ]
                dlc = Some Africa
                nameGerman = "Brillenpinguin"
            }
        | "African Wild Dog" ->
            { animal with
                region = Some [ "Sub-Saharan Africa" ]
                dlc = None
                nameGerman = "Afrikanischer Wildhund"
            }
        | "Aldabra Giant Tortoise" ->
            { animal with
                region = Some [ "Seychelles" ]
                dlc = None
                nameGerman = "Aldabra-Riesenschildkröte"
            }
        | "Amazonian Giant Centipede" ->
            { animal with
                region = Some [ "South America, Caribbean" ]
                dlc = None
                nameGerman = "Brasilianischer Riesenläufer"
            }
        | "American Bison" ->
            { animal with
                region = Some [ "Canada, USA" ]
                dlc = None
                nameGerman = "Amerikanischer Bison"
            }
        | "Arctic Wolf" ->
            { animal with
                region = Some [ "Canada, Greenland" ]
                dlc = Some Arctic
                nameGerman = "Polarwolf"
            }

        // B
        | "Babirusa" ->
            { animal with
                region = Some [ "Indonesia" ]
                dlc = Some SoutheastAsia
                nameGerman = "Babirusa"
            }
        | "Bactrian Camel" ->
            { animal with
                region =
                    Some [
                        "Mongolia, China, Himalayas, Sibiria"
                    ]
                dlc = None
                nameGerman = "Trampeltier"
            }
        | "Baird's Tapir" ->
            { animal with
                region =
                    Some [
                        "Belize, Colombia, Costa Rica, Guatemala, Honduras, Mexico, Nicaragua, Panama"
                    ]
                dlc = None
                nameGerman = "Mittelamerikanischer Tapir"
            }
        | "Bengal Tiger" ->
            { animal with
                region =
                    Some [
                        "India, Bangladesh, Nepal, Bhutan, China, Myanmar"
                    ]
                dlc = None
                nameGerman = "Königstiger"
            }
        | "Binturong" ->
            { animal with
                region =
                    Some [
                        "Philippines, Bhutan, Thailand, Malaysia, Indonesia, Brunei, Singapore, Laos, Vietnam, Myanmar, Cambodia, Bangladesh, China, India, Nepal"
                    ]
                dlc = Some SoutheastAsia
                nameGerman = "Binturong"
            }
        | "Black Wildebeest" ->
            { animal with
                region =
                    Some [
                        "South Africa, Eswatini, Lesotho, Namibia"
                    ]
                dlc = None
                nameGerman = "Weißschwanzgnu"
            }
        | "Boa Constrictor" ->
            { animal with
                region =
                    Some [
                        "Colombia, Ecuador, Peru, Venezuela, Trinidad and Tobago, Guyana, Suriname, French Guiana, Brazil, Bolivia, Uruguay, Argentina"
                    ]
                dlc = None
                nameGerman = "Abgottschlange"
            }
        | "Bongo" ->
            { animal with
                region =
                    Some [
                        "Cameroon, Central African Republic, Republic of Congo, Democratic Republic of Congo, Ivory Coast, Equatorial Guinea, Gabon, Ghana, Liberia, Sierra Leone, Sudan"
                    ]
                dlc = None
                nameGerman = "Bongo"
            }
        | "Bonobo" ->
            { animal with
                region = Some [ "Democratic Republic of Congo" ]
                dlc = None
                nameGerman = "Bonobo"
            }
        | "Bornean Orangutan" ->
            { animal with
                region = Some [ "Borneo, Malaysia, Indonesia" ]
                dlc = None
                nameGerman = "Borneo-Orang-Utan"
            }
        | "Brazilian Salmon Pink Tarantula" ->
            { animal with
                region = Some [ "Brazil" ]
                dlc = None
                nameGerman = "Brasilianische Riesenvogelspinne"
            }
        | "Brazilian Wandering Spider" ->
            { animal with
                region =
                    Some [
                        "Brazil, Colombia, Venezuela, Ecuador, Peru, Bolivia, Paraguay, Argentina"
                    ]
                dlc = None
                nameGerman = "Brasilianische Wanderspinne"
            }

        // C
        | "Cheetah" ->
            { animal with
                region =
                    Some [
                        "Niger, Sudan, Ethiopia, Kenya, Tanzania, Namibia, Botswana"
                    ]
                dlc = None
                nameGerman = "Gepard"
            }
        | "Chinese Pangolin" ->
            { animal with
                region =
                    Some [
                        "India, Nepal, Bhutan, Bangladesh, Myanmar, China, Hainan, Taiwan"
                    ]
                dlc = None
                nameGerman = "Chinesisches Schuppentier"
            }
        | "Clouded Leopard" ->
            { animal with
                region =
                    Some [
                        "Malaysia, Thailand, Cambodia, Vietnam, Laos, Myanmar, China, Nepal, Bhutan, Bangladesh, India"
                    ]
                dlc = Some SoutheastAsia
                nameGerman = "Nebelparder"
            }
        | "Colombian White-Faced Capuchin Monkey" ->
            { animal with
                region = Some [ "Panama, Colombia, Ecuador" ]
                dlc = Some Dlc.SouthAmerica
                nameGerman = "Weißschulter-Kapuzineraffe"
            }
        | "Common Death Adder" ->
            { animal with
                region = Some [ "Australia" ]
                dlc = None
                nameGerman = "Todesotter"
            }
        | "Common Ostrich" ->
            { animal with
                region =
                    Some [
                        "Africa" // Original Ganz Afrika, mit Ausnahme der Wüsten und Regenwälder
                    ]
                dlc = None
                nameGerman = "Afrikanischer Strauß"
            }
        | "Common Warthog" ->
            { animal with
                region = Some [ "Sub-Saharan Africa" ]
                dlc = None
                nameGerman = "Warzenschwein"
            }
        | "Cuvier's Dwarf Caiman" ->
            { animal with
                region =
                    Some [
                        "Bolivia, Brazil, Colombia, Ecuador, French Guiana, Guyana, Paraguay, Peru, Suriname, Venezuela"
                    ]
                dlc = Some Aquatic
                nameGerman = "Brauen-Glattstirnkaiman"
            }
        // D
        | "Dall Sheep" ->
            { animal with
                region = Some [ "Alaska, Canada" ]
                dlc = Some Arctic
                nameGerman = "Dall-Schaf"
            }
        | "Dhole" ->
            { animal with
                region =
                    Some [
                        "China, India, Malaysia, Thailand, Mongolia, Russia, Vietnam, Cambodia, Laos, Myanmar, Bangladesh, Bhutan, Nepal"
                    ]
                dlc = Some SoutheastAsia
                nameGerman = "Rothund"
            }
        | "Diamondback Terrapin" ->
            { animal with
                region = Some [ "USA" ] // Original Eastern territories in the USA
                dlc = Some Aquatic
                nameGerman = "Diamantschildkröte"
            }
        | "Dingo" ->
            { animal with
                region = Some [ "Australia" ]
                dlc = Some Australia
                nameGerman = "Dingo"
            }
        // E
        | "Eastern Blue Tongued Lizard" ->
            { animal with
                region = Some [ "Australia" ]
                dlc = Some Australia
                nameGerman = "Blauzungenskink"
            }
        | "Eastern Brown Snake" ->
            { animal with
                region = Some [ "Australia, New Guinea" ]
                dlc = None
                nameGerman = "Östliche Braunschlange"
            }
        | "Fennec Fox" ->
            { animal with
                region =
                    Some [
                        "Morocco, Algeria, Tunisia, Libya, Egypt, Western Sahara, Mauritania, Mali, Niger, Chad, Sudan"
                    ]
                dlc = Some Africa
                nameGerman = "Fennek"
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
                region = Some [ "Galapagos Islands" ]
                dlc = None
                nameGerman = "Galapagos-Riesenschildkröte"
            }
        | "Gemsbok" ->
            { animal with
                region =
                    Some [
                        "Namibia, Botswana, South Africa"
                    ]
                dlc = None
                nameGerman = "Spießbock"
            }
        | "Gharial" ->
            { animal with
                region = Some [ "Bangladesh, Nepal, India" ]
                dlc = None
                nameGerman = "Gangesgavial"
            }
        | "Giant Anteater" ->
            { animal with
                region =
                    Some [
                        "Honduras, Nicaragua, Costa Rica, Panama, Colombia, Venezuela, Ecuador, Guyana, Suriname, French Guiana, Brazil, Argentina, Peru, Bolivia, Paraguay"
                    ]
                dlc = Some SouthAmerica
                nameGerman = "Großer Ameisenbär"
            }
        | "Giant Burrowing Cockroach" ->
            { animal with
                region = Some [ "Australia" ]
                dlc = None
                nameGerman = "Australische Großschabe"
            }
        | "Giant Desert Hairy Scorpion" ->
            { animal with
                region = Some [ "USA, Mexico" ]
                dlc = None
                nameGerman = "Haariger Wüstenskorpion"
            }
        | "Giant Forest Scorpion" ->
            { animal with
                region = Some [ "Sri Lanka, India" ]
                dlc = None
                nameGerman = "Indischer Riesenskorpion"
            }
        | "Giant Malaysian Leaf Insect" ->
            { animal with
                region = Some [ "Malaysia" ]
                dlc = Some SoutheastAsia
                nameGerman = "Großes Wandelndes Blatt"
            }
        | "Giant Otter" ->
            { animal with
                region =
                    Some [
                        "Bolivia, Brazil, Ecuador, French Guiana, Guyana, Colombia, Paraguay, Peru, Suriname, Venezuela"
                    ]
                dlc = Some Aquatic
                nameGerman = "Riesenotter"
            }
        | "Giant Panda" ->
            { animal with
                region = Some [ "China" ]
                dlc = None
                nameGerman = "Großer Panda"
            }
        | "Giant Tiger Land Snail" ->
            { animal with
                region =
                    Some [
                        "Sierra Leone, Liberia, Ivory Coast, Togo, Benin, Ghana, Nigeria"
                    ]
                dlc = None
                nameGerman = "Echte Achatschnecke"
            }
        | "Gila Monster" ->
            { animal with
                region = Some [ "USA, Mexico" ]
                dlc = None
                nameGerman = "Gila-Krustenechse"
            }
        | "Golden Poison Frog" ->
            { animal with
                region = Some [ "Colombia" ]
                dlc = None
                nameGerman = "Schrecklicher Pfeilgiftfrosch"
            }
        | "Goliath Beetle" ->
            { animal with
                region =
                    Some [
                        "Cameroon, Central African Republic, Republic of Congo, Gabon, Kenya, Nigeria, Tanzania, Uganda"
                    ]
                dlc = None
                nameGerman = "Goliathkäfer"
            }
        | "Goliath Birdeater" ->
            { animal with
                region =
                    Some [
                        "Suriname, Guyana, French Guiana, Brazil, Venezuela"
                    ]
                dlc = None
                nameGerman = "Goliath-Vogelspinne"
            }
        | "Goliath Frog" ->
            { animal with
                region = Some [ "Cameroon, Equatorial Guinea" ]
                dlc = None
                nameGerman = "Goliathfrosch"
            }
        | "Greater Flamingo" ->
            { animal with
                region =
                    Some [
                        "Bangladesh, Pakistan, India, Sri Lanka, Turkey, Israel, Lebanon, United Arab Emirates, Kuwait, Bahrain, Spain, Albania, Macedonia, Greece, Cyprus, Portugal, Italy"
                    ]
                dlc = None
                nameGerman = "Rosaflamingo"
            }
        | "Green Iguana" ->
            { animal with
                region =
                    Some [
                        "Mexico, Brazil, Ecuador, Caribbean, USA"
                    ]
                dlc = None
                nameGerman = "Grüner Leguan"
            }
        | "Grey Seal" ->
            { animal with
                region =
                    Some [
                        "UK, Ireland, Iceland, Norway, Denmark, France, Netherlands, Belgium, Germany, Sweden, Finland, Estonia, Latvia, Lithunia, Poland, Russia, Canada, USA"
                    ]
                dlc = Some Aquatic
                nameGerman = "Kegelrobbe"
            }
        | "Grizzly Bear" ->
            { animal with
                region = Some [ "Canada, Alaska" ]
                dlc = None
                nameGerman = "Grizzlybär"
            }
        // H
        | "Himalayan Brown Bear" ->
            { animal with
                region =
                    Some [
                        "Afghanistan, Pakistan, India, China, Nepal, Kazakhstan"
                    ]
                dlc = None
                nameGerman = "Isabellbär"
            }
        | "Hippopotamus" ->
            { animal with
                region = Some [ "Sub-Saharan Africa" ]
                dlc = None
                nameGerman = "Flusspferd"
            }
        // I
        | "Indian Elephant" ->
            { animal with
                region =
                    Some [
                        "India, Nepal,Bangladesh, Bhutan, Myanmar, Thailand, Malaysia, Laos, China, Cambodia, Vietnam"
                    ]
                dlc = None
                nameGerman = "Indischer Elefant"
            }
        | "Indian Peafowl" ->
            { animal with
                region = Some [ "India" ]
                dlc = None
                nameGerman = "Blauer Pfau"
            }
        | "Indian Rhinoceros" ->
            { animal with
                region = Some [ "Nepal, India, Bhutan" ]
                dlc = None
                nameGerman = "Panzernashorn"
            }
        // J
        | "Jaguar" ->
            { animal with
                region =
                    Some [
                        "Mexico, Colombia, Venezuela, Ecuador, Peru, Bolivia, Paraguay, Uruguay, Brazil, Guyana, Suriname, Panama, Costa Rica, French Guiana, Nicaragua, Honduras, El Salvador, Guatemala, Belize"
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
        | "King Penguin" ->
            { animal with
                region =
                    Some [
                        "Falkland Island, Geogien, Sandwich Islands, Prince Edward Island, Crozet Islands, Marion Island, Heard Island, McDonald Islands, Macquarie Islands, Argentina, Chile"
                    ]
                dlc = Some Aquatic
                nameGerman = "Königspinguin"
            }
        | "Koala" ->
            { animal with
                region = Some [ "Australia" ]
                dlc = Some Australia
                nameGerman = "Koala"
            }
        | "Komodo Dragon" ->
            { animal with
                region =
                    Some [
                        "Indonesia" // Original Island of Indonesia (Komodo, Rinca, Flores, Gili Motang)
                    ]
                dlc = Some Deluxe
                nameGerman = "Komodowaran"
            }
        // L
        | "Lehmann's Poison Frog" ->
            { animal with
                region = Some [ "Colombia" ]
                dlc = None
                nameGerman = "Lehmanns Pfeilgiftfrosch"
            }
        | "Lesser Antillean Iguana" ->
            { animal with
                region = Some [ "Lesser Antilles" ]
                dlc = None
                nameGerman = "Grüner Inselleguan"
            }
        | "Llama" ->
            { animal with
                region =
                    Some [
                        "Ecuador, Peru, Bolivia, Chile, Argentina"
                    ]
                dlc = Some SouthAmerica
                nameGerman = "Lama"
            }
        // M
        | "Malayan Tapir" ->
            { animal with
                region = Some [ "Malaysia, Indonesia, Thailand" ]
                dlc = Some SoutheastAsia
                nameGerman = "Malaysischer Tapir"
            }
        | "Mandrill" ->
            { animal with
                region =
                    Some [
                        "Cameroon, Gabon, Equatorial Guinea, Republic of Congo"
                    ]
                dlc = None
                nameGerman = "Mandrill"
            }
        | "Meerkat" ->
            { animal with
                region =
                    Some [
                        "Angola, Namibia, Botswana, South Africa, Lesotho"
                    ]
                dlc = Some Africa
                nameGerman = "Erdmännchen"
            }
        | "Mexican Red Knee Tarantula" ->
            { animal with
                region = Some [ "Mexico" ]
                dlc = None
                nameGerman = "Mexikanische Rotknie-Vogelspinne"
            }
        // N
        | "Nile Monitor" ->
            { animal with
                region = Some [ "Sub-Saharan Africa" ]
                dlc = None
                nameGerman = "Nilwaran"
            }
        | "Nyala" ->
            { animal with
                region =
                    Some [
                        "Malawi, Mozambique, South Africa, Eswatini, Zimbabwe, Botswana, Namibia"
                    ]
                dlc = None
                nameGerman = "Nyala"
            }
        // O
        | "Okapi" ->
            { animal with
                region = Some [ "Democratic Republic of Congo" ]
                dlc = None
                nameGerman = "Okapi"
            }
        // P
        | "Plains Zebra" ->
            { animal with
                region = Some [ "Africa" ]
                dlc = None
                nameGerman = "Steppenzebra"
            }
        | "Polar Bear" ->
            { animal with
                region =
                    Some [
                        "Canada, Alaska, Greenland, Svalbard, Russia, Iceland"
                    ]
                dlc = Some Arctic
                nameGerman = "Eisbär"
            }
        | "Proboscis Monkey" ->
            { animal with
                region = Some [ "Borneo" ]
                dlc = Some SoutheastAsia
                nameGerman = "Nasenaffe"
            }
        | "Pronghorn Antelope" ->
            { animal with
                region = Some [ "USA, Canada, Mexico" ]
                dlc = None
                nameGerman = "Gabelbock"
            }
        | "Puff Adder" ->
            { animal with
                region =
                    Some [
                        "Sub-Saharan Africa, Middle East"
                    ]
                dlc = None
                nameGerman = "Puffotter"
            }
        | "Pygmy Hippo" ->
            { animal with
                region =
                    Some [
                        "Sierra Leone, Liberia, Guinea, Ivory Coast"
                    ]
                dlc = Some Deluxe
                nameGerman = "Zwergflusspferd"
            }
        // R
        | "Red Kangaroo" ->
            { animal with
                region = Some [ "Australia" ]
                dlc = Some Australia
                nameGerman = "Rotes Riesenkänguru"
            }
        | "Red Panda" ->
            { animal with
                region = Some [ "Himalayas, China" ]
                dlc = None
                nameGerman = "Kleiner Panda"
            }
        | "Red Ruffed Lemur" ->
            { animal with
                region = Some [ "Madagascar" ]
                dlc = None
                nameGerman = "Roter Vari"
            }
        | "Red-Eyed Tree Frog" ->
            { animal with
                region =
                    Some [
                        "Mexico, Guatemala, Honduras, Nicaragua, Costa Rica, Panama, Colombia"
                    ]
                dlc = Some SouthAmerica
                nameGerman = "Rotaugenlaubfrosch"
            }
        | "Reindeer" ->
            { animal with
                region =
                    Some [
                        "Sibiria, Canada, Alaska, Norway, Denmark, Finland, Greenland"
                    ]
                dlc = Some Arctic
                nameGerman = "Rentier"
            }
        | "Reticulated Giraffe" ->
            { animal with
                region = Some [ "Somalia, Ethiopia, Kenya" ]
                dlc = None
                nameGerman = "Netzgiraffe"
            }
        | "Ring Tailed Lemur" ->
            { animal with
                region = Some [ "Madagascar" ]
                dlc = None
                nameGerman = "Katta"
            }
        // S
        | "Sable Antelope" ->
            { animal with
                region =
                    Some [
                        "Mozambique, Zimbabwe, Eswatini, Lesotho, Malawi, South Africa, Botswana"
                    ]
                dlc = None
                nameGerman = "Rappenantilope"
            }
        | "Sacred Scarab Beetle" ->
            { animal with
                region =
                    Some [
                        "Morocco, Sahara, Algeria, Tunisia, Libya, Egypt, Saudi Arabia, Israel, Lebanon, Syria, Italy, France"
                    ]
                dlc = Some Africa
                nameGerman = "Heiliger Pillendreher"
            }
        | "Saltwater Crocodile" ->
            { animal with
                region = Some [ "Asia, India, Australia" ]
                dlc = None
                nameGerman = "Leistenkrokodil"
            }
        | "Siberian Tiger" ->
            { animal with
                region =
                    Some [
                        "China, Russia, North Korea, Mongolia"
                    ]
                dlc = None
                nameGerman = "Siribrischer Tiger"
            }
        | "Snow Leopard" ->
            { animal with
                region =
                    Some [
                        "China, Sibiria, Himalayas, Mongolia"
                    ]
                dlc = None
                nameGerman = "Schneeleopard"
            }
        | "Southern Cassowary" ->
            { animal with
                region =
                    Some [
                        "Australia, Papua New Guinea, Indonesia"
                    ]
                dlc = Some Australia
                nameGerman = "Helmkasuar"
            }
        | "Southern White Rhinoceros" ->
            { animal with
                region =
                    Some [
                        "South Africa, Angola, Zambia, Zimbabwe, Malawi, Mozambique, Namibia, Botswana, Lesotho, Eswatini"
                    ]
                dlc = Some Africa
                nameGerman = "Breitmaulnashorn"
            }
        | "Spotted Hyena" ->
            { animal with
                region = Some [ "Sub-Saharan Africa" ]
                dlc = None
                nameGerman = "Tüpfelhyäne"
            }
        | "Springbok" ->
            { animal with
                region =
                    Some [
                        "Namibia, Botswana, South Africa"
                    ]
                dlc = None
                nameGerman = "Springbock"
            }
        | "Sun Bear" ->
            { animal with
                region =
                    Some [
                        "Malaysia, Indonesia, Brunei, Thailand, Cambodia, Vietnam, Myanmar, Laos, Bangladesh, India"
                    ]
                dlc = Some SoutheastAsia
                nameGerman = "Sonnenbär"
            }
        // T
        | "Thomson's Gazelle" ->
            { animal with
                region = Some [ "Tanzania, Kenya" ]
                dlc = Some Deluxe
                nameGerman = "Thomson-Gazelle"
            }
        | "Timber Wolf" ->
            { animal with
                region =
                    Some [
                        "USA, Canada, Greenland, Spain, Italy, Norway, Sweden, Russia, Finland, China, India"
                    ]
                dlc = None
                nameGerman = "Timberwolf"
            }
        | "Titan Beetle" ->
            { animal with
                region =
                    Some [
                        "Venezuela, Colombia, Ecuador, Peru, The Guianas, Brazil"
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
                        "Guinea, Senegal, Liberia, Sierra Leone, Ivory Coast"
                    ]
                dlc = None
                nameGerman = "Westlicher Simpanse"
            }
        | "Western Diamondback Rattlesnake" ->
            { animal with
                region = Some [ "USA, Mexico" ]
                dlc = None
                nameGerman = "Texas-Klapperschlange"
            }
        | "Western Lowland Gorilla" ->
            { animal with
                region =
                    Some [
                        "Angola, Cameroon, Central African Republic, Equatorial Guinea, Gabon, Democratic Republic of Congo"
                    ]
                dlc = None
                nameGerman = "Westlicher Flachlandgorilla"
            }
        // Y
        | "Yellow Anaconda" ->
            { animal with
                region =
                    Some [
                        "Paraguay, Bolivia, Argentina, Brazil"
                    ]
                dlc = None
                nameGerman = "Gelbe Anakonda"
            }

        | _ -> animal

    let regionListToStringArray (regionList: string) =
        regionList.Split ','
        |> Array.toList
        |> List.map (fun el -> el.Trim())

    let zooAnimalRegionNacharbeit (animal: ZooAnimal) =
        let newRegion =
            match animal.region with
            | None -> None
            | Some region ->
                region
                |> List.head
                |> regionListToStringArray
                |> Some

        { animal with region = newRegion }

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
        |> zooAnimalRegionNacharbeit
