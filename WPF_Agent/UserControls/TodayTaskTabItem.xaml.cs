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

namespace WPF_Agent.UserControls
{
    /// <summary>
    /// Interaction logic for TodayTaskTabItem.xaml
    /// </summary>
    public partial class TodayTaskTabItem : UserControl
    {
        public TodayTaskTabItem(String time, String company, String stage, string type)
        {
            InitializeComponent();


            Time.Text = time;
            Company.Text = company;
            Stage.Text = stage;

            switch (type)
            {
                case "call":
                    TaskImage.Source = new BitmapImage(new Uri("/Resources/Images/CallTask.png", UriKind.Relative));
                    break;
                case "email":
                    TaskImage.Source = new BitmapImage(new Uri("/Resources/Images/EmailTask.png", UriKind.Relative));
                    break;
                case "webinar":
                    TaskImage.Source = new BitmapImage(new Uri("/Resources/Images/WebinarTask.png", UriKind.Relative));
                    break;
                case "presentation":
                    TaskImage.Source = new BitmapImage(new Uri("/Resources/Images/Presentation.png", UriKind.Relative));
                    break;
            }
        }
    }
}
