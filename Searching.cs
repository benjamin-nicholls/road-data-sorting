using System;
using System.Collections.Generic;

namespace algorithm_assessment_1 {
    class Searching {
        public static string BinarySearchIterativeALL(int[] array, int numberToFind) {
            int left = 0;
            int right = array.Length - 1;
            List<int> indexesOfNumberToFind = new List<int>();
            while (left <= right) {
                int midpoint = (left + right) / 2;
                if (array[midpoint] == numberToFind) {
                    indexesOfNumberToFind.Add(midpoint);
                    // Search left and right of midpoint sequentially for any other instance of numberToFind
                    int pointer = midpoint - 1;
                    if (pointer >= 0) {
                        while (array[pointer] == numberToFind) {
                            indexesOfNumberToFind.Add(pointer);
                            pointer--;
                            if (pointer < 0) { break; }
                        }
                    }
                    pointer = midpoint + 1;
                    if (pointer < array.Length -1) {
                        while (array[pointer] == numberToFind) {
                            indexesOfNumberToFind.Add(pointer);
                            pointer++;
                            if (pointer > array.Length - 1) { break; }
                        }
                    }
                    break;
                }
                if (array[midpoint] < numberToFind) { left = midpoint + 1; }
                else { right = midpoint - 1; }
            }
            if (indexesOfNumberToFind.Count == 0) { return $"{numberToFind} is not in the data."; }
            // List > array > sort (array) > string > return
            return $"{numberToFind} is located in the following indexes: {String.Join(", ", Sorting.QuickSort(indexesOfNumberToFind.ToArray()))}.";
        }
        public static string BinarySearchIterativeNEAREST(int[] array, int numberToFind) {
            int left = 0;
            int right = array.Length - 1;
            List<int> indexesOfNumberToFind = new List<int>();
            while (left <= right) {
                int midpoint = (left + right) / 2;
                if (array[midpoint] == numberToFind) {
                    indexesOfNumberToFind.Add(midpoint);
                    // Search left and right of midpoint sequentially for any other instance of numberToFind
                    int pointer = midpoint - 1;
                    if (pointer >= 0) {
                        while (array[pointer] == numberToFind) {
                            indexesOfNumberToFind.Add(pointer);
                            pointer--;
                            if (pointer < 0) { break; }
                        }
                    }
                    pointer = midpoint + 1;
                    if (pointer > array.Length - 1) {
                        while (array[pointer] == numberToFind) {
                            indexesOfNumberToFind.Add(pointer);
                            pointer++;
                            if (pointer > array.Length - 1) { break; }
                        }
                    }
                    break;
                }
                if (array[midpoint] < numberToFind) { left = midpoint + 1; }
                else { right = midpoint - 1; }
            }
            if (indexesOfNumberToFind.Count == 0) {
                // out of bounds checks
                if (left >= array.Length) {
                    return $"{numberToFind} is not present in the data. {array[right]} is the closest value. {BinarySearchIterativeALL(array, array[right])}";
                } else if (right < 0) {
                    return $"{numberToFind} is not present in the data. {array[left]} is the closest value. {BinarySearchIterativeALL(array, array[left])}";
                }
                // actual checks
                if (array[left] - numberToFind < numberToFind - array[right]) {
                    return $"{numberToFind} is not present in the data. {array[left]} is the closest value. {BinarySearchIterativeALL(array, array[left])}";
                } else if (numberToFind - array[right] < array[left] - numberToFind) {
                    return $"{numberToFind} is not present in the data. {array[right]} is the closest value. {BinarySearchIterativeALL(array, array[right])}";
                } else {
                    return $"{numberToFind} is not present in the data. {array[right]} and {array[left]} are the closest values." +
                        $"\n{BinarySearchIterativeALL(array, array[right])}" + $"\n{BinarySearchIterativeALL(array, array[left])}";
                }
            }
            // List > array > sort (array) > string > return
            return $"{numberToFind} is located in the following indexes: {String.Join(", ", Sorting.QuickSort(indexesOfNumberToFind.ToArray()))}.";
        }
    }
}