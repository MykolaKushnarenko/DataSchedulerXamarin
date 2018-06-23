using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Support.Design.Widget;
using Java.Lang;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Thread = System.Threading.Thread;

namespace App11.Droid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class TimeDay
    {
        public string Time { get; set; }
        public int TimeOcloc { get; set; }
        public int Day { get; set; }
        public int Mounth { get; set; }
    }
    public partial class GridDay : ContentPage
    {
        private TimeDay selectItem { get; set; }
        public TimePicker timePicker { get; private set; }
        private DatePicker dataDay { get; set; }
        public List<TimeDay> Phones { get; private set; }
        public Button button { get; set; }
        private DatePicker a { get; set; }
        string[] separators = { ",", ".", "!", "?", ";", ":", " " };
        public GridDay(string data, int day, int moun)
        {
            //a = new DatePicker() { Date = dataNow.Date };
            //dataDay = dataNow;
            //dataNow = new DatePicker() { Date = DateTime.Now };
            button = new Button() { Text = "Clicked!",FontFamily = "MarkerFelt-Thin",BorderColor = Color.Brown, HeightRequest = 60,BackgroundColor = Color.DarkGray, IsVisible = false };
            button.Clicked += Button_Clicked;
            Label header = new Label
            {
                Text = data,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Phones = new List<TimeDay>
            {
                new TimeDay{Time = "00:00", TimeOcloc = 0,Day = day, Mounth = moun},
                new TimeDay{Time = "01:00", TimeOcloc = 1,Day = day, Mounth = moun},
                new TimeDay{Time = "02:00", TimeOcloc = 2,Day = day, Mounth = moun},
                new TimeDay{Time = "03:00", TimeOcloc = 3,Day = day, Mounth = moun},
                new TimeDay{Time = "04:00", TimeOcloc = 4,Day = day, Mounth = moun},
                new TimeDay{Time = "05:00", TimeOcloc = 5,Day = day, Mounth = moun},
                new TimeDay{Time = "06:00", TimeOcloc = 6,Day = day, Mounth = moun},
                new TimeDay{Time = "07:00", TimeOcloc = 7,Day = day, Mounth = moun},
                new TimeDay{Time = "08:00", TimeOcloc = 8,Day = day, Mounth = moun},
                new TimeDay{Time = "09:00", TimeOcloc = 9,Day = day, Mounth = moun},
                new TimeDay{Time = "10:00", TimeOcloc = 10,Day = day, Mounth = moun},
                new TimeDay{Time = "11:00", TimeOcloc = 11,Day = day, Mounth = moun},
                new TimeDay{Time = "12:00", TimeOcloc = 12,Day = day, Mounth = moun},
                new TimeDay{Time = "13:00", TimeOcloc = 13,Day = day, Mounth = moun},
                new TimeDay{Time = "14:00", TimeOcloc = 14,Day = day, Mounth = moun},
                new TimeDay{Time = "15:00", TimeOcloc = 15,Day = day, Mounth = moun},
                new TimeDay{Time = "16:00", TimeOcloc = 16,Day = day, Mounth = moun},
                new TimeDay{Time = "17:00", TimeOcloc = 17,Day = day, Mounth = moun},
                new TimeDay{Time = "18:00", TimeOcloc = 18,Day = day, Mounth = moun},
                new TimeDay{Time = "19:00", TimeOcloc = 19,Day = day, Mounth = moun},
                new TimeDay{Time = "20:00", TimeOcloc = 20,Day = day, Mounth = moun},
                new TimeDay{Time = "21:00", TimeOcloc = 21,Day = day, Mounth = moun},
                new TimeDay{Time = "22:00", TimeOcloc = 22,Day = day, Mounth = moun},
                new TimeDay{Time = "23:00", TimeOcloc = 23,Day = day, Mounth = moun},
                new TimeDay{Time = "24:00", TimeOcloc = 24,Day = day, Mounth = moun}
            };
            ListView listView = new ListView
            {

                HasUnevenRows = true,
                ItemsSource = Phones,


                ItemTemplate = new DataTemplate(() =>
                {
                    Label titleLabel = new Label { FontSize = 25 };
                    titleLabel.SetBinding(Label.TextProperty, "Time");
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 0),
                            Orientation = StackOrientation.Vertical,
                            Children = {new BoxView{BackgroundColor = Color.DarkGray, HeightRequest = 0.5, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.FillAndExpand},
                                new StackLayout
                                {
                                    Padding = new Thickness(20, 20),
                                    Orientation = StackOrientation.Vertical,
                                    Children = { titleLabel }

                                },
                            },

                        }
                    };
                })
            };
            listView.ItemTapped += OnItemTapped;
            this.Content = new StackLayout { Children = { header, listView, button } };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            but.BackgroundColor = Color.SteelBlue;
            
            CrossLocalNotifications.Current.Show("Reminder", "Date set", 101);
            Navigation.PopAsync();
        }

        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            TimeDay selectedTimeDay = e.Item as TimeDay;
            DateTime nowTime = DateTime.Now;
            int day = nowTime.Day;
            int mouth = nowTime.Month;
            int hour = nowTime.Hour;
            if (selectedTimeDay != null)
            {
                if (selectedTimeDay.Mounth > mouth)
                {
                    
                    selectItem = selectedTimeDay;
                    button.IsVisible = true;
                    await DisplayAlert("Data set: ", $"{selectedTimeDay.Time}", "OK");

                }
                else
                {
                    if (selectedTimeDay.Day > day)
                    {
                        selectItem = selectedTimeDay;
                        button.IsVisible = true;
                        await DisplayAlert("Data set: ", $"{selectedTimeDay.Time}", "OK");
                    }
                    else
                    {
                        if (selectedTimeDay.TimeOcloc > hour)
                        {
                            selectItem = selectedTimeDay;
                            button.IsVisible = true;
                            await DisplayAlert("Data set: ", $"{selectedTimeDay.Time}", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Error.", "The time has passed", "OK");
                        }
                            
                    }
                    
                }

            }
        }

        private void SelectingItems()
        {

        }
        protected override bool OnBackButtonPressed()
        {
            dataDay.Date = DateTime.Now;
            return base.OnBackButtonPressed();
        }
    }
}