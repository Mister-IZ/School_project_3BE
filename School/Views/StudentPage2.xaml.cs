using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Maui.Controls;

namespace School.Views
{
    public partial class StudentPage2 : ContentPage
    {
        private List<string> activityList;

        public StudentPage2()
        {
            InitializeComponent();

            // Chargez la liste des activités dans le Picker
            LoadActivitiesPicker();
        }

        // Méthode pour charger les activités dans le Picker
        private void LoadActivitiesPicker()
        {
            try
            {
                string filePath = "activities.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Read all lines from the file
                    var activityLines = File.ReadAllLines(filePath);

                    // Initialize the list of activities
                    var activityList = new List<string>();

                    foreach (var activityLine in activityLines)
                    {
                        // Split each line to get individual data (course, code, ECTS, Teacher)
                        var activityData = activityLine.Split(',');

                        // Make sure the line contains the expected number of elements
                        if (activityData.Length >= 1)
                        {
                            // Add the course to the list
                            activityList.Add(activityData[0].Trim());
                        }
                        else
                        {
                            Console.WriteLine($"The line '{activityLine}' does not contain the expected number of elements.");
                        }
                    }

                    // Bind the list of activities to the Picker
                    courseActivityPicker.ItemsSource = activityList;
                }
                else
                {
                    // Handle the case where the file does not exist
                }
            }
            catch (Exception ex)
            {
                // Handle errors when reading the activities file here
                Console.WriteLine($"Error reading activities file: {ex.Message}");
            }
        }


        private void OnCreateActivityClicked(object sender, EventArgs e)
        {
            // Vérifiez si une activité a été sélectionnée
            if (string.IsNullOrWhiteSpace(courseActivityPicker.SelectedItem?.ToString()))
            {
                // Affichez un message d'erreur
                DisplayAlert("Erreur", "Vous devez sélectionner une activité pour créer un étudiant.", "OK");
                return; // Sortez de la méthode car la sélection est invalide
            }

            // Continuez avec la création de l'étudiant
            var studentModel = new StudentModel
            {
                firstname = coursefirstname.Text,
                lastname = courselastname.Text,
                // Utilisez la sélection du Picker pour l'activité
                SelectedActivities = new List<string> { courseActivityPicker.SelectedItem?.ToString() ?? string.Empty },
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
