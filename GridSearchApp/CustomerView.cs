using GridSearchApp.Entities;
using GridSearchApp.Services;

namespace GridSearchApp
{
    public partial class CustomerView : Form
    {
        private CustomerService customerService;

        private IQueryable<Customer> customers;

        private string? searchFilter => txtSearchBar.Text;

        public CustomerView()
        {
            InitializeComponent();

            customerService = new CustomerService();

            LoadData();
            HideGridColumns();
        }

        private void LoadData()
        {
            var hasData = customerService.LoadData();
            if(hasData && customerService.Customers is not null)
            {
                customers = customerService.Customers.OrderBy(c => c.FirstName);
                dgvCustomers.DataSource = customers.ToList();

               
            }
        }

        private IQueryable<Customer> GetCustomers()
        {
            if (customers is null) return null;

            if (string.IsNullOrWhiteSpace(searchFilter)) return null;

            var filteredCustomers = customers.Where(c => c.FirstName.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) ||
            c.FullName.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) ||
            c.LastName.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) || c.City.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) ||
            c.Country.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) || c.Phone.Contains(searchFilter, StringComparison.OrdinalIgnoreCase));

            return filteredCustomers.OrderBy(c => c.FirstName);
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchFilter)) return;

            dgvCustomers.DataSource = GetCustomers().ToList();
        }

        private void HideGridColumns()
        {
            this.dgvCustomers.Columns[nameof(Customer.FullName)].Visible = false;
        }
    }
}