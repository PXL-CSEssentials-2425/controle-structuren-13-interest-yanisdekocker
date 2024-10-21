using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace intrest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            startKapitalTextBox.Clear();
            endKapitalTextBox.Clear();
            intrestTextBox.Clear();
            resultTextBox.Clear();
            startKapitalTextBox.Focus();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            decimal capital = 0.0M;
            decimal desiredCapital = 0.0M;
            decimal interest = 0.0M;
            bool isFailed = !decimal.TryParse(startKapitalTextBox.Text, out capital) ||
                !decimal.TryParse(endKapitalTextBox.Text, out desiredCapital) ||
                !decimal.TryParse(intrestTextBox.Text, out interest);

            if (isFailed)
            {
                deleteButton_Click(this, null);
                return;
            }
            if (capital >= desiredCapital)
            {
                resultTextBox.Text = $"Waarde na 0 jaren: {capital}";
                return;
            }

            int numberOfYears = 0;

            StringBuilder sb = new StringBuilder();
            do
            {
                numberOfYears++;
                capital *= (1.0M + (interest / 100.0M)); // capital += (interest / 100.0M) * capital;
                sb.AppendLine($"Waarde na {numberOfYears,2} jaren: {capital:c}");
            } while (capital < desiredCapital);
            resultTextBox.Text = sb.ToString();




        }

    }
}