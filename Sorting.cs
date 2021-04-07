using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm_assessment_1 {
    class Sorting {
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
                    }
                }
            }
            return array;
        }
    }
}