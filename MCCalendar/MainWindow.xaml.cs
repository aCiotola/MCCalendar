using MCCalendar.Controls;
using MCCalendar.Database;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MCCalendar
{
    /// <summary>
    /// Window that will display the month calendar with clickable dates.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// No parameter constructir which initializes components and sets up the calendar.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //Only to load EF models so it will not freeze later
            using (var db = new CalendarContext())
            {
                db.clients.Where(c => c.id < 0).ToList();
            }

            // Main page is the expenses.
            UserControl usc = new CalendarControl();
            mainWindow.Children.Add(usc);
        }

        /// <summary>
        /// Event triggerred when clicking on a nav bar.
        /// Will display the selected control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectedNavigation(object sender, SelectionChangedEventArgs e)
        {
            mainWindow.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "itemCalendar":
                    mainWindow.Children.Add(new CalendarControl());
                    break;
                case "itemAppointments":
                    mainWindow.Children.Add(new AppointmentControl());
                    break;
                case "itemEmployees":
                    mainWindow.Children.Add(new EmployeeControl());
                    break;
                case "itemClients":
                    mainWindow.Children.Add(new ClientControl());
                    break;
                default:
                    mainWindow.Children.Add(new CalendarControl());
                    break;
            }
        }

        /// <summary>
        /// Method responsible for changing the window to the selected date.
        /// </summary>
        /// <param name="usc"></param>
        public void changeControl(UserControl usc)
        {
            mainWindow.Children.Clear();
            mainWindow.Children.Add(usc);
        }
    }    
}
