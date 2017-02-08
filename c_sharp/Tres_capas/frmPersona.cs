using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmPersona
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void btnguardar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            persona.cedula = txtcedula.Text;
            persona.nombre = txtnombre.Text;
            persona.apellido = txtapellido.Text;
            persona.edad = txtedad.Text;
            persona.fechaNacimiento = Convert.ToDataTime(txtfechanacimiento.Text);
            if(persona.NuevaPersona(persona)>0) {
                lbmensaje.Text = "Registro ingresado correctamente";
            } else {
                lbmensaje.Text = "Fallo el intento de registro";
            }
        }

        public void btnactualizar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            persona.cedula = txtcedula.Text;
            persona.nombre = txtnombre.Text;
            persona.apellido = txtapellido.Text;
            persona.edad = txtedad.Text;
            persona.fechaNacimiento = Convert.ToDataTime(txtfechanacimiento.Text);
            if(persona.ActualizarPersona(persona)>0) {
                lbmensaje.Text = "Registro actualizado correctamente";
            } else {
                lbmensaje.Text = "Fallo el intento de actualizar";
            }
        }

        public void btneliminar_Click(object sender, EventArgs e)
        {
            Persona p = new Persona();
            p.cedula = txtcedula.Text;
            if(p.EliminarPersona(p.cedula)>0)
            {
                lbmensaje.Text = "Registro eliminado correctamente...";
            } else
            {
                lbmensaje.Text = "No se pudo eliminar el registro";
            }
        }
        
        public void btnconsultar_Click(object sender, EventArgs e)
        {
            Persona p = new Persona();
            p.cedula = txtcedula.Text;
            p.getPersona(p);
            if(p!=null)
            {
                lbmensaje.Text = "Registro encontrado..";
                txtcedula.Text = p.cedula;
                txtnombre.Text = p.nombre;
                txtapellido.Text = p.apellido;
                txtedad.Text = p.edad;
                txtfechanacimiento.Text = p.fechaNacimiento.ToString();
            } else {
                lbmensaje.Text = "No se encuentra el registro";
            }
        }

        public void btnlistar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            dgPersona.DataSource = persona.getPersonas();
            dgPersona.DataBindings();
        }
    }
}
