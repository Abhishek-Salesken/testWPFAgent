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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Agent.UserControls;

namespace WPF_Agent.Pages
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private Border activeTodayTaskTabItem = new Border();
        public Dashboard()
        {
            InitializeComponent();
            AddToDoItems();
            AddTodayTaskTabItems();
            AddWonLeadsCarousal();
            AddPipelineCarousal();
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
                    FilterByActivities.Text = "Presentation Task";
                    break;
                case "WebinarTaskButton":
                    FilterByActivities.Text = "Webinar Task";
                    break;

            }
        }





        private void AddToDoItems()
        {
            for (int i = 0; i < 3; i++)
            {
                List<String> images = new List<string>
                {
                    "https://image.shutterstock.com/image-photo/studio-shot-young-man-looking-260nw-372072697.jpg",
                    "https://www.leisureopportunities.co.uk/images/imagesX/249542_405534.jpg",
                     "https://www.leisureopportunities.co.uk/images/imagesX/249542_405534.jpg",
                    "https://storage.googleapis.com/istar-user-images/files/D.png"
                 };
                ToDoListStackPanel.Children.Add(new ToDoListItem("Event Name", "11:00 PM", images));
            }
            List<String> images1 = new List<string>
            {

            };
            ToDoListStackPanel.Children.Add(new ToDoListItem("Event Name", "11:00 PM", images1));
        }

        private void ActivitiesButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            string btnName = ((Button)sender).Name;


            switch (btnName)
            {
                case "CallTaskButtonFilter":
                    FilterByActivities.Text = "Call Task";
                    break;
                case "EmailTaskButtonFilter":
                    FilterByActivities.Text = "Email Task";
                    break;
                case "PresentationTaskButtonFilter":
                    FilterByActivities.Text = "Presentation Task";
                    break;
                case "WebinarTaskButtonFilter":
                    FilterByActivities.Text = "Webinar Task";
                    break;

            }

        }

        private void StagesButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterByStages.FontWeight = FontWeights.Normal;
            Button button = sender as Button;
            FilterByStages.Text = button.Content.ToString();
        }

        //<-------TODAY TASK FUNCTIONS
        private void AddTodayTaskTabItems()
        {
            //Get Request for TodayTaskTabItems only and set the task id in variable id in the for loop
            Panel.SetZIndex(activeTodayTaskTabItem, 10);
            for (int i = 0; i < 5; i++)
            {
                //replace 'i' with your task ID and it will be available in addTodayTaskDetails function as a parameter to add task details
                int id = i;
                String type = "call";
                if (i == 1) { type = "email"; }
                if (i == 4) { type = "presentation"; }
                if (i == 3) { type = "webinar"; }

                Border border = new Border();
                newTabItemBorderStyle(border, id, type);

                if (i == 1)
                {
                    border.Child = new TodayTaskTabItem("11:00 PM", "Tesla", "Stage 02", type);
                }
                else
                {
                    border.Child = new TodayTaskTabItem("11:00 PM", "My Company", "Stage 02", type);
                }
                TodayTaskTabItemPanel.Children.Add(border);
                if (i == 0)
                {

                    activeTodayTaskTabItem = border;
                    activeTabItemStyle(border);
                    border.MouseLeave -= Border_MouseLeave;
                    addTodayTaskDetails(border.Tag.ToString());
                }
            }

        }

        public void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            nonActiveTabItemStyle(activeTodayTaskTabItem);
            activeTodayTaskTabItem.MouseLeave += Border_MouseLeave;

            Border border = sender as Border;
            activeTabItemStyle(border);
            border.MouseLeave -= Border_MouseLeave;
            activeTodayTaskTabItem = border;


            addTodayTaskDetails(border.Tag.ToString());

        }
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            activeTabItemStyle(border);
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            nonActiveTabItemStyle(border);
        }
        private void activeTabItemStyle(Border border)
        {
            border.Background = new SolidColorBrush(Colors.White);
            border.Effect = new DropShadowEffect
            {
                Color = Colors.Black,
                Direction = 320,
                ShadowDepth = 0,
                Opacity = 0.2,
                BlurRadius = 40
            };
            Panel.SetZIndex(border, 10);
        }
        private void nonActiveTabItemStyle(Border border)
        {

            border.Background = Brushes.Transparent;
            border.Effect = new DropShadowEffect
            {
                Color = Colors.White,
                Direction = 320,
                ShadowDepth = 0,
                Opacity = 0.2,
                BlurRadius = 20
            };
            Panel.SetZIndex(border, 0);

        }
        private void newTabItemBorderStyle(Border border, int id, String type)
        {

            border.Tag = id.ToString() + " " + type;
            border.BorderBrush = new SolidColorBrush(Color.FromRgb(238, 238, 238));
            border.Cursor = Cursors.Hand;
            Thickness borderThickness = border.BorderThickness;
            borderThickness.Bottom = 1;
            border.BorderThickness = borderThickness;
            Thickness margin = border.Margin;
            margin.Left = 20;
            margin.Right = -2;
            border.Margin = margin;
            border.MouseEnter += Border_MouseEnter;
            border.MouseLeave += Border_MouseLeave;
            border.MouseDown += Border_MouseDown;

        }

        private void addTodayTaskDetails(String tag)
        {
            String[] Tag = tag.Split(' ');
            TodayTaskHistoryPanel.Child = new TodayTaskHistory(Tag[0], Tag[1]);
        }
        //TODAY TASK FUNCTIONS END------------->

        private void AddWonLeadsCarousal()
        {
            Carousal carousal = new Carousal();


            //ONLY EDITABLE CODE--------
            for (int i = 0; i < 4; i++)
            {
                //Only Add CarousalItems
                Random random = new Random();
                String a = random.Next(10, 100).ToString();

                carousal.Data.Children.Add(new WonLeadCarousalItem(a));
            }
            //----------->

            carousal.Setup();
            WonLeadCarousalPanel.Children.Add(carousal);
        }
        private void AddPipelineCarousal()
        {
            PipelineCarousalPanel.Children.Add(new PipelineCarousal());
        }
    }
}
