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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XUi.Controls
{
    /// <summary>
    /// XUiWindowTool, wrap the <see cref="WindowStyle.ToolWindow"/> into the XUi style
    /// Don't support <see cref="Dialogs.Dialog"/> from XUi
    /// </summary>
    /// 
    /// <remarks>
    /// Implement a default DataContext, you can't put a DataContext on the XUiWindow itself, you must set it to another control
    /// </remarks>
    public class XUiWindowTool : Window
    {
        /// <summary>
        /// Set the Window top bar brush
        /// </summary>
        public SolidColorBrush WindowBarBrush
        {
            get { return (SolidColorBrush)GetValue(WindowBarBrushProperty); }
            set { SetValue(WindowBarBrushProperty, value); }
        }
        public static readonly DependencyProperty WindowBarBrushProperty = DependencyProperty.Register("WindowBarBrush", typeof(SolidColorBrush), typeof(XUiWindowTool), new UIPropertyMetadata(Brushes.Black));

        static XUiWindowTool()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XUiWindowTool), new FrameworkPropertyMetadata(typeof(XUiWindowTool)));
        }

        public XUiWindowTool()
        {
            // Load the default DataContext for the native Window behaviour
            // That's mean you can't put a DataContext on XUiWindowTool
            this.DataContext = new XUiWindowToolViewModel(this);

            this.Loaded += (sender, e) =>
            {
                // Add the hook on the Window
                XUiWindowToolViewModel xUiWindowViewModel = this.DataContext as XUiWindowToolViewModel;
                xUiWindowViewModel.WindowHandle = new WindowInteropHelper(this).Handle;
                HwndSource.FromHwnd(xUiWindowViewModel.WindowHandle).AddHook(xUiWindowViewModel.WindowResizer.WindowProc);
            };
        }

        /// <summary>
        /// Internal view model of <see cref="XUiWindowTool"/>
        /// </summary>
        internal class XUiWindowToolViewModel : BaseViewModel
        {
            #region Public Members

            public WindowResizer WindowResizer { get; set; }
            public IntPtr WindowHandle { get; set; }

            #endregion

            #region Commands
            public ICommand CloseCommand { get; set; }
            public ICommand MenuCommand { get; set; }

            #endregion

            #region Private Members

            private Window _window;

            #endregion

            /// <summary>
            /// Main constructor for XUi_Window
            /// </summary>
            /// 
            /// <param name="window"><see cref="Window"/> to set up the view model</param>
            public XUiWindowToolViewModel(Window window)
            {
                _window = window;
                // Set window resizer behaviour
                WindowResizer = new WindowResizer(_window);

                CloseCommand = new RelayCommand(() => WindowResizer.SendMessage(WindowHandle, NativeMethods.WM_SYSCOMMAND, new IntPtr(NativeMethods.SC_CLOSE), IntPtr.Zero));
                MenuCommand = new RelayCommand(() =>
                {
                    // Get the mouse position
                    Point mousePosition = Mouse.GetPosition(_window);
                    Point screenPosition;
                    // Create the screen position
                    if (_window.WindowState != WindowState.Maximized)
                        screenPosition = new Point(_window.Left, 30 + _window.Top);
                    else
                        screenPosition = new Point(0, 30);

                    // Display the system menu
                    SystemCommands.ShowSystemMenu(_window, screenPosition);
                });
            }
        }
    }
}
