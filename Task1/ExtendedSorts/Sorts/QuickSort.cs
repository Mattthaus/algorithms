namespace Sorts
{
    public static class QuickSort
    {
        public static void DoQuickSort(int[] array, int start, int end, int k)
        {
            if (start < end)
            {
                //Ищем граничный элемент, который поставим на своё место, и запустим сортировки для двух полученных частей
                int border = FindBorder(array, start, end);
                DoQuickSort(array, start, border, k);
                DoQuickSort(array, border + 1, end, k);
            }
        }

        static int FindBorder(int[] array, int start, int end)
        {
            //Предполагаем, что какой-то средний на своём месте
            int borderElement = array[(start + end) / 2];
            int i = start - 1;
            int j = end + 1;
            // Двигаемся с каждой стороны массива к этому элементу, если встречаем элементы, которые 
            // слева меньше, а справа больше данного, меняем местами
            // и так пока i < j. Возвращаем границу
            while (true)
            {
                do 
                {
                    i++;
                } while (array[i] < borderElement);

                do
                {
                    j--;
                } while (array[j] > borderElement);

                if (i < j)
                    Swap(ref array[i], ref array[j]);
                else return j;
            }
        }

        //Простой свап через третью переменную
        static void Swap(ref int a, ref int b)
        {
            int z = a; 
            a = b; 
            b = z; 
        }
    }
}