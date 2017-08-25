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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Professional_calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Presenter.Presenter presenter = new Presenter.Presenter(this);
        }

        /// <summary>
        /// Handler for MainWindow event - "Activated"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Activated(object sender, EventArgs e)
        {
            mainWindowFocused.Invoke(sender, e);
        }

        event EventHandler mainWindowFocused = null;
        public event EventHandler MainWindowFocused
        {
            add { mainWindowFocused += value; }
            remove { mainWindowFocused -= value; }
        }     

        /// <summary>
        /// Filter letters and another incorrect for expression symbols
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Display_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            keyFilter.Invoke(sender, e);
        }

        event KeyEventHandler keyFilter = null;
        public event KeyEventHandler KeyFilter
        {
            add { keyFilter += value; }
            remove { keyFilter -= value; }
        }


        private void btn_ClrCurrentOperand_Click(object sender, RoutedEventArgs e)
        {
            int renderingTier = (RenderCapability.Tier) >> 16;
            if (renderingTier == 0)
            {
                tbDisplay.Text = "Tier = 0";
            }
            else if (renderingTier == 1)
            {
                tbDisplay.Text = "Tier = 1";
            }
            else if (renderingTier == 2)
            {
                tbDisplay.Text = "Tier = 2";
            }
            else
                tbDisplay.Text = "Something else";
        }

        /// <summary>
        /// Handler for event "button Equal click"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            btnEqualClick.Invoke(sender, e);
        }
        /// <summary>
        /// event and itself property for handling button "Equal" click
        /// </summary>
        event EventHandler btnEqualClick = null;
        public event EventHandler BtnEqualClik
        {
            add { btnEqualClick += value; }
            remove { btnEqualClick -= value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEqual_GotFocus(object sender, RoutedEventArgs e)
        {
            tbDisplay.Focus();
        }

        /// <summary>
        /// Event handler for expanderLog event - "Expanded"
        /// </summary>
        event EventHandler expLogExpanded = null;
        public event EventHandler ExpLogExpanded
        {
            add { expLogExpanded += value; }
            remove { expLogExpanded -= value; }
        }
        private void expndLog_Expanded(object sender, RoutedEventArgs e)
        {
            expLogExpanded.Invoke(sender, e);
        }

        /// <summary>
        /// Event handler for expanderLog event - "Collapsed"
        /// </summary>
        event EventHandler expLogCollapsed = null;
        public event EventHandler ExpLogCollapsed
        {
            add { expLogCollapsed += value; }
            remove { expLogCollapsed -= value; }
        }
        private void expndLog_Collapsed(object sender, RoutedEventArgs e)
        {
            expLogCollapsed.Invoke(sender, e);
        }
    }
}
