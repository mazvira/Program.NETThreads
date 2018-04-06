using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Lab5
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool _canExecute;
        private RelayCommand _startWorking;
        private RelayCommand _endWorking;
        private readonly Action<bool> _showLoaderAction;
        static object locker = new object();
        private string _nameOfProcess;
        private long _idOfProcess;
        private bool _isProcessActive;
        private double _CPUOfProcess;
        private double _RAMamount;
        private int _quantityOfThreads;
        private string _nameOfOwner;
        private string _nameAndPathToTheFile;
        private MyProcess _processes;
        private Thread _threadUpdateProcesses;
        private Thread _threadUpdateInformation;


        public MainWindowViewModel(Action<bool> showLoader)
        {
            _showLoaderAction = showLoader;
            CanExecute = true;
           _processes = Process.GetProcesses();
        }

        public bool CanExecute
        {
            get { return _canExecute; }
            private set { _canExecute = value; OnPropertyChanged(); }
        }

        public string NameOfProcess
        {
            get { return _nameOfProcess; }
            private set { _nameOfProcess = value; OnPropertyChanged(); }
        }

        public long IdOfProcess
        {
            get { return _idOfProcess; }
            private set { _idOfProcess = value; OnPropertyChanged(); }
        }

        public bool IsProcessActive
        {
            get { return _isProcessActive; }
            private set { _isProcessActive = value; OnPropertyChanged(); }
        }

        public double CPUOfProcess
        {
            get { return _CPUOfProcess; }
            private set { _CPUOfProcess = value; OnPropertyChanged(); }
        }

        public double RAMamount
        {
            get { return _RAMamount ; }
            private set { _RAMamount = value; OnPropertyChanged(); }
        }

        public int QuantityOfThreads
        {
            get { return _quantityOfThreads; }
            private set { _quantityOfThreads = value; OnPropertyChanged(); }
        }

        public string NameOfOwner
        {
            get { return _nameOfOwner; }
            private set { _nameOfOwner = value; OnPropertyChanged(); }
        }

        public string NameAndPathToTheFile
        {
            get { return _nameAndPathToTheFile; }
            private set { _nameAndPathToTheFile = value; OnPropertyChanged(); }
        }

        public static void UpdateProcesses()
        {
            lock (locker)
            {
                MyProcess[] processlist = MyProcess.GetProcesses();
                foreach (MyProcess theprocess in processlist)
                {
                    //  Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
                }
                Thread.Sleep(5000);
            }
        }

        public static void UpdateInformationAboutProcesses()
        {
            lock (locker)
            {
                foreach (MyProcess theprocess in processlist) //у чому тут помилка?
                {
                   // Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id, theprocess.);
                }
                Thread.Sleep(2000);

            }
        }

        /*public RelayCommand CountAge
        {
            get
            {
                return _countAge ?? (_countAge = new RelayCommand(CountAgeImpl, o => !String.IsNullOrWhiteSpace(_name) && _dateOfBirth != DateTime.MinValue &&
                                                                                     !String.IsNullOrWhiteSpace(_lastName) && !String.IsNullOrWhiteSpace(_email)));
            }
        }*/


        /* private async void CountAgeImpl(object o)
         {
             _showLoaderAction.Invoke(true);
             CanExecute = false;
             await Task.Run((() =>
             {
                 StationManager.CurrentPerson = DBAdapter.CreatePerson(_name, _lastName, _email, _dateOfBirth);
                 Thread.Sleep(3000);
             }));
             if (StationManager.CurrentPerson == null)
                 MessageBox.Show($"Date of birth {_dateOfBirth} is  invalid.");
    
             else
             {
                 if (_dateOfBirth.DayOfYear == DateTime.Today.DayOfYear)
                     MessageBox.Show("Happy Birthday");
                 OnPropertyChanged(nameof(NameForResult));
                 OnPropertyChanged(nameof(LastNameForResult));
                 OnPropertyChanged(nameof(EmailForResult));
                 Age = $"{StationManager.CurrentPerson.Age}";
    
             }
             CanExecute = true;
             _showLoaderAction.Invoke(false);
         }*/


        #region Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}


