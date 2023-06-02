using System;

namespace LinkedListDay14
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public int Size { get; private set; }

        public LinkedList()
        {
            Head = null;
            Size = 0;
        }

        public void AddNode(int data)
        {
            Node newNode = new Node(data);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node current = Head;

                while (current.Next != null && current.Next.Data < data)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
            }

            Size++;
        }

        public void Pop()
        {
            if (Head != null)
            {
                Head = Head.Next;
                Size--;
            }
        }

        public void PopLast()
        {
            if (Head == null || Head.Next == null)
            {
                Head = null;
                Size = 0;
                return;
            }

            Node current = Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            current.Next = null;
            Size--;
        }

        public Node Search(int key)
        {
            Node current = Head;

            while (current != null)
            {
                if (current.Data == key)
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public void InsertAfter(int key, int data)
        {
            Node searchResult = Search(key);

            if (searchResult != null)
            {
                Node newNode = new Node(data);
                newNode.Next = searchResult.Next;
                searchResult.Next = newNode;
                Size++;
            }
        }

        public void DeleteNode(int key)
        {
            if (Head == null)
                return;

            if (Head.Data == key)
            {
                Head = Head.Next;
                Size--;
                return;
            }

            Node current = Head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data == key)
                {
                    previous.Next = current.Next;
                    Size--;
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        public void Display()
        {
            Node current = Head;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linked list program ....");

            LinkedList linkedList = new LinkedList();

            linkedList.AddNode(56);
            linkedList.AddNode(30);
            linkedList.AddNode(40);
            linkedList.AddNode(70);

            linkedList.Display();

            int searchKey = 40;
            Node searchResult = linkedList.Search(searchKey);
            if (searchResult != null)
            {
                Console.WriteLine($"Node with key {searchKey} found.");
                linkedList.DeleteNode(searchKey);
                linkedList.Display();
            }
            else
            {
                Console.WriteLine($"Node with key {searchKey} not found.");
            }

            Console.WriteLine($"Linked List size: {linkedList.Size}");
        }
    }
}
