module Tests

open PlanetZooApp.Functions
open PlanetZooApp.Types

open Expecto

[<Tests>]
let tests =
    let tests = testList "default"

    tests [
        testCase "regionsFromAnimalList"
        <| fun _ ->
            let defAnimal =
                {
                    name = ""
                    nameGerman = ""
                    continent = []
                    region = None
                    biome = []
                    dlc = None
                    can_swim = false
                    status = ""
                    exhibit = false
                    dominance = ""
                    relationship_human = None
                    mating_system = ""
                    life_expectancy = { male = 0; female = 0 }
                    habitat_requirements =
                        {
                            guest_enter = None
                            exhibit = false
                            land_ = None
                            land_additional = None
                            water_additional = None
                            climbable_additional = None
                            water = None
                            climbable = None
                            humidity = { min = 0; max = 0 }
                            temperature = { min = 0; max = 0 }
                            fence = None
                            group_male = None
                            group_female = None
                            group_mixed = None
                        }
                    latin_name = ""
                    category = ""
                    description = ""
                    image_url = None
                    image_path = None
                    slug = ""
                }

            let animalList =
                [
                    { defAnimal with
                        region = Some [ "Kanada"; "Neuseeland" ]
                    }
                    { defAnimal with
                        region = Some [ "Kanada"; "Deutschland" ]
                    }
                ]

            let result = regionsFromAnimalList animalList

            let expected =
                [
                    "Kanada"
                    "Neuseeland"
                    "Deutschland"
                ]
                |> Set.ofList

            Expect.sequenceEqual result expected "Hier stimmt doch was nicht!"
    ]

(*testList
        "samples"
        [
            testCase "universe exists (╭ರᴥ•́)"
            <| fun _ ->
                let subject = true
                Expect.isTrue subject "I compute, therefore I am."

            testCase "when true is not (should fail)"
            <| fun _ ->
                let subject = false
                Expect.isTrue subject "I should fail because the subject is false"

            testCase "I'm skipped (should skip)"
            <| fun _ -> Tests.skiptest "Yup, waiting for a sunny day..."

            testCase "I'm always fail (should fail)"
            <| fun _ -> Tests.failtest "This was expected..."

            testCase "contains things"
            <| fun _ -> Expect.containsAll [| 2; 3; 4 |] [| 2; 4 |] "This is the case; {2,3,4} contains {2,4}"

            testCase "contains things (should fail)"
            <| fun _ -> Expect.containsAll [| 2; 3; 4 |] [| 2; 4; 1 |] "Expecting we have one (1) in there"

            testCase "Sometimes I want to ༼ノಠل͟ಠ༽ノ ︵ ┻━┻"
            <| fun _ -> Expect.equal "abcdëf" "abcdef" "These should equal"

            test "I am (should fail)" { "╰〳 ಠ 益 ಠೃ 〵╯" |> Expect.equal true false }
        ]*)
