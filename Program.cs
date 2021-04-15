using System;
using System.Collections.Generic;

namespace algorithm_assessment_1 {
    class Program {
        static void Main(string[] args) {
            List<Road> roads = new List<Road>();
            string[] Filepaths = { "Road_1_256.txt", "Road_2_256.txt", "Road_3_256.txt", "Road_1_2048.txt", "Road_2_2048.txt", "Road_3_2048.txt"};
            string[] MenuOptions = { " 0. Exit.", " 1. Switch road number.", " 2. Print unordered (for reference).\n",
                " 3. Print ordered (Quick Sort).", " 4. Print ordered (Bubble Sort).",
                " 5. Print ordered (Selection Sort)", " 6. Print ordered (Merge Sort)",
                " 7. Print ordered (Insersion Sort)\n",
                " 8. Print ordered (every 10th value ascending).", " 9. Print ordered (every 10th value descending).",
                "10. Print ordered (every 50th value ascending).", "11. Print ordered (every 50th value descending).",
                "12. Print ordered (custom).\n",
                "13. Search for a value (return indexes) (Binary Search).", "14. Search for a value (return indexes or nearest) (Binary Search).",
                "15. Search for a value (return indexes) (Sequential Search).", "16. Search for a value (return indexes or nearest) (Sequential Search).\n",
            };
            int MaxMenuOptionNumber = int.Parse(MenuOptions[^1].Split(".")[0]);
            int UserResponseMenu;
            int UserResponseOption;
            int SelectedRoad = 0;  // Default road.
            string LastAction = "Program started.";

            GetRoadData(roads, Filepaths);

            // Main loop.
            do {
                while (true) {
                    Console.Clear();
                    Console.WriteLine("= = = = = = =  Algorithms and Complexity - Search and Sort Program  = = = = = = =\n");
                    Console.WriteLine($">>> Last Action: {LastAction}");
                    Console.WriteLine($">>> Selected road: { SelectedRoad + 1}. {roads[SelectedRoad].Name}.\n");
                    foreach (string option in MenuOptions) {
                        Console.WriteLine("    " + option);
                    }
                    UserResponseMenu = GetIntInputFromUser();
                    if (UserResponseMenu >= 0 && UserResponseMenu <= MaxMenuOptionNumber) { break; }
                }

                Console.WriteLine();
                Sorting.ResetStepsCounter();
                Searching.ResetStepsCounter();

                switch (UserResponseMenu) {
                    case 0:  // Exit.
                        break;

                    case 1:  // Switch road number.
                        while (true) {
                            for (int i = 0; i < roads.Count; i++) {
                                Console.WriteLine($"    {i+1}. {roads[i].Name}");
                            }

                            Console.WriteLine($"\n    Current number of roads: {roads.Count}.\n    Which road would you like to select?");
                            SelectedRoad = GetIntInputFromUser() - 1;

                            if (SelectedRoad >= 0 && SelectedRoad < roads.Count) {
                                LastAction = $"Changed selected road to road {SelectedRoad + 1}.";
                                break;
                            } else {
                                Console.WriteLine("ERROR: Invalid input.");
                            }
                        }
                        break;

                    case 2:  // Print unordered (for reference).
                        roads[SelectedRoad].PrintRoadDataUnordered();
                        LastAction = $"Printed road {SelectedRoad + 1} (unordered) to screen.";
                        break;

                    case 3:  // Print ordered (QuickSort).
                        roads[SelectedRoad].PrintRoadDataOrderedQuickSort();
                        LastAction = $"Printed road {SelectedRoad + 1} (ordered by Quick Sort) to screen.";
                        break;

                    case 4:  // Print ordered (Bubble Sort).
                        roads[SelectedRoad].PrintRoadDataOrderedBubbleSort();
                        LastAction = $"Printed road {SelectedRoad + 1} (ordered by Bubble Sort) to screen.";
                        break;

                    case 5:  // Print ordered (Selection Sort).
                        roads[SelectedRoad].PrintRoadDataOrderedSelectionSort();
                        LastAction = $"Printed road {SelectedRoad + 1} (ordered by Selection Sort) to screen.";
                        break;

                    case 6:  // Print ordered (Merge Sort).
                        roads[SelectedRoad].PrintRoadDataOrderedMergeSort();
                        LastAction = $"Printed road {SelectedRoad + 1} (ordered by Merge Sort) to screen.";
                        break;

                    case 7:  // Print ordered (Insertion Sort).
                        roads[SelectedRoad].PrintRoadDataOrderedInsertionSort();
                        LastAction = $"Printed road {SelectedRoad + 1} (ordered by Insertion Sort) to screen.";
                        break;

                    case 8:  // Print ordered (every 10th value ascending).
                        roads[SelectedRoad].PrintRoadDataOrderedQuickSort(10);
                        LastAction = $"Printed road {SelectedRoad + 1} (every 10th value ascending) to screen.";
                        break;

                    case 9:  // Print ordered (every 10th value descending).
                        roads[SelectedRoad].PrintRoadDataOrderedQuickSort(-10);
                        LastAction = $"Printed road {SelectedRoad + 1} (every 10th value descending) to screen.";
                        break;

                    case 10:  // Print ordered (every 50th value ascending).
                        roads[SelectedRoad].PrintRoadDataOrderedQuickSort(50);
                        LastAction = $"Printed road {SelectedRoad + 1} (every 50th value ascending) to screen.";
                        break;

                    case 11:  // Print ordered (every 50th value descending).
                        roads[SelectedRoad].PrintRoadDataOrderedQuickSort(-50);
                        LastAction = $"Printed road {SelectedRoad + 1} (every 50th value descending) to screen.";
                        break;

                    case 12:  // Print ordered (user input).
                        while (true) {
                            Console.WriteLine("    What number do you want to increment by? Negative numbers can be used for decreasing incrementation.");
                            UserResponseOption = GetIntInputFromUser();

                            if (UserResponseOption != 0 && UserResponseOption < roads[SelectedRoad].DataUnordered.Length - 1
                                && UserResponseOption > -roads[SelectedRoad].DataUnordered.Length - 1)  {
                                LastAction = $"Printed road {SelectedRoad + 1} (custom: {UserResponseOption}) to screen.";
                                break;
                            } else {
                                Console.WriteLine("ERROR: Invalid input. Make your incrementation smaller and not 0.");
                            }
                        }
                        roads[SelectedRoad].PrintRoadDataOrderedQuickSort(UserResponseOption);
                        break;

                    case 13:  // Search for a value (return indexes) (Binary Search).
                        Console.WriteLine($"What number do you want to search for?");
                        UserResponseOption = GetIntInputFromUser();
                        roads[SelectedRoad].FindValueBinaryALL(UserResponseOption);
                        LastAction = $"Searched for {UserResponseOption} (Binary Search).";
                        break;

                    case 14:  // Search for a value (return indexes or nearest) (Binary Search).
                        Console.WriteLine($"What number do you want to search for?");
                        UserResponseOption = GetIntInputFromUser();
                        roads[SelectedRoad].FindValueBinaryNEAREST(UserResponseOption);
                        LastAction = $"Searched for {UserResponseOption} (Binary Search).";
                        break;

                    case 15:  // Search for a value (return indexes) (Sequential Search).
                        Console.WriteLine($"What number do you want to search for?");
                        UserResponseOption = GetIntInputFromUser();
                        roads[SelectedRoad].FindValueSequentialALL(UserResponseOption);
                        LastAction = $"Searched for {UserResponseOption} (Sequential Search).";
                        break;

                    case 16:  // Search for a value (return indexes or nearest) (Sequential Search).
                        Console.WriteLine($"What number do you want to search for?");
                        UserResponseOption = GetIntInputFromUser();
                        roads[SelectedRoad].FindValueSequentialNEAREST(UserResponseOption);
                        LastAction = $"Searched for {UserResponseOption} (Sequential Search).";
                        break;

                    default:
                        LastAction = "ERROR: Invalid input.";
                        break;
                }

                if (UserResponseMenu != 0) {
                    if (UserResponseMenu > 2) {
                        Console.WriteLine(String.Format("Number of steps taken Sorting: {0}, Searching: {1}.\n", Sorting.StepsCounter, Searching.StepsCounter));
                    }
                    Console.WriteLine("\n>>> Waiting for keypress.");
                    Console.ReadKey();
                }

            } while (UserResponseMenu != 0);
        }


        private static int GetIntInputFromUser() {
            int input;
            while (true) {
                try {
                    input = Convert.ToInt16(Console.ReadLine());
                    break;
                } catch {
                    Console.WriteLine("ERROR: Invalid input. Please try again.\n");
                }
            }
            return input;
        }


        private static void GetRoadData(List<Road> roads, string[] Filepaths) {
            while (roads.Count > 0) {
                roads.RemoveAt(roads.Count - 1);
            }
            foreach (string filePath in Filepaths) {
                Road r = new Road(filePath);
                roads.Add(r);
            }
            Road r1 = new Road("Road_1_256.txt and Road_3_256.txt merged", MiscMethods.MergeArrays(roads[0].DataUnordered, roads[2].DataUnordered));
            roads.Add(r1);
            int[] array = MiscMethods.MergeArrays(roads[3].DataUnordered, roads[4].DataUnordered, roads[5].DataUnordered);
            Road r2 = new Road("Road_1_2048.txt, Road_2_2048.txt, and Road_3_2048.txt merged", array);
            roads.Add(r2);
        }

    }
}