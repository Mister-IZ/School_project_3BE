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
            if (string.IsNullOrWhiteSpace(coursefirstname.Text) || string.IsNullOrWhiteSpace(courselastname.Text))
            {
                DisplayAlert("Erreur", "Veuillez saisir le prénom et le nom de l'étudiant.", "OK");
                return;
            }

            var studentModel = new StudentModel
            {
                firstname = coursefirstname.Text,
                lastname = courselastname.Text,
            };

            var studentRepository = new StudentRepository();
            studentRepository.SaveStudents(studentModel);

            Navigation.PushAsync(new StudentPage());
        }

        private void OnReturnToMainPageClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
