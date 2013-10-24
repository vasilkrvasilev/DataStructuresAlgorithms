using System;
using System.Collections.Generic;

public class TreeExample
{
    public static void Main()
    {
        Tree<int> tree = GenerateTree();

        // First task
        TreeNode<int> root = tree.Root;

        // Second task
        List<TreeNode<int>> leaves = tree.FindLeaves();

        // Third task
        List<TreeNode<int>> middle = tree.FindMiddle();

        // Fourth task
        int maxPath = tree.FindMaxPath();

        // Fifth task
        List<TreeNode<int>> paths = tree.FindPathWithSum(6);

        // Sixth task
        List<TreeNode<int>> subtrees = tree.FindSubtreeWithSum(6);
    }

    private static Tree<int> GenerateTree()
    {
        int numberNodes = int.Parse(Console.ReadLine());
        List<TreeNode<int>> nodes = new List<TreeNode<int>>();

        // Create 0, 1, or 2 nodes from the input
        for (int count = 0; count < numberNodes - 1; count++)
        {
            string input = Console.ReadLine();
            string[] nodeData = input.Split(' ');
            int parentValue = int.Parse(nodeData[0]);
            int childValue = int.Parse(nodeData[1]);
            bool parentExist = false;
            TreeNode<int> parent = null;
            TreeNode<int> child = null;

            // Check is the node with value parentValue or childValue already created
            for (int index = 0; index < nodes.Count; index++)
            {
                TreeNode<int> parentNode = nodes[index].FindChild(parentValue);
                TreeNode<int> childNode = nodes[index].FindChild(childValue);

                // If node with value parentValue is already created
                if (parentNode != null)
                {
                    if (!parentNode.Value.Equals(nodes[index].Value))
                    {
                        parentExist = true;
                    }

                    parent = parentNode;
                }

                // If node with value childValue is already created
                if (childNode != null)
                {
                    child = childNode;
                }
            }

            // If there is no node with value parentValue
            if (parent == null)
            {
                parent = new TreeNode<int>(parentValue);
            }
            else
            {
                nodes.Remove(parent);
            }

            // If there is no node with value childValue
            if (child == null)
            {
                child = new TreeNode<int>(childValue);
            }
            else
            {
                nodes.Remove(child);
            }

            // Add child node to parent and add parent to nodes if there is no node with value parentValue 
            parent.AddChild(child);
            if (!parentExist)
            {
                nodes.Add(parent);
            }
        }

        return new Tree<int>(nodes[0]);
    }
}