namespace SkewHeap.Data
{
	public class SkewHeapNode<T> where T : IComparable<T>
	{
		private T? value;
		private SkewHeapNode<T>? parentNode;
		private SkewHeapNode<T>? leftNode;
		private SkewHeapNode<T>? rightNode;

        public SkewHeapNode(T value)
        {
			this.Value = value;
			this.ParentNode = null;
			this.LeftNode = null;
            this.RightNode = null;
        }

		public T? Value
		{
			get => value;
			set => this.value = value;
		}

		public SkewHeapNode<T>? ParentNode
		{
			get => parentNode;
			set => parentNode = value;
		}

		public SkewHeapNode<T>? LeftNode
		{
			get => leftNode;
			set => leftNode = value;
		}

		public SkewHeapNode<T>? RightNode
		{
			get => rightNode;
			set => rightNode = value;
		}
	}
}
