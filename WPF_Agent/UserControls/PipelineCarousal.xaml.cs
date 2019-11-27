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
    /// Interaction logic for PipelineCarousal.xaml
    /// </summary>
    public partial class PipelineCarousal : UserControl
    {
        public int PipelineId = 0;
        public int max = 4;
        private Carousal carousalPrev;
        public PipelineCarousal()
        {
            InitializeComponent();
            AddPipeline(0);
        }

        public void AddPipeline(int i)
        {
            i++;
            PipelineName.Text = "Pipeline 0" + i.ToString() + " ";
            AddStages();
        }
        public void AddStages()
        {

            Carousal carousal = new Carousal(StageName);
            List<string> stageNames = new List<string>();
            PipelineCarousalPanel.Children.Clear();

            //ONLY EDITABLE CODE--------
            for (int i = 0; i < 4; i++)
            {
                //Only Add CarousalItems
                String stageName = "Stage 0" + (i + 1).ToString();
                stageNames.Add(stageName);

                carousal.Data.Children.Add(new PipelineCarousalItem());
            }
            //----------->

            carousal.StageNames = stageNames;
            carousal.Setup();
            PipelineCarousalPanel.Children.Add(carousal);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Tag.ToString() == "Right")
            {
                PipelineId++;
                if (PipelineId < max)
                {
                    AddPipeline(PipelineId);
                    Left.IsEnabled = true;
                    Left.Style = (Style)FindResource("SalesKenCarousalArrowButton");
                }
                else if (PipelineId == max)
                {
                    AddPipeline(PipelineId);
                    Right.IsEnabled = false;
                    Right.Style = (Style)FindResource("SalesKenCarousalArrowDisabledButton");
                }
                else
                {
                    Right.IsEnabled = false;
                    Right.Style = (Style)FindResource("SalesKenCarousalArrowDisabledButton");
                }
            }
            else
            {
                PipelineId--;
                if (PipelineId > 0)
                {
                    AddPipeline(PipelineId);
                    Right.IsEnabled = true;
                    Right.Style = (Style)FindResource("SalesKenCarousalArrowButton");
                }
                else if (PipelineId == 0)
                {
                    AddPipeline(PipelineId);
                    Left.IsEnabled = false;
                    Left.Style = (Style)FindResource("SalesKenCarousalArrowDisabledButton");
                }
                else
                {
                    Left.IsEnabled = false;
                    Left.Style = (Style)FindResource("SalesKenCarousalArrowDisabledButton");
                }
            }
        }
    }
}
