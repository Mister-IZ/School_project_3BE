
namespace School.Views;

    public partial class StudentPage2 : ContentPage
    {
        public StudentPage2()
        {
            InitializeComponent();

            createStudentButton.Clicked += OnCreateStudentClicked;
        }

        private void OnCreateStudentClicked(object sender, EventArgs e)
        {
            var studentModel = new StudentModel
            {
                firstname = firstnameEntered.Text,
                lastname = lastnameEntered.Text,
                
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