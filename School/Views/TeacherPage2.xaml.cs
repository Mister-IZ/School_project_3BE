namespace School.Views;

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
                firstName = firstnameEntered.Text,
                lastName = lastnameEntered.Text,
                salary = salaryEntered.Text,
            };

            var teacherRepository = new TeacherRepository();
            teacherRepository.SaveTeachers(teacherModel);

            Navigation.PushAsync(new TeacherPage());
        }
    
        private void OnReturnToMainPageClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new MainPage());
    }
}