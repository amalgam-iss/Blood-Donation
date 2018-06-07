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

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LogIn();
        }

        private void LogIn()
        {
            int user_type = ctrl.login(tbxUsername.Text, tbxPassword.Password);
            Debug.WriteLine("user type" + user_type);
            switch (user_type)
            {

                case 1:
                    DonorWindow donorWindow = new DonorWindow(tbxUsername.Text);
                    donorWindow.Show();
                    this.Close();
                    break;
                case 2:
                    // Send the userId to doctorWindow
                    User user;
                    using (var db = new Model1())
                    {
                        Debug.WriteLine("tbxUsername:  " + tbxUsername.Text);
                      //  Debug.WriteLine("usr.Username:  " + usr.Username);
                        user = db.Users.Where(usr => usr.Username == tbxUsername.Text).First();
                    }
                    DoctorWindow doctorWindow = new DoctorWindow(user.Id.ToString());

                    doctorWindow.Show();
                    ;
                    this.Close();
                    break;
                case 3:
                    NurseWindow nurseWindow = new NurseWindow(tbxUsername.Text);
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

        private void tbxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
                LogIn();
        }
    }
    
}
