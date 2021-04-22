using System;
using System.Collections.Generic;

namespace algorithm_assessment_1 {
    class MiscMethods {
        public static void PrintIntArrayToScreen(int[] array) {
            PrintIntArrayToScreen(array, 1);
        }

        public static void PrintIntArrayToScreen(int[] array, int everyNthValue) {
            if (everyNthValue > 0) {
                for (int i = 0; i < array.Length; i += everyNthValue) {
                    Console.Write(array[i] + " ");
                }
            } else {  // Negative everyNthValue allows for descending
                for (int i = array.Length - 1; i >= 0; i += everyNthValue) {
                    Console.Write(array[i] + " ");
                }
            }
        }


        public static int[] MergeArrays(int[] array1, int[] array2) {
            List<int> list = new List<int>();
            list.AddRange(array1);
            list.AddRange(array2);
            return list.ToArray();
        }
        public static int[] MergeArrays(int[] array1, int[] array2, int[] array3) {
            return MergeArrays(MergeArrays(array1, array2), array3);
        }
    }
}