using System.Windows;
using System.Windows.Controls;

namespace ExampleCalculator
{
    public partial class MainWindow : Window
    {
        private CalculatorEngine _calculator = new CalculatorEngine();
        private bool _isOperationJustPressed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Digital_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var textBlock = (TextBlock)button.Content;
            string value = textBlock.Text;

            if (txtResult.Text == "0" || _isOperationJustPressed)
            {
                txtResult.Text = value;
                _isOperationJustPressed = false;
            }
            else
            {
                txtResult.Text += value;
            }
        }

        private void Button_Operation_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var textBlock = (TextBlock)button.Content;
            string operation = textBlock.Text;

            if (double.TryParse(txtResult.Text, out double inputValue))
            {
                double result = _calculator.SetOperation(operation, inputValue);
                txtResult.Text = result.ToString();
                _isOperationJustPressed = true;
            }

        }

        private void Button_Equals_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtResult.Text, out double inputValue))
            {
                double result = _calculator.CalculateResult(inputValue);
                txtResult.Text = result.ToString();
                _isOperationJustPressed = true;
            }
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Clear();
            txtResult.Text = "0";
            _isOperationJustPressed = false;
        }

        private void Button_Backspace_Click(object sender, RoutedEventArgs e)
        {
            int len = txtResult.Text.Length;
            if (len > 1)
            {
                string str = txtResult.Text.Substring(0, len - 1);
                txtResult.Text = str;
            }
            else
            {
                txtResult.Text = "0";
            }
        }
    }
}