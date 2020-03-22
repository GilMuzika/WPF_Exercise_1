using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Exercise_1
{
    /// <summary>
    /// Interaction logic for Part_3.xaml
    /// </summary>
    public partial class Part_3 : UserControl
    {
        public string Title
        {
            get => tblTitle.Text;
            set
            {
                tblTitle.Text = value;
            }
        }


        public Part_3()
        {
            InitializeComponent();
        }

        public override string ToString()
        {
            return this.Title;
        }


    }
}
