namespace Sorts
{
    public static class InsertionSort
    {
        //k здесь чисто для делегата нужна, не обращаем внимание
        public static void DoInsertionSort(int[] array, int start, int end, int k = 0)
        {
            //Проходя по массиву, если находим какой-то элемент меньше, чем левый, запоминаем его в key 
            //И перемещаем всё остальное вправо на 1, пока не найдём очередной элемент слева, который будет меньше,
            //ну или пришли к самому началу
            for (int i = start + 1; i <= end; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j > -1 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                
                array[j + 1] = key;
            }
        }
    }
}