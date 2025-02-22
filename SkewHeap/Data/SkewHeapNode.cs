namespace SkewHeap.Data
{
	internal class SkewHeapNode<T> where T : IComparable<T>
	{
		private T? value;
		private SkewHeapNode<T>? parentNode;
		private SkewHeapNode<T>? LeftNode;
		private SkewHeapNode<T>? RightNode;

        public SkewHeapNode(T value)
        {
			this.value = value;
			this.parentNode = null;
			this.LeftNode = null;
            this.RightNode = null;
        }
    }
}
