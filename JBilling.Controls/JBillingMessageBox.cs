using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBilling.Controls
{
    /// <summary>
    /// A custom message box for JBilling application.
    /// </summary>
    public static class JBillingMessageBox
    {
        /// <summary>
        /// Shows execption for JBilling application.
        /// </summary>
        /// <param name="ex">Exception to be shown to user.</param>
        public static void ShowException(Exception ex)
        {
            MessageBox.Show(ex.Message, "JBilling Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows custom execption for JBilling application.
        /// </summary>
        /// <param name="ex">Exception to be shown to user.</param>
        public static void ShowException(string ex)
        {
            MessageBox.Show(ex, "JBilling Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
