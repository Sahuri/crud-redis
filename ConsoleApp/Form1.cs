using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var p = new RedisDictionary<int, Phone>("phone");
            this.dataGridView1.DataSource = p.Values.OrderBy(x=>x.Id).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var phone = new RedisDictionary<int, Phone>("phone");
            var p = new Phone()
            {
                Id = Convert.ToInt32(textBox1.Text),
                Model = textBox2.Text,
                Manufacturer = textBox3.Text
            };

            phone.Add(p.Id,p);
            this.dataGridView1.DataSource = phone.Values.OrderBy(x => x.Id).ToList();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = e.RowIndex;
                var id = this.dataGridView1.Rows[row].Cells[0].Value;
                var model = this.dataGridView1.Rows[row].Cells[1].Value;
                var manufacture = this.dataGridView1.Rows[row].Cells[2].Value;

                textBox1.Text =id.ToString();
                textBox2.Text = model.ToString();
                textBox3.Text = manufacture.ToString();



            }
            catch (Exception ex)
            {
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var phone = new RedisDictionary<int, Phone>("phone");
            phone.Remove(Convert.ToInt32(textBox1.Text));
            this.dataGridView1.DataSource = phone.Values.OrderBy(x => x.Id).ToList();
        }
    }
}
