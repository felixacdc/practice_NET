using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosSistema
    {
        // metodo para llenar un DataTable
        public DataTable getDatos(string nomprocedimento, string[] nomparametros, params Object[]valparametros)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            Conexion con = new Conexion();
            cmd.Connection = con.getConexion();
            cmd.CommandText = nomprocedimento;
            cmd.CommandType = CommandType.StoredProcedure;
            if(nomprocedimento.Length!=0 && nomparametros.Length==valparametros.Length)
            {
                int i = 0;
                foreach(string parametro in nomparametros)
                    cmd.Parameters.AddWithValue(parametro,valparametros[i++]);

                try {
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    return dt;
                } catch(Exception) {

                }
            }
            return dt;
        }
    }
}
