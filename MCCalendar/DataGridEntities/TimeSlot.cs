namespace MCCalendar.DataGridEntities
{
    class TimeSlot
    {
        public string time { get; set; }
        public string client1 { get; set; }
        public string client2 { get; set; }
        public string client3 { get; set; }

        /// <summary>
        /// No parameter constructor for initialization.
        /// </summary>
        public TimeSlot()
        { }

        public TimeSlot(string time, string client1, string client2, string client3)
        {
            this.time = time;
            this.client1 = client1;
            this.client2 = client2;
            this.client3 = client3;
        }

        /// <summary>
        /// Method responsible for displaying the class variables as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Time: " + time + "\nClient 1: " + client1 + "\nClient 2: " + client2 + "\nClient 3: " + client3;
        }
    }
}
