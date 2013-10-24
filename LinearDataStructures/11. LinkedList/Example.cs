using System;

public class Example
{
    public static void Main()
    {
        // Create LinkedList and test its methods
        ListItem<int> lastElement = new ListItem<int>(5);
        LinkedList<int> linkedList = new LinkedList<int>(lastElement);
        ListItem<int> middleElement = new ListItem<int>(2);
        linkedList.Add(middleElement);
        ListItem<int> firstElement = new ListItem<int>(-3);
        linkedList.Add(firstElement);
        bool contains = linkedList.Contains(firstElement);
        linkedList.Remove(middleElement);
        int index = linkedList.IndexOf(lastElement);
        int count = linkedList.Count();
        ListItem<int> element = linkedList[index];
        bool isSame = lastElement == element;
    }
}