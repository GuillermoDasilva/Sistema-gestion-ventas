using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace EntidadesCompartidas
{
    public class Categoria
    {
        string codigo;
        string nombre;

        string formatoCodigo = "^[a-zA-Z0-9]{6}$";

        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (!Regex.IsMatch(value, formatoCodigo))
                    throw new Exception("El código ingresado no es válido");

                codigo = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value == "")
                    throw new Exception("El Articulo debe tener un nombre");
                else if (value.Trim().Length > 30)
                    throw new Exception("El nombre no puede exceder los 30 caracteres");
                else
                    nombre = value;
            }
        }
        public  virtual string Mostrar
        {
            get { return Nombre; }
        }

        public Categoria(string pCodigos, string pNombre)
        {
            Codigo = pCodigos;
            Nombre = pNombre;
        }

        public override string ToString()
        {
            return ("Código: " + Codigo + " - Nombre: " + Nombre);
        }
    }
}
