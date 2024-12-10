using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sigortadurum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       // List<Hasta> hastalar = new List<Hasta>();
       BindingList<Hasta> hastalar = new BindingList<Hasta>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Hasta hasta1 = new Hasta { Id = 1, AdSoyad = "Furkan", Birim = "Dahiliye", Tarih = DateTime.Now, yas = 21 };
            Hasta hasta2 = new Hasta { Id = 2, AdSoyad = "Halil", Birim = "Dahiliye", Tarih = DateTime.Now, yas = 24};
            Hasta hasta3 = new Hasta { Id = 3, AdSoyad = "Yasin", Birim = "Cildiye ", Tarih = DateTime.Now, yas = 25 };
            Hasta hasta4 = new Hasta { Id = 4, AdSoyad = "Havva", Birim = "Hariciye", Tarih = DateTime.Now, yas = 25};
            hastalar.Add(hasta1);
            hastalar.Add(hasta2);
            hastalar.Add(hasta3);
            hastalar.Add(hasta4);
            dataGridView1.DataSource = hastalar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt16(textBox1.Text);
            string AdSoyad = textBox2.Text;
            DateTime Tarih = dateTimePicker1.Value.Date;
            string Birim = comboBox1.Text;
            int yas = Convert.ToInt16(numericUpDown1.Value);
            Hasta hastam=new Hasta { Id = Id, AdSoyad = AdSoyad, Birim = Birim, Tarih = Tarih,yas=yas };
            hastalar.Add(hastam);
            dataGridView1.DataSource = hastalar;
            dataGridView1.Refresh();
            MessageBox.Show("Kayıt Eklendi");
           
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hastam1 = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;
                textBox1.Text = hastam1.Id.ToString();
                textBox2.Text = hastam1.AdSoyad;
                dateTimePicker1.Value = hastam1.Tarih;
                comboBox1.Text = hastam1.Birim;
                numericUpDown1.Value = hastam1.yas;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hastam1 = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;
                hastam1.AdSoyad = textBox1.Text;
                hastam1.Tarih= dateTimePicker1.Value;   
                hastam1.Birim= comboBox1.Text;
                hastam1.yas = Convert.ToInt16(numericUpDown1.Value);
                dataGridView1.Refresh();
                MessageBox.Show("Kayıt Güncellendi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Hasta hastam1 = (Hasta)dataGridView1.SelectedRows[0].DataBoundItem;
                //seçim yapılan datagrid içindeki verileri hastam1 classiçine ata
                DialogResult cevap = MessageBox.Show("Bu Kaydı Silmek İstiyor musun?", "Silme Kaydı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(cevap==DialogResult.Yes)
                {
                    hastalar.Remove(hastam1);
                    MessageBox.Show("Kayıt Silindi");
                    dataGridView1.Refresh();
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
