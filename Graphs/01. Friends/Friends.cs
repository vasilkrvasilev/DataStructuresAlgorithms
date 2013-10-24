using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Friends
{
    public static void Main()
    {
        // Read input
        string input = Console.ReadLine();
        string[] inputData = input.Split(' ');
        int buildings = int.Parse(inputData[0]);
        int streets = int.Parse(inputData[1]);
        int hospitals = int.Parse(inputData[2]);
        string hospitalsInput = Console.ReadLine();
        string[] hospitalsData = hospitalsInput.Split(' ');
        HashSet<int> hospitalsID = new HashSet<int>();
        for (int count = 0; count < hospitals; count++)
        {
            int currentID = int.Parse(hospitalsData[count]) - 1;
            hospitalsID.Add(currentID);
        }

        // Create matrix of neighborhood
        int[,] graph = new int[buildings, buildings];
        for (int count = 0; count < streets; count++)
        {
            string streetInput = Console.ReadLine();
            string[] streetData = streetInput.Split(' ');
            int firstBuildingID = int.Parse(streetData[0]) - 1;
            int secondBuildingID = int.Parse(streetData[1]) - 1;
            int length = int.Parse(streetData[2]);
            graph[firstBuildingID, secondBuildingID] = length;
            graph[secondBuildingID, firstBuildingID] = length;
        }

        // Start Dijkstra algorithm for each hospital, 
        // Sum the distances to each house and find the min one
        int minPathSum = int.MaxValue;
        foreach (var id in hospitalsID)
        {
            int[] distance = Dijkstra(graph, id);
            int currentPathSum = 0;
            for (int count = 0; count < distance.Length; count++)
            {
                if (!hospitalsID.Contains(count))
                {
                    currentPathSum += distance[count];
                }
            }

            if (currentPathSum < minPathSum)
            {
                minPathSum = currentPathSum;
            }
        }

        Console.WriteLine(minPathSum);
    }

    public static int[] Dijkstra(int[,] graph, int source)
    {
        // Create array to keep distances to different houses and hash set to keep their IDs 
        int[] distance = new int[graph.GetLength(0)];
        HashSet<int> setOfNodes = new HashSet<int>();
        for (int count = 0; count < graph.GetLength(0); count++)
        {
            distance[count] = int.MaxValue;
            setOfNodes.Add(count);
        }

        // Set the distance to current hospital to 0 and find disctance to each house
        distance[source] = 0;
        while (setOfNodes.Count != 0)
        {
            // Find ID the closest building (first time the hospital)
            int minNode = int.MaxValue;
            foreach (var node in setOfNodes)
            {
                if (minNode > distance[node])
                {
                    minNode = node;
                }
            }

            // Remove current building from hash set and check for unconnected graph
            setOfNodes.Remove(minNode);
            if (minNode == int.MaxValue)
            {
                break;
            }

            // Find the dictance from current building to its neighbors and
            // If it is shorter save it in array distance
            for (int count = 0; count < graph.GetLength(0); count++)
            {
                if (graph[minNode, count] > 0)
                {
                    int potencialDistance = distance[minNode] + graph[minNode, count];
                    if (potencialDistance < distance[count])
                    {
                        distance[count] = potencialDistance;
                    }
                }
            }
        }

        return distance;
    }
}
