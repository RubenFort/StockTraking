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
        public ProductDetailDTO detail = new ProductDetailDTO();
        public ProductDTO dto = new ProductDTO();
        public bool isUpdate = false;
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
            if (isUpdate)
            {
                txtProductName.Text = detail.productName;
                txtPrice.Text = detail.price.ToString();
                cmbCategory.SelectedValue = detail.categoryId;
            }
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
                if (!isUpdate)//Add
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
                else
                {
                    if (detail.productName == txtProductName.Text.Trim() &&
                        detail.categoryId == Convert.ToInt32(cmbCategory.SelectedValue) &&
                        detail.price == Convert.ToInt32(txtPrice.Text))
                            MessageBox.Show("There is no change");
                    else
                    {
                        detail.productName = txtProductName.Text;
                        detail.categoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                        detail.price = Convert.ToInt32(txtPrice.Text);
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Product was updated");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
