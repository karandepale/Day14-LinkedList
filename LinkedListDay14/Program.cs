using System;

namespace LinkedListDay14
{
    public class LinkedList
    {
        public Node Head { get; set; }

        public LinkedList()
        {
            Head = null;
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
        }

        public void Pop()
        {
            if (Head != null)
            {
                Head = Head.Next;
            }
        }

        public void PopLast()
        {
            if (Head == null || Head.Next == null)
            {
                Head = null;
                return;
            }

            Node current = Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            current.Next = null;
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
            linkedList.AddNode(70);

            linkedList.Display();

            int searchKey = 30;
            Node searchResult = linkedList.Search(searchKey);
            if (searchResult != null)
            {
                Console.WriteLine($"Node with key {searchKey} found.");
                linkedList.InsertAfter(searchKey, 40);
                linkedList.Display();
            }
            else
            {
                Console.WriteLine($"Node with key {searchKey} not found.");
            }
        }
    }
}
