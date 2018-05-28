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

namespace BloodDonor
{
    /// <summary>
    /// Interaction logic for NurseWindow.xaml
    /// </summary>
    public partial class NurseWindow : Window
    {
        public NurseWindow(String nameOfNurse="Nurse")
        {
            InitializeComponent();
            lblTitle.Content = "Hello, " + nameOfNurse + "!";
        }
 
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            AddBloodPack win1 = new AddBloodPack();
            bool? result = win1.ShowDialog();

            if (result.HasValue && result.Value)
            {
                 String groupTxtNurse = win1.groupTxt;
                 String rhTxtNurse = win1.rhTxt;
                 String statusTxtNurse = win1.statusTxt;
                 DateTime currentDateNurse = win1.currentDate;
                //TODO Create the object
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Object myItem = dgvBloodPack.SelectedItem;
            //Object cellId = dgvBloodPack.SelectedCells[0];
            RemoveBloodPack win1 = new RemoveBloodPack(myItem); // or cellId
            bool? result = win1.ShowDialog();

            if (result.HasValue && result.Value)
            {
                String cellRemovedId = win1.bloodPackIdTxt;
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //TOOD update dgv
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            Object myItem = dgvBloodPack.SelectedItem;
            // Object cellId = dgvBloodPack.SelectedCells[0];
            EditBloodPack win1 = new EditBloodPack(myItem); // or cellId
            bool? result = win1.ShowDialog();

            if (result.HasValue && result.Value)
            {
                String groupTxtNurse = win1.groupTxt;
                String rhTxtNurse = win1.rhTxt;
                String statusTxtNurse = win1.statusTxt;
                DateTime currentDateNurse = win1.currentDate;
                //TODO Update the object
            }
        }
    }
}
