using GridSearchApp.Entities;
using GridSearchApp.Services;

namespace GridSearchApp
{
    public partial class Form1 : Form
    {
        private CustomerService customerService;

        private IQueryable<Customer> Customers;

        private string? searchFilter => txtSearchBar.Text;

        public Form1()
        {
            InitializeComponent();

            customerService = new CustomerService();

            LoadData();
        }

        private void LoadData()
        {
            var hasData = customerService.LoadData();
            if(hasData && customerService.Customers is not null)
            {
                Customers = customerService.Customers;
                dgvCustomers.DataSource = Customers.ToList();
               
            }
        }

        private IQueryable<Customer> GetCustomers()
        {
            if (Customers is null) return null;

            if (string.IsNullOrWhiteSpace(searchFilter)) return null;

            var filteredCustomers = Customers.Where(c => c.FirstName.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) ||
            c.LastName.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) || c.City.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) ||
            c.Country.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) || c.Phone.Contains(searchFilter, StringComparison.OrdinalIgnoreCase));

            return filteredCustomers;
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchFilter)) return;

            dgvCustomers.DataSource = GetCustomers().ToList();
        }
    }
}