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

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSales frm = new FrmSales();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

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
        }
    }
}
