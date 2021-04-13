using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm_assessment_1 {
    class Sorting {
        private static int _StepsCounter;
        public static int StepsCounter {
            get { return _StepsCounter; }
        }
        public static void ResetStepsCounter() {
            _StepsCounter = 0;
        }
        public static int[] QuickSort(int[] array) {
            return QuickSort(array, 0, array.Length - 1);
        }
        private static int[] QuickSort(int[] array, int left, int right) {
            var pivot = array[(left + right) / 2];
            int a = left;
            int b = right;
            while (a <= b) {
                while (array[a] < pivot) { a++; }
                while (array[b] > pivot) { b--; }
                if ( a <= b) {
                    var temp = array[a];
                    array[a] = array[b];
                    array[b] = temp;
                    a++;
                    b--;
                    _StepsCounter++;
                }
            }
            if (left < b) { array = QuickSort(array, left, b);  }
            if (a < right) { array = QuickSort(array, a, right); }
            return array;
        }

        public static int[] BubbleSort(int[] array) {
            for (int a = 0; a < array.Length; a++) {
                for (int b = 0; b < array.Length - 1; b++) {
                    if (array[b] > array[b + 1]) {
                        int temp = array[b + 1];
                        array[b + 1] = array[b];
                        array[b] = temp;
                        _StepsCounter++;
                    }
                }
            }
            return array;
        }

        public static int[] SelectionSort(int[] array) {
            for (int a = 0; a < array.Length; a++) {
                int IndexOfSmallestValue = a;
                // check the rest of the array, anything less than b is already in order
                for (int b = a + 1; b < array.Length; b++) {
                    if (array[b] < array[IndexOfSmallestValue]) { IndexOfSmallestValue = b; }
                }
                if (IndexOfSmallestValue != a) {
                    int temp = array[IndexOfSmallestValue];
                    array[IndexOfSmallestValue] = array[a];
                    array[a] = temp;
                    _StepsCounter++;
                }
            }
            return array;
        }
    }
}