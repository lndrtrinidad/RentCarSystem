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
    public class RentasBLL
    {
        private static bool Insertar(Rentas rentas )
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Rentas.Add(rentas);
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
                encontrado = contexto.Rentas.Any(e => e.RentaId == id);
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

        public static bool Modificar(Rentas rentas)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(rentas).State = EntityState.Modified;
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

        public static bool Guardar(Rentas rentas)
        {
            if (!Existe(rentas.RentaId))
                return Insertar(rentas);

            else
                return Modificar(rentas);

        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var rentas = contexto.Rentas.Find(id);

                if (rentas != null)
                {
                    contexto.Rentas.Remove(rentas);
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

        public static Rentas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Rentas rentas;

            try
            {
                rentas = contexto.Rentas.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return rentas;
        }

        public static List<Rentas> GetRentas()
        {
            List<Rentas> lista = new List<Rentas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Rentas.ToList();
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

        public static List<Rentas> GetList(Expression<Func<Rentas, bool>> criterio)
        {
            List<Rentas> lista = new List<Rentas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Rentas.Where(criterio).ToList();
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
