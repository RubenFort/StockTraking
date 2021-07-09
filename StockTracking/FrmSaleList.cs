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
    public partial class FrmSaleList : Form
    {
        SalesBLL bll = new SalesBLL();
        SalesDTO dto = new SalesDTO();
        SalesDetailDTO detail = new SalesDetailDTO();

        public FrmSaleList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.salesId == 0)
                MessageBox.Show("Please select a sales from table");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("Sales was deleted");
                        bll = new SalesBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.sales;
                        CleanFilters();
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.salesId == 0)
                MessageBox.Show("Please select a sale from table");
            else
            {
                FrmSales frm = new FrmSales();
                frm.detail = detail;
                frm.dto = dto;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new SalesBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.sales;
                CleanFilters();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSales frm = new FrmSales();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

            dto = bll.Select();
            dataGridView1.DataSource = dto.sales;
            CleanFilters();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utils.isNumber(e);
        }

        private void txtDalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utils.isNumber(e);
        }

        private void FrmSaleList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.sales;
            dataGridView1.Columns[0].HeaderText = "Customer Name";
            dataGridView1.Columns[1].HeaderText = "Product Name";
            dataGridView1.Columns[2].HeaderText = "Category Name";
            dataGridView1.Columns[6].HeaderText = "Sales Amount";
            dataGridView1.Columns[7].HeaderText = "Price";
            dataGridView1.Columns[8].HeaderText = "Sales Date";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            cmbCategory.DataSource = dto.categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "Id";
            cmbCategory.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<SalesDetailDTO> list = dto.sales;
            if (txtProductName.Text.Trim() != "")
                list = list.Where(x => x.productName.Contains(txtProductName.Text)).ToList();
            if (txtCustomerName.Text.Trim() != "")
                list = list.Where(x => x.customerName.Contains(txtCustomerName.Text)).ToList();
            if (cmbCategory.SelectedIndex != -1)
                list = list.Where(x => x.categoryId == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
            if (txtPrice.Text.Trim() != "")
            {
                if (rbEqualPrice.Checked)
                    list = list.Where(x => x.price == Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbMorePrice.Checked)
                    list = list.Where(x => x.price > Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbLessPrice.Checked)
                    list = list.Where(x => x.price < Convert.ToInt32(txtPrice.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterion from price group");
            }
            if (txtSalesAmount.Text.Trim() != "")
            {
                if (rbEqualSalesAmount.Checked)
                    list = list.Where(x => x.salesAmount == Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else if (rbMoreSalesAmount.Checked)
                    list = list.Where(x => x.salesAmount > Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else if (rbLessSalesAmount.Checked)
                    list = list.Where(x => x.salesAmount < Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterion from sale amount group");
            }
            if (chkDate.Checked)
                list = list.Where(x => x.salesDate > dtpStart.Value && x.salesDate > dtpEnd.Value).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtPrice.Clear();
            txtCustomerName.Clear();
            txtProductName.Clear();
            txtSalesAmount.Clear();
            rbEqualPrice.Checked = false;
            rbMorePrice.Checked = false;
            rbLessPrice.Checked = false;
            rbEqualSalesAmount.Checked = false;
            rbMoreSalesAmount.Checked = false;
            rbLessSalesAmount.Checked = false;
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;
            chkDate.Checked = false;
            cmbCategory.SelectedIndex = -1;
            dataGridView1.DataSource = dto.sales;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new SalesDetailDTO();
            try
            {
                detail.salesId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
                detail.productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                detail.customerName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                detail.productName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                detail.price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                detail.salesAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
