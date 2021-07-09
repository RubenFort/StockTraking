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
            if (cmbDeletedData.SelectedIndex == 1)
            {
                dataGridView1.DataSource = dto.customers;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Customer Name";
            }
            if (cmbDeletedData.SelectedIndex == 2)
            {
                dataGridView1.DataSource = dto.products;
                dataGridView1.Columns[0].HeaderText = "Product Name";
                dataGridView1.Columns[1].HeaderText = "Category Name";
                dataGridView1.Columns[2].HeaderText = "Stock Amount";
                dataGridView1.Columns[3].HeaderText = "Price";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
            if (cmbDeletedData.SelectedIndex == 3)
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
            }
        }
    }
}
