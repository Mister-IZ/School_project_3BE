namespace School.Views;

public partial class TeacherPage : ContentPage   ///partial = répartie sur plusieurs fichiers
{
	public TeacherPage()          ///Création de l'enseignant (constructeur), !!! utiliser un autre que nom que le Teacher du modèle
	{
		var name_entered = new Entry();  ///Champ de texte
		var course_entered = new Entry();
		var button = new Button { Text = "Créer enseignant"};
		InitializeComponent();

		button.Clicked += (sender, e) => 
		{
			var teacherModel = new TeacherModel
			{
				name = name_entered.Text,
				course = course_entered.Text

			};

			var teacherRepository = new TeacherRepository();
			teacherRepository.SaveTeachers(teacherModel); ///on sauve le teacherModel qui a été entré


			Content = new StackLayout  ///C'est le contenu de l'affichage
			{
				Children = {new Label { Text = "Nom:"}, name_entered, new Label {Text = "Matière:"}, course_entered, button}



			};

	

		};
	}
}