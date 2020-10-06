using System;

namespace Searches
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = CreateRandomArray(1048576, 10000000);
            Array.Sort(array);

            Random random = new Random();
            int indexOfElementToFind = random.Next(0, array.Length - 1);

            Console.WriteLine($"Searching element: {array[indexOfElementToFind]}");
            Console.WriteLine($"Its position: {Array.IndexOf(array, array[indexOfElementToFind])}");
            
            double startTime = (DateTime.Now - new DateTime(2020, 10, 5)).TotalMilliseconds;
            LinearSearch.Execute(array, array[indexOfElementToFind]);
            double endTime = (DateTime.Now - new DateTime(2020, 10, 5)).TotalMilliseconds;
            Console.WriteLine($"Time (Linear search): {endTime - startTime}");

            startTime = (DateTime.Now - new DateTime(2020, 10, 5)).TotalMilliseconds;
            BinarySearch.Execute(array, array[indexOfElementToFind]);
            endTime = (DateTime.Now - new DateTime(2020, 10, 5)).TotalMilliseconds;
            Console.WriteLine($"Time (Binary search): {endTime - startTime}");
            
            startTime = (DateTime.Now - new DateTime(2020, 10, 5)).TotalMilliseconds;
            InterpolationSearch.Execute(array, array[indexOfElementToFind]);
            endTime = (DateTime.Now - new DateTime(2020, 10, 5)).TotalMilliseconds;
            Console.WriteLine($"Time (Interpolation search): {endTime - startTime}");
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
