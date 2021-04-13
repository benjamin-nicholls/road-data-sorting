using System;
using System.Collections.Generic;

namespace algorithm_assessment_1 {
    class Road {
        private readonly string _name;
        private int[] _dataUnordered;
        private int[] _dataOrdered;

        public string Name { 
            get { return _name; } 
        }
        public int[] DataUnordered {
            get { return _dataUnordered; }
        }


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


        private void ParseFile(string inputFileName) {
            try {
                string[] data = System.IO.File.ReadAllLines(inputFileName);
                Array.Resize(ref _dataUnordered, data.Length);
                Array.Resize(ref _dataOrdered, data.Length);
                for (int i = 0; i < data.Length; i++) {
                    _dataUnordered[i] = Convert.ToInt32(data[i]);
                }
            } catch (System.IO.FileNotFoundException) {
                Console.WriteLine($"ERROR: File was not found. '{inputFileName}'.");
                EndProgram();
            } catch (System.IO.DirectoryNotFoundException) {
                Console.WriteLine("ERROR: Directory was not found.");
                EndProgram();
            } catch (System.IO.IOException) {
                Console.WriteLine("ERROR: The file could not be opened.");
                EndProgram();
            }
            ResetOrderedData();
        }


        public void ResetOrderedData() {
            List<int> tempList = new List<int>();
            foreach (int n in _dataUnordered) {
                tempList.Add(n);
            }
            int[] tempArray = tempList.ToArray();
            _dataOrdered = tempArray;
        }


        public void PrintRoadDataUnordered() {
            MiscMethods.PrintIntArrayToScreen(_dataUnordered);
        }


        private void EndProgram() {
            Console.WriteLine("\nProgram will close.\n\n>>> Waiting for keypress.");
            Console.ReadKey();
            Environment.Exit(0);
        }


        // Printing ordered
        public void PrintRoadDataOrderedQuickSort() {
            PrintRoadDataOrderedQuickSort(1);
        }

        public void PrintRoadDataOrderedQuickSort(int everyNthValue) {
            ResetOrderedData();
            _dataOrdered = Sorting.QuickSort(_dataOrdered);
            MiscMethods.PrintIntArrayToScreen(_dataOrdered, everyNthValue);
        }


        // Bubble
        public void PrintRoadDataOrderedBubbleSort() {
            PrintRoadDataOrderedBubbleSort(1);
        }

        public void PrintRoadDataOrderedBubbleSort(int everyNthValue) {
            ResetOrderedData();
            _dataOrdered = Sorting.BubbleSort(_dataOrdered);
            MiscMethods.PrintIntArrayToScreen(_dataOrdered, everyNthValue);
        }


        // Selection
        public void PrintRoadDataOrderedSelectionSort() {
            PrintRoadDataOrderedSelectionSort(1);
        }

        public void PrintRoadDataOrderedSelectionSort(int everyNthValue) {
            ResetOrderedData();
            _dataOrdered = Sorting.SelectionSort(_dataOrdered);
            MiscMethods.PrintIntArrayToScreen(_dataOrdered, everyNthValue);
        }


        // Binary
        public void FindValueBinaryALL(int NumberToSearchFor) {
            ResetOrderedData();
            _dataOrdered = Sorting.QuickSort(_dataOrdered);
            Console.WriteLine(Searching.BinarySearchIterativeALL(_dataOrdered, NumberToSearchFor));
        }

        public void FindValueBinaryNEAREST(int NumberToSearchFor) {
            ResetOrderedData();
            _dataOrdered = Sorting.QuickSort(_dataOrdered);
            Console.WriteLine(Searching.BinarySearchIterativeNEAREST(_dataOrdered, NumberToSearchFor));
        }


        // Sequential
        public void FindValueSequentialALL(int NumberToSearchFor) {
            ResetOrderedData();
            _dataOrdered = Sorting.QuickSort(_dataOrdered);
            Console.WriteLine(Searching.SequentialSearchALL(_dataOrdered, NumberToSearchFor));
        }

        public void FindValueSequentialNEAREST(int NumberToSearchFor) {
            ResetOrderedData();
            _dataOrdered = Sorting.QuickSort(_dataOrdered);
            Console.WriteLine(Searching.SequentialSearchNEAREST(_dataOrdered, NumberToSearchFor));
        }
    }
}