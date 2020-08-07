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
        public SubjectCalculatorModel subjectModel { get; set; }
        public SimpleCommand simpleCommand { get; set; }

        public SubjectCalculatorViewModel()
        {
            subjectModel = new SubjectCalculatorModel();
            this.simpleCommand = new SimpleCommand(this);
        }

        public void CalculateButton()
        {
            this.subjectModel.CalculateSubjectMarks();
            this.subjectModel.CalculateWAM();
        }
    }
}
