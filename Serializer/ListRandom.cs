using System.Collections.Generic;
using System.IO;

namespace Serializer
{

    internal class ListRandom
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public ListRandom() { }

        public ListRandom(ListNode Head, ListNode Tail, int count)
        {
            this.Head = Head;
            this.Tail = Tail;
            this.Count = count;
        }

        public void Serialize(Stream s)
        {
            System.Console.WriteLine("Serialize\n");

            List<ListNode> nodes = new List<ListNode>();
            ListNode tmp = Head;

            while (tmp != null)
            {
                nodes.Add(tmp);
                tmp = tmp.Next;
            }

            using (StreamWriter writer = new StreamWriter(s))
            {
                foreach (var node in nodes)
                {
                    writer.WriteLine($"{node.Data}:{nodes.IndexOf(node.Random)}");

                }
            }
        }

        public void Deserialize(Stream s)
        {
            System.Console.WriteLine("Deserialize\n");

            List<ListNode> nodes = new List<ListNode>();
            ListNode tmpNode = new ListNode();
            Count = 0;
            Head = tmpNode;
            string line;


            using (StreamReader reader = new StreamReader(s))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.Equals(""))
                    {
                        Count++;
                        tmpNode.Data = line;
                        tmpNode.Next = new ListNode();
                        nodes.Add(tmpNode);

                        tmpNode.Next.Previous = tmpNode;
                        tmpNode = tmpNode.Next;
                    }

                }
            }

            Tail = tmpNode.Previous;
            Tail.Next = null;

            foreach (var node in nodes)
            {
                node.Random = nodes[int.Parse(node.Data.Split(':')[1])];
                node.Data = node.Data.Split(':')[0];
            }
        }
    }
}