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

                // Assurez-vous que la colonne des notes existe et n'est pas vide
                if (grade.Note != null && double.TryParse(grade.Note, out double score))
                {
                    // Vérifiez si la note est valide (supérieure à zéro)
                    if (score >= 0)
                    {
                        // Ajustez la note en fonction de l'échelle (20 points dans ce cas)
                        score = score * 20 / 20;

                        totalScore += score;
                        count++;
                    }
                }
            }

            // Calculez la moyenne
            if (count > 0)
            {
                // Utilisez (count + 1) comme dénominateur pour compenser l'ajout de 1 dans AddGrade
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

            // Mettez à jour la moyenne en ajoutant la nouvelle note
            if (double.TryParse(grade.Note, out double score))
            {
                // Utilisez (Grades.Count - 1) comme dénominateur pour compenser l'ajout de 1
                Average = (Average * (Grades.Count - 1) + score) / Grades.Count;
            }
        }





        public void ClearGrades()
        {
            Grades.Clear();
            Average = 0; // Assurez-vous de réinitialiser la moyenne lorsque vous effacez les notes
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

