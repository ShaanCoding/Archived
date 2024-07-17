using Markkd.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markkd.Models
{
    public class SubjectCalculatorModel : INotifyPropertyChanged
    {
        private double _wamMark;
        private SubjectClass[] _subjects = new SubjectClass[4];
        private int _totalSubjectPoints = 24;

        public SubjectCalculatorModel()
        {
            for (int i = 0; i < 4; i++)
            {
                _subjects[i] = new SubjectClass("Subject", 0, 6);
            }
        }

        public double WamMark
        {
            get
            {
                return _wamMark;
            }
            set
            {
                _wamMark = value;
                OnPropertyChanged(nameof(WamMark));
            }
        }

        public SubjectClass[] Subjects
        {
            get
            {
                return _subjects;
            }
            set
            {
                _subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

        public int TotalSubjectPoints
        {
            get
            {
                return _totalSubjectPoints;
            }
            set
            {
                _totalSubjectPoints = value;
                OnPropertyChanged(nameof(TotalSubjectPoints));
            }
        }

        public void CalculateSubjectMarks()
        {
            int totalCoursePoints = 0;
            foreach (SubjectClass subject in _subjects)
            {
                if (subject != null)
                {
                    totalCoursePoints += subject.SubjectWeight;
                }
            }
            TotalSubjectPoints = totalCoursePoints;
        }

        public void CalculateWAM()
        {
            double markSum = 0;

            foreach (SubjectClass subject in _subjects)
            {
                if (subject != null)
                {
                    markSum += subject.Mark * ((double)subject.SubjectWeight / (double)TotalSubjectPoints);
                }
            }

            WamMark = markSum;
        }

        #region EventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}