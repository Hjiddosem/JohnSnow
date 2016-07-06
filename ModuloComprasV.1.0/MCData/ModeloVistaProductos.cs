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
            Entidad.Cantidad = 1;
            Entidad.Precio = 0;

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

            base.ReBusqueda();
        }
        protected override void Get()
        {
            ManejadorProductos mgr = new ManejadorProductos();

            VistaProductos = mgr.Get(BusquedaEntidad);

            base.Get();
        }        
    }
}
