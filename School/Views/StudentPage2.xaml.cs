namespace School.Views
{
    public partial class StudentPage2 : ContentPage
    {
        public StudentPage2()
        {
            InitializeComponent();
        }

        private void OnCreateStudentClicked(object sender, EventArgs e)
        {
            // Vérifiez si le prénom et le nom sont saisis
            if (string.IsNullOrWhiteSpace(coursefirstname.Text) || string.IsNullOrWhiteSpace(courselastname.Text))
            {
                // Affichez un message d'erreur
                DisplayAlert("Erreur", "Veuillez saisir le prénom et le nom de l'étudiant.", "OK");
                return;
            }

            // Continuez avec la création de l'étudiant
            var studentModel = new StudentModel
            {
                firstname = coursefirstname.Text,
                lastname = courselastname.Text,
                // Vous avez déjà une activité spécifique sélectionnée pour l'étudiant lors de sa création
            };

            var studentRepository = new StudentRepository();
            studentRepository.SaveStudents(studentModel);

            Navigation.PushAsync(new MainPage());
        }

        private void OnReturnToMainPageClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
