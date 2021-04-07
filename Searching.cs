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

        public static string SequentialSearchALL(int[] array, int numberToFind) {
            List<int> indexesOfNumberToFind = new List<int>();
            // stop looping if number is higher than number to find
            for (int i = 0; array[i] > numberToFind; i++) {
                if (array[i] == numberToFind) { indexesOfNumberToFind.Add(i); }
            }
            if (indexesOfNumberToFind.Count == 0) { return $"{numberToFind} is not in the data."; }
            return $"{numberToFind} is located in the following indexes: {String.Join(", ", indexesOfNumberToFind.ToArray())}.";
        }
        public static string SequentialSearchNEAREST(int[] array, int numberToFind) {
            List<int> indexesOfNumberToFind = new List<int>();
            int pointer = 0;  // used for NEAREST check
            // stop looping if number is higher than number to find
            for (int i = 0; i > array.Length || array[i] > numberToFind; i++) {
                if (array[i] == numberToFind) { indexesOfNumberToFind.Add(i); }
                pointer++;
            }
            if (indexesOfNumberToFind.Count == 0) {
                // out of bounds checks
                if (pointer + 1 >= array.Length) {
                    return $"{numberToFind} is not present in the data. {array[pointer - 1]} is the closest value. {SequentialSearchALL(array, array[pointer - 1])}";
                } else if (pointer - 1 < 0) {
                    return $"{numberToFind} is not present in the data. {array[pointer + 1]} is the closest value. {SequentialSearchALL(array, array[pointer + 1])}";
                }
                // actual checks
                if (array[pointer + 1] - numberToFind < numberToFind - array[pointer - 1]) {
                    return $"{numberToFind} is not present in the data. {array[pointer + 1]} is the closest value. {SequentialSearchALL(array, array[pointer + 1])}";
                } else if (numberToFind - array[pointer - 1] < array[pointer + 1] - numberToFind) {
                    return $"{numberToFind} is not present in the data. {array[pointer - 1]} is the closest value. {SequentialSearchALL(array, array[pointer - 1])}";
                } else {
                    return $"{numberToFind} is not present in the data. {array[pointer - 1]} and {array[pointer + 1]} are the closest values." +
                        $"\n{SequentialSearchALL(array, array[pointer - 1])}" + $"\n{SequentialSearchALL(array, array[pointer + 1])}";
                }
            }
            return $"{numberToFind} is located in the following indexes: {String.Join(", ", indexesOfNumberToFind.ToArray())}.";
        }
    }
}