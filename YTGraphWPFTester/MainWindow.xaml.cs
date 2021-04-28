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
using System.Windows.Threading;

namespace YTGraphWPFTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime timeStarted;
        double yValue = 2;
        double dVariance = 0;
        Random rand;
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            graphUC.CheckAndAddSeriesToGraph("trial", "rpm");
            dVariance = yValue ;
            rand = new Random();
            timeStarted = DateTime.Now;
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            double dValueX = (double)(DateTime.Now.Subtract(timeStarted).TotalSeconds);
            graphUC.AddPointToLine("trial", yValue + (rand.NextDouble() - dVariance), dValueX);
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            graphUC.Width = e.NewSize.Width - 40;
            graphUC.Height = e.NewSize.Height - 20;
        }
    }
}
