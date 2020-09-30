using System;
using System.Reflection;

namespace Sorts
{
    static class Program
    {

        delegate void SortMethod(int[] array, int start = 0, int end = 0, int k = 0);

        private const int TwoDegree8 = 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
        private const int TwoDegree17 = 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;

        static void Main(string[] args)
        {
            //Создаём 4 массива, для каждого случая по одному, и запускаем прогоны
            int[][] arraysForTesting = new int[4][];
            arraysForTesting[0] = CreateRandomArray(TwoDegree8, TwoDegree8);
            arraysForTesting[1] = CreateRandomArray(TwoDegree17, TwoDegree17);
            
            arraysForTesting[2] = (int[])arraysForTesting[1].Clone();
            QuickSort.DoQuickSort(arraysForTesting[2], 0, arraysForTesting[2].Length - 1, 0);
            ReplaceSomeElements(arraysForTesting[2], 66);
            
            arraysForTesting[3] = CreateRandomArray(TwoDegree17, 256);
            
            SortMethod sortMethod = BubbleSort.DoBubbleSort;
            CheckTimeForSortingMethod((int[][])arraysForTesting.Clone(), sortMethod);
            
            sortMethod = InsertionSort.DoInsertionSort;
            CheckTimeForSortingMethod((int[][])arraysForTesting.Clone(), sortMethod);
            
            sortMethod = QuickSort.DoQuickSort;
            CheckTimeForSortingMethod((int[][])arraysForTesting.Clone(), sortMethod);
            
            sortMethod = MergeSort.DoMergeSort;
            CheckTimeForSortingMethod((int[][])arraysForTesting.Clone(), sortMethod);
            
            sortMethod = MergeHybridSort.DoMergeHybridSort;
            CheckTimeForSortingMethod((int[][])arraysForTesting.Clone(), sortMethod, 2);

            sortMethod = CountingSort.DoCountingSort;
            CheckTimeForSortingMethod((int[][])arraysForTesting.Clone(), sortMethod);

            //Пузырьком, Вставки, Быстрая, Слиянием, Гибрид, Черпаком
            //Рандомный массив из 2^8, 2^17, Почти упорядоченный 2^17,массив с малой выборкой
        }

        static void CheckTimeForSortingMethod(int[][] arraysForTesting, SortMethod sortMethod, int k = 0)
        {
            for (int i = 0; i < 4; i++)
            {
                double timeForCase = CountTimeForOneSort(arraysForTesting[i], k, sortMethod);
                Console.WriteLine($"time for {i+1} case ({sortMethod.Method.Name}): {timeForCase}");
            }   
        }
        
        static double CountTimeForOneSort(int[] arrayToSort, int k, SortMethod sortMethod)
        {
            var startTime = (DateTime.Now - new DateTime(2020, 9, 19)).TotalMilliseconds;
            
            sortMethod(arrayToSort, 0, arrayToSort.Length - 1, k);
            
            var endTime = (DateTime.Now - new DateTime(2020, 9, 19)).TotalMilliseconds;
            return endTime - startTime;
        }
        static int[] CreateRandomArray(int sizeOfArray, int maxValueOfElement)
        {
            int[] array = new int[sizeOfArray];
            Random random = new Random();
            for (int i = 0; i < sizeOfArray; i++)
            {
                array[i] = random.Next(0, maxValueOfElement);
            }
            return array;
        }

        static void ReplaceSomeElements(int[] array, int elementPairsAmount)
        {
            Random random = new Random();
            for (int k = 0; k < elementPairsAmount; k++)
            {
                int i = random.Next(0, array.Length - 1);
                int j = random.Next(0, array.Length - 1);
                Swap(ref array[i],ref array[j]);
            }
        }
        
        static void Swap(ref int a, ref int b)
        {
            int z = a; 
            a = b; 
            b = z; 
        }
        
        static void PrintArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
            
            Console.WriteLine();
        }
    }
}