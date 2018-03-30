using System;
using System.Windows.Input;

namespace StudentSolution
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        #region Campos...
        readonly Action<Object> _execute;
        readonly Predicate<Object> _canExecute;

        #endregion

        #region Constructor...
        public RelayCommand(Action execute, Func<Boolean> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = z => execute();
            _canExecute = z => canExecute();
        }
        #endregion

        #region Métodos públicos...
        public bool CanExecute(Object parameter) => _canExecute(null);
        public void Execute(Object parameter)
        {
            _execute(parameter);
            RaiseCanExecuteChanged();
        }
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        #endregion
        
    }
}