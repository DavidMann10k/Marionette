using System.Collections.Generic;

namespace Marionette.Indexing {
	public class Cell<T> {
		LinkedList<T> items;

		public Cell() {
			items = new LinkedList<T> ();
		}

		public void Add(T item) {
			items.AddFirst(item);
		}

		public void Remove(T item) {
			items.Remove(item);
		}
	}
}

