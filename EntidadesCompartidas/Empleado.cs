using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Empleado
    {
        string contraseña;
        string usuDeLogueo;
        string nombre;


        public string Contraseña
        {
            get { return contraseña; }
            set
            {
                if (value.ToString().Length > 8 && value.ToString().Length < 20)
                    throw new Exception("La Contraseña debe tener mínimo 8 caracteres");

                contraseña = value;
            }
        }

        public string UsuDeLogueo
        {
            get { return usuDeLogueo; }
            set
            {
                if (value == "")
                    throw new Exception("El Usuario debe tener un nombre");
                else if (value.Trim().Length > 50)
                    throw new Exception("El nombre de usuario no puede exceder los 50 caracteres");

                usuDeLogueo = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value == "")
                    throw new Exception("El Usuario debe tener un nombre");
                else if (value.Trim().Length > 30)
                    throw new Exception("El nombre no puede exceder los 30 caracteres");

                nombre = value;
            }
        }

        public Empleado(string pContraseña, string pUsudeLogueo, string pNombre)
        {
            Contraseña = pContraseña;
            UsuDeLogueo = pUsudeLogueo;
            Nombre = pNombre;
        }

        public override string ToString()
        {
            return ("Usuario de Logueo : " + UsuDeLogueo + " - Nombre: " + Nombre );
        }
    }
}
