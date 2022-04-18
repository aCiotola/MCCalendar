namespace MCCalendar.Models
{
    /// <summary>
    /// Class responsible for representing an employee.
    /// </summary>
    public class Employee
    {        
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        public Employee()
        { }

        public Employee(int id, string name, string phone)
        { 
            this.id = id;
            this.name = name;
            this.phone = phone;
        }

        /// <summary>
        /// Method responsible for displaying the class variables as a string.
        /// </summary>
        /// <returns></returns>
        public string convertToString()
        {
            return "ID: " + id + "\nName: " + name + "\nPhone: " + phone;
        }

        /// <summary>
        /// Method responsible for returning the name of the employee.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }
}
