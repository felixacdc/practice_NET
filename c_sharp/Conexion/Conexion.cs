using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Form;

namespace PruebaConexion
{
    class Conexion
    {
        SqlConnection cm;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;

        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Cadena de conexion");
                cn.Open();
                MessageBox.show("Conectado");
            }
            catch(Exception ex)
            {
                MessageBox.show("No se conecto la db: " + ex.ToString());
            }
        }

        public string insertar(int id,string nombre,string apellidos,string fecha)
        {
            string salida = "Se se inserto";
            try
            {
                cmd = new SqlCommand("Insert into Persona(Id,Nombre,Apellidos,FechaNacimiento) values("+id+",'"+nombre+"','"+apellidos+"','"+fecha+"')",cn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                salida = "No se conecto: " + ex.ToString();
            }
            return salida;
        }

        public int personaRegistrada(int id)
        {
            int contador = 0;
            try
            {
                cmd = new SqlCommand("Select * from Persona where Id="+id+"", cn);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar bien: "+ex.ToString());
            }
            return contador;
        }

        public void cargarPersonas(DataGridView dgv)
        {
            try {
                da = new SqlDataAdapter("Select * from Persona",cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            } catch(Exception ex) {
                MessageBox.Show("No se pudo llenar el Datagridview: "+ex.ToString());
            }
        }

        public void llenarTexBoxConsulta(int id,TextBox txtNombre,TextBox txtApellidos,DateTimePicker dtpFecha)
        {
            try
            {
                cmd = new SqlCommand("Select * from Persona where Id="+id+"",cn);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    txtNombre.Text = dr["Nombre"].ToString();
                    txtApellidos.Text = dr["Apellidos"].ToString();
                    dtpFecha.Text = dr["FechaNacimiento"].ToString();

                }
                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo llenar los campos: "+ex.ToString());
            }
        }

        public string atualizar(int id,string nombre,string apellidos,string fecha)
        {
            string salida = "Se actualizaron los datos";
            try {
                cmd = new SqlCommand("Update Persona set Nombre ='"+nombre+"' ,Apellidos='"+apellidos+"', FechaNacimiento='"+fecha+"' where Id="+id+"",cn);
                cmd.ExecuteNonQuery();
            } catch(Exception ex) {
                salida = "No se actualizo: " + ex.ToString();
            }
            return salida;
        }
    }
}