namespace School.Views
{
    public partial class TeacherPage2 : ContentPage
    {
        public TeacherPage2()
        {
            InitializeComponent();

            createTeacherButton.Clicked += OnCreateTeacherClicked;
        }

        private void OnCreateTeacherClicked(object sender, EventArgs e)
        {
            var teacherModel = new TeacherModel
            {
                name = nameEntered.Text,
                course = courseEntered.Text
            };

            var teacherRepository = new TeacherRepository();
            teacherRepository.SaveTeachers(teacherModel);

            Navigation.PushAsync(new TeacherPage());
        }
    }
}