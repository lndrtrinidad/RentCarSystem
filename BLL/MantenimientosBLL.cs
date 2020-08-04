using Microsoft.EntityFrameworkCore;
using RentCarSystem.DAL;
using RentCarSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RentCarSystem.BLL
{
    public class MantenimientosBLL
    {
        private static bool Insertar(Mantenimientos mantenimientos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Mantenimientos.Add(mantenimientos);
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
                encontrado = contexto.Mantenimientos.Any(e => e.MantenimientoId == id);
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

        public static bool Modificar(Mantenimientos mantenimientos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(mantenimientos).State = EntityState.Modified;
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

        public static bool Guardar(Mantenimientos mantenimientos)
        {
            if (!Existe(mantenimientos.MantenimientoId))
                return Insertar(mantenimientos);

            else
                return Modificar(mantenimientos);

        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var mantenimientos = contexto.Mantenimientos.Find(id);

                if (mantenimientos != null)
                {
                    contexto.Mantenimientos.Remove(mantenimientos);
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

        public static Mantenimientos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Mantenimientos mantenimientos;

            try
            {
                mantenimientos = contexto.Mantenimientos.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return mantenimientos;
        }

        public static List<Mantenimientos> GetMantenimientos()
        {
            List<Mantenimientos> lista = new List<Mantenimientos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Mantenimientos.ToList();
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

        public static List<Mantenimientos> GetList(Expression<Func<Mantenimientos, bool>> criterio)
        {
            List<Mantenimientos> lista = new List<Mantenimientos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Mantenimientos.Where(criterio).ToList();
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
