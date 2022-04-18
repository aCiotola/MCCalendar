using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MCCalendar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var sb = new StringBuilder();

            AppendExceptionMessages(sb, e.Exception);
            AppendExceptionStacktraces(sb, e.Exception);

            File.AppendAllText(@"C:\Logs\MCCalendarCrash.log", sb.ToString());
        }

        private void AppendExceptionMessages(StringBuilder sb, Exception e)
        {
            while (e != null)
            {
                sb.AppendLine("============== Exception ===============").AppendLine(e.Message);
                e = e.InnerException;
            }
        }
        private void AppendExceptionStacktraces(StringBuilder sb, Exception e)
        {
            while (e != null)
            {
                sb.AppendLine("======== Exception Stacktrace ==========").AppendLine(e.StackTrace);
                e = e.InnerException;
            }
        }
    }
}
