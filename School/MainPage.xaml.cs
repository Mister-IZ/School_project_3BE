using School.Views;

namespace School;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		var teacherPageButton = new Button { Text = "Créer Enseignant" };
        teacherPageButton.Clicked += (sender, e) => Navigation.PushAsync(new TeacherPage());

        var activitePageButton = new Button { Text = "Créer Activité" };
        // Ajoutez un événement similaire pour la page de création d'activités

        var etudiantPageButton = new Button { Text = "Créer Étudiant" };
        // Ajoutez un événement similaire pour la page de création d'étudiants

        Content = new StackLayout
        {
            Children = { teacherPageButton, activitePageButton, etudiantPageButton }
        };
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

