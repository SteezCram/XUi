using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XUi
{
    internal class RelayCommand : ICommand
    {
        #region Public Events

        /// <summary>
        /// Event fired when <see cref="CanExecute(object)"/> has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Private Members

        private Action _action;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayCommand(Action action) => _action = action;

        #endregion

        #region Public Methods

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) => _action();

        #endregion
    }
}
