using System;

namespace LinkedListDay14
{
    public class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class SortedLinkedList<T> where T : IComparable<T>
    {
        public Node<T> Head { get; set; }
        public int Size { get; private set; }

        public SortedLinkedList()
        {
            Head = null;
            Size = 0;
        }

        public void AddNode(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (Head == null || data.CompareTo(Head.Data) < 0)
            {
                newNode.Next = Head;
                Head = newNode;
            }
            else
            {
                Node<T> current = Head;

                while (current.Next != null && data.CompareTo(current.Next.Data) >= 0)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
            }

            Size++;
        }

        public void Display()
        {
            Node<T> current = Head;

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

            SortedLinkedList<int> sortedLinkedList = new SortedLinkedList<int>();

            sortedLinkedList.AddNode(56);
            sortedLinkedList.AddNode(30);
            sortedLinkedList.AddNode(40);
            sortedLinkedList.AddNode(70);

            sortedLinkedList.Display();
        }
    }
}
