using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XUi.Controls.Dialog
{
    /// <summary>
    /// Logique d'interaction pour ProgressDialog.xaml
    /// </summary>
    public partial class ProgressDialog : UserControl, IDialog
    {
        public ProgressDialog(string text = "")
        {
            InitializeComponent();
            this.Loaded += DialogLoaded;
            this.DataContext = this;

            TextTextBlock.Text = text;
        }

        /// <summary>
        /// Make the initial storyboard to the dialog
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void DialogLoaded(object sender, RoutedEventArgs e)
        {
            Storyboard storyboardGrid = this.FindResource("DialogGridLoaded") as Storyboard;
            storyboardGrid.Begin(DialogGrid);

            await Task.Delay(250);
            DialogBorder.Visibility = Visibility.Visible;
            Storyboard storyboardBorder = this.FindResource("DialogBorderLoaded") as Storyboard;
            storyboardBorder.Begin(DialogBorder);

            await Task.Delay(500);
        }

        /// <summary>
        /// Make the exit storyboard to the dialog
        /// </summary>
        /// 
        /// <returns>
        /// </returns>
        public async Task ExitAnimation()
        {
            Storyboard storyboardBorder = this.FindResource("DialogBorderClose") as Storyboard;
            storyboardBorder.Begin(DialogBorder);

            await Task.Delay(500);

            Storyboard storyboardGrid = this.FindResource("DialogGridClose") as Storyboard;
            storyboardGrid.Begin(DialogGrid);

            await Task.Delay(250);
        }

        public void SetText(string text) => TextTextBlock.Text = text;

        public Task<MessageResult> WaitMessageResult()
        {
            throw new NotImplementedException();
        }
    }
}
