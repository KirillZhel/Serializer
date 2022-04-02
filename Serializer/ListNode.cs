namespace Serializer
{
    internal class ListNode
    {
        public ListNode Previous;
        public ListNode Next;
        public ListNode Random; // произвольный элемент внутри списка
        public string Data;
        //поля, которые будут использоваться для десериализации
        public static int Indexer = 0;
        public int Index;
        public int RandomIndex;

        public ListNode()
        {
            SetIndex();
        }

        public ListNode (string data, int index, int randomIndex)
        {
            SetIndex();
            Data = data;
            Index = index;
            RandomIndex = randomIndex;
        }

        private void SetIndex()
        {
            Index = Indexer++;
        }
    }
}
