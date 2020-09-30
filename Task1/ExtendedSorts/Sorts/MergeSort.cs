namespace Sorts
{
    public static class MergeSort
    {
        public static void DoMergeSort(int[] array, int start, int end, int k)
        {
            // Сравниваем, не пустой ли у нас полученный массив и если нет, то сортируем дальше
            if (start < end)
            {
                int border = (start + end) / 2; //Устанавливаем условно середину
                DoMergeSort(array, start, border, k); //Вызываем рекурсивно для первой половины и для второй
                DoMergeSort(array, border + 1, end, k);
                DoMerge(array, start, border, end); //После отработки верхних, склеиваем две уже отсортированные половины
            }
        }

        static void DoMerge(int[] array, int start, int border, int end)
        {
            int[] sortedSubArray = new int[end - start + 1]; //Сюда записываем числа из двух половин
            int i = start; //стартовый индекс первого подмассива
            int j = border + 1; //стартовый индекс второго подмассива
            int k = 0; //индекс массива, который собран из первых двух
            
            // для первого while
            // идём по элементу из каждого массива
            // когда элемент из второго массива меньше чем элемент первого,
            // записываем его в общий и двигаемся только по второму
            // иначе записываем элемент первого массива и сдвигаемся на один элемент по первому,
            // и так пока не дойдём до конца одного из массивов
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

            //Следующие 2 while просто дописывают "хвост" для массива
            //Один из них не отработает, но не важно
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
            
            //Переписываем те два куска на итоговый массив
            for (i = start, k = 0; i <= end; i++, k++)
            {
                array[i] = sortedSubArray[k];
            }
        }
    }
}