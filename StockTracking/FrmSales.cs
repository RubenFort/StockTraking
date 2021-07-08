using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.BLL;
using StockTracking.DAL.DTO;

namespace StockTracking
{
    public partial class FrmSales : Form
    {
        public SalesDTO dto = new SalesDTO();
        bool comboFull = false;

        public FrmSales()
        {
            InitializeComponent();
        }

        private void txtSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utils.isNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = dto.categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "Id";
            cmbCategory.SelectedIndex = -1;
            gridProduct.DataSource = dto.products;
            gridProduct.Columns[0].HeaderText = "Product Name";
            gridProduct.Columns[1].HeaderText = "Category Name";
            gridProduct.Columns[2].HeaderText = "Stock Amount";
            gridProduct.Columns[3].HeaderText = "Price";
            gridProduct.Columns[4].Visible = false;
            gridProduct.Columns[5].Visible = false;
            gridCustomers.DataSource = dto.customers;
            gridCustomers.Columns[0].Visible = false;
            gridCustomers.Columns[1].HeaderText = "Customer Name";
            if (dto.categories.Count > 0)
                comboFull = true;
            
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                List<ProductDetailDTO> list = dto.products;
                list = list.Where(x => x.categoryId == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                gridProduct.DataSource = list;
            }
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            List<CustomerDetailDTO> list = dto.customers;
            list = list.Where(x => x.customerName.Contains(txtCustomerSearch.Text)).ToList();
            gridCustomers.DataSource = list;
        }
    }
}
