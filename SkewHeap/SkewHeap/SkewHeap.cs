namespace SkewHeap.SkewHeap
{
	using global::SkewHeap.Data;

	public class SkewHeap<T> where T : IComparable<T>
	{
		private SkewHeapNode<T>? root;

        public SkewHeap(T value)
        {
            this.root = new SkewHeapNode<T>(value);            
        }
    }
}
