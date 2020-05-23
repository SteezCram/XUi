using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace XUi.Controls.Dialog
{
    /// <summary>
    /// Dialog Type
    /// Each dialog type have a special functionnement and a special method to be show
    /// </summary>
    public enum DialogType
    {
        Message = 0,
        Progress = 2,
    }

    /// <summary>
    /// All the message result
    /// Come from a special button
    /// </summary>
    public enum MessageResult
    {
        Yes = 0,
        No = 2,
        Custom1 = 4,
        Custom2 = 8
    }

    /// <summary>
    /// Manage the dialog in XUi
    /// Each dialog are base on <see cref="UserControl"/>
    /// </summary>
    public static class Dialog
    {
        private static IDialog dialogLoaded = null;

        /// <summary>
        /// Show a <see cref="CustomDialog"/>
        /// The dialog is defined by the UIElement sended to this method
        /// Can take any controls
        /// </summary>
        /// 
        /// <param name="dialog">Dialog to load</param>
        /// 
        /// <returns>
        /// <see cref="CustomDialog"/> to interact with him
        /// </returns>
        /// 
        /// <remarks>
        /// Useful to create a dialog with some specific actions
        /// </remarks>
        public static async Task<IDialog> ShowCustomDialog(this XUiWindow window, IDialog dialog)
        {
            dialogLoaded = dialog;
            Grid grid = window.Template.FindName("DialogContainer", window) as Grid;
            grid.Children.Add((UIElement)dialog);

            // Return the progress dialog
            await Task.Delay(500);
            return dialog;
        }

        /// <summary>
        /// Show an <see cref="InputDialog"/>
        /// </summary>
        /// 
        /// <param name="dialogSettings"><see cref="DialogSettings"/> of the <see cref="InputDialog"/></param>
        /// 
        /// <returns>
        /// <see cref="ProgressDialog"/> to interact with him
        /// </returns>
        public static async Task<InputDialog> ShowInputDialog(this XUiWindow window, string title, string message, string dataToSet)
        {
            // Create the message dialog
            InputDialog inputDialog = new InputDialog(title, message, dataToSet);
            dialogLoaded = inputDialog;
            Grid grid = window.Template.FindName("DialogContainer", window) as Grid;
            grid.Children.Add(inputDialog);

            // Wait the animation is finished
            await Task.Delay(500);
            // Return the dialog
            return inputDialog;
        }

        /// <summary>
        /// Show a <see cref="MessageDialog"/>
        /// </summary>
        /// 
        /// <param name="title">Title of the <see cref="MessageDialog"/></param>
        /// <param name="message">Message of the <see cref="MessageDialog"/></param>
        /// 
        /// <returns>
        /// <see cref="ProgressDialog"/> to interact with him
        /// </returns>
        public static async Task<InputDialog> ShowInputDialog(this XUiWindow window, DialogSettings dialogSettings)
        {
            // Create the message dialog
            InputDialog inputDialog = new InputDialog(dialogSettings);
            dialogLoaded = inputDialog;
            Grid grid = window.Template.FindName("DialogContainer", window) as Grid;
            grid.Children.Add(inputDialog);

            // Wait the animation is finished
            await Task.Delay(500);
            // Return the dialog
            return inputDialog;
        }

        /// <summary>
        /// Show a <see cref="MessageDialog"/>
        /// </summary>
        /// 
        /// <param name="title">Title of the <see cref="MessageDialog"/></param>
        /// <param name="message">Message of the <see cref="MessageDialog"/></param>
        /// 
        /// <returns>
        /// A <see cref="MessageResult"/> which depend of the button clicked by the user
        /// </returns>
        public static async Task<MessageResult> ShowMessageDialog(this XUiWindow window, string title, string message)
        {
            // Create the message dialog
            MessageDialog messageDialog = new MessageDialog(title, message);
            dialogLoaded = messageDialog;
            Grid grid = window.Template.FindName("DialogContainer", window) as Grid;
            grid.Children.Add(messageDialog);

            // Wait the message result and return it
            MessageResult messageResult = await messageDialog.WaitMessageResult();
            return messageResult;
        }

        /// <summary>
        /// Show a <see cref="MessageDialog"/>
        /// </summary>
        /// 
        /// <param name="dialogSettings"><see cref="DialogSettings"/> of the <see cref="MessageDialog"/></param>
        /// 
        /// <returns>
        /// <see cref="MessageResult"/> which depend of the button clicked by the user
        /// </returns>
        public static async Task<MessageResult> ShowMessageDialog(this XUiWindow window, DialogSettings dialogSettings)
        {
            // Create the message dialog
            MessageDialog messageDialog = new MessageDialog(dialogSettings);
            dialogLoaded = messageDialog;
            Grid grid = window.Template.FindName("DialogContainer", window) as Grid;
            grid.Children.Add(messageDialog);

            // Wait the message result and return it
            MessageResult messageResult = await messageDialog.WaitMessageResult();
            return messageResult;
        }

        /// <summary>
        /// Show a <see cref="ProgressDialog"/>
        /// </summary>
        /// 
        /// <param name="dialogSettings"><see cref="DialogSettings"/> of the <see cref="MessageDialog"/></param>
        /// 
        /// <returns>
        /// <see cref="ProgressDialog"/> to interact with him
        /// </returns>
        public static async Task<ProgressDialog> ShowProgressDialog(this XUiWindow window, string text = "", bool keepAlive = false)
        {
            if (dialogLoaded != null && keepAlive)
            {
                // Get the progress dialog
                Grid grid = window.Template.FindName("DialogContainer", window) as Grid;
                ProgressDialog progressDialog = grid.Children[0] as ProgressDialog;

                // Reset the text
                progressDialog.SetText(text);
                return progressDialog;
            }
            else
            {
                // Create the message dialog
                ProgressDialog progressDialog = new ProgressDialog(text);
                dialogLoaded = progressDialog;
                Grid grid = window.Template.FindName("DialogContainer", window) as Grid;
                grid.Children.Add(progressDialog);

                // Return the progress dialog
                await Task.Delay(500);
                return progressDialog;
            }
        }

        /// <summary>
        /// Show a <see cref="MessageDialog"/>
        /// </summary>
        /// 
        /// <param name="title">Title of the <see cref="MessageDialog"/></param>
        /// <param name="message">Message of the <see cref="MessageDialog"/></param>
        /// 
        /// <returns>
        /// <see cref="object"/> which depend of the seleccted item
        /// </returns>
        public static async Task<object> ShowSelectDialog(this XUiWindow window, string title, string message, IEnumerable itemSource)
        {
            // Create the message dialog
            SelectDialog selectDialog = new SelectDialog(title, message);
            dialogLoaded = selectDialog;
            Grid grid = window.Template.FindName("DialogContainer", window) as Grid;
            grid.Children.Add(selectDialog);

            // Set the item source
            selectDialog.SelectComboBox.ItemsSource = itemSource;
            selectDialog.SelectComboBox.SelectedIndex = 0;

            // Wait the message result and return it
            await selectDialog.WaitMessageResult();
            return selectDialog.SelectComboBox.SelectedItem;
        }

        /// <summary>
        /// Show a <see cref="MessageDialog"/>
        /// </summary>
        /// 
        /// <param name="dialogSettings"><see cref="DialogSettings"/> of the <see cref="MessageDialog"/></param>
        /// 
        /// <returns>
        /// <see cref="object"/> which depend of the seleccted item
        /// </returns>
        public static async Task<object> ShowSelectDialog(this XUiWindow window, DialogSettings dialogSettings, IEnumerable itemSource)
        {
            // Create the message dialog
            SelectDialog selectDialog = new SelectDialog(dialogSettings);
            dialogLoaded = selectDialog;
            Grid grid = window.Template.FindName("DialogContainer", window) as Grid;
            grid.Children.Add(selectDialog);

            // Set the item source
            selectDialog.SelectComboBox.ItemsSource = itemSource;
            selectDialog.SelectComboBox.SelectedIndex = 0;

            // Wait the message result and return it
            await selectDialog.WaitMessageResult();
            return selectDialog.SelectComboBox.SelectedItem;
        }

        /// <summary>
        /// Close the <see cref="MessageDialog"/>
        /// </summary>
        /// 
        /// <returns>
        /// </returns>
        public static async Task CloseDialog(this XUiWindow window)
        {
            await dialogLoaded.ExitAnimation();

            ((Grid)window.Template.FindName("DialogContainer", window)).Children.Remove(dialogLoaded as UIElement);
            dialogLoaded = null;
        }

        /// <summary>
        /// Check if a dialog is already opened
        /// </summary>
        public static bool IsDialogOpen(this XUiWindow window)
        {
            // Check if a dialog is already loaded
            if (dialogLoaded != null)
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// Dialog settings to all the dialog
    /// Contains many settings around all the dialog type
    /// </summary>
    public class DialogSettings
    {
        private string _defaultButton = "Yes";
        private string _yesText = "Yes";
        private string _noText = "No";

        private HorizontalAlignment _buttonAlignement = HorizontalAlignment.Left;
        private HorizontalAlignment _titleAlignement = HorizontalAlignment.Left;
        private HorizontalAlignment _messageAlignement = HorizontalAlignment.Left;


        public string Title;
        public string Message;
        public string DataToSet;
        public bool IsProtected;
        public string DefaultButton { get => _defaultButton; set { _defaultButton = value; } }

        public string YesText { get => _yesText; set { _yesText = value; } }
        public string NoText { get => _noText; set { _noText = value; } }
        public string Custom1Text;
        public string Custom2Text;

        public HorizontalAlignment ButtonAlignement { get => _buttonAlignement; set { _buttonAlignement = value; } }
        public HorizontalAlignment TitleAlignement { get => _titleAlignement; set { _titleAlignement = value; } }
        public HorizontalAlignment MessageAlignement { get => _messageAlignement; set { _messageAlignement = value; } }
    }
}
