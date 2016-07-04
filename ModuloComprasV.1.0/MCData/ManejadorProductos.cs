using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCData
{
    public class ManejadorProductos
    {
        public List<Productos> Get()
        {
            List<Productos> ret = new List<Productos>();

            // QUE HACER: Agregar el metodo de acceso a datos aqui
            ret = CreadorDatos();

            return ret;
        }

        private List<Productos> CreadorDatos()
        {
            List<Productos> ret = new List<Productos>();

            ret.Add(new Productos()
            {
                IdProducto = 1,
                NombreProducto = "Iphone 6s",
                Descripcion = "IOS 9, 16Gb, 13Mpx, 3D Touch",
                Precio = Convert.ToDecimal(750.00),
                Cantidad = 12
            });

            ret.Add(new Productos()
            {
                IdProducto = 2,
                NombreProducto = "MacBook Air 13",
                Descripcion = "macOS Sierra, i5 Dual Core a 1.6 Ghz, 8Gb RAM, 256Gb, Modelo 2015",
                Precio = Convert.ToDecimal(1350.00),
                Cantidad = 4
            });

            ret.Add(new Productos()
            {
                IdProducto = 3,
                NombreProducto = "MacBook Pro 13",
                Descripcion = "macOS Sierra, i5 Dual Core a 2.2 Ghz, 8Gb RAM, 256Gb, Modelo 2015",
                Precio = Convert.ToDecimal(1650.00),
                Cantidad = 3
            });

            return ret;
        }
    }
}
