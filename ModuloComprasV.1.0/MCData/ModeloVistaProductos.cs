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

        public string EventArgument { get; set; }

        public bool AreaDetalleVisible { get; set; }
        public bool AreaListaVisible { get; set; }
        public bool AreaBusquedaVisible { get; set; }
        public bool EsValido { get; set; }
        public string Modo { get; set; }
        public List<KeyValuePair<string, string>> ValidacionErrores { get; set; }

        private void Iniciar()
        {
            EventCommand = "List";
            EventArgument = string.Empty;
            ValidacionErrores = new List<KeyValuePair<string, string>>();

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

                case "edit":
                    System.Diagnostics.Debugger.Break();
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
            ManejadorProductos mgr = new ManejadorProductos();

            if (Modo == "Add")
            {
                mgr.Insertar(Entidad);
            }

            ValidacionErrores = mgr.ValidacionErrores;
            if (ValidacionErrores.Count > 0)
            {
                EsValido = false;
            }

            if (!EsValido)
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

        private void Editar()
        {
            ManejadorProductos mgr = new ManejadorProductos();
        }

        private void ModoAgregar()
        {
            AreaListaVisible = false;
            AreaBusquedaVisible = false;
            AreaDetalleVisible = true;

            Modo = "Add";
        }

        private void ModoEditar()
        {
            AreaListaVisible = false;
            AreaBusquedaVisible = false;
            AreaDetalleVisible = true;

            Modo = "Edit";
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
