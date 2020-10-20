
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

            binaryTree.BuildTree(numbersToAdd);
            
            Console.WriteLine("Got Tree:");
            binaryTree.PrintTree();

            Console.WriteLine("Height before balancing:");
            Console.WriteLine($"{binaryTree.GetHeight()}");
            
            Console.WriteLine("Ascending sequence:");
            foreach (int number in binaryTree.GetAscendingSequence())
            {
                Console.Write($"{number} ");
            }
            
            Console.WriteLine();
            
            Console.WriteLine("Descending sequence:");
            foreach (int number in binaryTree.GetDescendingSequence())
            {
                Console.Write($"{number} ");
            }
            
            Console.WriteLine();

            int k = 3;
            Console.WriteLine($"k-th minimal element is: {binaryTree.FindKthMinimalElement(3)} (k = {k})");
        }
    }
}