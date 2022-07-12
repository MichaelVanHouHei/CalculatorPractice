using org.mariuszgromada.math.mxparser;
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

namespace CalculatorPractice
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        

        public string resultStr
        {
            get { return (string)GetValue(resultStrProperty); }
            set { SetValue(resultStrProperty, value); }
        }

        // Using a DependencyProperty as the backing store for resultStr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty resultStrProperty =
            DependencyProperty.Register("resultStr", typeof(string), typeof(MainWindow), new PropertyMetadata("0"));


        public List<string> signs => new List<string>() { "+", "-", "*", "/" ,"(" ,")", "Clear" };
        public List<int> numbers => Enumerable.Range(0, 10).ToList();

        private void ProcessClick(object sender, RoutedEventArgs e)
        {
            string input = ((Button)sender).Content.ToString();
            if (input == "Clear") { resultStr = ""; return; }
            resultStr += input;
        }

        private void CalculateClick(object sender, RoutedEventArgs e)
        {
            try
            {
            
                resultStr += " = " + new org.mariuszgromada.math.mxparser.Expression(resultStr).calculate().ToString();
                 
            }
            catch
            {
                resultStr = "ERROR INPUT";
            }
          
        }
    }
}
