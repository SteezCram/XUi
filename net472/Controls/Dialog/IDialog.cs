using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XUi.Controls.Dialog
{
    public interface IDialog
    {
        Task<MessageResult> WaitMessageResult();
        Task ExitAnimation();

        void DialogLoaded(object sender, RoutedEventArgs e);
    }
}
