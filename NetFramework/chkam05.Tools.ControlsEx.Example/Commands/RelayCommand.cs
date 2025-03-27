using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace chkam05.Tools.ControlsEx.Example.Commands
{
    public class RelayCommand : ICommand
    {

        //  EVENTS

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }


        //  VARIABLES

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> RelayCommand class constructor. </summary>
        /// <param name="execute"> Action to execute. </param>
        /// <param name="canExecute"> Action validating the ability to execute a command. </param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion CONSTRUCTORS

        #region EXECUTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Checks if the command can be executed. </summary>
        /// <param name="parameter"> Command action parameter. </param>
        /// <returns> True - command can be executed; False - otherwise. </returns>
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        //  --------------------------------------------------------------------------------
        /// <summary> Performs command action. </summary>
        /// <param name="parameter"> Command action parameter. </param>
        public void Execute(object parameter) => _execute(parameter);

        #endregion EXECUTION METHODS
    }
}
