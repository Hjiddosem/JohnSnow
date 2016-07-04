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
            VistaProductos = new List<Productos>();
            EventCommand = "List";
        }

        public string EventCommand { get; set; }
        public List<Productos> VistaProductos { get; set; }

        public void ManejadorSolicitud()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                    Get();
                    break;
                default:
                    break;
            }
        }
        public void Get()
        {
            ManejadorProductos mgr = new ManejadorProductos();
            VistaProductos = mgr.Get();
        }

        public static implicit operator ModeloVistaProductos(ManejadorProductos v)
        {
            throw new NotImplementedException();
        }
    }
}
