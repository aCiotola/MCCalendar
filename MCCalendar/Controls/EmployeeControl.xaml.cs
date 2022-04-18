using MCCalendar.Database;
using MCCalendar.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MCCalendar.Controls
{
    /// <summary>
    /// Interaction logic for EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        private static Employee selectedEmployee = null;

        /// <summary>
        /// No parameter constructor for setting up the employee control.
        /// </summary>
        public EmployeeControl()
        {
            InitializeComponent();
            setDataGrid();
        }

        /// <summary>
        /// Method responsible for saving/updating the employee information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveEmployee(object sender, RoutedEventArgs e)
        {
            if (!nameText.Text.Equals("")) // A name is required.
            {
                if (selectedEmployee == null)
                    createEmployee();
                else
                {
                    deleteEmployee(selectedEmployee);
                    createEmployee();
                }

                setDataGrid();
                clearFields();
            }
            else
                MessageBox.Show("Please enter the name of the person!");
        }

        /// <summary>
        /// Event triggered when a row is selected.
        /// EDIT: anything but first column.
        /// DELETE: first column only.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectEmployee(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                selectedEmployee = (Employee)dataGrid.SelectedItem;
                int index = dataGrid.CurrentCell.Column.DisplayIndex;

                // Check if first column is chosen for deletion.
                if (index == 0)
                    deleteEmployeePrompt();
                else
                    displaySelectedEmployee();

                dataGrid.SelectedItem = null;
            }
        }

        /// <summary>
        /// Method responsible for displaying selected row on fields.
        /// </summary>
        private void displaySelectedEmployee()
        {
            nameText.Text = selectedEmployee.name;
            phoneText.Text = selectedEmployee.phone;
        }

        /// <summary>
        /// Method responsible for displaying the delete promt to the user.
        /// </summary>
        private void deleteEmployeePrompt()
        {
            Employee employee = (Employee)dataGrid.Items[dataGrid.SelectedIndex];

            //Check if user actually wants to delete the chosen invoice.
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to remove " + employee.name + "?",
                "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                deleteEmployee(employee);
                setDataGrid();
                clearFields();
            }
        }


        /// <summary>
        /// Method responsible for setting the client datagrid with all clients in the database.
        /// </summary>
        private void setDataGrid()
        {
            List<Employee> employees = readEmployees();
            dataGrid.ItemsSource = employees;
        }

        /*****************************************************************
         *                                                               *
         * The following are methods that interact with the database.    *
         *                                                               *
         *****************************************************************/

        /// <summary>
        /// Method responsible for adding an employee to the database.
        /// </summary>
        private void createEmployee()
        {
            using (var db = new CalendarContext())
            {
                db.Add(new Employee
                {
                    name = nameText.Text,
                    phone = phoneText.Text             
                });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Method responsible for returning a list of all employees.
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
        /// Method responsible for deleting a person in the database.
        /// </summary>
        /// <param name="employee"></param>
        private void deleteEmployee(Employee employee)
        {
            using (var db = new CalendarContext())
            {
                db.Remove(employee);
                db.SaveChanges();
            }
            selectedEmployee = null;
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
            selectedEmployee = null;
            dataGrid.SelectedItem = null;

            nameText.Text = "";
            phoneText.Text = "";
        }
    }
}
