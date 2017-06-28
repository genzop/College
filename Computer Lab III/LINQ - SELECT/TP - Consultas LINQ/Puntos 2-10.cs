using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP___Consultas_LINQ
{
    public partial class Form1 : Form
    {

        NorthwindDataContext db = new NorthwindDataContext();

        public Form1()
        {
            InitializeComponent();            
        }
        
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            var punto2 = from emp in db.Employees
                            select emp;
            dgvNorthwind.DataSource = punto2;
        }

        private void btnPunto3_Click(object sender, EventArgs e)
        {
            var punto3 = from emp in db.Employees
                         select new
                         {
                             LastName = emp.LastName,
                             FirstName = emp.FirstName,
                             Address = emp.Address,
                             Country = emp.Country
                         };
            dgvNorthwind.DataSource = punto3;

        }

        private void btnPunto4_Click(object sender, EventArgs e)
        {
            var punto4 = from emp in db.Employees
                         where emp.City == "London"
                         select emp;
            dgvNorthwind.DataSource = punto4;
        }

        private void btnPunto5_Click(object sender, EventArgs e)
        {
            var punto5 = from emp in db.Employees
                         where emp.City == "London" && emp.TitleOfCourtesy == "Mr."
                         select emp;
            dgvNorthwind.DataSource = punto5;
        }

        private void btnPunto6_Click(object sender, EventArgs e)
        {
            var punto6 = from emp in db.Employees
                         where emp.Country == "USA" || emp.City == "Seattle"
                         select emp;
            dgvNorthwind.DataSource = punto6;
        }

        private void btnPunto7_Click(object sender, EventArgs e)
        {
            var punto7 = from emp in db.Employees
                         where emp.Title.StartsWith("Sales")
                         select emp;
            dgvNorthwind.DataSource = punto7;
        }

        private void btnPunto8_Click(object sender, EventArgs e)
        {
            var punto8 = from emp in db.Employees
                         where emp.LastName.EndsWith("n")
                         select emp;
            dgvNorthwind.DataSource = punto8;
        }

        private void btnPunto9_Click(object sender, EventArgs e)
        {
            var punto9 = from prod in db.Products
                         orderby prod.UnitsInStock ascending
                         select prod;
            dgvNorthwind.DataSource = punto9;
        }

        private void btnPunto10_Click(object sender, EventArgs e)
        {
            var punto10 = from prod in db.Products
                         orderby prod.UnitPrice ascending, prod.UnitsInStock descending
                         select prod;
            dgvNorthwind.DataSource = punto10;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
