using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class Graph
    {
        private List<List<int>> AdjacencyLists { get; set; }
        public List<List<int>> ConnectivityComponents { get; }
        private List<bool> UsedVertexes { get; set; }

        public Graph(List<List<int>> adjacencyLists)
        {
            AdjacencyLists = new List<List<int>>(adjacencyLists);
            ConnectivityComponents = new List<List<int>>();
            UsedVertexes = new List<bool>();
            
            for (int i = 0; i < AdjacencyLists.Count; i++)
            {
                UsedVertexes.Add(false);
            }

            BuildConnectivityComponents();
        }

        public Graph(int[][] adjacencyMatrix)
        {
            AdjacencyLists = new List<List<int>>(); 
            for (int i = 0; i < adjacencyMatrix.Length; i++)
            {
                AdjacencyLists.Add(new List<int>());
                for (int j = 0; j < adjacencyMatrix[i].Length; j++)
                {
                    if (adjacencyMatrix[i][j] == 1)
                    {
                        AdjacencyLists[i].Add(j);
                    }
                }
            }
            
            ConnectivityComponents = new List<List<int>>();
            UsedVertexes = new List<bool>();
            
            for (int i = 0; i < AdjacencyLists.Count; i++)
            {
                UsedVertexes.Add(false);
            }

            BuildConnectivityComponents();
        }

        public Graph(string[] words)
        {
            AdjacencyLists = new List<List<int>>();
            for (int i = 0; i < words.Length; i++)
            {
                AdjacencyLists.Add(new List<int>());
                char lastCharOfWord = words[i].Last();
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].First() == lastCharOfWord && i != j)
                    {
                        AdjacencyLists[i].Add(j);
                    }
                }
            }
            
            ConnectivityComponents = new List<List<int>>();
            UsedVertexes = new List<bool>();
            
            for (int i = 0; i < AdjacencyLists.Count; i++)
            {
                UsedVertexes.Add(false);
            }

            BuildConnectivityComponents();
        }

        private void BuildConnectivityComponents()
        {
            for (int i = 0; i < UsedVertexes.Count; i++)
            {
                if (!UsedVertexes[i])
                {
                    List<int> currentConnectivityComponent = new List<int>();
                    FindOneComponent(i, currentConnectivityComponent);
                    ConnectivityComponents.Add(currentConnectivityComponent);
                }
            }

            for (int i = 0; i < UsedVertexes.Count; i++) { UsedVertexes[i] = false; }
        }

        private void FindOneComponent(int currentVertex, List<int> currentConnectivityComponent)
        {
            UsedVertexes[currentVertex] = true;
            currentConnectivityComponent.Add(currentVertex);

            for (int i = 0; i < AdjacencyLists[currentVertex].Count; i++)
            {
                int whereDoWeGoNext = AdjacencyLists[currentVertex][i];
                if (!UsedVertexes[whereDoWeGoNext])
                {
                    FindOneComponent(whereDoWeGoNext, currentConnectivityComponent);
                }
            }
        }
        
        public bool IsEuler()
        {
            foreach (var vertexList in AdjacencyLists)
            {
                if (vertexList.Count % 2 != 0)
                    return false;
            }

            return ConnectivityComponents.Count == 1;
        }
        
        public Stack<int> EulerCycle()
        {
            if (!IsEuler())
            {
                return null;
            }
            
            Stack<int> tempStack = new Stack<int>();
            Stack<int> eulerStack = new Stack<int>();
            
            List<List<int>> graphCopy = new List<List<int>>(AdjacencyLists);
            
            int vertex = 0;

            tempStack.Push(vertex);
            
            while (tempStack.Count > 0)
            {
                vertex = tempStack.Peek();

                if (graphCopy[vertex].Count > 0)
                {
                    int nextVertex = graphCopy[vertex][0];

                    tempStack.Push(nextVertex);
                    
                    graphCopy[vertex].Remove(nextVertex);
                    graphCopy[nextVertex].Remove(vertex);
                }
                else
                {
                    int vertexToEuler = tempStack.Pop();
                    eulerStack.Push(vertexToEuler);
                }
            }

            return eulerStack;
        }
    }
}