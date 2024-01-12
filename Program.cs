using System;
using MyCustomDataStructure;

class Program
{
    public static void Main()
    {
        //Create a data
        Data data1 = new Data();
        data1.name = "Shubham";
        //Creates a node
        Node<Data> node1 = Node<Data>.Create(data1);
        //Creates second node
        Node<Data> node2 = Node<Data>.Create(new Data("Sudhanshu"));

        //Connect first node to second
        node1.next = node2;

        Node<Data>.InsertAfter(0, Node<Data>.Create(new Data("Kush")));
        Node<Data>.InsertAtEnd(Node<Data>.Create(new Data("Raushan")));

        if (Node<Data>.FindNode(2, out Node<Data>? foundNode))
        {
            Console.WriteLine(foundNode?.data.name);
        }

        Console.WriteLine(Node<Data>.Size);
    }
}