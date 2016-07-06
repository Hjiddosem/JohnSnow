using System.Collections.Generic;

namespace PTCCommon
{
    public class ModeloBaseVistas
    {
        public ModeloBaseVistas()
        {
            Iniciar();
        }

        public string EventArgument { get; set; }

        public bool AreaDetalleVisible { get; set; }
        public bool AreaListaVisible { get; set; }
        public bool AreaBusquedaVisible { get; set; }
        public string EventCommand { get; set; }
        public bool EsValido { get; set; }
        public string Modo { get; set; }
        public List<KeyValuePair<string, string>> ValidacionErrores { get; set; }

        public virtual void ManejadorSolicitud()
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

        protected virtual void ModoLista()
        {
            EsValido = true;

            AreaListaVisible = true;
            AreaBusquedaVisible = true;
            AreaDetalleVisible = false;

            Modo = "List";
        }

        protected virtual void ReBusqueda()
        {

        }

        protected virtual void ModoAgregar()
        {
            AreaListaVisible = false;
            AreaBusquedaVisible = false;
            AreaDetalleVisible = true;

            Modo = "Add";
        }

        protected virtual void ModoEditar()
        {
            AreaListaVisible = false;
            AreaBusquedaVisible = false;
            AreaDetalleVisible = true;

            Modo = "Edit";
        }

        protected virtual void Iniciar()
        {
            EventCommand = "List";
            EventArgument = string.Empty;
            ValidacionErrores = new List<KeyValuePair<string, string>>();

            ModoLista();
        }



        protected virtual void Get()
        {

        }

        protected virtual void Agregar()
        {
            ModoAgregar();
        }

        protected virtual void Editar()
        {
            ModoEditar();
        }

        protected virtual void Eliminar()
        {
            ModoLista();
        }

        protected virtual void Guardar()
        {            
            if (ValidacionErrores.Count > 0)
            {
                EsValido = false;
            }

            if (!EsValido)
            {
                if (Modo == "Add")
                {
                    ModoAgregar();
                }
            }
        }
    }
}
