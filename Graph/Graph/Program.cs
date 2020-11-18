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
            GraphWithComponentsDemo();
            BipartiteDemo();
        }

        private static void GraphWithComponentsDemo()
        {
            Console.Out.WriteLine("Demo with connectivity components:");

            int[][] adjacencyMatrix = {
                new[]{0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                new[]{1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                new[]{1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                new[]{0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0},
                new[]{0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                new[]{0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0},
                new[]{0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0},
                new[]{0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
                new[]{0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                new[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };
            
            Graph graphWithComponents = new Graph(adjacencyMatrix);
            
            PrintConnectivityComponents(graphWithComponents.ConnectivityComponents);
            
            PrintIsGraphBipartite(graphWithComponents);
        }

        private static void BipartiteDemo()
        {
            Console.Out.WriteLine("Demo with bipartite graph");

            int[][] adjacencyMatrix = {
                new[]{0, 0, 0, 0, 0, 0, 1, 0, 0, 1},
                new[]{0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
                new[]{0, 0, 0, 0, 0, 1, 0, 1, 0, 0},
                new[]{0, 0, 0, 0, 0, 0, 0, 0, 1, 1},
                new[]{0, 0, 0, 0, 0, 0, 1, 0, 0, 1},
                new[]{0, 1, 1, 0, 0, 0, 0, 0, 0, 0},
                new[]{1, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                new[]{0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                new[]{0, 1, 0, 1, 0, 0, 0, 0, 0, 0},
                new[]{1, 0, 0, 1, 1, 0, 0, 0, 0, 0}
                
            };
            
            Graph bipartiteGraph = new Graph(adjacencyMatrix);
            
            PrintConnectivityComponents(bipartiteGraph.ConnectivityComponents);
            
            PrintIsGraphBipartite(bipartiteGraph);
        }
        
        private static void PrintConnectivityComponents(List<List<int>> connectivityComponents)
        {
            Console.WriteLine("===========");
            Console.WriteLine($"Connectivity Components.");

            Console.WriteLine ($"The largest component is of size {connectivityComponents.Max(component => component.Count)}");
            
            Console.WriteLine($"Total Amount is {connectivityComponents.Count}");
            for (int i = 0; i < connectivityComponents.Count; i++)
            {
                StringBuilder sb = new StringBuilder("");

                sb.Append($"Component {i} - {{ ");
                foreach (int currentVertex in connectivityComponents[i])
                    sb.Append($"{currentVertex}, ");

                sb.Remove(sb.Length - 2, 1);
                sb.Append("}");
                Console.WriteLine(sb.ToString());
            }
            Console.WriteLine("===========");
        }

        private static void PrintIsGraphBipartite(Graph graph)
        {
            Console.WriteLine("===========");
            (List<int> firstPart, List<int> secondPart) = graph.FindBipartiteParts();
            
            if (firstPart != null && secondPart != null)
            {
                Console.WriteLine("Graph is bipartite");
                
                Console.Write("First part: ");
                foreach (int vertex in firstPart)
                {
                    Console.Write($"{vertex} ");
                }
            
                Console.WriteLine();
            
                Console.Write("Second part: ");
                foreach (int vertex in secondPart)
                {
                    Console.Write($"{vertex} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("This graph is not bipartite");
            }
            
            Console.WriteLine("===========");
        }
        
    }
}