using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Monoflector.Data
{
    /// <summary>
    /// Represents a collection of <see cref="IModelObject"/>s.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    public interface IModelCollection<T> : IList<T>, IModelObject, INotifyCollectionChanged
        where T : class, IModelObject
    {

    }
}
