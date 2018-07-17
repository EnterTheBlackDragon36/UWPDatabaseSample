using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Diagnostics;
using UWPDatabaseSample.code;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPDatabaseSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        const string connectionString = @"Data Source=DESKTOP-EUATNCH;Initial Catalog=EnterpriseManager;Integrated Security=SSPI";
        const string connectionString1 = @"Data Source=DESKTOP-EUATNCH;Initial Catalog=EmployeesDB;Integrated Security=SSPI";


        public MainPage()
        {
            this.InitializeComponent();
            EmployeeList.ItemsSource = GetEmployees(connectionString);
        }
       

        public ObservableCollection<Employee> GetEmployees(string connectionString)
        {
            //const string GetEmployeesQuery = "SELECT TOP 5 [Name], [Organization_Unit], [Group_ID], [Department], [UserName], [Default_Password] FROM Employees";

            var employees = new ObservableCollection<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = new SqlCommand("TOP5EMPLOYEES", conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            //cmd.CommandText = GetEmployeesQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var employee = new Employee();
                                    employee.Name = reader.GetString(0);
                                    employee.OrganizationUnit = reader.GetString(1);
                                    employee.GroupID = reader.GetString(2);
                                    employee.Department = reader.GetString(3);
                                    employee.Username = reader.GetString(4);
                                    employee.Password = reader.GetString(5);
                                    employees.Add(employee);
                                }
                            }
                        }
                    }
                }
                return employees;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}
