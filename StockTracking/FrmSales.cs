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
        public SalesDetailDTO detail = new SalesDetailDTO();
        public bool isUpdate = false;
        SalesBLL bll = new SalesBLL();
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
            if (!isUpdate)
            {
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
            else
            {
                panel1.Hide();
                txtCustomerName.Text = detail.customerName;
                txtProductName.Text = detail.productName;
                txtPrice.Text = detail.price.ToString();
                txtSalesAmount.Text = detail.salesAmount.ToString();
                ProductDetailDTO product = dto.products.First(x => x.productId == detail.productId);
                detail.stockAmount = product.stockAmount;
                txtStock.Text = detail.stockAmount.ToString();
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                List<ProductDetailDTO> list = dto.products;
                list = list.Where(x => x.categoryId == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                gridProduct.DataSource = list;
                if (list.Count == 0)
                {
                    txtProductName.Clear();
                    txtPrice.Clear();
                    txtStock.Clear();
                }
            }
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            List<CustomerDetailDTO> list = dto.customers;
            list = list.Where(x => x.customerName.Contains(txtCustomerSearch.Text)).ToList();
            gridCustomers.DataSource = list;
            if (list.Count == 0)
                txtCustomerName.Clear();
        }

        private void gridProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.productName = gridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.price = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[3].Value);
            detail.stockAmount = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[2].Value);
            detail.productId = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[4].Value);
            detail.categoryId = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[5].Value);
            txtProductName.Text = detail.productName;
            txtPrice.Text = detail.price.ToString();
            txtStock.Text = detail.stockAmount.ToString();
        }

        private void gridCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.customerName = gridCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.customerId = Convert.ToInt32(gridCustomers.Rows[e.RowIndex].Cells[0].Value);
            txtCustomerName.Text = detail.customerName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSalesAmount.Text.Trim() == "")
                MessageBox.Show("Please fill the sales amounta rea");
            else
            {
                if (!isUpdate)//Add
                {
                    if (detail.productId == 0)
                        MessageBox.Show("Please select a product from sale table");
                    else if (detail.customerId == 0)
                        MessageBox.Show("Please select a customer from sale table");
                    else if (detail.stockAmount < Convert.ToInt32(txtSalesAmount.Text))
                        MessageBox.Show("You have bot enough product for sale");
                    else
                    {
                        detail.salesAmount = Convert.ToInt32(txtSalesAmount.Text);
                        detail.salesDate = DateTime.Today;
                        if (bll.Insert(detail))
                        {
                            MessageBox.Show("Sales was added");
                            bll = new SalesBLL();
                            dto = bll.Select();
                            gridProduct.DataSource = dto.products;
                            comboFull = false;
                            cmbCategory.DataSource = dto.categories;
                            if (dto.products.Count > 0)
                                comboFull = true;
                            txtSalesAmount.Clear();
                        }
                    }
                }
                else//Update
                {
                    if (detail.salesAmount == Convert.ToInt32(txtSalesAmount.Text))
                        MessageBox.Show("There is no change");
                    else
                    {
                        int temp = detail.stockAmount + detail.salesAmount;
                        if (temp<Convert.ToInt32(txtSalesAmount.Text))
                            MessageBox.Show("You have not enough product for sale");
                        else
                        {
                            detail.salesAmount = Convert.ToInt32(txtSalesAmount.Text);
                            detail.stockAmount = temp - detail.salesAmount;
                            if (bll.Update(detail))
                            {
                                MessageBox.Show("Sales was updated");
                            }
                        }
                    }
                }
            }
        }
    }
}
