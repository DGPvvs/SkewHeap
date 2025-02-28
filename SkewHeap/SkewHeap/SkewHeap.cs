namespace SkewHeap.SkewHeap
{
	using global::SkewHeap.Data;
	using global::SkewHeap.GlobalConst;
	using System.Collections;
	using System.Text;

	public class SkewHeap<T> : IEnumerable<T?> where T : IComparable<T?>
	{
		private SkewHeapNode<T>? root;
		private EnumerableEnum order;
		private EnumerableEnum foreOrder;

		public SkewHeap()
		{
			this.order = EnumerableEnum.LBR;
			this.foreOrder = EnumerableEnum.BFS;
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

		public SkewHeapNode<T>? Root
		{
			get => this.root;
		}

		public int Count
		{
			get
			{
				int count = 0;
				if (this.root != null)
				{
					foreach (var it in this)
					{
						count++;
					}
				}

				return count;
			}
		}

		public T Min
		{
			get
			{
				if (this.root != null)
				{
					return this.root.Value;
				}
				else
				{
					throw new Exception();
				}
			}
		}

		public EnumerableEnum Order
		{
			get => this.order;
			set => this.order = value;
		}

		public EnumerableEnum ForeOrder
		{
			get => this.foreOrder;
			set => this.foreOrder = value;
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

		public void Add(IEnumerable<T> collection)
		{
			foreach (var node in collection)
			{
				SkewHeapNode<T> temp = new SkewHeapNode<T>(node);

				this.root = this.Merge(this.root, temp);
			}
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

		public T? Delete()
		{
			if (this.Count > 0)
			{
				T? result = this.root.Value;
				this.root = this.Merge(this.root.LeftNode, this.root.RightNode);
				return result;
			}

			return default;
		}

		public void Inorder(SkewHeapNode<T> r, string s, ref StringBuilder sb)
		{
			s = s + "   ";
			if (r == null)
			{
				return;
			}

			if (this.order == EnumerableEnum.LBR)
			{
				this.Inorder(r.RightNode, s, ref sb);
				sb.AppendLine($"{s}{r.Value.ToString()}");
				this.Inorder(r.LeftNode, s, ref sb);
			}
			else if (this.order == EnumerableEnum.BLR)
			{
				sb.AppendLine($"{s}{r.Value.ToString()}");
				this.Inorder(r.LeftNode, s, ref sb);
				this.Inorder(r.RightNode, s, ref sb);
			}
			else if (this.order == EnumerableEnum.LRB)
			{
				this.Inorder(r.LeftNode, s, ref sb);
				this.Inorder(r.RightNode, s, ref sb);
				sb.AppendLine($"{s}{r.Value.ToString()}");
			}

			return;
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (this.root != null)
			{
				SkewHeapNode<T> currentNode = this.root;

				if (this.foreOrder == EnumerableEnum.BFS)
				{
					Queue<SkewHeapNode<T>> q = new Queue<SkewHeapNode<T>>();

					q.Enqueue(currentNode);

					while (q.Count > 0)
					{
						currentNode = q.Dequeue();


						if (currentNode.LeftNode != null)
						{
							q.Enqueue(currentNode.LeftNode);
						}

						if (currentNode.RightNode != null)
						{
							q.Enqueue(currentNode.RightNode);
						}

						yield return currentNode.Value;
					}
				}

				if (this.foreOrder == EnumerableEnum.DFS)
				{
					Stack<SkewHeapNode<T>> q = new Stack<SkewHeapNode<T>>();

					q.Push(currentNode);

					while (q.Count > 0)
					{
						currentNode = q.Pop();

						if (currentNode.LeftNode != null)
						{
							q.Push(currentNode.LeftNode);
						}

						if (currentNode.RightNode != null)
						{
							q.Push(currentNode.RightNode);
						}

						yield return currentNode.Value;
					}
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			this.Inorder(this.root, "", ref stringBuilder);

			return stringBuilder.ToString().TrimEnd();
		}
	}
}
