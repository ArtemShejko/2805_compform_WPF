using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework_2805_compform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _products = new List<Product>();
            _cart = new List<Product>();
           //_cartsum = 0;
            comboBox1.DataSource = _products;
            comboBox1.DisplayMember = "Name";
            listBox1.DataSource = _cart;
            listBox1.DisplayMember = "AllChar";
            btnInfo.Text = "Add Item to List";
        }

        List<Product> _products;
        List <Product> _cart;
        //double _cartsum;
        public double CartSum
        {
            get
            {
                double sum = 0;
                foreach (var item in _cart)
                {
                    sum += item.Price;
                }
                return sum;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            //    Label tmplabel = new Label() { Text = ((Product)comboBox1.SelectedValue).AllChar };

            //listBox1.Items.Add(((Product)comboBox1.SelectedValue).AllChar);
            //_cart.Add((Product)comboBox1.SelectedValue);
            //_cartsum += ((Product)comboBox1.SelectedValue).Price;
            //cost.Text = _cartsum.ToString();

            _cart.Add((Product)comboBox1.SelectedValue);
            cost.Text = CartSum.ToString();
            CurrencyManager cm = (CurrencyManager)listBox1.BindingContext[listBox1.DataSource];
            cm.Refresh();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                SpecForm form = new SpecForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _products.Add(form.Obj);
                    btnInfo.Text = "Info";
                    price.Text = form.Obj.Price.ToString();
                    CurrencyManager cm = (CurrencyManager)listBox1.BindingContext[comboBox1.DataSource];
                    cm.Refresh();
                }
            }
            else
            {
                SpecForm form = new SpecForm(_products[comboBox1.SelectedIndex]);
                form.ShowDialog();
                if (form.AddNewItem == true)
                {
                    _products.Add(form.Obj);
                    CurrencyManager cm = (CurrencyManager)listBox1.BindingContext[comboBox1.DataSource];
                    cm.Refresh();
                }
                else if (form.AddNewItem == false)
                {
                    _products[comboBox1.SelectedIndex].Name = form.Obj.Name;
                    _products[comboBox1.SelectedIndex].Description = form.Obj.Description;
                    _products[comboBox1.SelectedIndex].Specification = form.Obj.Specification;
                    _products[comboBox1.SelectedIndex].Price = form.Obj.Price;
                    form.Close();
                    CurrencyManager cm = (CurrencyManager)listBox1.BindingContext[comboBox1.DataSource];
                    cm.Refresh();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                btnInfo.Text = "Add Item to List";
            }
            else
             {
                btnInfo.Text = "Info";
                price.Text = _products[comboBox1.SelectedIndex].Price.ToString();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                //_cartsum -= _cart[listBox1.SelectedIndex].Price;
                //_cart.RemoveAt(listBox1.SelectedIndex);
                //listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                //cost.Text = _cartsum.ToString();


                _cart.RemoveAt(listBox1.SelectedIndex);
                cost.Text=CartSum.ToString();
                CurrencyManager cm = (CurrencyManager)listBox1.BindingContext[listBox1.DataSource];
                cm.Refresh();

            }
        }
    }
}
