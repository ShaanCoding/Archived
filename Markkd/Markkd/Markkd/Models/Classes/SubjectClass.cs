using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markkd.Models.Classes
{
    public class SubjectClass
    {
        private string _subjectName;
        private double _mark;
        private int _subjectWeight;

        public SubjectClass(string subjectName, double mark, int subjectWeight)
        {
            SubjectName = subjectName;
            Mark = mark;
            SubjectWeight = subjectWeight;
        }

        public string SubjectName
        {
            get
            {
                return _subjectName;
            }
            set
            {
                _subjectName = value;
            }
        }

        public double Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                _mark = value;
            }
        }

        public int SubjectWeight
        {
            get
            {
                return _subjectWeight;
            }
            set
            {
                _subjectWeight = value;
            }
        }
    }
}
