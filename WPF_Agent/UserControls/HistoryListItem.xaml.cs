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
    /// Interaction logic for HistoryListItem.xaml
    /// </summary>
    public partial class HistoryListItem : UserControl
    {
        public HistoryListItem(String sentiment, String name, String date, String taskType, String image)
        {
            InitializeComponent();
            switch (sentiment)
            {
                case "Angry":
                    Sentiment.Foreground = new SolidColorBrush(Color.FromRgb(232, 76, 76));
                    break;
                case "Happy":
                    Sentiment.Foreground = new SolidColorBrush(Color.FromRgb(87, 178, 128));
                    break;
            }
            Sentiment.Text = sentiment;
            Name.Text = name;
            Date.Text = date;
            UserImage.ImageSource = new BitmapImage(new Uri(@image)); ;
        }
    }
}
