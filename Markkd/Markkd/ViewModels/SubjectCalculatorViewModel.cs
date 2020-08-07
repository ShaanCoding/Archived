using Markkd.Models;
using Markkd.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markkd.ViewModels
{
    public class SubjectCalculatorViewModel
    {
        public SubjectCalculatorModel subjectsModel { get; set; }
        public SimpleCommand simpleCommand { get; set; }

        public SubjectCalculatorViewModel()
        {
            subjectsModel = new SubjectCalculatorModel();
            this.simpleCommand = new SimpleCommand(this);
        }

        public void CalculateButton()
        {
            this.subjectsModel.CalculateSubjectMarks();
            this.subjectsModel.CalculateWAM();
        }
    }
}
