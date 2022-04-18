using System;

namespace MCCalendar.Models
{
    public class Appointment
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string clientName { get; set; }
        public string employeeName { get; set; }
        public string note { get; set; }

        /// <summary>
        /// No parameter constructor for initialization.
        /// </summary>
        public Appointment()
        { }

        /// <summary>
        /// Constructor for initializing the variables.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="clientName"></param>
        /// <param name="employeeName"></param>
        /// <param name="note"></param>
        public Appointment(int id, DateTime date, string start, string end, string clientName, 
            string employeeName, string note)
        {
            this.id = id;
            this.date = date;
            this.start = start;
            this.end = end;
            this.clientName = clientName;
            this.employeeName = employeeName;
            this.note = note;
        }

        /// <summary>
        /// Method responsible for displaying the class variables as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "ID: " + id + "\nDate: " + date + "\nStart: " + start + "\nEnd: " + end + "\nCustomer Name: " +
                clientName + "\nEmployee Name: " + employeeName;
        }
    }
}
