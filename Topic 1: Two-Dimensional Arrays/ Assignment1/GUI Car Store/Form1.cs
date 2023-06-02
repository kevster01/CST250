using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarShopGui
{
    public partial class Form1 : Form
    {
        Store store = new Store();

        BindingSource carListBinding = new BindingSource();
        BindingSource ShoppingListBinding = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            SetBindings();
        }

        private void SetBindings()
        {
            carListBinding.DataSource = store.CarList;
            listBox1.DataSource = carListBinding;
            listBox1.DisplayMember = "Display";
            listBox1.ValueMember = "Display";

            ShoppingListBinding.DataSource = store.ShoppingList;
            listBox2.DataSource = ShoppingListBinding;
            listBox2.DisplayMember = "Display";
            listBox2.ValueMember = "Display";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Car newCar = new Car();
                newCar.Year = int.Parse(textBox1.Text);
                newCar.Make = textBox2.Text;
                newCar.Model = textBox3.Text;
                newCar.Color = textBox4.Text;
                newCar.Price = decimal.Parse(textBox5.Text);

                store.CarList.Add(newCar);

                carListBinding.ResetBindings(false);
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            store.ShoppingList.Add((Car)listBox1.SelectedItem);
            ShoppingListBinding.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal total = store.checkout();
            label7.Text = total.ToString();

        }
    }
}
