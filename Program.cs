using System;
using System.Collections.Generic;

namespace algorithm_assessment_1 {
    class Program {
        static void Main(string[] args) {
            List<Road> roads = new List<Road>();
            string[] Filepaths = { "Road_1_256.txt", "Road_2_256.txt", "Road_3_256.txt", "Road_1_2048.txt", "Road_2_2048.txt", "Road_3_2048.txt"};
            string[] MenuOptions = { "0. Exit.", "1. Switch road number.", "2. Print unordered (for reference).", "3. Print ordered (QuickSort).",
                "4. Print ordered (every 10th value ascending).", "5. Print ordered (every 10th value descending).",
                "6. Print ordered (every 50th value ascending).", "7. Print ordered (every 50th value descending).", "8. Search for a value (return indexes).",
                "9. Search for a value (return indexes or nearest)" };
            int UserResponse = 1;
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
                try {
                    Console.Clear();
                    Console.WriteLine("= = = =  Algorithms and Complexity - Search and Sort Program  = = = =\n");
                    Console.WriteLine($">>> Last Action: {LastAction}");
                    Console.WriteLine($">>> Selected road: { UserRoadNumber + 1}. {roads[UserRoadNumber].GetName()}.\n");
                    foreach (string option in MenuOptions) { Console.WriteLine("    " + option);  }
                    UserResponse = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine();
                    switch (UserResponse) {
                        case 0:  // exit
                            break;
                        case 1:  // Switch road number
                            while (true) {
                                for (int i =0; i < roads.Count; i++) { Console.WriteLine($"    {i+1}. {roads[i].GetName()}"); }
                                Console.WriteLine($"\n    Current number of roads: {roads.Count}.\n    Which road would you like to select?");
                                UserRoadNumber = Convert.ToInt16(Console.ReadLine()) - 1;
                                if (UserRoadNumber >= 0 && UserRoadNumber < roads.Count) {
                                    LastAction = $"Changed selected road to road {UserRoadNumber + 1}.";
                                    break;
                                }
                                Console.WriteLine("ERROR: Invalid input.");
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
                        default:
                            LastAction = "ERROR: Invalid input.";
                            break;
                    }
                    if (UserResponse != 0) {
                        Console.WriteLine("\n>>> Waiting for keypress.");
                        Console.ReadKey();
                    }
                } catch {
                    LastAction = "ERROR: During runtime.";
                }
            } while (UserResponse != 0);
        }
    }
}

/*
1. Read the files “Road_1_256.txt”, “Road_2_256.txt”, and “Road_3_256.txt”, into individual Arrays
   - DONE
2. Sort in ascending and descending order and display every 10th value of the selected Array(s).
   - DONE
3. Search the selected Array for a user-defined value, if the value exists, then provide its location
   (if it appears more than once then provide ALL the locations) otherwise provide an error message.
   - DONE
4. Repeat the previous task, but if the value does not exist then provide the value(s) and location(s) of its nearest value.
   - DONE
5. Your Console Application should be in position to input the files with length 2048. Then repeat Tasks 2 to 4 and display the corresponding values for all the selected arrays, for the 2048 length array(s) display every 50th value.
   - DONE
NOTE: All Assessment Briefings should be made available prior to the commencement of the module, clearly signposted on the module Blackboard site as well as included in any module handbook or briefing document.
6. For additional marks, Merge the Road_1_256.txt and Road_3_256.txt files. Then repeat Tasks 2 to 4 and display the corresponding values.
   - DONE
7. For top marks repeat task 6 using the files with length 2048.
   - DONE

*/