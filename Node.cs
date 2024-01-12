using System;

namespace MyCustomDataStructure
{
    //Data struct to store custom data in the Node class
    struct Data
    {
        public string name;

        //Data constructor
        public Data(string name)
        {
            this.name = name;
        }
    }

    //Generic Node class to store data as a singly linked list
    class Node<T> where T : struct
    {
        //Data
        public T data;

        //Link
        public Node<T>? next;

        //Static properties
        public static int Size { get; private set; }
        public static Node<T>? Head { get; private set; }

        //Node constructor
        public Node(T data, Node<T>? nextNode)
        {
            this.data = data;
            next = nextNode;
        }

        //Creates a new node with null link
        public static Node<T> Create(T data)
        {
            Node<T>? newNode = new Node<T>(data, null);
            if (Size == 0)
            {
                Node<T>.Head = newNode;
            }
            Size++;
            return newNode;
        }

        //Finds the end of the linked list
        public static Node<T>? FindEnd()
        {
            Node<T>? startNode;
            if (Head == null)
            {
                return null;
            }
            startNode = Head;
            while (startNode.next != null)
            {
                startNode = startNode.next;
            }

            return startNode;
        }

        //Inserts a new node at the beginning
        public static void InsertAtStart(Node<T> newNode)
        {
            if(Head != null)
            {
                newNode.next = Head;
            }
            Head = newNode;
        }

        //Inserts a new node at the end
        public static void InsertAtEnd(Node<T> newNode)
        {
            Node<T>? endNode = FindEnd();
            if (endNode == null)
            {
                Create(newNode.data);
            }
            else
            {
                endNode.next = newNode;
            }
        }

        //Inserts a new node after a specific node
        public static void InsertAfter(int nthNode, Node<T> newNode)
        {
            Node<T>? refNode = Head;
            
            if(refNode ==  null)
            {
                Create(newNode.data);
                return;
            }
            if(FindNode(nthNode, out refNode))
            {
                newNode.next = refNode?.next;
                refNode.next = newNode;
            }
        }

        //Finds nth node
        public static bool FindNode(int nthNode, out Node<T>? node)
        {
            if (nthNode > Size - 1)
            {
                node = FindEnd();
                return false;
            }
            else
            {
                Node<T>? refNode = Head;
                while (nthNode > 0)
                {
                    refNode = refNode?.next;
                    nthNode--;
                }
                node =  refNode;
                return true;
            }
        }
    }
}
