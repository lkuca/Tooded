using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tooded
{
    public partial class Form1 : Form
    {
        SqlConnection connect=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Toded.mdf;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand comand;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
            NaitaKategooria();
            
        }
        public void NaitaKategooria()
        {
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("Select KategooriaNimetus From TKategooria", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);
            foreach(DataRow item in dt_kat.Rows)
            {
                comboBox1.Items.Add(item["KategooriaNimetus"]);
            }
            connect.Close();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            comand = new SqlCommand("Insert INTO TKategooria (KategooriaNimetus)Values (@kat)", connect);
            connect.Open();
            comand.Parameters.AddWithValue("@kat", comboBox1.Text);
            connect.Close();
            comboBox1.Items.Clear();
            NaitaKategooria();
        }

        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("Select * from toode", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.DataSource = dt_toode;
            connect.Close();

        }
    }
}
