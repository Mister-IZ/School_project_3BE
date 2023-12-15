
namespace School.Views
{
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
                name = nameEntered.Text,
                
            };

            var teacherRepository = new StudentRepository();
            teacherRepository.SaveStudents(studentModel);

            Navigation.PushAsync(new StudentPage());
        }
    }
}