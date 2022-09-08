using System.Diagnostics;

namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList sll = new SinglyLinkedList();
            sll.Add(5);
            sll.Add(7);
            sll.Add(91);
            sll.Add(734);
            sll.Add(32);
            sll.Add(6);
            sll.Add(87);
            sll.Add(0);
            sll.Add(2);
            sll.RemoveAt(3);
            sll.PrintValues();
            Console.WriteLine(sll.Find(36).data);
            // sll.Remove();
            // sll.Remove();
            sll.PrintValues();
        }
    }

    public class SLLNode
    {
        public int data;
        public SLLNode? Next;
        public SLLNode(int value = 0, SLLNode? next = null){
            this.data = value;
            this.Next = next;
        }
    }

    public class SinglyLinkedList
    {
        public SLLNode? Head;
        public SinglyLinkedList()
        {
            this.Head = null;
        }

        public void Add(int value)
        {
            SLLNode newNode = new SLLNode(value);
            if(Head == null)
            {
                Head = newNode;
            }
            else
            {
                SLLNode runner = Head;
                while(runner.Next != null) {
                    runner = runner.Next;
                }
                runner.Next = newNode;
            }
        }

        public void PrintValues()
        {
            if(Head == null)
            {
                return;
            }
            SLLNode? runner = Head;
            while(runner.Next != null)
            {
                Console.WriteLine($"The value is :{runner.data} ");
                runner = runner.Next;
            }
            return;
        }

        public void Remove()
        {
            if(Head == null)
            {
                return;
            }
            SLLNode? runner = Head;
            SLLNode? prevNode = runner;
            while(runner.Next != null)
            {
                prevNode = runner;
                runner = runner.Next;
            }
            prevNode.Next = null;
        }

        public SLLNode? Find(int val)
        {
            if(Head == null)
            {
                Console.WriteLine($"List Doesn't Exist Creating with value : {val}");
                return new SLLNode(val);
            }
            SLLNode? runner = Head;
            while(runner.Next != null)
            {
                if(runner.data == val)
                {
                    return runner;
                }
                runner = runner.Next;
            }
            SLLNode? newNode = new SLLNode(val);
            runner.Next = newNode;
            return newNode;
        }

        public void RemoveAt(int val)
        {
            if(Head == null) 
                {
                    Console.WriteLine("No list");
                    return;
                }
                SLLNode? runner = Head;
                SLLNode? prevNode = runner;
                int count = 0;
                while(count < val - 1)
                {
                    prevNode = runner;
                    count++;
                    runner = runner?.Next;
                }
                prevNode.Next = runner.Next;
        }
    }
}