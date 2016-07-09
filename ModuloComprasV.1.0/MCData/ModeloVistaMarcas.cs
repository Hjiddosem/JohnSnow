using PTCCommon;
using System;
using System.Collections.Generic;

namespace MCData
{
    public class ModeloVistaMarcas : ModeloBaseVistas
    {
        public ModeloVistaMarcas() : base()
        {

        }

        public Marcas Entidad { get; set; }
        public List<Marcas> VistaMarcas { get; set; }
        public Marcas BusquedaEntidad { get; set; }


        protected override void Iniciar()
        {
            VistaMarcas = new List<Marcas>();
            BusquedaEntidad = new Marcas();
            Entidad = new Marcas();

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
            ManejadorMarcas mgr = new ManejadorMarcas();

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

            Entidad = new Marcas();
            Entidad.Estado = "Activo";

            base.Agregar();
        }

        protected override void Editar()
        {
            ManejadorMarcas mgr = new ManejadorMarcas();

            Entidad = mgr.Get(Convert.ToInt32(EventArgument));

            base.Editar();
        }

        protected override void Eliminar()
        {
            ManejadorMarcas mgr = new ManejadorMarcas();
            Entidad = new Marcas();
            Entidad.IdMarca = Convert.ToInt32(EventArgument);

            mgr.Eliminar(Entidad);
            Get();

            base.Eliminar();
        }

        protected override void ReBusqueda()
        {
            BusquedaEntidad = new Marcas();
        }
        protected override void Get()
        {
            ManejadorMarcas mgr = new ManejadorMarcas();

            VistaMarcas = mgr.Get(BusquedaEntidad);
        }
    }
    }


