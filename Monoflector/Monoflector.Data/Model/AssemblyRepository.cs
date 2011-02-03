using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Monoflector.Data.Model
{
    /// <summary>
    /// Represents a repository of assemblies.
    /// </summary>
    public class AssemblyRepository : ModelCollection<AssemblyData>
    {
        private bool _refreshComplete;
        private Func<IEnumerable<AssemblyData>> _enumerator;
        private ManualResetEvent _refreshPause;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyRepository"/> class.
        /// </summary>
        /// <param name="enumerator">The enumerator.</param>
        public AssemblyRepository(Func<IEnumerable<AssemblyData>> enumerator)
        {
            if (enumerator == null)
                throw new ArgumentNullException("enumerator");
            _enumerator = enumerator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyRepository"/> class.
        /// </summary>
        /// <param name="enumerator">The enumerator.</param>
        public AssemblyRepository(IEnumerable<AssemblyData> enumerator)
            : this(() => enumerator)
        {
            if (enumerator == null)
                throw new ArgumentNullException("enumerator");
        }

        /// <summary>
        /// Resumes the refresh.
        /// </summary>
        public void Resume()
        {
            if (_refreshPause != null)
                _refreshPause.Set();
        }

        /// <summary>
        /// Pauses the refresh.
        /// </summary>
        public void Pause()
        {
            if (_refreshPause != null)
                _refreshPause.Set();
        }

        /// <summary>
        /// Starts a new refresh.
        /// </summary>
        public void Refresh()
        {
            var tmp = _refreshPause;
            _refreshPause = new ManualResetEvent(false);
            Resume();
            if (tmp != null)
            {
                tmp.Reset();
                tmp.Dispose();
            }

            this.Clear();
            var worker = new Action<ManualResetEvent>(Worker);
            worker.BeginInvoke(_refreshPause, EndWorker, worker);
        }

        private void Worker(ManualResetEvent controller)
        {
            foreach (var item in _enumerator())
            {
                if (_refreshPause != controller)
                    break;
                if (_refreshPause == controller)
                    this.Add(item);
                if (_refreshPause == controller)
                    _refreshPause.WaitOne();
                if (_refreshPause != controller)
                    break;
            }
        }

        private void EndWorker(IAsyncResult result)
        {
            try
            {
                ((Action<ManualResetEvent>)result.AsyncState).EndInvoke(result);
            }
            catch
            {

            }
        }
    }
}
