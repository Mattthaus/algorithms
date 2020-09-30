namespace Sorts
{
    public class CountingSort
    {
        //Пробегаем по массиву, записывая в вспомогательный массив по индексу значения элемента массива
        //количество раз, сколько этот элемент встретился в исходном, а потом переписываем массив,
        //проходя по каждому элементу нового массива, нужное количество раз
        public static void DoCountingSort(int[] array, int l = 0, int r = 0, int k = 0)
        {
            int n = array.Length;
            int[] countOfElementsArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                countOfElementsArray[i] = 0;
            }
            
            for (int i = 0; i < n; i++)
                countOfElementsArray[array[i]]++;
            int b = 0;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < countOfElementsArray[i]; j++) 
                {
                    array[b] = i;
                    b++;
                }
            }	
        }
    }
}