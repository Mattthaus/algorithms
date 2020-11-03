
using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            int[] numbersToAdd = new[] {1, 2, 9, 6, 7, 4, 10};

            Console.WriteLine("Got array:");
            
            foreach (var number in numbersToAdd)
            {
                Console.Write($"{number} ");
            }
            
            Console.WriteLine();
            
            binaryTree.BuildTree(numbersToAdd);
            
            Console.WriteLine("Got Tree:");
            binaryTree.PrintTree();

            Console.WriteLine("Height before balancing:");
            Console.WriteLine($"{binaryTree.GetHeight()}");
            
            Console.WriteLine("Ascending sequence:");
            foreach (int number in binaryTree.AscendingSequence())
            {
                Console.Write($"{number} ");
            }
            
            Console.WriteLine();
            
            Console.WriteLine("Descending sequence:");
            foreach (int number in binaryTree.DescendingSequence())
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
            
            Console.WriteLine("Equivalent sequence:");
            foreach (int number in binaryTree.EquivalentSequence())
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
            
            Console.WriteLine("Across:");
            foreach (int number in binaryTree.Across())
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();

            int k = 3;
            Console.WriteLine($"k-th minimal element is: {binaryTree.FindKthMinimalElement(3)} (k = {k})");
        }
    }
}