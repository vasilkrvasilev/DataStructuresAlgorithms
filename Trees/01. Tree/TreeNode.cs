using System;
using System.Collections;
using System.Collections.Generic;

public class TreeNode<T>
{
    private T value;

    public TreeNode(T value)
    {
        this.Value = value;
        this.Depth = 0;
        this.Parent = null;
        this.Children = new List<TreeNode<T>>();
    }

    /// <summary>
    /// Parent node of this node
    /// </summary>
    public TreeNode<T> Parent { get; private set; }

    /// <summary>
    /// Child nodes of this node
    /// </summary>
    public List<TreeNode<T>> Children { get; private set; }

    /// <summary>
    /// Distance from the most distant predecessor (root of tree)
    /// </summary>
    public int Depth { get; set; }

    /// <summary>
    /// Sum of value of this node and all its descendants
    /// </summary>
    public int Sum { get; set; }

    /// <summary>
    /// Value of this node
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If try to create node with value equal to null</exception>
    public T Value
    {
        get { return this.value; }
        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Invalid input! The node value cannot be null.");
            }

            this.value = value;
        }
    }

    /// <summary>
    /// Add new child of this node
    /// </summary>
    /// <param name="child">Child to add</param>
    /// <exception cref="ArgumentNullException">
    /// If try to add child with value equal to null</exception>
    public void AddChild(TreeNode<T> child)
    {
        if (child == null)
        {
            throw new ArgumentNullException(
                "Invalid input! The node cannot be null.");
        }

        child.Parent = this;
        this.Children.Add(child);
    }

    /// <summary>
    /// Find the descendant of this node with given value 
    /// </summary>
    /// <param name="value">Value of the searched node</param>
    /// <returns>Found node or null if there is no node with such value</returns>
    public TreeNode<T> FindChild(T value)
    {
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(this);
        while (queue.Count > 0)
        {
            TreeNode<T> current = queue.Dequeue();
            if (current.Value.Equals(value))
            {
                return current;
            }

            foreach (var node in current.Children)
            {
                queue.Enqueue(node);
            }
        }

        return null;
    }
}