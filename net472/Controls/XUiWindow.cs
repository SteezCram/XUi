using MahApps.Metro.IconPacks;
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
    /// XUiWindow, wrap the <see cref="WindowStyle.ThreeDBorderWindow"/> into the XUi style
    /// Support <see cref="Dialog.Dialog"/> from XUi
    /// </summary>
    /// 
    /// <remarks>
    /// Implement a default DataContext, you can't put a DataContext on the XUiWindow itself, you must set it to another control
    /// </remarks>
    public class XUiWindow : Window
    {
        /// <summary>
        /// Set the Window top bar brush
        /// </summary>
        public SolidColorBrush WindowBarBrush
        {
            get { return (SolidColorBrush)GetValue(WindowBarBrushProperty); }
            set { SetValue(WindowBarBrushProperty, value); }
        }
        /// <summary>
        /// Window top bar brush DependencyProperty
        /// </summary>
        public static readonly DependencyProperty WindowBarBrushProperty = DependencyProperty.Register("WindowBarBrush", typeof(SolidColorBrush), typeof(XUiWindow), new UIPropertyMetadata(Brushes.Black));

        static XUiWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XUiWindow), new FrameworkPropertyMetadata(typeof(XUiWindow)));
        }

        /// <summary>
        /// Show a <see cref="Window"/> with a native <see cref="Dialog.Dialog"/> support and the XUi flat style applied
        /// </summary>
        public XUiWindow()
        {
            // Load the default DataContext for the native Window behaviour
            // That's mean you can't put a DataContext on XUiWindowTool
            this.DataContext = new XUiWindowViewModel(this);

            this.Loaded += (sender, e) =>
            {
                // Add the hook on the Window
                XUiWindowViewModel xUiWindowViewModel = this.DataContext as XUiWindowViewModel;
                xUiWindowViewModel.WindowHandle = new WindowInteropHelper(this).Handle;
                HwndSource.FromHwnd(xUiWindowViewModel.WindowHandle).AddHook(xUiWindowViewModel.WindowResizer.WindowProc);
            };
        }

        /// <summary>
        /// Internal view model of <see cref="XUiWindowTool"/>
        /// </summary>
        internal class XUiWindowViewModel : BaseViewModel
        {
            #region Public Members

            public WindowResizer WindowResizer { get; set; }
            public IntPtr WindowHandle { get; set; }

            public CornerRadius BorderCorner { get => _borderCorner; set { if (_borderCorner != value) { _borderCorner = value; OnPropertyChanged(); } } }
            public PackIconMaterialKind MaximizeIcon { get => _maximizeIcon; set { if (_maximizeIcon != value) { _maximizeIcon = value; OnPropertyChanged(); } } }

            #endregion

            #region Commands

            public ICommand MinimizeCommand { get; set; }
            public ICommand MaximizeCommand { get; set; }
            public ICommand CloseCommand { get; set; }
            public ICommand MenuCommand { get; set; }
            public ICommand SizeChanged { get; set; }

            #endregion

            #region Private Members

            private readonly Window _window;

            private CornerRadius _borderCorner = ((CornerRadius)XUiTheme.XUiDictionaries["CornerRadius"]);
            private PackIconMaterialKind _maximizeIcon = PackIconMaterialKind.WindowMaximize;

            #endregion

            /// <summary>
            /// Main constructor for XUi_Window
            /// </summary>
            /// 
            /// <param name="window"><see cref="Window"/> to set up the view model</param>
            public XUiWindowViewModel(Window window)
            {
                _window = window;
                // Set window resizer behaviour
                WindowResizer = new WindowResizer(_window);

                // Create all the window command
                CloseCommand = new RelayCommand(() => WindowResizer.SendMessage(WindowHandle, NativeMethods.WM_SYSCOMMAND, new IntPtr(NativeMethods.SC_CLOSE), IntPtr.Zero));
                MinimizeCommand = new RelayCommand(() => WindowResizer.SendMessage(WindowHandle, NativeMethods.WM_SYSCOMMAND, new IntPtr(NativeMethods.SC_MINIMIZE), IntPtr.Zero));
                MaximizeCommand = new RelayCommand(() =>
                {
                    if (_window.WindowState != WindowState.Maximized)
                    {
                        // Remove all the extra space
                        BorderCorner = new CornerRadius(0);
                        MaximizeIcon = PackIconMaterialKind.WindowRestore;
                    }
                    else
                    {
                        // Set all the extra space
                        BorderCorner = ((CornerRadius)XUiTheme.XUiDictionaries["CornerRadius"]);
                        MaximizeIcon = PackIconMaterialKind.WindowMaximize;
                    }

                    _window.WindowState ^= WindowState.Maximized;
                });

                // Create the menu command
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

                // Create the size changed command
                SizeChanged = new RelayCommand(() =>
                {
                    if (_window.WindowState == WindowState.Maximized)
                    {
                        // Remove all the extra space
                        BorderCorner = new CornerRadius(0);
                        MaximizeIcon = PackIconMaterialKind.WindowRestore;
                    }
                    else
                    {
                        // Set all the extra space
                        BorderCorner = ((CornerRadius)XUiTheme.XUiDictionaries["CornerRadius"]);
                        MaximizeIcon = PackIconMaterialKind.WindowMaximize;
                    }
                });
            }
        }
    }
}
