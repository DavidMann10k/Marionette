using System.Collections.Generic;

namespace Marionette.Indexing
{
    public interface IGridItem<T>
    {
        Bounds2D Bounds { get; }

        void OnInsert(Cell<T> cell);
    }
}
