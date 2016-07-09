using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCData
{
    public class ManejadorProductos
    {
        public ManejadorProductos()
        {
            ValidacionErrores = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string, string>> ValidacionErrores { get; set; }

        public bool Validar(Productos entidad)
        {
            ValidacionErrores.Clear();

            if (!string.IsNullOrEmpty(entidad.NombreProducto))
            {
                if (entidad.NombreProducto.ToLower()==entidad.NombreProducto)
                {
                    
                }
            }

            return (ValidacionErrores.Count == 0);
        }

        public Productos Get(int idProducto)
        {
            var list = new List<Productos>();
            var ret = new Productos();

            //QUE HACER: Llamar al metodo de acceso de datos aqui
            list = CreadorDatos();

            ret = list.Find(p => p.IdProducto == idProducto);

            return ret;
        }

        public bool Actualizar(Productos entidad)
        {
            bool ret = false;

            ret = Validar(entidad);
            if (ret)
            {
                // QUE HACER: Crear el codigo de actualizar aqui
            }

            return ret;
        }

        public bool Insertar(Productos entidad)
        {
            bool ret = false;

            ret = Validar(entidad);
            if (ret)
            {
                // QUE HACER: Crear el codigo INSERT aqui
            }

            return ret;
        }

        public bool Eliminar(Productos entidad)
        {
            // QUE HACER: Crear el codigo de eliminar aqui
            return true;
        }

        public List<Productos> Get(Productos entidad)
        {
            var ret = new List<Productos>();

            // QUE HACER: Agregar el metodo de acceso a datos aqui
            ret = CreadorDatos();

            if (!string.IsNullOrEmpty(entidad.NombreProducto))
            {
                ret = ret.FindAll(p => p.NombreProducto.ToLower().StartsWith(entidad.NombreProducto, StringComparison.CurrentCultureIgnoreCase));
            }

            return ret;
        }

        private List<Productos> CreadorDatos()
        {
            var ret = new List<Productos>();

            ret.Add(new Productos()
            {
                IdProducto = 1,
                NombreProducto = "Iphone 6s",
                Descripcion = "IOS 9, 16Gb, 13Mpx, 3D Touch",
                Precio = Convert.ToDecimal(value: 750.00),
                Cantidad = 12,
                Estado="Activo",
                Marca="Apple",
                UnidadMedida="Kilogramos (Kg)" 
            });

            ret.Add(new Productos()
            {
                IdProducto = 2,
                NombreProducto = "MacBook Air 13",
                Descripcion = "macOS Sierra, i5 Dual Core a 1.6 Ghz, 8Gb RAM, 256Gb, Modelo 2015",
                Precio = Convert.ToDecimal(value: 1350.00),
                Cantidad = 4,
                Estado = "Activo",
                Marca = "Apple",
                UnidadMedida = "Kilogramos (Kg)"
            });

            ret.Add(new Productos()
            {
                IdProducto = 3,
                NombreProducto = "MacBook Pro 13",
                Descripcion = "macOS Sierra, i5 Dual Core a 2.2 Ghz, 8Gb RAM, 256Gb, Modelo 2015",
                Precio = Convert.ToDecimal(value: 1650.00),
                Cantidad = 3,
                Estado = "Activo",
                Marca = "Apple",
                UnidadMedida = "Kilogramos (Kg)"
            });

            return ret;
        }

        
    }
}
