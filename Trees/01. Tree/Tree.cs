using System;
using System.Collections.Generic;

public class Tree<T>
{
    private TreeNode<T> root;

    public Tree(TreeNode<T> root)
    {
        this.Root = root;
    }

    /// <summary>
    /// Root of the tree
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If try to create tree with root equal to null</exception>
    public TreeNode<T> Root
    {
        get { return this.root; }
        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Invalid input! The tree root cannot be null.");
            }

            this.root = value;
        }
    }

    /// <summary>
    /// Find all leave nodes in the tree
    /// </summary>
    /// <remarks>Leave node is node with parent and no children</remarks>
    /// <returns>Collection (List) of all found tree nodes</returns>
    public List<TreeNode<T>> FindLeaves()
    {
        List<TreeNode<T>> leaves = new List<TreeNode<T>>();
        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
        stack.Push(this.Root);
        while (stack.Count > 0)
        {
            TreeNode<T> current = stack.Pop();
            if (current.Children.Count == 0)
            {
                leaves.Add(current);
            }

            foreach (var node in current.Children)
            {
                stack.Push(node);
            }
        }

        return leaves;
    }

    /// <summary>
    /// Find all middle nodes in the tree
    /// </summary>
    /// <remarks>Middle node is node with parent and children</remarks>
    /// <returns>Collection (List) of all found tree nodes</returns>
    public List<TreeNode<T>> FindMiddle()
    {
        List<TreeNode<T>> middle = new List<TreeNode<T>>();
        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
        stack.Push(this.Root);
        while (stack.Count > 0)
        {
            TreeNode<T> current = stack.Pop();
            if (current.Children.Count > 0 && current.Parent != null)
            {
                middle.Add(current);
            }

            foreach (var node in current.Children)
            {
                stack.Push(node);
            }
        }

        return middle;
    }

    /// <summary>
    /// Find node of the tree with max depth
    /// (distance from the root of the tree)
    /// </summary>
    /// <returns>Depth of found node</returns>
    public int FindMaxPath()
    {
        SetDepth();
        int maxPath = 0;
        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
        stack.Push(this.Root);
        while (stack.Count > 0)
        {
            TreeNode<T> current = stack.Pop();
            if (current.Depth > maxPath)
            {
                maxPath = current.Depth;
            }

            foreach (var node in current.Children)
            {
                stack.Push(node);
            }
        }

        return maxPath;
    }

    /// <summary>
    /// Calculate value and set Depth property of each node in the tree
    /// </summary>
    /// <remarks>Distance from the root of the tree</remarks>
    private void SetDepth()
    {
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(this.Root);
        while (queue.Count > 0)
        {
            TreeNode<T> current = queue.Dequeue();
            int depth = current.Depth + 1;
            foreach (var node in current.Children)
            {
                node.Depth = depth;
                queue.Enqueue(node);
            }
        }
    }

    /// <summary>
    /// Find all paths, which sum is equal to given sum
    /// </summary>
    /// <remarks>Each path is a subtree, 
    /// so its sum is equal to the sum of this subtree</remarks>
    /// <param name="sum">The sum is looked for</param>
    /// <returns>Collection (List) of all found paths</returns>
    public List<TreeNode<T>> FindPathWithSum(int sum)
    {
        List<Tree<T>> paths = ExtractPaths();
        List<TreeNode<T>> pathList = new List<TreeNode<T>>();
        foreach (var path in paths)
        {
            SetSum(path.Root);
            List<TreeNode<T>> nodeList = new List<TreeNode<T>>();
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(path.Root);
            while (stack.Count > 0)
            {
                TreeNode<T> current = stack.Pop();
                if (current.Sum == sum)
                {
                    nodeList.Add(current);
                }

                foreach (var node in current.Children)
                {
                    stack.Push(node);
                }
            }

            pathList.AddRange(nodeList);
        }

        return pathList;
    }

    /// <summary>
    /// Extracts all subtrees with last node leave of the tree
    /// </summary>
    /// <remarks>Each node has only one child, leaves - zero</remarks>
    /// <returns>Collection (List) of all found paths</returns>
    private List<Tree<T>> ExtractPaths()
    {
        List<Tree<T>> paths = new List<Tree<T>>();
        List<TreeNode<T>> leaves = FindLeaves();
        foreach (var leave in leaves)
        {
            TreeNode<T> currentNode = leave;
            TreeNode<T> parentNode = leave.Parent;
            while (parentNode != null)
            {
                TreeNode<T> newNode = new TreeNode<T>(leave.Parent.Value);
                newNode.AddChild(currentNode);
                currentNode = newNode;
                parentNode = parentNode.Parent;
            }

            Tree<T> path = new Tree<T>(currentNode);
            paths.Add(path);
        }

        return paths;
    }

    /// <summary>
    /// Calculate value and set Sum property of each node in the tree
    /// </summary>
    /// <remarks>It is the sum of the value of current node 
    /// and values of all its descendants</remarks>
    /// <param name="node">Current node</param>
    /// <returns>Value of Sum property of the current node</returns>
    private int SetSum(TreeNode<T> node)
    {
        int childrenSum = 0;
        if (node.Children.Count > 0)
        {
            foreach (var child in node.Children)
            {
                childrenSum += SetSum(child);
            }
        }

        int sum = (dynamic)node.Value + childrenSum;
        node.Sum = sum;
        return sum;
    }

    /// <summary>
    /// Find all subtrees, which sum is equal to given sum
    /// </summary>
    /// <remarks>Each tree node is a subtree, 
    /// so subtree's sum is equal to the sum of this tree node</remarks>
    /// <param name="sum">The sum is looked for</param>
    /// <returns>Collection (List) of all found tree nodes</returns>
    public List<TreeNode<T>> FindSubtreeWithSum(int sum)
    {
        SetSum(this.Root);
        List<TreeNode<T>> nodeList = new List<TreeNode<T>>();
        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
        stack.Push(this.Root);
        while (stack.Count > 0)
        {
            TreeNode<T> current = stack.Pop();
            if (current.Sum == sum)
            {
                nodeList.Add(current);
            }

            foreach (var node in current.Children)
            {
                stack.Push(node);
            }
        }

        return nodeList;
    }
}