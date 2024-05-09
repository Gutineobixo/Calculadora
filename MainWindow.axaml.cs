using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace AvaloniaCalculator
{
    public partial class MainWindow : Window
    {
        private TextBox inputBox;

        public MainWindow()
        {
            InitializeComponent();
            inputBox = this.FindControl<TextBox>("InputBox");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void OnNumberClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            inputBox.Text += button.Content.ToString();
        }

        public void OnClearClick(object sender, RoutedEventArgs e)
        {
            inputBox.Text = String.Empty;
        }

        public void OnCalculateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = new System.Data.DataTable().Compute(inputBox.Text, null);
                inputBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                inputBox.Text = "Erro: " + ex.Message;
            }
        }
    }
}