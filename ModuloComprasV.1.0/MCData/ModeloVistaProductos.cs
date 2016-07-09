using PTCCommon;
using System;
using System.Collections.Generic;

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

        protected override void Guardar()
        {
            ManejadorProductos mgr = new ManejadorProductos();

            if (Modo == "Add")
            {
                mgr.Insertar(Entidad);
            }
            else
            {
                mgr.Actualizar(Entidad);
            }

            ValidacionErrores = mgr.ValidacionErrores;

            base.Guardar();
        }
                
        protected override void Agregar()
        {
            EsValido = true;

            Entidad = new Productos();
            Entidad.Cantidad = 0;
            Entidad.Precio = 0;
            Entidad.UnidadMedida = "Mililitros (ml)";
            Entidad.Estado = "Activo";

            base.Agregar();
        }

        protected override void Editar()
        {
            ManejadorProductos mgr = new ManejadorProductos();

            Entidad = mgr.Get(Convert.ToInt32(EventArgument));

            base.Editar();
        }

        protected override void Eliminar()
        {
            ManejadorProductos mgr = new ManejadorProductos();
            Entidad = new Productos();
            Entidad.IdProducto = Convert.ToInt32(EventArgument);

            mgr.Eliminar(Entidad);
            Get();

            base.Eliminar();
        }

        

        protected override void ReBusqueda()
        {
            BusquedaEntidad = new Productos();
        }
        protected override void Get()
        {
            ManejadorProductos mgr = new ManejadorProductos();

            VistaProductos = mgr.Get(BusquedaEntidad);
        }        
    }
}
