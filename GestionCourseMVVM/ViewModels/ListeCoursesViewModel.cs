using GestionCourseMVVM.Models;
using GestionCourseMVVM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestionCourseMVVM.ViewModels
{
	public class ListeCoursesViewModel : BindableObject
	{
		private List<Course> _courses;
		public List<Course> Courses { get => _courses; set { _courses = value; OnPropertyChanged(); } }
		public Command AjouterCoureurCommande { get; set; }
		public Command AjouterCourseCommande { get; set; }
		public INavigation Navigation { get; set; }
		public ListeCoursesViewModel(INavigation navigation)

		{
			if (Courses == null)
				Courses = new List<Course>();
			InitilisationListeCourse();
			AjouterCoureurCommande = new Command(ajoutCoureur);
			AjouterCourseCommande = new Command(ajoutCourse);
			Navigation = navigation;
		}

        private void ajoutCourse(object obj)
        {
			Navigation.PushAsync(new AjoutCourse());
		}

        private void ajoutCoureur(object obj)
        {
			Navigation.PushAsync(new AjoutCoureur());
        }
		

        private  void InitilisationListeCourse()
		{
			Courses.Add(new Course { Nom = "Marathon de Paris", Lieu = "Paris", Distance = 42.195f });
			Courses.Add(new Course { Nom = "Marathon de Montpellier", Lieu = "Montpellier", Distance = 42.195f });
			Courses.Add(new Course { Nom = "Semi-Marathon de Phalempin", Lieu = "Phalempin", Distance = 21.1f });
		}
	}
}
