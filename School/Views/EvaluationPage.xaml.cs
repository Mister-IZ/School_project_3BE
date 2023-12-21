namespace School.Views;

public partial class EvaluationPage : ContentPage
{
    public EvaluationPage()
    {
        InitializeComponent();
    }

    private void OnCreateEvaluationClicked(object sender, EventArgs e)
    {
        var evaluationModel = new EvaluationModel
        {
            Course = courseNameEntered.Text,
            Student = studentNameEntered.Text,
            Grade = gradeEntered.Text,
        };

        var evaluationRepository = new EvaluationRepository(); // Assurez-vous de créer cette classe pour gérer le stockage des évaluations
        evaluationRepository.SaveEvaluation(evaluationModel);

        // Ajoutez la logique pour afficher un message de succès ou naviguer vers une autre page si nécessaire
        DisplayAlert("Succès", "Évaluation ajoutée avec succès.", "OK");
    }

    private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}
