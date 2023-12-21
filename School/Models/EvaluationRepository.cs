public class EvaluationRepository
{
    public void SaveEvaluation(EvaluationModel evaluation)
    {
        string filePath = "evaluations.txt";
        string evaluationLine = $"{evaluation.Course}, {evaluation.Student}, {evaluation.Note}, {evaluation.Appreciation}";

        File.AppendAllText(filePath, evaluationLine + Environment.NewLine);
    }

    public List<EvaluationModel> GetGradesByStudent(string studentName)
    {
        string filePath = "evaluations.txt";
        var grades = new List<EvaluationModel>();

        try
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var data = line.Split(',');

                    if (data.Length >= 2 && data[1].Trim() == studentName)
                    {
                        var grade = new EvaluationModel
                        {
                            Course = data[0].Trim(),
                            Student = data[1].Trim(),
                            Note = data.Length > 2 ? data[2].Trim() : string.Empty,
                            Appreciation = data.Length > 3 ? data[3].Trim() : string.Empty
                        };

                        grades.Add(grade);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la lecture des évaluations : {ex.Message}");
        }

        return grades;
    }
    // public double GetAverageGradeByStudent(string studentName)
    // {
    //     var grades = GetGradesByStudent(studentName);
    //     if (grades.Count > 0)
    //     {
    //         double total = grades.Sum(grade => grade.Note);
    //         return total / grades.Count;
    //     }
    //     return 0; // Ou une valeur par défaut si l'étudiant n'a pas de notes
    // }

}
