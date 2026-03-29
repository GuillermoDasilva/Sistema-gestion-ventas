using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Ventas
    {
        int numero;
        DateTime fechaVenta;
        string estado;
        string direccion;
        int cantidad;

        Cliente cli;
        Articulos art;
        Empleado emp;

        public Articulos Art
        {
            get { return art; }
            set
            {
                if (value == null)
                    throw new Exception("Debe seleccionar un Articulo");

                art = value;
            }
        }
        public Empleado Emp
        {
            get { return emp; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar un Empleado");

                emp = value;
            }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public DateTime FechaVenta
        {
            get { return fechaVenta; }
            set
            {
                if (value >= DateTime.Now.AddMinutes(-10))
                    fechaVenta = value;
                else
                    throw new Exception("La fecha tiene que ser acorde a la fecha actual");
            }
        }

        public string Estado
        {
            get { return estado; }
            set
            {
                if (value == "armado" || value == "enviado" || value == "entregado" || value == "dçevuelto")
                    estado = value;
                else
                    throw new Exception("Debe seleccionar el Estado correctamente");
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (value.Trim().Length <= 30)
                    direccion = value;
                else
                    throw new Exception("La dirección no puede exceder de 30 caracteres");
            }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value > 0)
                    cantidad = value;
                else
                    throw new Exception("La cantidad debe ser mayor a 0");
            }
        }

        public Cliente Cli
        {
            get { return cli; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar un Cliente");

                cli = value;
            }
        }

        public Ventas(int pNumero, DateTime pFechaVenta, int pCantidad, string pEstado, string pDireccion, Empleado pEmpleado, Cliente pCliente, Articulos pArticulos)
        {
            Numero = pNumero;
            FechaVenta = pFechaVenta;
            Estado = pEstado;
            Cantidad = pCantidad;
            Direccion = pDireccion;
            Emp = pEmpleado;
            Cli = pCliente;
            Art = pArticulos;
        }

        public override string ToString()
        {
            return ("Número de ventas: " + Numero + " - Fecha de la venta: " + FechaVenta + " - Estado: " + Estado + " - Dirección: " + Direccion + " - Cantidad: " + Cantidad + " - Cliente: " + Cli + " - Empleado: " + Emp + " - Articulo: " + Art );
        }
    }
}
