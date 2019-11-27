using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Agent.UserControls;

namespace WPF_Agent.Pages
{
    /// <summary>
    /// Interaction logic for CallTask.xaml
    /// </summary>
    public partial class CallTask : Page
    {
        private Timer _timer;

        public CallTask()
        {
            InitializeComponent();
            AddRecentListItems();
            AddLeadListItems();

        }

        private void AddRecentListItems()
        {
            for (int i = 0; i < 3; i++)
            {

                RecentListPanel.Children.Add(new RecentListItem("+ 91 989 898 8789", "05:10 Min"));
            }
        }
        private void AddLeadListItems()
        {
            for (int i = 0; i < 3; i++)
            {
                LeadListPanel.Children.Add(new LeadListHistoryItem("Globex Corporation Inc.", "+ 91 989 898 8789"));
            }
        }
        private void NewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);


            string btnName = ((Button)sender).Name;


            switch (btnName)
            {
                case "CallTaskButton":
                    ns.Navigate(new CallTask());
                    break;
                case "EmailTaskButton":
                    ns.Navigate(new EmailTask());
                    break;
                case "PresentationTaskButton":

                    break;
                case "WebinarTaskButton":

                    break;

            }
        }

        private void Dial_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DialedNumber.Background = new SolidColorBrush(Colors.Transparent);
            if (DialedNumber.Text.Length < 14)
            {
                DialedNumber.Text = DialedNumber.Text + button.Tag.ToString();
            }


        }

        private void DialedNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                // Enable copy/paste and selection of all text.
                case Key.C:
                case Key.V:
                case Key.A:
                    if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                        return;
                    break;

                // Enable keyboard navigation/selection.
                case Key.Left:
                case Key.Up:
                case Key.Right:
                case Key.Down:
                case Key.PageUp:
                case Key.PageDown:
                case Key.Home:
                case Key.End:
                    return;
            }
            e.Handled = true;
        }

        private void BackSpace(object sender, RoutedEventArgs e)
        {
            try
            {
                DialedNumber.Text = DialedNumber.Text.Remove(DialedNumber.Text.Length - 1, 1);
            }
            catch { }
        }
        private void Backspace_MouseDown(object sender, MouseEventArgs e)
        {
            _timer = new Timer
            {
                Interval = 1000
            };
            _timer.Elapsed += Dialer_clear;
            _timer.Enabled = true;
            _timer.Start();
        }

        private void Dialer_clear(object sender, EventArgs e)
        {
            DialedNumber.Clear();
            Console.Out.WriteLine("cleared");
        }

        private void Backspace_MouseUp(object sender, MouseEventArgs e)
        {

            _timer.Enabled = false;
            _timer.Stop();
        }

        private void LeadSearchIcon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DialedNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DialedNumber.Text.Length >= 10)
            {
                Panel.SetZIndex(MainPanel, 2);
                NumberRunText.Text = DialedNumber.Text;
                MakeCallButton.IsEnabled = true;
            }
            else
            {
                Panel.SetZIndex(MainPanel, -1);
                MakeCallButton.IsEnabled = false;
            }
        }
    }
}
