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
    }
}