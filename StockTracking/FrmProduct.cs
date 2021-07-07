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
    public partial class FrmProduct : Form
    {
        public ProductDTO dto = new ProductDTO();
        ProductBLL bll = new ProductBLL();

        public FrmProduct()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utils.isNumber(e);
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = dto.categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "Id";
            cmbCategory.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Product name is empty");
            else if (cmbCategory.SelectedIndex == -1)
                MessageBox.Show("Please leect a category");
            else if (txtPrice.Text.Trim() == "")
                MessageBox.Show("Price is empty");
            else
            {
                ProductDetailDTO product = new ProductDetailDTO();
                product.productName = txtProductName.Text;
                product.categoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                product.price = Convert.ToInt32(txtPrice.Text);
                if (bll.Insert(product))
                {
                    MessageBox.Show("Product was added");
                    txtPrice.Clear();
                    txtProductName.Clear();
                    cmbCategory.SelectedIndex = -1;
                }
            }
        }
    }
}
