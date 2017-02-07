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

        private void RbInsertar_CheckedChanged(object sender, EventArgs e)
        {
            txtId.Enabled = true;
            txtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            dtpFecha.Enabled = true;
            BtnAgregar.Enabled=true;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RbInsertar.Checked = true;
            Conexion c = new Conexion();
            c.cargarPersonas(DgvPersonas);
        }

        private void RbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            txtId.Enabled = true;
            txtNombre.Enabled = false;
            txtApellidos.Enabled = false;
            dtpFecha.Enabled = false;
            BtnEliminar.Enabled = true;
            BtnAgregar.Enabled = false;
            BtnModificar.Enabled = false;
        }

        private void RbModificar_CheckedChanged(object sender, EventArgs e)
        {
            BtnModificar.Enabled = true;
            BtnEliminar.Enabled = false;
            BtnAgregar.Enabled = false;
            txtId.Enabled = true;
            txtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            dtpFecha.Enabled = true;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if(c.personaRegistrada(Convert.ToInt32(txtId.Text))==0) {
                MessageBox.Show(c.insertar(Convert.ToInt32(txtId.Text),txtNombre.Text,txtApellidos.Text,dtpFecha.Text));
                c.cargarPersonas(DgvPersonas);
                txtId.Text = "";
                txtNombre.Text = "";
                txtApellidos.Text = "";
            } else {
              MessageBox.Show("Imposible de regitrar, El registro ya existe");
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if(RbModificar.Checked==true)
            {
              if(c.personaRegistrada(Convert.ToInt32(txtId.Text))>0)
              {
                  c.llenarTexBoxConsulta(Convert.ToInt32(txtId.Text), txtNombre, txtApellidos, dtpFecha);
                  BtnModificar.Enabled = true;
              }
              else
              {
                  txtNombre.Text = "";
                  txtApellidos.Text = "";
                  BtnModificar.Enabled = false;
              }
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(c.atualizar(Convert.ToInt32(txtId.Text),txtNombre.Text,txtApellidos.Text,dtpFecha.Text));
            c.cargarPersonas(DgvPersonas);
        }
    }
}
