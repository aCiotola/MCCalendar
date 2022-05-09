using MCCalendar.Windows;
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

namespace MCCalendar.Controls
{
    /// <summary>
    /// Interaction logic for CalendarControl.xaml
    /// </summary>
    public partial class CalendarControl : UserControl
    {
        private Label[] labels; //Keep track of calendar labels.
        private int monthNum = -1; //Keep track of current month.
        private int yearNum = -1; //Keep track of current year.

        /// <summary>
        /// No parameter constructir which initializes components and sets up the calendar.
        /// </summary>
        public CalendarControl()
        {
            InitializeComponent();

            PrepareCells();
            SetupCalendar(DateTime.Now);
        }

        /// <summary>
        /// Responsible for setting up the current month of the calendar.
        /// </summary>
        /// <param name="time"></param>
        private void SetupCalendar(DateTime time)
        {
            DateTime date = time;
            monthNum = date.Month;
            yearNum = date.Year;
            monthName.Content = date.ToString("MMMM yyyy");

            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string startName = firstDayOfMonth.ToString("dddd");
            string endName = lastDayOfMonth.ToString("dddd");

            string[] startEnd = new string[2];
            startEnd[0] = startName;
            startEnd[1] = endName;

            int[] startEndCol = new int[2];
            startEndCol[0] = -1;
            startEndCol[1] = -1;

            //Find out where the 1st day begins and where the last day ends.
            for (int i = 0; i < 2; i++)
            {
                switch (startEnd[i])
                {
                    case "Sunday":
                        startEndCol[i] = 0;
                        break;
                    case "Monday":
                        startEndCol[i] = 1;
                        break;
                    case "Tuesday":
                        startEndCol[i] = 2;
                        break;
                    case "Wednesday":
                        startEndCol[i] = 3;
                        break;
                    case "Thursday":
                        startEndCol[i] = 4;
                        break;
                    case "Friday":
                        startEndCol[i] = 5;
                        break;
                    case "Saturday":
                        startEndCol[i] = 6;
                        break;
                }
            }

            //Set the contents of the buttons to the day of the month.
            int count = 0;
            for (int i = startEndCol[1]; i < labels.Length; i++)
            {
                count++;
                labels[i].Content = count+"";

                if (count == lastDayOfMonth.Day)
                    break;
            }
        }

        /// <summary>
        /// Map the buttons to a position in an array for ease of content control.
        /// </summary>
        private void PrepareCells()
        {
            labels = new Label[42];
            labels[0] = btn0;
            labels[1] = btn1;
            labels[2] = btn2;
            labels[3] = btn3;
            labels[4] = btn4;
            labels[5] = btn5;
            labels[6] = btn6;
            labels[7] = btn7;
            labels[8] = btn8;
            labels[9] = btn9;
            labels[10] = btn10;
            labels[11] = btn11;
            labels[12] = btn12;
            labels[13] = btn13;
            labels[14] = btn14;
            labels[15] = btn15;
            labels[16] = btn16;
            labels[17] = btn17;
            labels[18] = btn18;
            labels[19] = btn19;
            labels[20] = btn20;
            labels[21] = btn21;
            labels[22] = btn22;
            labels[23] = btn23;
            labels[24] = btn24;
            labels[25] = btn25;
            labels[26] = btn26;
            labels[27] = btn27;
            labels[28] = btn28;
            labels[29] = btn29;
            labels[30] = btn30;
            labels[31] = btn31;
            labels[32] = btn32;
            labels[33] = btn33;
            labels[34] = btn34;
            labels[35] = btn35;
            labels[36] = btn36;
            labels[37] = btn37;
            labels[38] = btn38;
            labels[39] = btn39;
            labels[40] = btn40;
            labels[41] = btn41;
        }

        /// <summary>
        /// Empty all button content so it's ready for use again.
        /// </summary>
        private void ClearCells()
        {
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Content = "";
            }
        }

        /// <summary>
        /// When clicking a button, open the schedule window with the clicked date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label label = sender as Label;
            if (!label.Content.Equals(""))
            {
                int day = Int32.Parse(label.Content+"");

                DateTime date = new DateTime(yearNum, monthNum, day);
                AppointmentControl appointmentControl = new AppointmentControl(date);

                //Used to call methods and objects from the MainWindow Window.
                ((MainWindow)Application.Current.MainWindow).listViewMenu.SelectedIndex = 1;
                ((MainWindow)Application.Current.MainWindow).changeControl(appointmentControl);                
            }
        }

        /// <summary>
        /// Responsible for changing the month to the next month.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearCells();
            if (monthNum == 12)
            {
                monthNum = 1;
                yearNum += 1;
                SetupCalendar(new DateTime(yearNum, monthNum, 1));
            }
            else
                SetupCalendar(new DateTime(yearNum, monthNum + 1, 1));
        }

        /// <summary>
        /// Responsible for changing the month to the previous month.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearCells();
            if (monthNum == 1)
            {
                monthNum = 12;
                yearNum = yearNum - 1;
                SetupCalendar(new DateTime(yearNum, monthNum, 1));
            }
            else
                SetupCalendar(new DateTime(yearNum, monthNum - 1, 1));
        }
    }
}
