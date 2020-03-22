﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<UserControl> _alluserControls = new List<UserControl>();
        private List<String> _alluserControlsObservColl = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmbpart1Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {                
            foreach (var s in _alluserControls)
            {
                if (s.ToString() == (string)(sender as ComboBox).SelectedItem) s.Visibility = Visibility.Visible;
                else s.Visibility = Visibility.Collapsed;
            }            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Statics.FindVisualChildren<UserControl>(this).ToList().ForEach(c => { _alluserControls.Add(c); c.Visibility = Visibility.Collapsed; });
            _alluserControls.ForEach(c => _alluserControlsObservColl.Add(c.ToString()));
            cmbpart1Combo.ItemsSource = _alluserControlsObservColl;            
        }
    }
}
