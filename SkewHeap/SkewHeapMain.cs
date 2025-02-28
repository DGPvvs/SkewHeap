namespace SkewHeap
{
	using global::SkewHeap.GlobalConst;
	using global::SkewHeap.SkewHeap;

	internal class SkewHeapMain
	{
		static void Main(string[] args)
		{
			int count = 5000;
			int factor = 1;
			SkewHeap<int> heap = new SkewHeap<int>(0);
			heap.Order = EnumerableEnum.LBR;
			Console.WriteLine($"Heap ");
            Console.WriteLine(heap);
			Console.WriteLine();
			Console.WriteLine($"Heap Root {heap.Root.Value}");

			for (int i = 0; i < count; ++i)
			{				
				//heap.Add(i + 1);
				factor *= -1;
				//heap.Add(factor * (i + 1));				
				heap.Add(factor);				
			}

			//heap.Order = EnumerableEnum.LBR;

			//Console.WriteLine($"Heap {heap.Order.ToString()}");
			//heap.Inorder(heap.Root, " ");
			//Console.WriteLine();
			//Console.WriteLine($"Heap Root {heap.Root.Value}");


			heap.ForeOrder = EnumerableEnum.BFS;
			Console.WriteLine(string.Join(" ", heap));

			heap.ForeOrder = EnumerableEnum.DFS;

			Console.WriteLine(string.Join(" ", heap));

			Console.WriteLine(heap.Count);

			Console.WriteLine(heap);

			while (heap.Count > 0)
			{
				Console.WriteLine($"Delete {heap.Min}");
				heap.Delete();

				heap.Order = EnumerableEnum.LBR;
				Console.WriteLine(heap);

				heap.ForeOrder = EnumerableEnum.BFS;
				Console.WriteLine(string.Join(" ", heap));

				heap.ForeOrder = EnumerableEnum.DFS;

				Console.WriteLine(string.Join(" ", heap));

				Console.WriteLine(heap.Count);

				Thread.Sleep(3000);
			}

			//Console.WriteLine();
			//Console.WriteLine($"Heap Root {(heap.Root != null ? heap.Root.Value.ToString() : "")}");

			//string s = new string('*', 100);

			//foreach (var i in s)
			//{
			//	Console.WriteLine(i);
			//}
		}
	}
}
