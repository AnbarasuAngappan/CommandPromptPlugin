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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommandPromptPlugin;

namespace WpfAppTestCommandPrompt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommadPrompt commadPrompt = new CommadPrompt();
            //commadPrompt.Commandpromt();
            //commadPrompt.ExecuteCommandPrompt("ipconfig");

            //commadPrompt.DisconnectRemoteDesktop();
            //commadPrompt.Manipulation("0,1");
            //commadPrompt.PirntDialog("",@"D:\Anbu\Personal\RC Book Request Letter.pdf",1,2);
            commadPrompt.PrintPDF(@"D:\Anbu\MVC Framework 4.pdf");

        }
    }
}
