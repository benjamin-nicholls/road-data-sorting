using System;
using System.Collections.Generic;

namespace algorithm_assessment_1 {
    class Searching {
        private static int _StepsCounter;
        public static int StepsCounter {
            get { return _StepsCounter; }
        }
        public static void ResetStepsCounter() {
            _StepsCounter = 0;
        }


        // Return results only for numberToFind.
        public static string BinarySearchIterativeALL(int[] array, int numberToFind) {
            int left = 0;
            int right = array.Length - 1;
            List<int> indexesOfNumberToFind = new List<int>();

            while (left <= right) {
                _StepsCounter++;
                int midpoint = (left + right) / 2;

                if (array[midpoint] == numberToFind) {
                    indexesOfNumberToFind.Add(midpoint);

                    // Search left and right of midpoint sequentially for any other instance of numberToFind.
                    int pointer = midpoint - 1;
                    if (pointer >= 0) {
                        while (array[pointer] == numberToFind) {
                            indexesOfNumberToFind.Add(pointer);
                            pointer--;
                            _StepsCounter++;
                            if (pointer < 0) { break; }
                        }
                    }

                    pointer = midpoint + 1;
                    if (pointer < array.Length -1) {
                        while (array[pointer] == numberToFind) {
                            indexesOfNumberToFind.Add(pointer);
                            pointer++;
                            _StepsCounter++;
                            if (pointer > array.Length - 1) { break; }
                        }
                    }

                    break;
                }

                if (array[midpoint] < numberToFind) { left = midpoint + 1; }
                else { right = midpoint - 1; }
            }

            if (indexesOfNumberToFind.Count == 0) {
                return String.Format("{0} is not in the data.", numberToFind);
            }

            // List > array > sort (array) > string > return
            return String.Format("{0} is located in the following indexes: {1}.", numberToFind, String.Join(", ", Sorting.QuickSort(indexesOfNumberToFind.ToArray())));
        }


        // Return results for numberToFind unless there is none, then return results for nearest value(s).
        public static string BinarySearchIterativeNEAREST(int[] array, int numberToFind) {
            int left = 0;
            int right = array.Length - 1;
            List<int> indexesOfNumberToFind = new List<int>();

            while (left <= right) {
                int midpoint = (left + right) / 2;

                if (array[midpoint] == numberToFind) {
                    indexesOfNumberToFind.Add(midpoint);

                    // Search left and right of midpoint sequentially for any other instance of numberToFind.
                    int pointer = midpoint - 1;
                    if (pointer >= 0) {
                        while (array[pointer] == numberToFind) {
                            indexesOfNumberToFind.Add(pointer);
                            pointer--;
                            _StepsCounter++;
                            if (pointer < 0) { break; }
                        }
                    }

                    pointer = midpoint + 1;
                    if (pointer > array.Length - 1) {
                        while (array[pointer] == numberToFind) {
                            indexesOfNumberToFind.Add(pointer);
                            pointer++;
                            _StepsCounter++;
                            if (pointer > array.Length - 1) { break; }
                        }
                    }

                    break;
                }

                if (array[midpoint] < numberToFind) {
                    left = midpoint + 1;
                } else {
                    right = midpoint - 1;
                }
            }
            if (indexesOfNumberToFind.Count == 0) {
                // Edge cases / out of bounds checks.
                if (left >= array.Length) {
                    return String.Format("{0} is not present in the data. {1} is the closest value. {2}", numberToFind, array[right], BinarySearchIterativeALL(array, array[right]));
                } else if (right < 0) {
                    return String.Format("{0} is not present in the data. {1} is the closest value. {2}", numberToFind, array[left], BinarySearchIterativeALL(array, array[left]));
                }

                // Regular checks.
                if (array[left] - numberToFind < numberToFind - array[right]) {
                    return String.Format("{0} is not present in the data. {1} is the closest value. {2}", numberToFind, array[left], BinarySearchIterativeALL(array, array[left]));
                } else if (numberToFind - array[right] < array[left] - numberToFind) {
                    return String.Format("{0} is not present in the data. {1} is the closest value. {2}", numberToFind, array[right], BinarySearchIterativeALL(array, array[right]));
                } else {
                    return String.Format("{0} is not present in the data. {1} and {2} are the closest values.", numberToFind, array[right], array[left] +
                        $"\n{BinarySearchIterativeALL(array, array[right])}" +
                        $"\n{BinarySearchIterativeALL(array, array[left])}");
                }
            }

            // List > array > sort (array) > string > return.
            return String.Format("{0} is located in the following indexes: {1}.", numberToFind, String.Join(", ", Sorting.QuickSort(indexesOfNumberToFind.ToArray())));
        }


        public static string SequentialSearchALL(int[] array, int numberToFind) {
            List<int> indexesOfNumberToFind = new List<int>();

            // Stop looping if number is higher than numberToFind.
            for (int i = 0; i < array.Length; i++) {
                if (array[i] > numberToFind ) { break; }
                if (array[i] == numberToFind) { indexesOfNumberToFind.Add(i); }
                _StepsCounter++;
            }

            if (indexesOfNumberToFind.Count == 0) {
                return String.Format("{0} is not in the data.", numberToFind);
            }
            return String.Format("{0} is located in the following indexes: {1}.", numberToFind, String.Join(", ", indexesOfNumberToFind.ToArray()));
        }
        public static string SequentialSearchNEAREST(int[] array, int numberToFind) {
            List<int> indexesOfNumberToFind = new List<int>();
            int pointer = 0;  // Used for NEAREST check later.

            // Stop looping if number is higher than numberToFind.
            for (int i = 0; i < array.Length; i++) {
                if (array[i] > numberToFind) { break; }
                if (array[i] == numberToFind) { indexesOfNumberToFind.Add(i); }
                pointer++;
                _StepsCounter++;
            }

            if (indexesOfNumberToFind.Count == 0) {
                // Edge cases / out of bounds checks.
                if (pointer + 1 >= array.Length) {
                    //return $"{numberToFind} is not present in the data. {array[pointer - 1]} is the closest value. {SequentialSearchALL(array, array[pointer - 1])}";
                    return String.Format("{0} is not present in the data. {1} is the closest value. {2}", numberToFind, array[pointer - 1], SequentialSearchALL(array, array[pointer - 1]));
                } else if (pointer - 1 < 0) {
                    return String.Format("{0} is not present in the data. {1} is the closest value. {2}", numberToFind, array[pointer + 1], SequentialSearchALL(array, array[pointer + 1]));
                }

                // Regular checks.
                if (array[pointer + 1] - numberToFind < numberToFind - array[pointer - 1]) {
                    return String.Format("{0} is not present in the data. {1} is the closest value. {2}", numberToFind, array[pointer + 1], SequentialSearchALL(array, array[pointer + 1]));
                } else if (numberToFind - array[pointer - 1] < array[pointer + 1] - numberToFind) {
                    return String.Format("{0} is not present in the data. {1} is the closest value. {2}", numberToFind, array[pointer - 1], SequentialSearchALL(array, array[pointer - 1]));
                } else {
                    return String.Format("{0} is not present in the data. {1} and {2} are the closest values.", numberToFind, array[pointer - 1], array[pointer + 1]) +
                        $"\n{SequentialSearchALL(array, array[pointer - 1])}" +
                        $"\n{SequentialSearchALL(array, array[pointer + 1])}";
                }
            }

            return String.Format("{0} is located in the following indexes: {1}.", numberToFind, String.Join(", ", indexesOfNumberToFind.ToArray()));
        }

    }
}