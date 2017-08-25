using Professional_calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Professional_calculator.Presenter
{
    class Presenter
    {
        MainWindow mainWindow = null;


        // Constructor
        public Presenter(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            mainWindow.KeyFilter += KeyFilter;
            // Set focus on Display
            mainWindow.MainWindowFocused += OnMainWindowFocused;
            // Button equal "=" click handler
            mainWindow.BtnEqualClik += OnBtnEqualClick;
            // Change window according to Log expanding
            mainWindow.ExpLogExpanded += OnExpLogExpanded;
            // Change window according to Log collapsing
            mainWindow.ExpLogCollapsed += OnExpLogCollapsed;
        }

        void OnMainWindowFocused(object sender, EventArgs e)
        {
            mainWindow.tbDisplay.Focus();
        }

        // Filter for keys
        public void KeyFilter(object sender, KeyEventArgs e)
        {
            if(!InputFilter.IsKeyAllowed(e.Key))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Calculate inputed into Display expression
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnBtnEqualClick(object sender, EventArgs e)
        {
            // Calculate expression
            string mathExpression = mainWindow.tbDisplay.Text;
            mainWindow.tbDisplay.Text = ArithmeticCalculator.Calculate(mathExpression).ToString();
            // Set cursor to the end
            mainWindow.tbDisplay.CaretIndex = mainWindow.tbDisplay.Text.Length;
            // 
            string newLogPost = String.Format(@"{0} =
                                {1}",mathExpression,mainWindow.tbDisplay.Text);
            mainWindow.lb_Log.Items.Add(newLogPost);
        }


        /// <summary>
        /// Handler for expanderLog event - "Expanded"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnExpLogExpanded (object sender, EventArgs e)
        {
            mainWindow.Width += mainWindow.lb_Log.Width;
        }
        /// <summary>
        /// Handler for expanderLog event - "Collapsed"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnExpLogCollapsed(object sender, EventArgs e)
        {
            mainWindow.Width -= mainWindow.lb_Log.Width;
        }
    }
}
