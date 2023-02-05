using GridSearchApp.Entities;
using GridSearchApp.Services;
using GridSearchApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridSearchApp
{
    public partial class UsersView : Form
    {

        private UserService userService;

        private IQueryable<User> users;

        public UsersView()
        {
            InitializeComponent();

            userService = new UserService();

            LoadData();
            GridViewUtil.HideGridColumns(this.dgvUsers, nameof(User.Fullname));
        }

        private void LoadData()
        {
            var hasData = userService.LoadData();
            if(hasData && userService.Users is not null)
            {
                users = userService.Users.OrderBy(u => u.Firstname);
                dgvUsers.DataSource = users.ToList();
            }
        }
    }
}
