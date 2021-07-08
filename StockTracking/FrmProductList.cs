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
    public partial class FrmProductList : Form
    {
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();

        public FrmProductList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.products;
            CleanFilters();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utils.isNumber(e);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utils.isNumber(e);
        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ProductDetailDTO> list = dto.products;
            if (txtProductName.Text.Trim() != null)
                list = list.Where(x => x.productName.Contains(txtProductName.Text)).ToList();
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
            if (txtStock.Text.Trim() != "")
            {
                if (rbEqualStock.Checked)
                    list = list.Where(x => x.stockAmount == Convert.ToInt32(txtStock.Text)).ToList();
                else if (rbMoreStock.Checked)
                    list = list.Where(x => x.stockAmount > Convert.ToInt32(txtStock.Text)).ToList();
                else if (rbLessStock.Checked)
                    list = list.Where(x => x.stockAmount < Convert.ToInt32(txtStock.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterion from stock group");
            }
            dataGridView1.DataSource = list;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtPrice.Clear();
            txtProductName.Clear();
            txtStock.Clear();
            cmbCategory.SelectedIndex = -1;
            rbEqualPrice.Checked = false;
            rbMorePrice.Checked = false;
            rbLessPrice.Checked = false;
            rbEqualStock.Checked = false;
            rbMoreStock.Checked = false;
            rbLessStock.Checked = false;
            dataGridView1.DataSource = dto.products;
        }
    }
}
