using School.Views;

namespace School
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
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

        private void OnTeacherPageButtonClicked(object sender, EventArgs e)
        {
            // Ajoutez le code ici pour gérer le clic sur le bouton "Créer Enseignant"
            // Par exemple, vous pouvez naviguer vers la page des enseignants comme vous l'avez fait pour le bouton Counter.
            Navigation.PushAsync(new TeacherPage());
        }


			private void OnActivityPageButtonClicked(object sender, EventArgs e)
        {
            // Ajoutez le code ici pour gérer le clic sur le bouton "Créer Enseignant"
            // Par exemple, vous pouvez naviguer vers la page des enseignants comme vous l'avez fait pour le bouton Counter.
            Navigation.PushAsync(new ActivityPage());
        }

		    private void OnStudentPageButtonClicked(object sender, EventArgs e)
        {
            // Ajoutez le code ici pour gérer le clic sur le bouton "Créer Enseignant"
            // Par exemple, vous pouvez naviguer vers la page des enseignants comme vous l'avez fait pour le bouton Counter.
            Navigation.PushAsync(new StudentPage());
        }
    }
}


