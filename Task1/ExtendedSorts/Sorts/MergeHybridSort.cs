namespace Sorts
{
    public class MergeHybridSort
    {
        //Всё как в MergeSort, только при определённом размере массива вместо рекурсивного вызова вызывается InsertionSort
        public static void DoMergeHybridSort(int[] array, int start, int end, int k)
        {
            if (end - start + 1 <= k)
            {
                InsertionSort.DoInsertionSort(array, start, end);
                return;
            }
            
            if (start < end)
            {
                int border = (start + end) / 2;
                // Делаем merge для левой и правой части
                DoMergeHybridSort(array, start, border, k);
                DoMergeHybridSort(array, border + 1, end, k);
                // Склейка в один массив
                DoMerge(array, start, border, end);
            }
        }

        static void DoMerge(int[] array, int start, int border, int end)
        {
            int[] sortedSubArray = new int[end - start + 1];
            int i = start;
            int j = border + 1;
            int k = 0;
            
            // Смотрим элементы из 2 отсортированных массивов
            
            while (i <= border && j <= end)
            {
                if (array[i] > array[j]) 
                {
                    sortedSubArray[k] = array[j]; 
                    j++;
                }
                else
                {
                    sortedSubArray[k] = array[i]; 
                    i++;
                }
                k++;
            }

            while (i <= border)
            {
                sortedSubArray[k] = array[i];
                k++;
                i++;
            }
            while (j <= end)
            {
                sortedSubArray[k] = array[j];
                k++;
                j++;
            }

            for (i = start, k = 0; i <= end; i++, k++)
            {
                array[i] = sortedSubArray[k];
            }
        }
    }
}