using System.Collections.Generic;

namespace Marionette.Indexing {
	public class Cell<T> {
		
		public int ItemCount { get { return items.Count; } }

		HashSet<T> items;

		public Cell() {
			items = new HashSet<T> ();

		}

		public void Add(T item) {
			items.Add(item);
		}

		public void Remove(T item) {
			items.Remove(item);
		}

		public bool Contains(T item) {
			return items.Contains (item);
		}
	}
}

