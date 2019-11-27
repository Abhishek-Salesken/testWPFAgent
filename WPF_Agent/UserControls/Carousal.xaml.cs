using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace WPF_Agent.UserControls
{
    /// <summary>
    /// Interaction logic for Carousal.xaml
    /// </summary>
    public partial class Carousal : UserControl
    {
        private RadioButton prevButton = new RadioButton();
        private int prevButtonTag = 0;
        private int currentTag = 0;
        DispatcherTimer dt;
        public StackPanel Data = new StackPanel();
        public TextBlock StageName = new TextBlock();
        public List<string> StageNames = new List<string>();
        public Carousal()
        {
            InitializeComponent();
            ContentElement.Children.Clear();
            Data = ContentElement;

        }
        public Carousal(TextBlock textBlock)
        {
            InitializeComponent();
            ContentElement.Children.Clear();
            StageName = textBlock;
            Data = ContentElement;
        }
        private async Task DoWorkAsyncInfiniteLoop(double time)
        {
            int itr = 0;
            int count = Buttons.Children.Count;



            await Task.Delay(TimeSpan.FromMilliseconds(time * 1000));
            while (true)
            {

                if (Buttons.IsVisible != true)
                {
                    await Task.Delay(2000);
                    continue;
                }
                if (itr == count) { itr = 0; }
                RadioButton button = Buttons.Children[itr] as RadioButton;
                if (button.IsEnabled == true)
                {
                    Animation(Buttons.Children[itr]);
                }


                await Task.Delay(10000);
                if (itr != currentTag) { itr = currentTag; }
                itr++;
            }
        }


        public void Setup()
        {


            for (int i = 0; i < ContentElement.Children.Count; i++)
            {
                RadioButton button = new RadioButton();
                if (i == 0)
                {
                    button.Style = (Style)FindResource("SalesKenRadioButtonChecked");
                    button.IsChecked = true;
                }
                else
                {
                    button.Style = (Style)FindResource("SalesKenRadioButtonUnChecked");
                }
                button.Tag = i;
                button.Click += Button_Click;

                Buttons.Children.Add(button);
            }

            var random = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
            Animation(Buttons.Children[0]);
            foreach (var control in Buttons.Children.OfType<RadioButton>())
            {
                control.IsEnabled = true;
            }

            double time = random.Value.NextDouble() * random.Value.Next(0, 10);
            _ = DoWorkAsyncInfiniteLoop(time);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Animation(sender);
        }

        private void Animation(object sender)
        {

            prevButton.Style = (Style)FindResource("SalesKenRadioButtonUnChecked");
            prevButton = sender as RadioButton;
            prevButton.Style = (Style)FindResource("SalesKenRadioButtonChecked");
            prevButton.IsChecked = true;

            int i = Int32.Parse(((RadioButton)sender).Tag.ToString());
            currentTag = i;
            int width = Convert.ToInt32(FindResource("CalendarWidth"));
            dt = new DispatcherTimer();
            double counter = Convert.ToInt32(Scroll.HorizontalOffset);


            if (i == prevButtonTag) { return; }

            foreach (var control in Buttons.Children.OfType<RadioButton>())
            {
                control.IsEnabled = false;
            }
            if (i >= prevButtonTag)
            {
                dt.Tick += delegate
                {
                    counter += 1;
                    Scroll.ScrollToHorizontalOffset((double)counter);
                    if (counter >= width * i)
                    {
                        dt.Stop();
                        foreach (var control in Buttons.Children.OfType<RadioButton>())
                        {
                            control.IsEnabled = true;

                        }
                    }
                };
                dt.Interval = TimeSpan.FromMilliseconds(0);
                dt.Start();
            }
            else
            {
                dt.Tick += delegate
                {
                    counter -= 1;
                    Scroll.ScrollToHorizontalOffset((double)counter);
                    if (counter <= width * i)
                    {
                        dt.Stop();
                        foreach (var control in Buttons.Children.OfType<RadioButton>())
                        {
                            control.IsEnabled = true;

                        }
                    }
                };
                dt.Interval = TimeSpan.FromMilliseconds(0);
                dt.Start();
            }
            prevButtonTag = i;

            if (StageNames.Count > 0)
            {
                StageName.Text = StageNames[currentTag];
            }

            Scroll.ScrollToHorizontalOffset((double)width * currentTag);

        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int width = Convert.ToInt32(FindResource("CalendarWidth"));
            Scroll.ScrollToHorizontalOffset((double)(width * currentTag));
        }
    }
}
