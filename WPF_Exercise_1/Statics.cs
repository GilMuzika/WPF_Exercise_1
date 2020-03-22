﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Dynamic;

namespace WPF_Exercise_1
{
    static class Statics
    {
        

        /// <summary>
        /// Finding children in WPF window by type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                var childType = child as T;
                if (childType != null)
                {
                    yield return (T)child;
                }

                foreach (var other in FindVisualChildren<T>(child))
                {
                    yield return other;
                }
            }
        }




    }





}
