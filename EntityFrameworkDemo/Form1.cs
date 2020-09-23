using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProductLoad();
        }
        ProductDal _productDal = new ProductDal();
        private void ProductLoad()
        {
            using (ETradeContext context = new ETradeContext())
            {
                dataGridView1.DataSource = context.Products.ToList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxAddName.Text,
                UnitPrice = Convert.ToDecimal(tbxAddUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxAddStockAmount.Text)
            });
            ProductLoad();
            MessageBox.Show("Added!!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id=Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name = tbxUpdateName.Text,
                UnitPrice = Convert.ToDecimal(tbxUpdateUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxUpdateStockAmount.Text)
            });
            ProductLoad();
            MessageBox.Show("Updated!!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxUpdateName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxUpdateUnitPrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxUpdateStockAmount.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)
            });
            ProductLoad();
            MessageBox.Show("Deleted!!");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _productDal.GetByName(tbxSearch.Text);
            // dataGridView1.DataSource = _productDal.GetByUnitPrice(Convert.ToDecimal(tbxSearch.Text));
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            _productDal.GetById(2);
        }
    }
}
