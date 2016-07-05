using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCData
{
    public class ModeloVistaProductos
    {
        public ModeloVistaProductos()
        {
            Iniciar();

            VistaProductos = new List<Productos>();
            BusquedaEntidad = new Productos();
            Entidad = new Productos();
        }

        public Productos Entidad { get; set; }
        public string EventCommand { get; set; }
        public List<Productos> VistaProductos { get; set; }
        public Productos BusquedaEntidad { get; set; }

        public bool AreaDetalleVisible { get; set; }
        public bool AreaListaVisible { get; set; }
        public bool AreaBusquedaVisible { get; set; }
        public bool EsValido { get; set; }
        public string Modo { get; set; }

        private void Iniciar()
        {
            EventCommand = "List";

            ModoLista();
        }
        public void ManejadorSolicitud()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;
                case "resetsearch":
                    ReBusqueda();
                    Get();
                    break;
                case "cancel":
                    ModoLista();
                    Get();
                    break;
                case "save":
                    Guardar();
                    if (EsValido)
                    {
                        Get();
                    }
                    break;
                case "add":
                    Agregar();
                    break;
                default:
                    break;
            }
        }

        private void Guardar()
        {
            if (EsValido)
            {
                if (Modo == "Add")
                {
                    // Agregar datos a base de datos aqui
                }
            }
            else
            {
                if (Modo=="Add")
                {
                    ModoAgregar();
                }
            }
        }

        private void ModoLista()
        {
            EsValido = true;

            AreaListaVisible = true;
            AreaBusquedaVisible = true;
            AreaDetalleVisible = false;

            Modo = "List";
        }

        private void Agregar()
        {
            EsValido = true;

            Entidad = new Productos();
            Entidad.Cantidad = 1;
            Entidad.Precio = 0;

            ModoAgregar();
        }

        private void ModoAgregar()
        {
            AreaListaVisible = false;
            AreaBusquedaVisible = false;
            AreaDetalleVisible = true;

            Modo = "Add";
        }

        private void ReBusqueda()
        {
            BusquedaEntidad = new Productos();
        }
        public void Get()
        {
            ManejadorProductos mgr = new ManejadorProductos();

            VistaProductos = mgr.Get(BusquedaEntidad);
        }

        public static implicit operator ModeloVistaProductos(ManejadorProductos v)
        {
            throw new NotImplementedException();
        }
    }
}
