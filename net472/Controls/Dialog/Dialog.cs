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
    /// Each dialog type have a special behaviour and a special method to be show
    /// </summary>
    public enum DialogType
    {
        /// <summary>
        /// The dialog is a message
        /// </summary>
        Message = 1,
        /// <summary>
        /// The dialog is a progress
        /// </summary>
        Progress = 2,
    }

    /// <summary>
    /// All the message result
    /// Come from a special button
    /// </summary>
    public enum MessageResult
    {
        /// <summary>
        /// Affirmative result
        /// </summary>
        Yes = 1,
        /// <summary>
        /// Negative result
        /// </summary>
        No = 2,
        /// <summary>
        /// Custom 1 result, make your own behaviour
        /// </summary>
        Custom1 = 4,
        /// <summary>
        /// Custom 2 result, make your own behaviour
        /// </summary>
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
        /// <param name="window">XUiWindow to use</param>
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
        /// Show a <see cref="CustomDialog"/>
        /// The dialog is defined by the UIElement sended to this method
        /// Can take any controls
        /// </summary>
        /// 
        /// <param name="grid">Grid to load the dialog</param>
        /// <param name="dialog">Dialog to load</param>
        /// 
        /// <returns>
        /// <see cref="CustomDialog"/> to interact with him
        /// </returns>
        /// 
        /// <remarks>
        /// Useful to create a dialog with some specific actions
        /// </remarks>
        public static async Task<IDialog> ShowCustomDialog(Grid grid, IDialog dialog)
        {
            dialogLoaded = dialog;
            grid.Children.Add((UIElement)dialog);

            // Return the progress dialog
            await Task.Delay(500);
            return dialog;
        }

        /// <summary>
        /// Show an <see cref="InputDialog"/>
        /// </summary>
        /// 
        /// <param name="window">XUiWindow to use</param>
        /// <param name="title">Title to set</param>
        /// <param name="message">Message to set</param>
        /// <param name="dataToSet">Header of the textblock to set</param>
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
        /// Show an <see cref="InputDialog"/>
        /// </summary>
        /// 
        /// <param name="grid">Grid to use</param>
        /// <param name="title">Title to set</param>
        /// <param name="message">Message to set</param>
        /// <param name="dataToSet">Header of the textblock to set</param>
        /// 
        /// <returns>
        /// <see cref="ProgressDialog"/> to interact with him
        /// </returns>
        public static async Task<InputDialog> ShowInputDialog(Grid grid, string title, string message, string dataToSet)
        {
            // Create the message dialog
            InputDialog inputDialog = new InputDialog(title, message, dataToSet);
            dialogLoaded = inputDialog;
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
        /// <param name="window">Window to use </param>
        /// <param name="dialogSettings">Dialog settings to use</param>
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
        /// <param name="grid">Grid to use </param>
        /// <param name="dialogSettings">Dialog settings to use</param>
        /// 
        /// <returns>
        /// <see cref="ProgressDialog"/> to interact with him
        /// </returns>
        public static async Task<InputDialog> ShowInputDialog(Grid grid, DialogSettings dialogSettings)
        {
            // Create the message dialog
            InputDialog inputDialog = new InputDialog(dialogSettings);
            dialogLoaded = inputDialog;
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
        /// <param name="window">Window to use</param>
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
        /// <param name="grid">Grid to use</param>
        /// <param name="title">Title of the <see cref="MessageDialog"/></param>
        /// <param name="message">Message of the <see cref="MessageDialog"/></param>
        /// 
        /// <returns>
        /// A <see cref="MessageResult"/> which depend of the button clicked by the user
        /// </returns>
        public static async Task<MessageResult> ShowMessageDialog(Grid grid, string title, string message)
        {
            // Create the message dialog
            MessageDialog messageDialog = new MessageDialog(title, message);
            dialogLoaded = messageDialog;
            grid.Children.Add(messageDialog);

            // Wait the message result and return it
            MessageResult messageResult = await messageDialog.WaitMessageResult();
            return messageResult;
        }

        /// <summary>
        /// Show a <see cref="MessageDialog"/>
        /// </summary>
        /// 
        /// <param name="window">Window to use</param>
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
        /// Show a <see cref="MessageDialog"/>
        /// </summary>
        /// 
        /// <param name="grid">Grid to use</param>
        /// <param name="dialogSettings"><see cref="DialogSettings"/> of the <see cref="MessageDialog"/></param>
        /// 
        /// <returns>
        /// <see cref="MessageResult"/> which depend of the button clicked by the user
        /// </returns>
        public static async Task<MessageResult> ShowMessageDialog(Grid grid, DialogSettings dialogSettings)
        {
            // Create the message dialog
            MessageDialog messageDialog = new MessageDialog(dialogSettings);
            dialogLoaded = messageDialog;
            grid.Children.Add(messageDialog);

            // Wait the message result and return it
            MessageResult messageResult = await messageDialog.WaitMessageResult();
            return messageResult;
        }

        /// <summary>
        /// Show a <see cref="ProgressDialog"/>
        /// </summary>
        /// 
        /// <param name="window">Window to use</param>
        /// <param name="text">Text to show</param>
        /// <param name="keepAlive">If the dialog is reusable</param>
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
        /// Show a <see cref="ProgressDialog"/>
        /// </summary>
        /// 
        /// <param name="grid">Grid to use</param>
        /// <param name="text">Text to show</param>
        /// <param name="keepAlive">If the dialog is reusable</param>
        /// 
        /// <returns>
        /// <see cref="ProgressDialog"/> to interact with him
        /// </returns>
        public static async Task<ProgressDialog> ShowProgressDialog(Grid grid, string text = "", bool keepAlive = false)
        {
            if (dialogLoaded != null && keepAlive)
            {
                ProgressDialog progressDialog = null;
                int childrenCount = grid.Children.Count;

                // Get the progress dialog
                for (int i = 0; i < childrenCount; i++)
                    if (grid.Children[i] is ProgressDialog)
                        progressDialog = grid.Children[i] as ProgressDialog;

                // Reset the text
                if (progressDialog != null)
                    progressDialog.SetText(text);
                return progressDialog;
            }
            else
            {
                // Create the message dialog
                ProgressDialog progressDialog = new ProgressDialog(text);
                dialogLoaded = progressDialog;
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
        /// <param name="window">Window to use</param>
        /// <param name="title">Title of the <see cref="MessageDialog"/></param>
        /// <param name="message">Message of the <see cref="MessageDialog"/></param>
        /// <param name="itemSource">Item to set in the combo box</param>
        /// 
        /// <returns>
        /// <see cref="object"/> which depend of the selected item
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
        /// <param name="grid">Grid to use</param>
        /// <param name="title">Title of the <see cref="MessageDialog"/></param>
        /// <param name="message">Message of the <see cref="MessageDialog"/></param>
        /// <param name="itemSource">Item to set in the combo box</param>
        /// 
        /// <returns>
        /// <see cref="object"/> which depend of the selected item
        /// </returns>
        public static async Task<object> ShowSelectDialog(Grid grid, string title, string message, IEnumerable itemSource)
        {
            // Create the message dialog
            SelectDialog selectDialog = new SelectDialog(title, message);
            dialogLoaded = selectDialog;
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
        /// <param name="window">Window to use</param>
        /// <param name="dialogSettings"><see cref="DialogSettings"/> of the <see cref="MessageDialog"/></param>
        /// <param name="itemSource">Item to set in the combo box</param>
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
        /// Show a <see cref="MessageDialog"/>
        /// </summary>
        /// 
        /// <param name="grid">Grid to use</param>
        /// <param name="dialogSettings"><see cref="DialogSettings"/> of the <see cref="MessageDialog"/></param>
        /// <param name="itemSource">Item to set in the combo box</param>
        /// 
        /// <returns>
        /// <see cref="object"/> which depend of the seleccted item
        /// </returns>
        public static async Task<object> ShowSelectDialog(Grid grid, DialogSettings dialogSettings, IEnumerable itemSource)
        {
            // Create the message dialog
            SelectDialog selectDialog = new SelectDialog(dialogSettings);
            dialogLoaded = selectDialog;
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
        /// <param name="window">Window to remove the dialog</param>
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
        /// Close the <see cref="MessageDialog"/>
        /// </summary>
        /// 
        /// <param name="grid">Grid to remove the dialog</param>
        /// 
        /// <returns>
        /// </returns>
        public static async Task CloseDialog(Grid grid)
        {
            await dialogLoaded.ExitAnimation();

            grid.Children.Remove(dialogLoaded as UIElement);
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

        private HorizontalAlignment _buttonAlignment = HorizontalAlignment.Left;
        private HorizontalAlignment _titleAlignment = HorizontalAlignment.Left;
        private HorizontalAlignment _messageAlignment = HorizontalAlignment.Left;


        /// <summary>
        /// Title to set for the dialog
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Message to set for the dialog
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Data type to enter for the dialog
        /// </summary>
        public string DataToSet { get; set; }
        /// <summary>
        /// If the input dialog must protect the input
        /// </summary>
        public bool IsProtected { get; set; }
        /// <summary>
        /// Set the default button text
        /// </summary>
        public string DefaultButton { get => _defaultButton; set { _defaultButton = value; } }

        /// <summary>
        /// Set the for the Yes button
        /// </summary>
        public string YesText { get => _yesText; set { _yesText = value; } }
        /// <summary>
        /// Set the for the No button
        /// </summary>
        public string NoText { get => _noText; set { _noText = value; } }
        /// <summary>
        /// Set the for the Custom1 button
        /// </summary>
        public string Custom1Text { get; set; }
        /// <summary>
        /// Set the for the Custom2 button
        /// </summary>
        public string Custom2Text { get; set; }

        /// <summary>
        /// Defined the button horizontal alignment
        /// </summary>
        public HorizontalAlignment ButtonAlignment { get => _buttonAlignment; set { _buttonAlignment = value; } }
        /// <summary>
        /// Defined the title horizontal alignment
        /// </summary>
        public HorizontalAlignment TitleAlignment { get => _titleAlignment; set { _titleAlignment = value; } }
        /// <summary>
        /// Defined the message horizontal alignment
        /// </summary>
        public HorizontalAlignment MessageAlignment { get => _messageAlignment; set { _messageAlignment = value; } }
    }
}
