using System;

public class Edge : IComparable
{
    public int StartNode { get; set; }
    public int EndNode { get; set; }
    public int Weight { get; set; }

    public Edge(int startNode, int endNode, int weight)
    {
        this.StartNode = startNode;
        this.EndNode = endNode;
        this.Weight = weight;
    }

    public override string ToString()
    {
        return string.Format("({0} {1}) -> {2}", StartNode, EndNode, Weight);
    }

    public int CompareTo(object obj)
    {
        int weightCompared = this.Weight.CompareTo((obj as Edge).Weight);

        if (weightCompared == 0)
        {
            return this.StartNode.CompareTo((obj as Edge).StartNode);
        }
        return weightCompared;
    }
}