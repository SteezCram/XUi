using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XUi.Controls.Dialog
{
    /// <summary>
    /// Interface for all the dialog, implement base method to interact with a dialog
    /// </summary>
    public interface IDialog
    {
        /// <summary>
        /// Wait the message result of the user
        /// </summary>
        /// <returns></returns>
        Task<MessageResult> WaitMessageResult();
        /// <summary>
        /// Start the exit animation for the dialog
        /// </summary>
        /// 
        /// <returns></returns>
        Task ExitAnimation();
        /// <summary>
        /// Loaded event of the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DialogLoaded(object sender, RoutedEventArgs e);
    }
}
