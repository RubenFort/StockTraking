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
    public partial class FrmDeleted : Form
    {
        SalesBLL bll = new SalesBLL();
        SalesDTO dto = new SalesDTO();
        ProductDTO productDTO = new ProductDTO();
        CategoryDetailDTO categoyDetail = new CategoryDetailDTO();
        CustomerDetailDTO customerDetail = new CustomerDetailDTO();
        ProductDetailDTO productDetail = new ProductDetailDTO();
        SalesDetailDTO salesDetail = new SalesDetailDTO();
        CategoryBLL categoryBLL = new CategoryBLL();
        CustomerBLL customerBLL = new CustomerBLL();
        ProductBLL productBLL = new ProductBLL();
        SalesBLL salesBLL = new SalesBLL();

        public FrmDeleted()
        {
            InitializeComponent();
        }

        private void FrmDeleted_Load(object sender, EventArgs e)
        {
            cmbDeletedData.Items.Add("Category");
            cmbDeletedData.Items.Add("Customer"); 
            cmbDeletedData.Items.Add("Product");
            cmbDeletedData.Items.Add("Sales");
            dto = bll.Select(true);

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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDeletedData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0)
            {
                dataGridView1.DataSource = dto.categories;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Category Name";
            }
            else if (cmbDeletedData.SelectedIndex == 1)
            {
                dataGridView1.DataSource = dto.customers;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Customer Name";
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                //productDTO = new ProductDTO();
                //productDTO = productBLL.Select();
                //dataGridView1.DataSource = productDTO.products;
                dataGridView1.DataSource = dto.products;
                dataGridView1.Columns[0].HeaderText = "Product Name";
                dataGridView1.Columns[1].HeaderText = "Category Name";
                dataGridView1.Columns[2].HeaderText = "Stock Amount";
                dataGridView1.Columns[3].HeaderText = "Price";
                dataGridView1.Columns[6].HeaderText = "Category deleted";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                //dataGridView1.Columns[6].Visible = false;
            }
            else if (cmbDeletedData.SelectedIndex == 3)
            {
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
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0)
            {
                categoyDetail = new CategoryDetailDTO();
                categoyDetail.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                categoyDetail.CategoryName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
             else if (cmbDeletedData.SelectedIndex == 1)
            {
                customerDetail = new CustomerDetailDTO();
                customerDetail.id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                customerDetail.customerName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                productDetail = new ProductDetailDTO();
                productDetail.productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                productDetail.categoryId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                productDetail.productName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                productDetail.price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                productDetail.isCategoryDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            }
            else
            {
                salesDetail = new SalesDetailDTO();
                salesDetail.salesId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
                salesDetail.productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                salesDetail.customerName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                salesDetail.productName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                salesDetail.price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                salesDetail.salesAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                salesDetail.isCategoyDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
                salesDetail.isCustomerDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
                salesDetail.isProductDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
            }
        }

        private void btnGetBack_Click(object sender, EventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0)
            {
                if (categoryBLL.GetBack(categoyDetail))
                {
                    MessageBox.Show("Category was get back");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.categories;
                }
            }
            else if (cmbDeletedData.SelectedIndex == 1)
            {
                if (customerBLL.GetBack(customerDetail))
                {
                    MessageBox.Show("Customer was get back");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.customers;
                }
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                
                if (productDetail.isCategoryDeleted)
                    MessageBox.Show("Category was deleted first get back category");
                else if (productBLL.GetBack(productDetail))
                {
                    MessageBox.Show("Product was get back");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.products;
                }
            }
            else
            {
                if (salesDetail.isCategoyDeleted || salesDetail.isCustomerDeleted || salesDetail.isProductDeleted)
                {
                    if (salesDetail.isCategoyDeleted)
                        MessageBox.Show("Category was deleted first get back category");
                    else if (salesDetail.isCustomerDeleted)
                        MessageBox.Show("Customer was deleted first get back category");
                    else if (salesDetail.isProductDeleted)
                        MessageBox.Show("Product was deleted first get back category");
                }
                else if (salesBLL.GetBack(salesDetail))
                {
                    MessageBox.Show("Sales was get back");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.sales;
                }
            }
        }
    }
}
