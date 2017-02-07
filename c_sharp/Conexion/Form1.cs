using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaConexion
{
    Conexion = new Conexion();
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RbInsertar.Checked = true;
            Conexion c = new Conexion();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if(c.personaRegistrada(Convert.ToInt32(txtId.Text))==0) {
                MessageBox.Show(c.insertar(Convert.ToInt32(txtId.Text),txtNombre.Text,txtApellidos.Text,dtpFecha.Text));
                txtId.Text = "";
                txtNombre.Text = "";
                txtApellidos.Text = "";
            } else {
              MessageBox.Show("Imposible de regitrar, El registro ya existe");
            }
        }
    }
}
