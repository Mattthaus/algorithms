using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            EulerDemo();
        }
        
        private static void EulerDemo()
        {
            Console.Out.WriteLine("Demo with Euler graph");

            int[][] vertexesWithEulerCycle =
            {
                new []{1, 3},
                new []{0, 2, 3, 4},
                new []{1, 4},
                new []{0, 1, 4, 5},
                new []{1, 2, 3, 6},
                new []{3, 6},
                new []{4, 5},
            };
            
            List<List<int>> eulerGraphList = new List<List<int>>();

            foreach (int[] vertex in vertexesWithEulerCycle)
            {
                eulerGraphList.Add(new List<int>(vertex));
            }
            
            //string[] words =
            //{
            //    "киев", //2
            //    "воронеж", //1
            //    "жданов", //2
            //    "витебск", //2
            //    "каранганда", //1
            //    "архангельск" //2
            //};
            
            Graph eulerGraph = new Graph(eulerGraphList);

            PrintEulerInfo(eulerGraph);
        }

        private static void PrintEulerInfo(Graph graph)
        {
            Console.WriteLine("===========");
            if (graph.IsEuler())
            {
                Console.WriteLine("Graph is Euler");
                
                Stack<int> eulerCycle = graph.EulerCycle();
                
                Console.Write("Euler cycle: ");
                while (eulerCycle.Count != 0)
                {
                    Console.Write($"{eulerCycle.Pop()} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Graph is not Euler");
            }
            Console.WriteLine("===========");
        }
    }
}