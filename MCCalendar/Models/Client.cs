namespace MCCalendar.Models
{
    /// <summary>
    /// Class responsible for representing a client.
    /// </summary>
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        public Client() 
        { 
        
        }

        /// <summary>
        /// Constructor for setting up a Client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        public Client(int id, string name, string phone)
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
        /// Method responsible for returning the name of the client.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }
}
