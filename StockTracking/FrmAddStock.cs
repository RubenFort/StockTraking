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
    public partial class FrmAddStock : Form
    {
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        ProductDetailDTO detail = new ProductDetailDTO();
        bool comboFull = false;

        public FrmAddStock()
        {
            InitializeComponent();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utils.isNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddStock_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Category Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            cmbCategory.DataSource = dto.categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "Id";
            cmbCategory.SelectedIndex = -1;

            if (dto.categories.Count > 0)
                comboFull = true;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                List<ProductDetailDTO> list = dto.products;
                list = list.Where(x => x.categoryId == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                dataGridView1.DataSource = list;
                if (list.Count == 0)
                {
                    txtPrice.Clear();
                    txtProductName.Clear();
                    txtStock.Clear();
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.productName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = detail.productName;
            detail.price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            txtPrice.Text = detail.price.ToString();
            detail.stockAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Please select a product from table");
            else if (txtStock.Text.Trim() == "")
                MessageBox.Show("Please give a stock amount");
            else
            {
                int sumStock = detail.stockAmount;
                sumStock += Convert.ToInt32(txtStock.Text);
                detail.stockAmount = sumStock;
                if (bll.Update(detail))
                {
                    MessageBox.Show("Stock was added");
                    bll = new ProductBLL();
                    dto = bll.Select();
                    dataGridView1.DataSource = dto.products;
                    txtStock.Clear();
                }
            }
        }
    }
}
