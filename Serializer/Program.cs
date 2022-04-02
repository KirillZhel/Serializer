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

            listRandomToWrite.Serialize(File.Open("listRandom_0.dat", FileMode.OpenOrCreate));
            PrintList(listRandomToWrite);
            listRandomToReading.Deserialize(File.Open("listRandom_0.dat", FileMode.Open));
            PrintList(listRandomToReading);
        }

        //создаём несколько ListNode и создаём из них ListRandom
        static ListRandom Init()
        {
            ListNode node_0 = new ListNode();
            ListNode node_1 = new ListNode();
            ListNode node_2 = new ListNode();
            ListNode node_3 = new ListNode();
            ListNode node_4 = new ListNode();

            node_0.Next = node_1;
            node_1.Next = node_2;
            node_2.Next = node_3;
            node_3.Next = node_4;
            node_4.Next = null;

            node_0.Previous = null;
            node_1.Previous = node_0;
            node_2.Previous = node_1;
            node_3.Previous = node_2;
            node_4.Previous = node_3;

            node_0.Random = node_2;
            node_1.Random = node_4;
            node_2.Random = node_1;
            node_3.Random = null;
            node_4.Random = node_3;

            node_0.RandomIndex = node_0.Random.Index;
            node_1.RandomIndex = node_1.Random.Index;
            node_2.RandomIndex = node_2.Random.Index;
            node_3.RandomIndex = node_3.Random is null ? -1 : node_3.Random.Index;
            node_4.RandomIndex = node_4.Random.Index;

            node_0.Data = "node 0";
            node_1.Data = "node 1";
            node_2.Data = "node 2";
            node_3.Data = "node 3";
            node_4.Data = "node 4";

            return new ListRandom(node_0, node_4, 5);
        }

        //печать ListRandom в консоль в прямом порядке, в обратном, в случайном
        static void PrintList(ListRandom list)
        {
            ListNode nodeTmp = list.Head;
            while (nodeTmp is not null)
            {
                Console.WriteLine("Data: {0}, index: {1}, NextIndex: {2}",
                    nodeTmp.Data,
                    nodeTmp.Index,
                    nodeTmp.Next is null ? "null" : nodeTmp.Next.Index);
                nodeTmp = nodeTmp.Next;
            }
            Console.WriteLine();

            nodeTmp = list.Tail;
            while (nodeTmp is not null)
            {
                Console.WriteLine("Data: {0}, index: {1}, PreviousIndex: {2}",
                    nodeTmp.Data,
                    nodeTmp.Index,
                    nodeTmp.Next is null ? "null" : nodeTmp.Next.Index);
                nodeTmp = nodeTmp.Previous;
            }
            Console.WriteLine();

            nodeTmp = list.Head;
            while (nodeTmp is not null)
            {
                Console.WriteLine("Data: {0}, index: {1}, RandomIndex: {2}",
                    nodeTmp.Data,
                    nodeTmp.Index,
                    nodeTmp.Random is null ? "null" : nodeTmp.Random.Index);
                nodeTmp = nodeTmp.Random;
            }
            Console.WriteLine();
        }
    }
}
