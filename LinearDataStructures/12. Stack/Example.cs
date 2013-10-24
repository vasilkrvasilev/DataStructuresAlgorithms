using System;

public class Example
{
    public static void Main()
    {
        // Create ResizedStack and test its methods
        ResizedStack<string> stack = new ResizedStack<string>();
        stack.Push("a");
        stack.Push("b");
        stack.Push("c");
        stack.Push("d");
        stack.Push("e");
        string lastElement = stack.Pop();
        string newLastElement = stack.Peek();
        int count = stack.Count;
        bool hasElement = stack.Contains("z");
        string[] array = stack.ToArray();
        stack.Clear();
    }
}