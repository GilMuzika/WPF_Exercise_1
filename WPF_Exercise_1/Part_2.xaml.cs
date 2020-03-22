using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_Exercise_1
{
    /// <summary>
    /// Interaction logic for Part_2.xaml
    /// </summary>
    public partial class Part_2 : UserControl
    {
        private string _saveLabelValue;

        public string Title
        {
            get => tblTitle.Text;
            set
            {
                tblTitle.Text = value;
            }
        }


        public Part_2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _saveLabelValue = (string)lblPart2Label.Content;
            System.Timers.Timer locTimer = new System.Timers.Timer();
            locTimer.Interval = 250;

            int labelValue = Int32.Parse((string)lblPart2Label.Content);
            locTimer.Elapsed += (object sender2, ElapsedEventArgs e2) =>
            {

                SafeInvoke(() => { lblPart2Label.Content = labelValue.ToString(); });
                

                if (labelValue == 0) { locTimer.Stop(); SafeInvoke(() => { lblPart2Label.Content = _saveLabelValue; });  }
                labelValue--;
            };
            locTimer.Start();
        }
        
        private void Button_Click_Dispatcher_Timer(object sender, RoutedEventArgs e)
        {
            _saveLabelValue = (string)lblPart2Label.Content;
            DispatcherTimer dispTimer = new DispatcherTimer();
            dispTimer.Interval = new TimeSpan(0,0,0,0,250);

            int labelValue = Int32.Parse((string)lblPart2Label.Content);
            dispTimer.Tick += (object sender2, EventArgs e2) =>
            
            {

                lblPart2Label.Content = labelValue.ToString();


                if (labelValue == 0) { dispTimer.Stop();  lblPart2Label.Content = _saveLabelValue; }
                labelValue--;
            };
            dispTimer.Start();
        }



        private void SafeInvoke(Action work)
        {
            if (Dispatcher.CheckAccess())
            {
                work.Invoke();
                return;
            }
            this.Dispatcher.BeginInvoke(work);
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
