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
        private Button[] buttons; //Keep track of button text.
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
            fillBorders();
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
            for (int i = startEndCol[0]; i < buttons.Length; i++)
            {
                count++;
                buttons[i].Content = count;

                if (count == lastDayOfMonth.Day)
                    break;
            }
        }

        /// <summary>
        /// Map the buttons to a position in an array for ease of content control.
        /// </summary>
        private void PrepareCells()
        {
            buttons = new Button[42];
            buttons[0] = btn0;
            buttons[1] = btn1;
            buttons[2] = btn2;
            buttons[3] = btn3;
            buttons[4] = btn4;
            buttons[5] = btn5;
            buttons[6] = btn6;
            buttons[7] = btn7;
            buttons[8] = btn8;
            buttons[9] = btn9;
            buttons[10] = btn10;
            buttons[11] = btn11;
            buttons[12] = btn12;
            buttons[13] = btn13;
            buttons[14] = btn14;
            buttons[15] = btn15;
            buttons[16] = btn16;
            buttons[17] = btn17;
            buttons[18] = btn18;
            buttons[19] = btn19;
            buttons[20] = btn20;
            buttons[21] = btn21;
            buttons[22] = btn22;
            buttons[23] = btn23;
            buttons[24] = btn24;
            buttons[25] = btn25;
            buttons[26] = btn26;
            buttons[27] = btn27;
            buttons[28] = btn28;
            buttons[29] = btn29;
            buttons[30] = btn30;
            buttons[31] = btn31;
            buttons[32] = btn32;
            buttons[33] = btn33;
            buttons[34] = btn34;
            buttons[35] = btn35;
            buttons[36] = btn36;
            buttons[37] = btn37;
            buttons[38] = btn38;
            buttons[39] = btn39;
            buttons[40] = btn40;
            buttons[41] = btn41;
        }

        /// <summary>
        /// Method responsible for displaying a black border around the grids.
        /// </summary>
        private void fillBorders()
        {
            for (int i = 0; i < 7; i++)
            {
                Rectangle rec = new Rectangle()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };
                Grid.SetColumn(rec, i);
                Grid.SetRow(rec, 0);
                calGrid.Children.Add(rec);                
            }
        }

        /// <summary>
        /// Empty all button content so it's ready for use again.
        /// </summary>
        private void ClearCells()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Content = "";
            }
        }

        /// <summary>
        /// When clicking a button, open the schedule window with the clicked date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (!btn.Content.Equals(""))
            {
                int day = Int32.Parse(btn.Content.ToString());

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
