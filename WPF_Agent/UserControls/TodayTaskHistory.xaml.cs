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
using WPF_Agent.Pages;

namespace WPF_Agent.UserControls
{
    /// <summary>
    /// Interaction logic for TodayTaskHistory.xaml
    /// </summary>
    public partial class TodayTaskHistory : UserControl
    {
        private String taskType;
        public TodayTaskHistory(String id, string type)
        {
            InitializeComponent();

            taskType = type;
            switch (taskType)
            {
                case "call":
                    TaskButton.Content = "CALL NOW";
                    break;
                case "email":
                    TaskButton.Content = "SEND NOW";
                    break;
            }
            getTodayTaskHistory(id);
        }

        private void CallNow_click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);

            switch (taskType)
            {
                case "call":
                    ns.Navigate(new CallTask());
                    break;
                case "email":
                    ns.Navigate(new EmailTask());
                    break;
            }

        }
        //get request to get all details
        private void getTodayTaskHistory(String id)
        {


            CompanyName.Text = "My Company";
            Name.Text = "Cool Guy";
            Designation.Text = "Chief Executive Officer";

            Number.Text = "+91 934 545 6767";
            string text = TaskTime.Text;
            TaskTime.Text = text + " 11:00 AM";


            if (taskType == "email")
            {
                Console.Out.WriteLine(taskType);
                CompanyName.Text = "Tesla";
                Name.Text = "Elon Musk";
                Designation.Text = "Chief Executive Officer";

                Number.Text = "+91 969 569 6420";

                TaskTime.Text = "Task at - 04:20 PM";
                return;
            }
            History.Children.Clear();


            for (int i = 0; i < 3; i++)
            {

                if (i == 1)
                {
                    History.Children.Add(new HistoryListItem("Happy", "Michele Foster", "June 26, 2019", "call", "https://www.leisureopportunities.co.uk/images/imagesX/249542_405534.jpg"));
                    continue;
                }

                History.Children.Add(new HistoryListItem("Angry", "Carmen Collinsder", "June 26, 2019", "call", "https://www.leisureopportunities.co.uk/images/imagesX/249542_405534.jpg"));
            }
        }
    }
}
