﻿using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour SelectDialog.xaml
    /// </summary>
    public partial class SelectDialog : UserControl, IDialog
    {
        public SelectDialog(string title, string message)
        {
            InitializeComponent();
            Title.Text = title;
            if (!string.IsNullOrEmpty(message))
                Message.Visibility = Visibility.Visible;
            Message.Text = message;

            this.Loaded += DialogLoaded;
        }

        public SelectDialog(DialogSettings dialogSettings)
        {
            InitializeComponent();

            Title.Text = dialogSettings.Title;
            if (!string.IsNullOrEmpty(dialogSettings.Message))
                Message.Visibility = Visibility.Visible;
            Message.Text = dialogSettings.Message;

            ((TextBlock)YesButton.Content).Text = dialogSettings.YesText;
            if (!string.IsNullOrEmpty(dialogSettings.NoText))
                ((TextBlock)NoButton.Content).Text = dialogSettings.NoText;

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

            return await tcs.Task;
        }

        #endregion
    }
}