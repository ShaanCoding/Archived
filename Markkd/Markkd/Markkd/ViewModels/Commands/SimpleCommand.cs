using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Markkd.ViewModels.Commands
{
    public class SimpleCommand : ICommand
    {
        public SubjectCalculatorViewModel viewModel { get; set; }

        public SimpleCommand(SubjectCalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string stringParameter = (string)parameter;
            if(stringParameter == "CalculateWAM")
            {
                this.viewModel.CalculateButton();
            }
        }
    }
}
