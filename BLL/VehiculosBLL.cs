using Microsoft.EntityFrameworkCore;
using RentCarSystem.DAL;
using RentCarSystem.Entidades;
using RentCarSystem.UI.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RentCarSystem.BLL
{
    public class VehiculosBLL
    {
        private static bool Insertar(Vehiculos vehiculos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.vehiculos.Add(vehiculos);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.vehiculos.Any(e => e.VehiculoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Modificar(Vehiculos vehiculos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(vehiculos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Guardar(Vehiculos vehiculos)
        {
            if (!Existe(vehiculos.VehiculoId))
                return Insertar(vehiculos);

            else
                return Modificar(vehiculos);

        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var vehiculos = contexto.vehiculos.Find(id);

                if (vehiculos != null)
                {
                    contexto.vehiculos.Remove(vehiculos);
                    eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return eliminado;
        }

        public static Vehiculos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Vehiculos vehiculos;

            try
            {
                vehiculos = contexto.vehiculos.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return vehiculos;
        }

        public static List<Vehiculos> GetVehiculos()
        {
            List<Vehiculos> lista = new List<Vehiculos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.vehiculos.ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> criterio)
        {
            List<Vehiculos> lista = new List<Vehiculos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.vehiculos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
