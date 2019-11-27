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

namespace WPF_Agent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _mainFrame.Navigate(new Dashboard());
            Dashboard.Style = (Style)FindResource("SelectedNavbarButtonStyle");
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
            e.Handled = true;
        }

        public void Navigate_To(object sender, RoutedEventArgs e)
        {
            var to = sender as Button;

            var normalStyle = (Style)FindResource("NavbarButtonStyle");

            Dashboard.Style = normalStyle;
            TaskDetails.Style = normalStyle;
            Leads.Style = normalStyle;
            Pipeline.Style = normalStyle;
            Reports.Style = normalStyle;

            switch (to.Name)
            {
                case "Dashboard":
                    _mainFrame.Navigate(new Dashboard());
                    to.Style = (Style)FindResource("SelectedNavbarButtonStyle");
                    break;
                case "TaskDetails":
                    _mainFrame.Navigate(new TaskDetails());
                    to.Style = (Style)FindResource("SelectedNavbarButtonStyle");
                    break;
                case "Pipeline":
                   
                    to.Style = (Style)FindResource("SelectedNavbarButtonStyle");
                    break;
                case "Reports":
                    _mainFrame.Navigate(new Reports());
                    to.Style = (Style)FindResource("SelectedNavbarButtonStyle");
                    break;
                case "Leads":
                    
                    to.Style = (Style)FindResource("SelectedNavbarButtonStyle");
                    break;
            }
        }
        public void Logout(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            App.Current.Resources["CalendarWidth"] = (this.ActualWidth - 80) / 4;
            App.Current.Resources["MaxWidth"] = (this.ActualWidth - 33);
        }
    }
}
