using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Monoflector.Data
{
    /// <summary>
    /// Represents the model object implementation.
    /// </summary>
    public interface IModelObject : INotifyPropertyChanged, IDataErrorInfo
    {

    }
}
