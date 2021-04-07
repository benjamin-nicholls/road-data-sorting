﻿using System;
using System.Collections.Generic;

namespace algorithm_assessment_1 {
    class Program {
        static void Main(string[] args) {
            List<Road> roads = new List<Road>();
            string[] Filepaths = { "Road_1_256.txt", "Road_2_256.txt", "Road_3_256.txt", "Road_1_2048.txt", "Road_2_2048.txt", "Road_3_2048.txt"};
            string[] MenuOptions = { "0. Exit.", "1. Switch road number.",
                "2. Print unordered (for reference).", "3. Print ordered (QuickSort).",
                "4. Print ordered (every 10th value ascending).", "5. Print ordered (every 10th value descending).",
                "6. Print ordered (every 50th value ascending).", "7. Print ordered (every 50th value descending).",
                "8. Search for a value (return indexes).", "9. Search for a value (return indexes or nearest)",
                "10. Print ordered (BubbleSort).", };
            int UserResponse;
            int UserRoadNumber = 0;
            int NumberToSearchFor;
            string LastAction = "Program started.";

            foreach (string filePath in Filepaths) {
                Road r = new Road(filePath);
                roads.Add(r);
            }

            // statement for local variable usage
            if (true) {
                Road r1 = new Road("Road_1_256.txt and Road_3_256.txt merged", MiscMethods.MergeArrays(roads[0].GetRoadData(), roads[2].GetRoadData()));
                roads.Add(r1);
                int[] array = MiscMethods.MergeArrays(roads[3].GetRoadData(), roads[4].GetRoadData(), roads[5].GetRoadData());
                Road r2 = new Road("Road_1_2048.txt, Road_2_2048.txt, and Road 3_2048.txt merged", array);
                roads.Add(r2);
            }

            do {
                while (true) {
                    Console.Clear();
                    Console.WriteLine("= = = =  Algorithms and Complexity - Search and Sort Program  = = = =\n");
                    Console.WriteLine($">>> Last Action: {LastAction}");
                    Console.WriteLine($">>> Selected road: { UserRoadNumber + 1}. {roads[UserRoadNumber].GetName()}.\n");
                    foreach (string option in MenuOptions) { Console.WriteLine("    " + option); }
                    try {
                        UserResponse = Convert.ToInt16(Console.ReadLine());
                        break;
                    } catch {
                        LastAction = "ERROR: Invalid input.";
                    }
                }
                Console.WriteLine();
                switch (UserResponse) {
                    case 0:  // exit
                        break;
                    case 1:  // Switch road number
                        while (true) {
                            for (int i =0; i < roads.Count; i++) { Console.WriteLine($"    {i+1}. {roads[i].GetName()}"); }
                            Console.WriteLine($"\n    Current number of roads: {roads.Count}.\n    Which road would you like to select?");
                            try {
                                UserRoadNumber = Convert.ToInt16(Console.ReadLine()) - 1;
                                if (UserRoadNumber >= 0 && UserRoadNumber < roads.Count) {
                                    LastAction = $"Changed selected road to road {UserRoadNumber + 1}.";
                                    break;
                                } else {
                                    Console.WriteLine("ERROR: Invalid input.");
                                }
                            } catch {
                                Console.WriteLine("ERROR: Invalid input.");
                            }  
                        }
                        break;
                    case 2:  // Print unordered (for reference)
                        roads[UserRoadNumber].PrintRoadDataUnordered();
                        LastAction = $"Printed road {UserRoadNumber + 1} (unordered) to screen.";
                        break;
                    case 3:  // Print ordered (QuickSort)
                        roads[UserRoadNumber].PrintRoadDataOrderedQuickSort();
                        LastAction = $"Printed road {UserRoadNumber + 1} (ordered by QuickSort) to screen.";
                        break;
                    case 4:  // Print ordered (every 10th value ascending)
                        roads[UserRoadNumber].PrintRoadDataOrderedQuickSort(10);
                        LastAction = $"Printed road {UserRoadNumber + 1} (every 10th value ascending) to screen.";
                        break;
                    case 5:  // Print ordered (every 10th value descending)
                        roads[UserRoadNumber].PrintRoadDataOrderedQuickSort(-10);
                        LastAction = $"Printed road {UserRoadNumber + 1} (every 10th value descending) to screen.";
                        break;
                    case 6:  // Print ordered (every 50th value ascending)
                        roads[UserRoadNumber].PrintRoadDataOrderedQuickSort(50);
                        LastAction = $"Printed road {UserRoadNumber + 1} (every 50th value ascending) to screen.";
                        break;
                    case 7:  // Print ordered (every 50th value descending)
                        roads[UserRoadNumber].PrintRoadDataOrderedQuickSort(-50);
                        LastAction = $"Printed road {UserRoadNumber + 1} (every 50th value descending) to screen.";
                        break;
                    case 8:  // Search for a value (return indexes)
                        Console.WriteLine($"What number do you want to search for?");
                        NumberToSearchFor = Convert.ToInt16(Console.ReadLine());
                        roads[UserRoadNumber].FindValueALL(NumberToSearchFor);
                        LastAction = $"Searched for {NumberToSearchFor}.";
                        break;
                    case 9:  // Search for a value (return indexes or nearest)
                        Console.WriteLine($"What number do you want to search for?");
                        NumberToSearchFor = Convert.ToInt16(Console.ReadLine());
                        roads[UserRoadNumber].FindValueNEAREST(NumberToSearchFor);
                        LastAction = $"Searched for {NumberToSearchFor}.";
                        break;
                    case 10:  // print ordered bubblesort
                        roads[UserRoadNumber].PrintRoadDataOrderedBubbleSort();
                        LastAction = $"Printed road {UserRoadNumber + 1} (ordered by Bubble Sort) to screen.";
                        break;
                    default:
                        LastAction = "ERROR: Invalid input.";
                        break;
                }
                if (UserResponse != 0) {
                    Console.WriteLine("\n>>> Waiting for keypress.");
                    Console.ReadKey();
                }
            } while (UserResponse != 0);
        }
    }
}