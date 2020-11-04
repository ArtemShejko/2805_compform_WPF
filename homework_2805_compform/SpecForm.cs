using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework_2805_compform
{
    public partial class SpecForm : Form
    {
        public SpecForm()
        {
            InitializeComponent();
            Obj = new Product();
        }
        public SpecForm(Product src)
        {
            InitializeComponent();
            Obj = new Product();
            AddNewItem = false;
            itemName.Text = src.Name;
            itemChar.Text = src.Specification;
            itemDesc.Text = src.Description;
            itemPrice.Text = src.Price.ToString();
        }

        Product _obj;
        bool _addNewItem;

        public Product Obj { get => _obj; set => _obj = value; }
        public bool AddNewItem { get => _addNewItem; set => _addNewItem = value; }

        private void itemName_TextChanged(object sender, EventArgs e)
        {
            Obj.Name = itemName.Text;
        }

        private void itemChar_TextChanged(object sender, EventArgs e)
        {
            Obj.Specification = itemChar.Text;
        }

        private void itemDesc_TextChanged(object sender, EventArgs e)
        {
            Obj.Description = itemDesc.Text;
        }

         private void itemPrice_TextChanged(object sender, EventArgs e)
        {
            double tmp = 0;
            if (Double.TryParse(itemPrice.Text, out tmp))
            {
                Obj.Price = tmp;
            }

        }

        private void itemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 44 && itemPrice.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44)
            {
                e.Handled = true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (itemName.Text != "" && itemChar.Text != "" && itemDesc.Text != "" && itemPrice.Text != "")
            {
                AddNewItem = true;
                MessageBox.Show("New Item Added", "New Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("All field must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (itemName.Text != "" && itemChar.Text != "" && itemDesc.Text != "" && itemPrice.Text != "")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("All field must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
