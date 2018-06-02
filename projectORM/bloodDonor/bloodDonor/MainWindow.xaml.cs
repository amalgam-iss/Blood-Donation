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
using System.Drawing;
using System.Diagnostics;
using BloodDonor.Utils;

using BloodDonor.Controllers;
using BloodDonor.Model;

namespace BloodDonor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainController ctrl;
        public MainWindow()
        {
            InitializeComponent();
            ctrl = new MainController();
            tbxPassword.Password = "pass";
            tbxUsername.Text = "george"; 

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            int user_type = ctrl.login(tbxUsername.Text, tbxPassword.Password);
       
            Console.WriteLine("user type" + user_type.ToString());
            switch (user_type)
            {

                case 1:
                    DonorWindow donorWindow = new DonorWindow();
                    donorWindow.Show();
                    this.Close();
                    break;
                case 2:
                    // Send the userId to doctorWindow
                    User user;
                    using (var db = new Model1())
                    {
                        user = db.Users.Where(usr => usr.Username == tbxUsername.Text).First();
                    }
                    DoctorWindow doctorWindow = new DoctorWindow(user.Id.ToString());
                    
                    doctorWindow.Show();
                    this.Close();
                    break;
                case 3:
                    NurseWindow nurseWindow = new NurseWindow();
                    nurseWindow.Show();
                    this.Close();
                    break;
                case -1:
                    MessageBox.Show("Invalid username or password");
                    break;
                default:
                    MessageBox.Show("Login failed! Upsie");
                    break;
            }
        }

        private void tbxUsername_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tbxUsername.Text = "";
        }

        private void lblNewUser_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SignUp window = new SignUp();
            window.Show();
        }
    }
    
}
