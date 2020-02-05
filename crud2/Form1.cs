using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crud2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Cargar()
        {
            SqlConnection conn = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=ProgramacionAvanzada;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT*FROM USUARIO", conn);
            SqlDataAdapter SQLDA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            SQLDA.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=ProgramacionAvanzada;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into usuario values(@Nombre,@FDN,@Photo,@Sexo,@Telefono,@Correo_Electronico,@Id,@idNacionalidad)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("Nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("FDN", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("Photo", textBox2.Text);
            cmd.Parameters.AddWithValue("Sexo", textBox3.Text);
            cmd.Parameters.AddWithValue("Telefono", textBox4.Text);
            cmd.Parameters.AddWithValue("Correo_Electronico", textBox5.Text);
            cmd.Parameters.AddWithValue("Id", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("IdNacionalidad", int.Parse(comboBox1.Text));

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Insert");
            Cargar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}

