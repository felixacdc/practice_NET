using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class Conexion
    {
        private SqlConnection con { get;set; }
        private string cadenaConexion()
        {
            return @"Data Source=localhost;Initial Catalog=TutorialCShar; User Id=Ing; Password=mypass"
        }
        //metodo obtener conexion
        public SqlConnection getConexion()
        {
            try {
                con = new SqlConnection(cadenaConexion());
                this.con.Open();
                return this.con;
            } catch(Exeption) {
                return null
            }
        }
        // metodo cerrar conexion
        public void CerrarConexion()
        {
            if(this.con!=null)
            {
                this.con.Close();
            }
        }
    }
}