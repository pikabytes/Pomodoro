using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class PomodoroPageViewModel : NotificationObject
    {
        private Timer timer;
        public int pomodoroDuration;
        public int breakDuration;
        private TimeSpan timeSpan;

        public TimeSpan Ellapsed
        {
            get { return timeSpan; }
            set { timeSpan = value;
                OnPropertyChanged();
            }
        }

        private bool isRunning;

        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value;
                OnPropertyChanged();
            }
        }

        private bool isInBreak;

        public bool IsInBreak
        {
            get { return isInBreak; }
            set { isInBreak = value;
                OnPropertyChanged();
            }
        }


        public ICommand StartOrPauseCommand { get; set; }

        public PomodoroPageViewModel()
        {
            InitializeTimer();
            LoadConfiguredValues();
            StartOrPauseCommand = new Command(StartOrPauseCommandExecute);
        }

        private void LoadConfiguredValues()
        {
            pomodoroDuration = (int)Application.Current.Properties[Literals.PomodoroDuration];
            breakDuration = (int)Application.Current.Properties[Literals.BreakDuration];
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed; // sobrecargando propiedad
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Ellapsed = Ellapsed.Add(TimeSpan.FromSeconds(1));
        }

        private void StartTimer()
        {
            timer.Start();
            IsRunning = true;
        }

        private void StopTimer()
        {
            timer.Stop();
            IsRunning = false;
        }


        private void StartOrPauseCommandExecute(object obj)
        {
            if (IsRunning)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }
    }
}
