using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;

namespace Monoflector.Data
{
    /// <summary>
    /// Represents a model object.
    /// </summary>
    public class ModelObject : IModelObject
    {
        #region - UI Members -
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the validation errors for a specified property or for the entire object.
        /// </summary>
        /// <param name="propertyName">The name of the property to retrieve validation errors for, or null or <see cref="F:System.String.Empty"/> to retrieve errors for the entire object.</param>
        /// <returns>
        /// The validation errors for the property or object.
        /// </returns>
        public string GetError(string propertyName)
        {
            if (propertyName == null)
            {
                if (_errors.Count == 0)
                    return null;
                else if (_errors.Count == 1)
                    return _errors.Values.First();
                else
                    return Properties.Resources.MultipleErrors;
            }
            else
            {
                string errs;
                if (_errors.TryGetValue(propertyName, out errs))
                {
                    if (!string.IsNullOrEmpty(errs))
                    {
                        return errs;
                    }
                    else
                    {
                        _errors.Remove(propertyName);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public string Error
        {
            get
            {
                return GetError(null);
            }
        }

        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <returns>The error message for the property. The default is an empty string ("").</returns>
        public string this[string columnName]
        {
            get
            {
                return GetError(columnName);
            }
        }
        #endregion

        /// <summary>
        /// The errors.
        /// </summary>
        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        #region - Ctor -
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelObject"/> class.
        /// </summary>
        public ModelObject()
        {

        }
        #endregion

        #region - Property Management -
        /// <summary>
        /// Sets the errors on a property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        protected virtual void SetErrors(string propertyName, string error)
        {
            _errors.Remove(propertyName);
            if (!string.IsNullOrEmpty(error))
                _errors.Add(propertyName, error);
        }

        /// <summary>
        /// Sets a property value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="storage">The storage variable.</param>
        /// <param name="value">The <see langword="value"/> variable.</param>
        protected virtual bool SetPropertyValue<TValue>(string propertyName, ref TValue storage, TValue value)
        {
            var error = ValidatePropertyValue(propertyName, value);
            // Remove errors.
            string old;
            bool removed;
            if (removed = _errors.TryGetValue(propertyName, out old) && old != null && old.Length > 0)
            {
                _errors.Remove(propertyName);
            }

            // Check for equality.
            if (object.ReferenceEquals(storage, value) ||
                (!object.ReferenceEquals(storage, null) && storage.Equals(value)) ||
                (!object.ReferenceEquals(value, null) && value.Equals(storage)))
            {

                // Check errors.
                if (error == null || error.Length == 0)
                {
                    // Do nothing.
                }
                else
                {
                    _errors.Add(propertyName, error);
                }

                return false;
            }


            // Set the value.
            var oldValue = storage;
            storage = value;

            if (error == null || error.Length == 0)
            {
                RaisePropertyChanged(propertyName, oldValue, value);

                return true;
            }
            else
            {
                _errors.Add(propertyName, error);
                RaisePropertyChanged(propertyName, oldValue, value);
                return false;
            }
        }

        /// <summary>
        /// Called when the errors for a property have changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnErrorsChanged(string propertyName)
        {

        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected void RaisePropertyChanged<TValue>(string propertyName, TValue oldValue, TValue newValue)
        {
            OnPropertyChanged(propertyName, oldValue, newValue);
            PropertyChanged.Dispatch(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Called when a property is changed.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected virtual void OnPropertyChanged<TValue>(string propertyName, TValue oldValue, TValue newValue)
        {

        }

        /// <summary>
        /// Validates the property value.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The value.</param>
        /// <returns><see langword="null"/> if the value is valid; otherwise, a error message.</returns>
        protected virtual string ValidatePropertyValue<TValue>(string propertyName, TValue value)
        {
            return null;
        }
        #endregion
    }
}
