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

namespace ESTUDIANTES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            conexionbd conexion = new conexionbd();
            //conexion.abrir();
            MessageBox.Show("conexion exitosa");
            //Conexion.Conectar();
            //MessageBox.Show("conexion exitosa");

            dataGridView1.DataSource = llenar_grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO ALUMNO (CODIGO,NOMBRES,APELLIDOS,DIRECCION)VALUES(@CODIGO,@NOMBRES,@APELLIDOS,@DIRECCION)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@CODIGO", txtcodigo.Text);
            cmd1.Parameters.AddWithValue("@NOMBRES", txtnombres.Text);
            cmd1.Parameters.AddWithValue("@APELLIDOS", txtapellidos.Text);
            cmd1.Parameters.AddWithValue("@DIRECCION", txtdireccion.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("los datos fueron agregados correctamente");

            dataGridView1.DataSource = llenar_grid();

        }
        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM ALUMNO";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtnombres.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtapellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtdireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }


            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE ALUMNO SET CODIGO=@CODIGO, NOMBRES=@NOMBRES, APELLIDOS=@APELLIDOS, DIRECCION=@DIRECCION WHERE CODIGO=@CODIGO";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@CODIGO", txtcodigo.Text);
            cmd2.Parameters.AddWithValue("@NOMBRES", txtnombres.Text);
            cmd2.Parameters.AddWithValue("@APELLIDOS", txtapellidos.Text);
            cmd2.Parameters.AddWithValue("@DIRECCION", txtdireccion.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron modificados correctamente");
            dataGridView1.DataSource = llenar_grid();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM ALUMNO WHERE CODIGO = @CODIGO";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@CODIGO", txtcodigo.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron eliminados correctamente");
            dataGridView1.DataSource = llenar_grid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtcodigo.Clear();
            txtnombres.Clear();
            txtapellidos.Clear();
            txtdireccion.Clear();
        }
    }
}
