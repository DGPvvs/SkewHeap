namespace SkewHeap
{
	using global::SkewHeap.GlobalConst;
	using global::SkewHeap.SkewHeap;

	internal class SkewHeapMain
	{
		static void Main(string[] args)
		{
			SkewHeap<int> heap = new SkewHeap<int>(0);
			Console.WriteLine($"Heap ");
			heap.Inorder(heap.Root, " ");
			Console.WriteLine();
			Console.WriteLine($"Heap Root {heap.Root.Value}");

			for (int i = 0; i < 50; ++i)
			{
				heap.Add(i % 8);

				heap.Order = EnumerableEnum.LBR;

				Console.WriteLine($"Heap {heap.Order.ToString()}");
				heap.Inorder(heap.Root, " ");
				Console.WriteLine();
				Console.WriteLine($"Heap Root {heap.Root.Value}");
			}


			heap.ForeOrder = EnumerableEnum.BFS;
			Console.WriteLine(string.Join(" ", heap));

			heap.ForeOrder = EnumerableEnum.DFS;

			Console.WriteLine(string.Join(" ", heap));

			while (heap.Count > 0)
			{
				Console.WriteLine($"Delete {heap.Min}");
				heap.Delete();
				heap.Inorder(heap.Root, " ");
				Console.WriteLine();
				Console.WriteLine($"Heap Root {(heap.Root != null ? heap.Root.Value.ToString() : "")}");
			}
		}
	}
}
