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

namespace Steganographer
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

        private void revealButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.WriteLine("python -m steganographer " + inputImageTextBox.Text);
            process.StandardInput.Close();
            string output = process.StandardOutput.ReadToEnd();
            string[] outputLines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            messageTextBox.Text = string.Join("\n", outputLines.Skip(5).Take(outputLines.Length - 5 - 2).ToArray());
            Console.WriteLine(output);
            Console.WriteLine(process.StandardError.ReadToEnd());
        }

        private void hideButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.WriteLine("python -m steganographer " + inputImageTextBox.Text + " -o " + outputImageTextBox.Text + " -m \"" + messageTextBox.Text + "\"");
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            Console.WriteLine(process.StandardError.ReadToEnd());
        }

        private void revealFileButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.WriteLine("python -m steganographer -r " + inputImageTextBox.Text);
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            Console.WriteLine(process.StandardError.ReadToEnd());
        }

        private void hideFileButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.WriteLine("python -m steganographer " + inputImageTextBox.Text + " -o " + outputImageTextBox.Text + " -f \"" + inputFileTextBox.Text + "\"");
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            Console.WriteLine(process.StandardError.ReadToEnd());
        }
    }
}
