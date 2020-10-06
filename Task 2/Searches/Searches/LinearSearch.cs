namespace Searches
{
    public static class LinearSearch
    {
        public static long Execute(int[] array, int numberToFind)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == numberToFind)
                    return i;

            return -1;
        }
    }
}