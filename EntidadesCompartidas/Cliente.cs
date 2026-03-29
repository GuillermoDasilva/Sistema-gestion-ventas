using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Cliente
    {
        int cedula;
        string nombreCompleto;
        long numTarjeta;
        int telefono;


        public int Cedula
        {
            get { return cedula; }
            set
            {
                if (value.ToString().Length != 8)
                    throw new Exception("La cédula debe tener 8 caracteres");

                cedula = value;
            }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set
            {
                if (value == "")
                    throw new Exception("El Cliente debe tener un nombre");
                else if (value.Trim().Length > 30)
                    throw new Exception("El nombre no puede exceder los 30 caracteres");

                nombreCompleto = value;
            }
        }

        public long NumTarjeta
        {
            get { return numTarjeta; }
            set
            {
                if (value.ToString().Length != 16)
                    throw new Exception("El numero de tarjeta debe tener 16 caracteres");

                numTarjeta = value;
            }
        }

        public int Telefono
        {
            get { return telefono; }
            set
            {
                if (value.ToString().Length >= 15)
                    throw new Exception("El numero de telefono debe tener menos de 15 caracteres");

                telefono = value;
            }
        }
        public virtual string AMostrar
        {
            get { return Cedula + " - " + NombreCompleto; }
        }

        public Cliente(int pCedula, string pNombreCompleto, long pNumTarjeta, int pTelefono)
        {
            Cedula = pCedula;
            NombreCompleto = pNombreCompleto;
            Telefono = pTelefono;
            NumTarjeta = pNumTarjeta;
        }

        public override string ToString()
        {
            return ("Cedula : " + Cedula + " - Nombre completo: " + NombreCompleto + " - Teléfono: " + Telefono + " - Número de tarjeta: " + NumTarjeta);
        }
    }
}
