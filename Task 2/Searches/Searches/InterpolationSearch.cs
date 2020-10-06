using System;

namespace Searches
{
    public static class InterpolationSearch
    {
        public static long Execute(int[] array, int numberToFind)
        {
            long start = 0;
            long end = array.Length - 1;
            
            while (array[start] < numberToFind && numberToFind < array[end] && array[start] != array[end])
            {
                long mid = start + (numberToFind - array[start]) * (end - start) / (array[end] - array[start]);

                if (array[mid] < numberToFind)
                    start = mid + 1;
                else if (array[mid] > numberToFind)
                    end = mid - 1;
                else if (array[mid] == numberToFind)
                    return mid;
            }

            if (array[start] == numberToFind)
                return start;

            if (array[end] == numberToFind)
                return end;

            return -1;
        } 
    }
}