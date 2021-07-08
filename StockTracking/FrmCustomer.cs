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
    public partial class FrmCustomer : Form
    {
        public CustomerDetailDTO detail = new CustomerDetailDTO();
        public bool isUpdate = false;
        CustomerBLL bll = new CustomerBLL();

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim() == "")
                MessageBox.Show("Customer name is empty");
            else
            {
                if (!isUpdate)
                {
                    CustomerDetailDTO customer = new CustomerDetailDTO();
                    customer.customerName = txtCustomerName.Text;
                    if (bll.Insert(customer))
                    {
                        MessageBox.Show("Customer was added");
                        txtCustomerName.Clear();
                    }
                }
                else
                {
                    if (detail.customerName == txtCustomerName.Text.Trim())
                        MessageBox.Show("There is no change");
                    else
                    {
                        detail.customerName = txtCustomerName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Category was updated");
                            this.Close();
                        }
                    }
                }
            }
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            if (isUpdate)
                txtCustomerName.Text = detail.customerName;
        }
    }
}
