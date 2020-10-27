using System;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearSoundingHashTable<int, int> linearSoundingHashTable = new LinearSoundingHashTable<int, int>(11);

            for (int i = 0; i < 20; i++)
                linearSoundingHashTable.Put(i, i * 100);

            for (int i = 0; i < 20; i++)
                Console.WriteLine(linearSoundingHashTable.Get(i).Value);
        }
    }
}