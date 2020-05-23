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
    /// Logique d'interaction pour MessageDialog.xaml
    /// </summary>
    public partial class MessageDialog : UserControl, IDialog
    {
        #region Constructor

        public MessageDialog(string title, string message)
        {
            InitializeComponent();

            Title.Text = title;
            Message.Text = message;

            Button defaultButton = this.FindName($"YesButton") as Button;
            defaultButton.IsDefault = true;
            defaultButton.Style = XUiTheme.XUiDictionnaries["XUi_ButtonAccent"] as Style;

            this.Loaded += DialogLoaded;
        }

        public MessageDialog(DialogSettings dialogSettings)
        {
            InitializeComponent();

            Title.Text = dialogSettings.Title;
            Message.Text = dialogSettings.Message;

            ButtonsStackPanel.HorizontalAlignment = dialogSettings.ButtonAlignement;
            Title.HorizontalAlignment = dialogSettings.TitleAlignement;
            Message.HorizontalAlignment = dialogSettings.MessageAlignement;

            Button defaultButton = this.FindName($"{dialogSettings.DefaultButton}Button") as Button;
            defaultButton.IsDefault = true;
            defaultButton.Style = XUiTheme.XUiDictionnaries["XUi_ButtonAccent"] as Style;

            if (dialogSettings.YesText != null && dialogSettings.YesText != "")
                ((TextBlock)YesButton.Content).Text = dialogSettings.YesText;
            else
                YesButton.Visibility = Visibility.Collapsed;

            if (dialogSettings.NoText != null && dialogSettings.NoText != "")
                ((TextBlock)NoButton.Content).Text = dialogSettings.NoText;
            else
                NoButton.Visibility = Visibility.Collapsed;

            if (dialogSettings.Custom1Text != null && dialogSettings.Custom1Text != "") {
                ((TextBlock)Custom1Button.Content).Text = dialogSettings.Custom1Text;
                Custom1Button.Visibility = Visibility.Visible;
            }

            if (dialogSettings.Custom2Text != null && dialogSettings.Custom2Text != "") {
                ((TextBlock)Custom2Button.Content).Text = dialogSettings.Custom2Text;
                Custom2Button.Visibility = Visibility.Visible;
            }

            this.Loaded += DialogLoaded;
        }

        #endregion

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
        /// Wait the result of the dialog
        /// </summary>
        /// 
        /// <returns>
        /// </returns>
        public async Task<MessageResult> WaitMessageResult()
        {
            TaskCompletionSource<MessageResult> tcs = new TaskCompletionSource<MessageResult>();

            YesButton.Click += (sender, e) =>
            {
                tcs.TrySetResult(MessageResult.Yes);
            };

            NoButton.Click += (sender, e) =>
            {
                tcs.TrySetResult(MessageResult.No);
            };

            Custom1Button.Click += (sender, e) =>
            {
                tcs.TrySetResult(MessageResult.Custom1);
            };

            Custom2Button.Click += (sender, e) =>
            {
                tcs.TrySetResult(MessageResult.Custom2);
            };

            return await tcs.Task;
        }

        #endregion
    }
}
