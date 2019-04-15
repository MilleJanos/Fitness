namespace Fitness.Common.MVVM
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Relay command with parameter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class RelayCommand<T> : ICommand
    {
        /// <summary>
        /// The execute action
        /// </summary>
        private Action<T> executeAction;

        /// <summary>
        /// The can execute function
        /// </summary>
        private Func<bool> canExecuteFunc;

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        public RelayCommand(Action<T> execute, Func<bool> canExecute = null)
        {
            this.ExecuteAction = execute;
            this.CanExecuteFunc = canExecute;
        }

        /// <summary>
        /// Gets or sets the execute action.
        /// </summary>
        /// <value>
        /// The execute action.
        /// </value>
        public Action<T> ExecuteAction
        {
            get
            {
                return this.executeAction;
            }

            set
            {
                this.executeAction = value;
            }
        }

        /// <summary>
        /// Gets or sets the can execute function.
        /// </summary>
        /// <value>
        /// The can execute function.
        /// </value>
        public Func<bool> CanExecuteFunc
        {
            get
            {
                return this.canExecuteFunc;
            }

            set
            {
                this.canExecuteFunc = value;
            }
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc != null)
            {
                return this.CanExecuteFunc.Invoke();
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (this.ExecuteAction != null)
            {
                if (parameter is T)
                {
                    this.ExecuteAction.Invoke((T)parameter);
                }
                else
                {
                    this.ExecuteAction.Invoke(default(T));
                }
            }
        }
    }

    /// <summary>
    /// Relay command
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The execute action
        /// </summary>
        private Action executeAction;

        /// <summary>
        /// The can execute function
        /// </summary>
        private Func<bool> canExecuteFunc;

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.ExecuteAction = execute;
            this.CanExecuteFunc = canExecute;
        }

        /// <summary>
        /// Gets or sets the execute action.
        /// </summary>
        /// <value>
        /// The execute action.
        /// </value>
        public Action ExecuteAction
        {
            get
            {
                return this.executeAction;
            }

            set
            {
                this.executeAction = value;
            }
        }

        /// <summary>
        /// Gets or sets the can execute function.
        /// </summary>
        /// <value>
        /// The can execute function.
        /// </value>
        public Func<bool> CanExecuteFunc
        {
            get
            {
                return this.canExecuteFunc;
            }

            set
            {
                this.canExecuteFunc = value;
            }
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc != null)
            {
                return this.CanExecuteFunc.Invoke();
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (this.ExecuteAction != null)
            {
                this.ExecuteAction.Invoke();
            }
        }
    }
}
