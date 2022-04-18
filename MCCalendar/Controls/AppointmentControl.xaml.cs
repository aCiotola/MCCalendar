using MCCalendar.Database;
using MCCalendar.DataGridEntities;
using MCCalendar.Models;
using MCCalendar.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MCCalendar.Controls
{
    /// <summary>
    /// Interaction logic for AppointmentControl.xaml
    /// User Control responsible for displaying and interacting with the Schedule
    /// </summary>
    public partial class AppointmentControl : UserControl
    {
        private DateTime date;
        private string startTime = "";

        /// <summary>
        /// No param constructor for showing appointments on current date.
        /// </summary>
        public AppointmentControl()
        {
            InitializeComponent();
            this.date = DateTime.Now;
            SetupSchedule();
        }

        /// <summary>
        /// Param constructor for showing schedule for chosen date.
        /// </summary>
        /// <param name="date"></param>
        public AppointmentControl(DateTime date)
        {
            InitializeComponent();
            this.date = date;            
            SetupSchedule();
        }

        /// <summary>
        /// Method responsible for setting up schedule for current date
        /// </summary>
        private void SetupSchedule()
        {
            dateLbl.Content = date.ToString("dddd, MMMM dd, yyyy");
            List<Appointment> appointmentList = readAppointments();
            List<Employee> employeeList = readEmployees();
            for (int i = 0; i < employeeList.Count; i++)
                dataGrid.Columns[i+1].Header = employeeList[i].name; //Set DataGrid header employee names.

            List<TimeSlot> timeSlotList = new List<TimeSlot>();
            DateTime moment = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
            for (int i = 0; i < 49; i++)
            {
                TimeSlot timeSlot = new TimeSlot();
                timeSlot.time = moment.ToString("hh:mm tt");
                timeSlot.client1 = "";
                timeSlot.client2 = "";
                timeSlot.client3 = "";

                for (int j = 0; j < appointmentList.Count; j++)
                {                    
                    //Check if there's an appointment at this time, add it to the proper employee.
                    if (timeSlot.time.Equals(appointmentList[j].start))
                    {
                        if (appointmentList[j].employeeName.Equals(employeeList[0].name))
                            timeSlot.client1 = appointmentList[j].clientName;
                        else if (appointmentList[j].employeeName.Equals(employeeList[1].name))
                            timeSlot.client2 = appointmentList[j].clientName;
                        else if (appointmentList[j].employeeName.Equals(employeeList[2].name))
                            timeSlot.client3 = appointmentList[j].clientName;
                    }

                    // Show block where client is scheduled
                    if (!timeSlot.time.Equals(appointmentList[j].start) && !appointmentList[j].end.Equals("") && 
                        Convert.ToDateTime(timeSlot.time) >= Convert.ToDateTime(appointmentList[j].start) &&
                        Convert.ToDateTime(appointmentList[j].end) > Convert.ToDateTime(timeSlot.time))
                    {
                        if (appointmentList[j].employeeName.Equals(employeeList[0].name))
                            timeSlot.client1 = " ";//Change color BG
                        else if (appointmentList[j].employeeName.Equals(employeeList[1].name))
                            timeSlot.client2 = " ";
                        else if (appointmentList[j].employeeName.Equals(employeeList[2].name))
                            timeSlot.client3 = " ";
                    }
                }

                timeSlotList.Add(timeSlot);
                moment = moment.AddMinutes(15);
            }

            dataGrid.ItemsSource = timeSlotList; // Set DataGrid
        }

        /// <summary>
        /// Method responsible for returning a list of employees.
        /// </summary>
        /// <returns></returns>
        private List<Employee> readEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (var db = new CalendarContext())
            {
                employees = db.employees.OrderBy(e => e.name).ToList();
            }
            return employees;
        }

        /// <summary>
        /// Method responsible for returning a list of appointments.
        /// </summary>
        /// <returns></returns>
        private List<Appointment> readAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            using (var db = new CalendarContext())
            {
                appointments = db.appointments.Where(a => a.date == date).OrderBy(a => a.date).ToList();
            }
            return appointments;
        }

        /// <summary>
        /// Event triggered when someone let's go of mouse click.
        /// Will set the time and employee of the appointment and open the appointment window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setEndTime(object sender, MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;

            if (dataGrid.CurrentCell.Column != null)
            {
                string empName = dataGrid.CurrentCell.Column.Header.ToString();
                if (row == null || empName.Equals("Time") || empName.Equals(""))
                    return;

                var cellInfo = dataGrid.SelectedCells[dataGrid.CurrentCell.Column.DisplayIndex];
                string clientName = ((TextBlock)cellInfo.Column.GetCellContent(cellInfo.Item)).Text;

                TimeSlot tSlot = (TimeSlot)row.Item;

                Appointment apt = checkAppointment(startTime, empName);
                if (apt != null)
                {
                    AppointmentWindow window = new AppointmentWindow(date, apt.start, apt.end, apt.employeeName, apt.clientName);
                    window.Show();
                }
                else 
                {
                    AppointmentWindow window = new AppointmentWindow(date, startTime, tSlot.time, empName, clientName);
                    window.Show();
                }

                dataGrid.SelectedItem = null; // Remove highlighted effect
            }
        }

        /// <summary>
        /// Event triggered when someone clicks the mouse button.
        /// Will set the start time of the appointment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setStartTime(object sender, MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            if (row == null)
                return;

            TimeSlot tSlot = (TimeSlot)row.Item;
            startTime = tSlot.time;
        }

        /// <summary>
        /// Method responsible for checking if an already booked appointment is clicked on.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="empName"></param>
        /// <returns></returns>
        private Appointment checkAppointment(string startTime, string empName)
        {
            Appointment appointment = new Appointment();
            using (var db = new CalendarContext())
            {
                appointment = db.appointments
                    .Where(a => a.date == date)
                    .Where(e => e.employeeName.Equals(empName))
                    .ToList()
                    .Where(t => Convert.ToDateTime(t.start) <= Convert.ToDateTime(startTime))
                    .Where(t => Convert.ToDateTime(t.end) >= Convert.ToDateTime(startTime))
                    .FirstOrDefault();
            }

            return appointment;
        }
    }
}
