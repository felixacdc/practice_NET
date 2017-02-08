using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class Persona
    {
        public string cedula {get;set;};
        public string nombre {get;set;};
        public string apellido {get;set;};
        public string edad {get;set;};
        public DateTime fechaNacimiento {get;set;};

        // ahora implementaremos el metodo para guardar un nuevo registro en la base de datos
        public int NuevaPersona(Persona persona)
        {
            DatosSistema datos = new DatosSistema();
            string[] parametros = {"@operacion",
                                    "@cedula",
                                    "@nombre",
                                    "@apellido",
                                    "@edad",
                                    "@fechaNacimiento"};

            return datos.Ejecutar("spPersonaIA",
                parametros, "I",
                persona.cedula,
                persona.nombre,
                persona.apellido,
                persona.edad,
                persona.fechaNacimiento);
        }

        // metodo para actualizar un registro
        public int ActualizarPersona(Persona persona)
        {
            DatosSistema datos = new DatosSistema();
            string[] parametros = {"@operacion",
                                    "@cedula",
                                    "@nombre",
                                    "@apellido",
                                    "@edad",
                                    "@fechaNacimiento"};

            return datos.Ejecutar("spPersonaIA",
                parametros, "A",
                persona.cedula,
                persona.nombre,
                persona.apellido,
                persona.edad,
                persona.fechaNacimiento);
        }

        // metodo para mostrar los registros almacenados en la DB
        public DataTable getPersonas()
        {
            string parametros[]={"@operacion", "@cedula"};
            DatosSistema datos = new DatosSistema();
            return datos.getDatosTabla("spPersonaSE", parametros, "Y", 0);
        }

        // metodo para eliminar
        public int EliminarPersona(string cedula)
        {
            string parametros[]={"@operacion", "@cedula"};
            DatosSistema datos = new DatosSistema();
            return datos.getDatosTabla("spPersonaSE", parametros, "E", cedula);
        }

        // metodo para consultar un registro
        public Persona getPersona(Persona p)
        {
            DatosSistema datos = new DatosSistema();
            Persona persona = new Persona();
            var dt = new DataTable();
            string[] parametros = {"@operacion","@cedula"};
            dt = datos.getDatosTabla("spPersonaSE", parametros, "S", p.cedula);
            foreach(DataRow fila in dt.Rows)
            {
                persona.cedula = fila["cedula"].ToString();
                persona.nombre = fila["nombre"].ToString();
                persona.apellido = fila["apellido"].ToString();
                persona.edad = fila["edad"].ToString();
                persona.fechaNacimiento = Convert.ToDataTime(fila["fechaNacimiento"].ToString());
            }
            return persona;
        }
    }
}