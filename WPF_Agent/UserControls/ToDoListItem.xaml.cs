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
    /// Interaction logic for ToDoListItem.xaml
    /// </summary>
    public partial class ToDoListItem : UserControl
    {
        public ToDoListItem(String EventName, String Time, List<String> Images)
        {
            InitializeComponent();
            eventNameText.Text = EventName;
            time.Text = Time;
            int i = Images.Count();
            foreach (String imagesrc in Images)
            {
                Border border = new Border();
                border.Background = new SolidColorBrush(Colors.White);
                border.CornerRadius = new CornerRadius(14);
                border.BorderThickness = new Thickness(2);
                border.BorderBrush = new SolidColorBrush(Colors.White);

                Ellipse myEllipse = new Ellipse();
                myEllipse.Width = 28;
                myEllipse.Height = 28;

                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = new BitmapImage(new Uri(imagesrc));
                imgBrush.Stretch = Stretch.UniformToFill;
                myEllipse.Fill = imgBrush;

                Thickness margin = myEllipse.Margin;
                margin.Left = -6;
                myEllipse.Margin = margin;

                Panel.SetZIndex(border, i);
                Panel.SetZIndex(myEllipse, i);

                border.Child = myEllipse;
                images.Children.Add(border);

                i--;
            }
        }
    }
}
