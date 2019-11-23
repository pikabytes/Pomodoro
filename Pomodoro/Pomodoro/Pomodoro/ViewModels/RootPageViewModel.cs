using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class RootPageViewModel : NotificationObject
    {
        private ObservableCollection<string> menuItems;

        public ObservableCollection<string> MenuItems
        {
            get { return menuItems; }
            set
            {
                menuItems = value;
                OnPropertyChanged();
            }
        }

        private string selectedMenuItem;

        public string SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set { 
                selectedMenuItem = value;
                OnPropertyChanged();
            }
        }


        public RootPageViewModel()
        {
            MenuItems = new ObservableCollection<string>();
            MenuItems.Add("Pomodoro");
            MenuItems.Add("Historico");
            MenuItems.Add("Configuracion");

            PropertyChanged += RootPageViewModel_PropertyChanged;
        }


        private void RootPageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(SelectedMenuItem))
            {
                if(SelectedMenuItem == "Configuracion")
                {
                    MessagingCenter.Send(this, "GoToConfiguration");
                }
                if (SelectedMenuItem == "Historico")
                {
                    MessagingCenter.Send(this, "GoToHistory");
                }
                if (selectedMenuItem == "Pomodoro")
                {
                    MessagingCenter.Send(this, "GoToPomodoro");
                }
                
            }
        }
    }
}
