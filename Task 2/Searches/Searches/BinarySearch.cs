namespace Searches
{
    public static class BinarySearch
    {
        public static int Execute(int[] array, int numberToFind)
        {
            int indexOfElement = -1;

            int start = 0;
            int end = array.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                
                if (array[mid] == numberToFind) 
                    return mid;
                
                if (array[mid] < numberToFind)
                    start = mid + 1;
                else 
                    end = mid - 1;
            }

            return indexOfElement;
        }
    }
}