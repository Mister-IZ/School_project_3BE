using School.Views;

namespace School
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnTeacherPageButtonClicked(object sender, EventArgs e)
        {
            // Ajoutez le code ici pour gérer le clic sur le bouton "Créer Enseignant"
            // Par exemple, vous pouvez naviguer vers la page des enseignants comme vous l'avez fait pour le bouton Counter.
            Navigation.PushAsync(new TeacherPage2());
        }

			private void OnActivityPageButtonClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new ActivityPage2());
        }

		    private void OnStudentPageButtonClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new StudentPage2());
        }
		    private void OnEvaluationPageButtonClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new EvaluationPage());
        }
        	private void OnColorPageButtonClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new ColorPage());
        }

        private void OnNavigateToEvaluationPageClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EvaluationPage());
        }

    }
}


