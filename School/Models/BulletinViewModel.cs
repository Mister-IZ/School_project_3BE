using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace School.Views
{
    public class BulletinViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<EvaluationModel> grades;
        private double average;

        public ObservableCollection<EvaluationModel> Grades
        {
            get { return grades; }
            set
            {
                grades = value;
                OnPropertyChanged(nameof(Grades));
            }
        }

        public double Average
        {
            get { return average; }
            set
            {
                average = value;
                OnPropertyChanged(nameof(Average));
            }
        }

        public BulletinViewModel()
        {
            Grades = new ObservableCollection<EvaluationModel>();
        }

        public void LoadGradesForStudent(string studentName)
        {
            var evaluationRepository = new EvaluationRepository();
            var grades = evaluationRepository.GetGradesByStudent(studentName);
            Grades.Clear();

            double totalScore = 0;
            int count = 0;

            foreach (var grade in grades)
            {
                Grades.Add(grade);

                if (grade.Note != null && double.TryParse(grade.Note, out double score))
                {
                    if (score >= 0)
                    {
                        score = score * 20 / 20;

                        totalScore += score;
                        count++;
                    }
                }
            }

            if (count > 0)
            {
                Average = totalScore / (count + 1);
            }
            else
            {
                Average = 0;
            }
        }

        public void AddGrade(EvaluationModel grade)
        {
            Grades.Add(grade);

            if (double.TryParse(grade.Note, out double score))
            {
                
                Average = (Average * (Grades.Count - 1) + score) / Grades.Count;
            }
        }





        public void ClearGrades()
        {
            Grades.Clear();
            Average = 0; 
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

