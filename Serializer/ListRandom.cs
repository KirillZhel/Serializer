using System.Collections.Generic;
using System.IO;

namespace Serializer
{

    internal class ListRandom
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public ListRandom() {}

        public ListRandom(ListNode Head, ListNode Tail, int count)
        {
        this.Head = Head;
        this.Tail = Tail;
        this.Count = count;
        }

        public void Serialize(Stream s)
        {
            System.Console.WriteLine("Serialize\n");

            using (BinaryWriter writer = new BinaryWriter(s))
            {
                ListNode nodeTmp = Head;

                for (int i = Count - 1; i >= 0; i--)
                {
                    writer.Write(nodeTmp.Data);
                    writer.Write(nodeTmp.Index);
                    writer.Write(nodeTmp.RandomIndex);
                    nodeTmp = nodeTmp.Next;
                }
            }
        }

        public void Deserialize(Stream s)
        {
            System.Console.WriteLine("Deserialize\n");

            List<ListNode> listTmp = new List<ListNode>();

            using (BinaryReader reader = new BinaryReader(s))
            {
                while (reader.PeekChar() > -1)
                {
                    string data = reader.ReadString();
                    int index = reader.ReadInt32();
                    int randomIndex = reader.ReadInt32();
                    
                    listTmp.Add(new ListNode(data, index, randomIndex));
                }
            }

            Head = listTmp[0];
            Tail = listTmp[listTmp.Count - 1];
            int randomIndexTmp;

            for (int i = 1; i < listTmp.Count; i++)
            {
                listTmp[i - 1].Next = listTmp[i];
                listTmp[i].Previous = listTmp[i - 1];
            }

            foreach (var node in listTmp)
            {
                randomIndexTmp = node.RandomIndex;
                node.Random = randomIndexTmp > 0 ? listTmp[randomIndexTmp] : null;
            }
        }
    }
}
