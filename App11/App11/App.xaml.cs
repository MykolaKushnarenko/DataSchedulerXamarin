using System;
using App11.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace App11
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new DataPage())
			{
                Title = "12123123123",
                BarTextColor = Color.Black,
                BarBackgroundColor = Color.Indigo
			};
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
