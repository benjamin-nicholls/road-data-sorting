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
                while (array[a] < pivot) {
                    a++;
                }
                while (array[b] > pivot) {
                    b--;
                }
                if (a <= b) {
                    var temp = array[a];
                    array[a] = array[b];
                    array[b] = temp;
                    a++;
                    b--;
                    _StepsCounter++;
                }
            }
            if (left < b) {
                array = QuickSort(array, left, b); 
            }
            if (a < right) {
                array = QuickSort(array, a, right);
            }
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
                // Check the rest of the array, anything less than b is already in order.
                for (int b = a + 1; b < array.Length; b++) {
                    if (array[b] < array[IndexOfSmallestValue]) {
                        IndexOfSmallestValue = b;
                    }
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


        public static int[] MergeSort(int[] array) {
            List<int> tempList = new List<int>();
            foreach (int n in array) {
                tempList.Add(n);
            }
            return MergeSort(tempList).ToArray();
        }

        private static List<int> MergeSort(List<int> list) {
            if (list.Count < 2) {
                return list;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int midpoint = list.Count / 2;

            for (int i = 0; i < midpoint; i++) {
                left.Add(list[i]);
                _StepsCounter++;
            }

            for (int i = midpoint; i < list.Count; i++) {
                right.Add(list[i]);
                _StepsCounter++;
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right) {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0) {
                if (left.Count > 0 && right.Count > 0) {

                    if (left[0] <= right[0]) {
                        result.Add(left[0]);
                        left.RemoveAt(0);
                        _StepsCounter++;
                    } else {
                        result.Add(right[0]);
                        right.RemoveAt(0);
                        _StepsCounter++;
                    }

                } else if (left.Count > 0) {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                    _StepsCounter++;

                } else if (right.Count > 0) {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                    _StepsCounter++;
                }
            }
            return result;
        }


        public static int[] InsertionSort(int[] array) {
            for (int a = 1; a < array.Length; a++) {
                int key = array[a];
                int b = a - 1;
                while (b >= 0 && array[b] > key) {
                    _StepsCounter++;
                    array[b + 1] = array[b];
                    b = b - 1;
                }
                array[b + 1] = key;
            }
            return array;
        }

    }
}