namespace Sorts
{
    public class BubbleSort
    {
        //Все переменные кроме массива для делегата
        //Проходим по массиву и меняем соседние элементы, если левый меньше правого
        public static void DoBubbleSort(int[] array, int l = 0, int r = 0, int k = 0)
        {
            for (int j = 0; j <= array.Length - 2; j++)
                for (int i = 0; i <= array.Length - 2; i++)
                    if (array[i] > array[i + 1]) 
                        Swap(ref array[i + 1], ref array[i]);
        }

        static void Swap(ref int a, ref int b)
        {
            int z = a; 
            a = b; 
            b = z; 
        }
    }
}