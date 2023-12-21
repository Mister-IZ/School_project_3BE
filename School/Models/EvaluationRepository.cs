public class EvaluationRepository
{
    public void SaveEvaluation(EvaluationModel evaluation)
    {
        string filePath = "evaluations.txt";
        string evaluationLine = $"{evaluation.Course}, {evaluation.Student}, {evaluation.Note}, {evaluation.Appreciation}";

        File.AppendAllText(filePath, evaluationLine + Environment.NewLine);
    }
}