using MCCalendar.Database;
using MCCalendar.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MCCalendar.Controls
{
    /// <summary>
    /// Interaction logic for ClientControl.xaml
    /// </summary>
    public partial class ClientControl : UserControl
    {
        private static Client selectedClient = null;

        /// <summary>
        /// No parameter constructor for setting up the client control.
        /// </summary>
        public ClientControl()
        {
            InitializeComponent();
            setDataGrid();
        }

        /// <summary>
        /// Method responsible for saving/updating the client information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveClient(object sender, RoutedEventArgs e)
        {
            if (!nameText.Text.Equals("")) // A name is required.
            {
                if (selectedClient == null)
                    createClient();
                else
                {
                    deleteClient(selectedClient);
                    createClient();
                }

                setDataGrid();
                clearFields();
            }
            else
                MessageBox.Show("Please enter the name of the client!");
        }

        /// <summary>
        /// Event triggered when a row is selected.
        /// EDIT: anything but first column.
        /// DELETE: first column only.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectClient(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                selectedClient = (Client)dataGrid.SelectedItem;
                int index = dataGrid.CurrentCell.Column.DisplayIndex;

                // Check if first column is chosen for deletion.
                if (index == 0)
                    deleteClientPrompt();
                else
                    displaySelectedClient();

                dataGrid.SelectedItem = null;
            }
        }

        /// <summary>
        /// Method responsible for displaying selected row on fields.
        /// </summary>
        private void displaySelectedClient()
        {
            nameText.Text = selectedClient.name;
            phoneText.Text = selectedClient.phone;
        }

        /// <summary>
        /// Method responsible for displaying the delete promt to the user.
        /// </summary>
        private void deleteClientPrompt()
        {
            Client client = (Client)dataGrid.Items[dataGrid.SelectedIndex];

            //Check if user actually wants to delete the chosen invoice.
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to remove " + client.name + "?",
                "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                deleteClient(client);
                setDataGrid();
                clearFields();
            }
        }


        /// <summary>
        /// Method responsible for setting the client datagrid with all clients in the database.
        /// </summary>
        private void setDataGrid()
        {
            List<Client> clients = readClients();
            dataGrid.ItemsSource = clients;
        }

        /*****************************************************************
         *                                                               *
         * The following are methods that interact with the database.    *
         *                                                               *
         *****************************************************************/

        /// <summary>
        /// Method responsible for adding a person to the database.
        /// </summary>
        private void createClient()
        {
            using (var db = new CalendarContext())
            {
                db.Add(new Client
                {
                    name = nameText.Text,
                    phone = phoneText.Text             
                });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Method responsible for returning a list of all clients.
        /// </summary>
        /// <returns></returns>
        private List<Client> readClients()
        {
            List<Client> clients = new List<Client>();
            using (var db = new CalendarContext())
            {
                clients = db.clients.OrderBy(c => c.name).ToList();
            }

            return clients;
        }

        /// <summary>
        /// Method responsible for deleting a client in the database.
        /// </summary>
        /// <param name="client"></param>
        private void deleteClient(Client client)
        {
            using (var db = new CalendarContext())
            {
                db.Remove(client);
                db.SaveChanges();
            }
            selectedClient = null;
        }

        /*****************************************************************
         *                                                               *
         * The following are methods that change the UI.                 *
         *                                                               *
         *****************************************************************/

        /// <summary>
        /// Event triggerred when a user clicks on the "clear" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearFields(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

        /// <summary>
        /// Method responsible for clearing all fields and selected items.
        /// </summary>
        private void clearFields()
        {
            selectedClient = null;
            dataGrid.SelectedItem = null;

            nameText.Text = "";
            phoneText.Text = "";
        }
    }
}
