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

    if (File.Exists(filePath))
    {
        var evaluationLines = File.ReadAllLines(filePath);

        var grades = evaluationLines
            .Select(line =>
            {
                var evaluationData = line.Split(',');
                return new EvaluationModel
                {
                    Course = evaluationData.Length > 0 ? evaluationData[0].Trim() : string.Empty,
                    Student = evaluationData.Length > 1 ? evaluationData[1].Trim() : string.Empty,
                    Note = evaluationData.Length > 2 ? evaluationData[2].Trim() : string.Empty,
                    Appreciation = evaluationData.Length > 3 ? evaluationData[3].Trim() : string.Empty
                };
            })
            .Where(evaluation => evaluation.Student.Equals(studentName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return grades;
    }

    return new List<EvaluationModel>();
}

}
 