using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App11.Droid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {

        DatePicker datePicker;
        public TimePicker timePicker;
        private Label lab;
        public DataPage()
        {
            InitializeComponent();

            datePicker = new DatePicker
            {
                Format = "D",
                MaximumDate = DateTime.Now.AddDays(10),
                MinimumDate = DateTime.Now.AddDays(0),
                Margin = 10

            };
            lab = new Label();
            lab.Text = "Choise date";
            datePicker.DateSelected += datePicker_DateSelected;
            StackLayout stack = new StackLayout { Children = { datePicker }, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center};
            this.Content = stack;
        }

        private async void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            StringBuilder s = new StringBuilder($"Day: {datePicker.Date.Day.ToString()}" + " " + $"Mounth: {datePicker.Date.Month.ToString()}");
            GridDay p = new GridDay(s.ToString(), datePicker.Date.Day, datePicker.Date.Month);
            await Navigation.PushAsync(p);
           

        }

    }
}