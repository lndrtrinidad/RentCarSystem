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
    public class EmpleadosBLL
    {
        private static bool Insertar(Empleados empleados)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Empleados.Add(empleados);
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
                encontrado = contexto.Empleados.Any(e => e.EmpleadoId == id);
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

        public static bool Modificar(Empleados empleados)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(empleados).State = EntityState.Modified;
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

        public static bool Guardar(Empleados empleados)
        {
            if (!Existe(empleados.EmpleadoId))
                return Insertar(empleados);

            else
                return Modificar(empleados);

        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var empleado = contexto.Empleados.Find(id);

                if (empleado != null)
                {
                    contexto.Empleados.Remove(empleado);
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

        public static  Empleados Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Empleados empleados;

            try
            {
                empleados = contexto.Empleados.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return empleados;
        }

        public static List<Empleados> GetEmpleados()
        {
            List<Empleados> lista = new List<Empleados>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Empleados.ToList();
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

        public static List<Empleados> GetList(Expression<Func<Empleados, bool>> criterio)
        {
            List<Empleados> lista = new List<Empleados>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Empleados.Where(criterio).ToList();
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
