﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            ProductLoad();
        }

        private void ProductLoad()
        {
            dataGridView1.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name=tbxAddName.Text,
                UnitPrice=Convert.ToDecimal(tbxAddUnitPrice.Text),
                StockAmount=Convert.ToInt32(tbxAddStockAmount.Text)
            });
            ProductLoad();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxUpdateName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxUpdateUnitPrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxUpdateStockAmount.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id= Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name=tbxUpdateName.Text.ToString(),
                UnitPrice = Convert.ToDecimal(tbxUpdateUnitPrice.Text),
                StockAmount =Convert.ToInt32(tbxUpdateStockAmount.Text)
                
            });
            
            ProductLoad();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            ProductLoad();
        }
    }
}
