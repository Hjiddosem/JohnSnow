﻿using System;
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
    }
}
