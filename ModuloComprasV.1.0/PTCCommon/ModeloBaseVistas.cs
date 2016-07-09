using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
