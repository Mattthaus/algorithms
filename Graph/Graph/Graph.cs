using System.Collections.Generic;

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

        public (List<int> firstPart, List<int> secondPart) FindBipartiteParts()
        {
            List<int> firstPart = new List<int>();
            List<int> secondPart = new List<int>();
            
            DepthColorSearch(0, firstPart, secondPart);
            if (firstPart.Count + secondPart.Count != AdjacencyLists.Count)
                return (null, null);
            
            foreach (int vertex in firstPart)
                if (secondPart.Contains(vertex))
                    return (null, null);

            return (firstPart, secondPart);
        }
        
        private void DepthColorSearch(int currentVertex, List<int> firstColorVertexes, List<int> secondColorVertexes, bool isFirstColor = true)
        {
            UsedVertexes[currentVertex] = true;
            
            if (isFirstColor)
                firstColorVertexes.Add(currentVertex);
            else
                secondColorVertexes.Add(currentVertex);

            for (int i = 0; i < AdjacencyLists[currentVertex].Count; i++)
            {
                int nextVertex = AdjacencyLists[currentVertex][i];
                if (!UsedVertexes[nextVertex])
                    DepthColorSearch(nextVertex, firstColorVertexes, secondColorVertexes, !isFirstColor);
            }
        }
    }
}