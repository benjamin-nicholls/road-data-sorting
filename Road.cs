using System;
using System.Collections.Generic;

namespace algorithm_assessment_1 {
    class Road {
        private readonly string _name;
        private int[] _dataUnordered;
        private int[] _dataOrdered;

        public Road(string inputFileName) {
            _name = inputFileName;
            ParseFile(inputFileName);
        }

        public Road(string name, int[] input) {
            _name = name;
            Array.Resize(ref _dataUnordered, input.Length);
            Array.Resize(ref _dataOrdered, input.Length);
            for (int i = 0; i < input.Length; i++) {
                _dataUnordered[i] = input[i];
                _dataOrdered[i] = input[i];
            }
        }

        public int[] GetRoadData() {
            return _dataUnordered;
        }

        public string GetName() {
            return _name;
        }

        private void ParseFile(string inputFileName) {
            try {
                string[] data = System.IO.File.ReadAllLines(inputFileName);
                Array.Resize(ref _dataUnordered, data.Length);
                Array.Resize(ref _dataOrdered, data.Length);
                for (int i = 0; i < data.Length; i++) {
                    _dataUnordered[i] = Convert.ToInt32(data[i]);
                    _dataOrdered[i] = Convert.ToInt32(data[i]);
                }
            } catch (System.IO.FileNotFoundException e) {
                Console.WriteLine($"ERROR: File was not found. '{inputFileName}'.");
                Console.WriteLine("\nProgram will close.\n\n>>> Waiting for keypress.");
                Console.ReadKey();
                Environment.Exit(0);
            } catch (System.IO.DirectoryNotFoundException e) {
                Console.WriteLine($"ERROR: Directory was not found.");
                Console.WriteLine("\nProgram will close.\n\n>>> Waiting for keypress.");
                Console.ReadKey();
                Environment.Exit(0);
            } catch (System.IO.IOException e) {
                Console.WriteLine($"ERROR: The file could not be opened.");
                Console.WriteLine("\nProgram will close.\n\n>>> Waiting for keypress.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void PrintRoadDataUnordered() {
            MiscMethods.PrintIntArrayToScreen(_dataUnordered);
        }

        public void PrintRoadDataOrderedQuickSort() {
            _dataOrdered = Sorting.QuickSort(_dataOrdered);
            MiscMethods.PrintIntArrayToScreen(_dataOrdered);
        }

        public void PrintRoadDataOrderedQuickSort(int everyNthValue) {
            _dataOrdered = Sorting.QuickSort(_dataOrdered);
            MiscMethods.PrintIntArrayToScreen(_dataOrdered, everyNthValue);
        }

        public void FindValueALL(int NumberToSearchFor) {
            _dataOrdered = Sorting.QuickSort(_dataOrdered);
            Console.WriteLine(Searching.BinarySearchIterativeALL(_dataOrdered, NumberToSearchFor));
        }

        public void FindValueNEAREST(int NumberToSearchFor) {
            _dataOrdered = Sorting.QuickSort(_dataOrdered);
            Console.WriteLine(Searching.BinarySearchIterativeNEAREST(_dataOrdered, NumberToSearchFor));
        }
    }
}