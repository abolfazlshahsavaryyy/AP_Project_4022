﻿using System;
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
using System.Windows.Shapes;
using AP_Project_4022.CustomerPage;

namespace AP_Project_4022.CustomerPage
{
    /// <summary>
    /// Interaction logic for restaurantMenuPage.xaml
    /// </summary>
    public partial class restaurantMenuPage : Window
    {
        public restaurantMenuPage()
        {
            InitializeComponent();
            AddUserControl();
        }
        void AddUserControl()
        {
            foodCategoryUserControl fCUC = new foodCategoryUserControl();
            fCUC.foodListStackPanel.Children.Add(new Button ());
            menuStackPanel.Children.Add(fCUC);
        }
        
    }
}
