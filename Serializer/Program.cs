using System;
using System.IO;

namespace Serializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListRandom listRandomToWrite = Init();
            ListRandom listRandomToReading = new ListRandom();

            listRandomToWrite.Serialize(File.Open("listRandom_10.dat", FileMode.OpenOrCreate));
            PrintList(listRandomToWrite);

            listRandomToReading.Deserialize(File.Open("listRandom_10.dat", FileMode.Open));
            PrintList(listRandomToReading);
        }

        //создаём несколько ListNode и создаём из них ListRandom
        static ListRandom Init()
        {
            ListRandom listRandom;

            int count = 5;
            ListNode head = new ListNode();
            ListNode tail = new ListNode();
            ListNode tmpNode = head;
            tail = head;

            for (int i = 0; i < count - 1; i++)
            {
                tail = AddNode(tail, i);
            }

            tail.Random = RandomNode(head, count);
            tail.Data = $"Node-{count - 1}";

            for (int i = 0; i < count; i++)
            {
                tmpNode.Random = RandomNode(head, count);
                tmpNode = tmpNode.Next;
            }

            listRandom = new ListRandom(head, tail, count);
            return listRandom;
        }

        static ListNode AddNode(ListNode previousNode, int i)
        {
            ListNode newNode = new ListNode();
            
            previousNode.Data = $"Node-{i}";
            previousNode.Next = newNode;
            newNode.Previous = previousNode;
            newNode.Next = null;


            //newNode.Previous = previousNode;
            //newNode.Data = $"Node-{i}";
            
            //previousNode.Next = newNode;

            return newNode;
        }

        static ListNode RandomNode(ListNode head, int count)
        {
            ListNode randomNode = head;

            Random random = new Random();
            int jumps = random.Next(0, count);

            int i = 0;
            while(i < jumps)
            {
                randomNode = randomNode.Next;
                i++;
            }

            return randomNode;
        }

        //печать ListRandom данных следующего элемента, предыдущего и случайного
        static void PrintList(ListRandom list)
        {
            ListNode nodeTmp = list.Head;
            while (nodeTmp is not null)
            {
                Console.WriteLine("Data: {0},\nNext node data: {1},\nPrevius node data: {2},\nRandom node data: {3}\n",
                    nodeTmp.Data,
                    nodeTmp.Next is null ? "null" : nodeTmp.Next.Data,
                    nodeTmp.Previous is null ? "null" : nodeTmp.Previous.Data,
                    nodeTmp.Random is null ? "null" : nodeTmp.Random.Data);
                nodeTmp = nodeTmp.Next;
            }
            Console.WriteLine();
        }
    }
}
