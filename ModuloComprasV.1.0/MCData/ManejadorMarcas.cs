using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCData
{
    public class ManejadorMarcas
    {
        public ManejadorMarcas()
        {
            ValidacionErrores = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string, string>> ValidacionErrores { get; set; }

        public bool Validar(Marcas entidad)
        {
            ValidacionErrores.Clear();

            if (!string.IsNullOrEmpty(entidad.NombreMarca))
            {
                if (entidad.NombreMarca.ToLower() == entidad.NombreMarca)
                {
                    ValidacionErrores.Add(new KeyValuePair<string, string>("NombreMarca", "El nombre de la marca no debe estar todo en minusculas."));
                }
            }

            return (ValidacionErrores.Count == 0);
        }

        public Marcas Get(int idMarca)
        {
            List<Marcas> list = new List<Marcas>();
            Marcas ret = new Marcas();

            //QUE HACER: Llamar al metodo de acceso de datos aqui
            list = CreadorDatos();

            ret = list.Find(p => p.IdMarca == idMarca);

            return ret;
        }

        public bool Actualizar(Marcas entidad)
        {
            bool ret = false;

            ret = Validar(entidad);
            if (ret)
            {
                // QUE HACER: Crear el codigo de actualizar aqui
            }

            return ret;
        }

        public bool Insertar(Marcas entidad)
        {
            bool ret = false;

            ret = Validar(entidad);
            if (ret)
            {
                // QUE HACER: Crear el codigo INSERT aqui
            }

            return ret;
        }

        public bool Eliminar(Marcas entidad)
        {
            // QUE HACER: Crear el codigo de eliminar aqui
            return true;
        }

        public List<Marcas> Get(Marcas entidad)
        {
            List<Marcas> ret = new List<Marcas>();

            // QUE HACER: Agregar el metodo de acceso a datos aqui
            ret = CreadorDatos();

            if (!string.IsNullOrEmpty(entidad.NombreMarca))
            {
                ret = ret.FindAll(p => p.NombreMarca.ToLower().StartsWith(entidad.NombreMarca, StringComparison.CurrentCultureIgnoreCase));
            }

            return ret;
        }

        private List<Marcas> CreadorDatos()
        {
            List<Marcas> ret = new List<Marcas>();

            ret.Add(new Marcas()
            {
                IdMarca = 1,
                NombreMarca = "Apple",
                RNC = 12345,
                Estado = "Activo"
            });

            ret.Add(new Marcas()
            {
                IdMarca = 2,
                NombreMarca = "Samsung",
                RNC = 54321,
                Estado = "Activo"
            });

            ret.Add(new Marcas()
            {
                IdMarca = 3,
                NombreMarca = "Sony",
                RNC = 99999,
                Estado = "Activo"
            });

            return ret;
        }
    }
}
