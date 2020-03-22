using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace WPF_Exercise_1
{
    class ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private AkaMessageBoxWindow _akaMessageBox = new AkaMessageBoxWindow();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        //OnPropertyChanging Properties
        private string _saveLabelValue;
        private string _part_2LabelValue = "50";
        public string Part_2LabelValue
        {
            get => _part_2LabelValue;
            set
            {
                if (String.Equals(_part_2LabelValue, value)) return;
                _part_2LabelValue = value;
                OnPropertyChanged();
            }
        }
        private string _part_3TextBoxValue;
        public string Part_3TextBoxValue
        {
            get => _part_3TextBoxValue;
            set
            {
                if (String.Equals(_part_3TextBoxValue, value)) return;
                _part_3TextBoxValue = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand Part2Button_Click_1_DelegComm { get; set; }        
        public DelegateCommand Part_3GoButton_click_DelegComm { get; set; }
        public DelegateCommand Part_3CancelButton_click_DelegComm { get; set; }


        public ViewModel()
        {   //creating and running Part2Button_Click_1_DelegComm
            Part2Button_Click_1_DelegComm = new DelegateCommand(async () => 
            {
                _saveLabelValue = Part_2LabelValue;
                System.Timers.Timer locTimer = new System.Timers.Timer();
                locTimer.Interval = 250;

                int labelValue = Int32.Parse(Part_2LabelValue);
                await Task.Run(() => 
                {
                    locTimer.Elapsed += (object sender, ElapsedEventArgs e) => 
                    {
                        Part_2LabelValue = labelValue.ToString();
                        if (labelValue == 0) { locTimer.Stop(); Part_2LabelValue = _saveLabelValue; }
                        labelValue--;
                    };
                    locTimer.Start();

                });

            }, () => { return true; });
            //End: creating and running Part2Button_Click_1_DelegComm

            //creating and running Part_3GoGutton_click_DelegComm
            Part_3GoButton_click_DelegComm = new DelegateCommand(Part_3GoGutton_butttonOnClick, () => 
            {
                if (Part_3TextBoxValue == null || Part_3TextBoxValue.Length <= 3) return false;

                return true; 
            });
            //End: creating and running 
            //creating and running Part_3CancelButton_click_DelegComm
            Part_3CancelButton_click_DelegComm = new DelegateCommand(Part_3CancelGutton_butttonOnClick, () => 
            {
                if (Part_3TextBoxValue == null || Part_3TextBoxValue.Length == 0) return false;
                return true; 
            });
            //End: creating and running Part_3CancelButton_click_DelegComm



            Task.Run(() =>
            {
                while (true)
                {
                    Part2Button_Click_1_DelegComm.RaiseCanExecuteChanged();
                    Part_3GoButton_click_DelegComm.RaiseCanExecuteChanged();
                    Part_3CancelButton_click_DelegComm.RaiseCanExecuteChanged();
                    Thread.Sleep(100);
                }
            });
        }
        private void Part_3GoGutton_butttonOnClick()
        {
            _akaMessageBox.ShowMesage($"Hello, {Part_3TextBoxValue}", $"{Part_3TextBoxValue}, smile and shine!");            
        }
        private void Part_3CancelGutton_butttonOnClick()
        {
            _akaMessageBox.Message = String.Empty;
            Part_3TextBoxValue = string.Empty;
        }



        public string Error => String.Empty;
        public string this[string columnName]
        {
            get => GetError(columnName);
        }
        private string GetError(string propertyName)
        {
            foreach (var s in this.GetType().GetProperties())
            {
                if (s.Name == propertyName)
                {
                    if (((string)s.GetValue(this)) == null || ((string)s.GetValue(this)).Length > 10) return "FuckingError";
                }
            }

            return String.Empty;
        }

    }

    
}
