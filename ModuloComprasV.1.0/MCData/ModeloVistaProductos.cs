using PTCCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCData
{
    public class ModeloVistaProductos : ModeloBaseVistas
    {
        public ModeloVistaProductos() : base()
        {
                        
        }

        public Productos Entidad { get; set; }        
        public List<Productos> VistaProductos { get; set; }
        public Productos BusquedaEntidad { get; set; }

        protected override void Iniciar()
        {
            VistaProductos = new List<Productos>();
            BusquedaEntidad = new Productos();
            Entidad = new Productos();

            base.Iniciar();
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
                    EsValido = true;
                    Editar();
                    break;

                case "delete":
                    ReBusqueda();
                    Eliminar();
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

        private void Eliminar()
        {
            ManejadorProductos mgr = new ManejadorProductos();
            Entidad = new Productos();
            Entidad.IdProducto = Convert.ToInt32(EventArgument);

            mgr.Eliminar(Entidad);
            Get();

            ModoLista();
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
        protected override void Get()
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
