namespace FocusHelper
{
    using System;
    using System.Media;
    using System.Windows.Media;
    using System.Windows.Threading;
    using Caliburn.Micro;

    public class TimerViewModel : Screen
    {
        private const string ZeroDisplay = "00:00";
        private readonly DispatcherTimer _timer;
        private int _countdown;

        public TimerViewModel()
        {
            DisplayName = "Focus Helper";
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += TimerOnTick;
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            _countdown--;
            if (_countdown <= 60)
                BackColor = Brushes.LightGoldenrodYellow;
            if (_countdown <= 0)
            {
                //we are done....
                TimeDisplay = ZeroDisplay;
                BackColor = Brushes.IndianRed;
                SystemSounds.Beep.Play();
            }
            else
            {
                int minutes = _countdown / 60;
                TimeDisplay = string.Format("{0}:{1}", minutes, (_countdown - minutes * 60).ToString("00"));
            }
        }

        private string _timeDisplay = ZeroDisplay;
        public string TimeDisplay
        {
            get { return _timeDisplay; }
            set
            {
                if (value != _timeDisplay)
                {
                    _timeDisplay = value;
                    NotifyOfPropertyChange(() => TimeDisplay);
                }
            }
        }
        private Brush _backColor = Brushes.White;
        public Brush BackColor
        {
            get { return _backColor; }
            set
            {
                if (value != _backColor)
                {
                    _backColor = value;
                    NotifyOfPropertyChange(() => BackColor);
                }
            }
        }

        private void StartTimer(int mins)
        {
            Reset();
            _countdown = mins * 60;
            _timer.Start();
        }

        public void Start5()
        {
            //set countdown, start timer...
            StartTimer(5);
        }


        public void Start10()
        {
            StartTimer(10);
        }

        public void Start15()
        {
            StartTimer(15);
        }

        public void Start20()
        {
            StartTimer(20);
        }

        public void Start25()
        {
            StartTimer(25);
        }

        public void Reset()
        {
            _timer.Stop();
            _timeDisplay = ZeroDisplay;
            BackColor = Brushes.White;
        }
    }
}