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
    /// Interaction logic for LeadListHistoryItem.xaml
    /// </summary>
    public partial class LeadListHistoryItem : UserControl
    {
        public LeadListHistoryItem(string company, string number)
        {
            InitializeComponent();
            Company.Text = company;
            Number.Text = number;
        }
    }
}
