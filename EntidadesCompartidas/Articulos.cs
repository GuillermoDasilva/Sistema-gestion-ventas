using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace EntidadesCompartidas
{
    public class Articulos
    {
        string codigo;
        string nombre;
        string tipo;
        int precio;
        int tamaño;

        string formatoCodigo = "^[a-zA-Z0-9]{10}$";
        Categoria cat;

        public Categoria Cat
        {
            get { return cat; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar una Categoría");

                cat = value;
            }
        }
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

        public string Tipo
        {
            get { return tipo; }
            set
            {
                if (value == "")
                    throw new Exception("El Articulo debe tener un tipo");
                else if (value.Trim().Length > 50)
                    throw new Exception("El tipo no puede exceder los 50 caracteres");
                else
                    tipo = value;
            }
        }

        public int Precio
        {
            get { return precio; }
            set
            {
                if (value < 0 )
                    throw new Exception("El precio debe ser mayor a 0");
                else
                    precio = value;
            }
        }

        public int Tamaño
        {
            get { return tamaño; }
            set
            {
                if (value < 0)
                    throw new Exception("El tamaño debe ser mayor a 0");
                else
                    tamaño = value;
            }
        }
        public Articulos(string pCodigos, string pNombre, string pTipo, int pTamaño, int pPrecio, Categoria pCat)
        {
            Codigo = pCodigos;
            Nombre = pNombre;
            Tipo = pTipo;
            Tamaño = pTamaño;
            Precio = pPrecio;
            Cat = pCat;
        }

        public override string ToString()
        {
            return ("Código: " + Codigo + " - Nombre: " + Nombre + " - Tipo: " + Tipo + " - Tamaño: " + Tamaño + " - Precio: " + Precio); 
        }

        public virtual string Mostrar
        {
            get { return Nombre + " -  $" + Precio + " - Tipo:" + Tipo + " - Tamaño:" + Tamaño + " - Categoría:" + Cat  ; }
        }

        public virtual string AMostrar
        {
            get { return Codigo; }
        }
    }
}
