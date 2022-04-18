using MCCalendar.Controls;
using MCCalendar.Database;
using MCCalendar.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MCCalendar.Windows
{
    /// <summary>
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class AppointmentWindow : Window
    {
        private DateTime date;
        private string startTime;
        private string endTime;
        private string empName;
        private string clientName;

        /// <summary>
        /// No parameter constructor initializing the window.
        /// </summary>
        public AppointmentWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor required for setting up the appointment window with only a start time.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="empName"></param>
        /// /// <param name="clientName"></param>
        public AppointmentWindow(DateTime date, string time, string empName, string clientName)
        {
            InitializeComponent();

            this.date = date;
            this.startTime = time;
            this.endTime = "";
            this.empName = empName;
            this.clientName = clientName;
            SetupAppointment();
        }

        /// <summary>
        /// Constructor required for setting up the appointment window with both start and end time.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="empName"></param>
        /// /// <param name="clientName"></param>
        public AppointmentWindow(DateTime date, string startTime, string endTime, string empName, string clientName)
        {
            InitializeComponent();

            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;
            this.empName = empName;
            this.clientName = clientName;
            SetupAppointment();
        }

        /// <summary>
        /// Method responsible for displaying the selected information on the window.
        /// </summary>
        private void SetupAppointment()
        {
            // Fill drop down box with employee names and select chosen employee.
            for (int i = 0; i < empBox.Items.Count; i++)
            {
                ComboBoxItem item = (ComboBoxItem)empBox.Items[i];
                if (item.Content.Equals(empName))
                    empBox.SelectedIndex = i;
            }

            // Fill the drop down box with client names
            using (var db = new CalendarContext())
            {
                custCombo.ItemsSource = db.clients.ToList();
            }

            if (!clientName.Equals(""))
                custCombo.Text = clientName;

            // Display selected time and date.
            dateBox.Text = date.ToString("dddd, MMMM dd, yyyy");

            Appointment apt = findAppointment();

            if (apt == null)
            {
                startTimeBox.Text = startTime;
                endTimeBox.Text = endTime;                
            }
            else
            {
                startTimeBox.Text = apt.start;
                endTimeBox.Text = apt.end;

                if (apt != null)
                    noteBox.Text = apt.note;
            }
        }

        /// <summary>
        /// Event triggerred when the user clicks on the "save" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAppointment(object sender, RoutedEventArgs e)
        {
            if (!dateBox.Text.Equals("") && !empBox.Text.Equals("") && !custCombo.Text.Equals("")
                && !startTimeBox.Text.Equals(""))
            {
                Appointment appointment = findAppointment();

                if (appointment == null)
                {
                    saveAppointment();
                    MessageBox.Show("Appointment has been successfully added!");
                }
                else
                {
                    deleteAppointment(appointment);
                    saveAppointment();
                }

                AppointmentControl appointmentControl = new AppointmentControl(date);
                ((MainWindow)Application.Current.MainWindow).changeControl(appointmentControl); 

                this.Close();
            }
            else
                MessageBox.Show("Please enter information");
        }

        /// <summary>
        /// Method responsible for saving the appointment to the database.
        /// </summary>
        private void saveAppointment()
        {
            addMissingFields();
            using (var db = new CalendarContext())
            {
                db.Add(new Appointment
                {
                    date = Convert.ToDateTime(dateBox.Text),
                    start = startTimeBox.Text,
                    end = endTimeBox.Text,
                    employeeName = empBox.Text,
                    clientName = custCombo.Text,
                    note = noteBox.Text
                });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Event triggerred when the user clicks on the "delete" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAppointment(object sender, RoutedEventArgs e)
        {
            Appointment appointment = findAppointment();

            //Check if user actually wants to delete the chosen invoice.
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to remove this appointment?",
                "Delete Confirmation", MessageBoxButton.YesNo);
            if (appointment != null && messageBoxResult == MessageBoxResult.Yes)
            {
                deleteAppointment(appointment);
                MessageBox.Show("Appointment has been successfully removed!");

                AppointmentControl appointmentControl = new AppointmentControl(date);
                ((MainWindow)Application.Current.MainWindow).changeControl(appointmentControl);
                this.Close();
            }
        }

        /// <summary>
        /// Method responsible for deleting an appointment from the database.
        /// </summary>
        /// <param name="appointment"></param>
        private void deleteAppointment(Appointment appointment)
        {
            using (var db = new CalendarContext())
            {
                db.Remove(appointment);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Method responsible for checking if the appointment already exists.
        /// </summary>
        /// <returns></returns>
        private Appointment findAppointment()
        {
            using (var db = new CalendarContext())
            {
                Appointment appointment = db.appointments
                    .Where(a => a.clientName == custCombo.Text)
                    .Where(a => a.employeeName == empBox.Text)
                    .Where(a => a.date == Convert.ToDateTime(dateBox.Text)).FirstOrDefault();

                return appointment;
            }
        }

        /// <summary>
        /// Method responsible for adding clients to the DB if they don't exist.
        /// </summary>
        private void addMissingFields()
        {
            using (var db = new CalendarContext())
            {
                Client client = db.clients.FirstOrDefault(c => c.name.Equals(custCombo.Text));
                // If client isn't in the database, add it.
                if (client == null)
                {
                    db.Add(new Client
                    {
                        name = custCombo.Text,
                        phone = ""                        
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
