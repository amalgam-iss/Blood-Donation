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
using System.Windows.Shapes;
using BloodDonor.Model;


namespace BloodDonor
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DonorWindow : Window
    {
        int FLAG_TEST_NOT_READY = 0;
        int FLAG_TEST_OK = 1;
        int FLAG_TEST_NOT_OK = 2;
        Donor donor;

        public DonorWindow(string UserId)
        {
            long userId = Convert.ToInt32(UserId);
            donor = new Donor();
            using (var db = new Model1())
            {
                donor = (Donor)db.Donors.SqlQuery("SELECT * FROM Donor d where d.UserId = " + userId + "").SingleOrDefault();
            }
            InitializeComponent();
            populate_history();
        }

        private void populate_history()
        {
            List<Donation> history = new List<Donation>();
            foreach (Donation d in history)
            {
                string test_results = "OK";
                if ((d.Flags & FLAG_TEST_OK) == FLAG_TEST_OK)
                {

                }
                dgvDonationsView.Items.Add("smth");
            }
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSend_Data(object sender, RoutedEventArgs e)
        {

        }

    }
}
