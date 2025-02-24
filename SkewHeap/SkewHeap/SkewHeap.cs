namespace SkewHeap.SkewHeap
{
	using global::SkewHeap.Data;
	using global::SkewHeap.GlobalConst;
	using System.Collections;

	public class SkewHeap<T> : IEnumerable<T> where T : IComparable<T>
	{
		private SkewHeapNode<T>? root;
		private EnumerableEnum order;

		public SkewHeap()
		{
			this.order = EnumerableEnum.LBR;
			this.root = null;
		}

		public SkewHeap(T value) : this()
		{
			this.root = new SkewHeapNode<T>(value);
		}

		public SkewHeap(SkewHeap<T> root) : this()
		{
			this.root = root.root;
		}

		public void Add(T value)
		{
			SkewHeapNode<T> addNode = new SkewHeapNode<T>(value);

			this.root = this.Merge(this.root, addNode);
		}

		public void Add(SkewHeap<T> root)
		{
			this.root = this.Merge(this.root, root.root);
		}

		public SkewHeapNode<T> Construct(IEnumerable<T> colection)
		{

			foreach (var node in colection)
			{
				SkewHeapNode<T> temp = new SkewHeapNode<T>(node);

				this.root = this.Merge(this.root, temp);
			}

			return this.root;
		}

		public SkewHeapNode<T> Merge(SkewHeapNode<T> h1, SkewHeapNode<T> h2)
		{
			// If one of the heaps is empty
			if (h1 == null)
			{
				return h2;
			}

			if (h2 == null)
			{
				return h1;
			}

			// Make sure that h1 has smaller
			// key.
			if (h1.Value?.CompareTo(h2.Value) > 0)
			{
				var temp = h1;
				h1 = h2;
				h2 = temp;
			}

			// Swap h1.left and h1.right
			var temp2 = h1.LeftNode;
			h1.LeftNode = h1.RightNode;
			h1.RightNode = temp2;

			// Merge h2 and h1.left and make
			// merged tree as left of h1.
			h1.LeftNode = this.Merge(h2, h1.LeftNode);

			return h1;
		}

		public void Inorder(SkewHeapNode<T> root)
		{
			if (root == null)
				return;
			else if (this.order == EnumerableEnum.LBR)
			{
				this.Inorder(root.LeftNode);
				Console.Write(root.ToString() + "  ");
				this.Inorder(root.RightNode);
			}
			return;
		}

		public IEnumerator<T> GetEnumerator()
		{
			Stack<SkewHeapNode<T>> stack = new Stack<SkewHeapNode<T>>();

			if (this.root != null)
			{
				stack.Push(this.root);
			}

			while (stack.Count != 0)
			{

			}

			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
	}
}
