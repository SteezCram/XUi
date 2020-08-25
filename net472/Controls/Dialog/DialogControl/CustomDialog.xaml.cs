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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XUi.Controls.Dialog
{
    /// <summary>
    /// Custom dialog for XUi
    /// </summary>
    public partial class CustomDialog : UserControl, IDialog
    {
        /// <summary>
        /// Custom dialog to show
        /// </summary>
        /// 
        /// <param name="dialog">Dialog content to set</param>
        public CustomDialog(UIElement dialog)
        {
            InitializeComponent();

            DialogBorder.Child = dialog;
            this.Loaded += DialogLoaded;
        }

        #region Dialog Generic Methods

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

        /// <summary>
        /// Wait the message, wait until the user click of one of the button
        /// </summary>
        /// 
        /// <returns></returns>
        public async Task<MessageResult> WaitMessageResult()
        {
            TaskCompletionSource<MessageResult> tcs = new TaskCompletionSource<MessageResult>();
            tcs.TrySetResult(MessageResult.Custom1);

            return await tcs.Task;
        }

        #endregion
    }
}
