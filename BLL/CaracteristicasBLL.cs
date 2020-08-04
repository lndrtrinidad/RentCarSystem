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
    public class CaracteristicasBLL
    {
        private static bool Insertar(Caracteristicas caracteristicas)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Caracteristicas.Add(caracteristicas);
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
                encontrado = contexto.Caracteristicas.Any(e => e.CaracteristicasId == id);
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

        public static bool Modificar(Caracteristicas caracteristicas)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(caracteristicas).State = EntityState.Modified;
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

        public static bool Guardar(Caracteristicas caracteristicas)
        {
            if (!Existe(caracteristicas.CaracteristicasId))
                return Insertar(caracteristicas);

            else
                return Modificar(caracteristicas);

        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var caracteristica = contexto.Caracteristicas.Find(id);

                if (caracteristica != null)
                {
                    contexto.Caracteristicas.Remove(caracteristica);
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

        public static Caracteristicas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Caracteristicas caracteristicas;

            try
            {
                caracteristicas = contexto.Caracteristicas.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return caracteristicas;
        }

        public static List<Caracteristicas> GetCaracteristicas()
        {
            List<Caracteristicas> lista = new List<Caracteristicas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Caracteristicas.ToList();
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

        public static List<Caracteristicas> GetList(Expression<Func<Caracteristicas, bool>> criterio)
        {
            List<Caracteristicas> lista = new List<Caracteristicas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Caracteristicas.Where(criterio).ToList();
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
