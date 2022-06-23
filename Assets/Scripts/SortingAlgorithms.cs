using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CircuitStream
{
    [InitializeOnLoad]
    public static class SortingAlgorithms
    {
        private static readonly int[] arrayTestSizes = {0, 1, 5, 1000};
        private static int currentTestSizeIndex = 2;
        private static int CurrentTestSize => arrayTestSizes[currentTestSizeIndex];

        [MenuItem("Sorting Algorithms/Change Test Size")]
        private static void CycleTestSize()
        {
            currentTestSizeIndex = (currentTestSizeIndex + 1) % arrayTestSizes.Length;
            Debug.Log($"New Test Size: {CurrentTestSize}");
        }

        [MenuItem("Sorting Algorithms/Insertion Sort")]
        private static void InsertionSort()
        {
            var array = GenerateRandomArray();
            Debug.LogWarning($"Starting Array: {String.Join(", ", array)}");

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j] > array[j - 1]) break;

                    int tmp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = tmp;
                }
            }

            Debug.Log($"Result: {String.Join(", ", array)}");
        }

        [MenuItem("Sorting Algorithms/Bubble Sort")]
        private static void BubbleSort()
        {
            var array = GenerateRandomArray();
            Debug.LogWarning($"Starting Array: {String.Join(", ", array)}");

            int tmp;
            bool arrayChanged;

            for (int i = 0; i <= array.Length - 2; i++)
            {
                arrayChanged = false;
                for (int j = 0; j <= array.Length - 2; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        tmp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = tmp;

                        arrayChanged = true;
                    }
                }

                if (!arrayChanged) break;
            }

            Debug.Log($"Result: {String.Join(", ", array)}");
        }

        [MenuItem("Sorting Algorithms/Merge Sort")]
        private static void MergeSort()
        {
            var array = GenerateRandomArray();
            Debug.LogWarning($"Starting Array: {String.Join(", ", array)}");

            // TODO

            Debug.Log($"Result: {String.Join(", ", array)}");
        }

        private static int[] GenerateRandomArray()
        {
            var array = new int[CurrentTestSize];

            for (int i = 0; i < CurrentTestSize; i++)
                array[i] = Random.Range(-1000, 1000);

            return array;
        }
    }
}

