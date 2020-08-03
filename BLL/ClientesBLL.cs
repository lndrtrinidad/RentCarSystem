using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RentCarSystem.DAL;
using RentCarSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentCarSystem.BLL
{
    public class ClientesBLL
    {
        private static bool Insertar(Clientes cliente)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Clientes.Add(cliente);
                paso = contexto.SaveChanges() > 0;
            }
            catch(Exception)
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
                encontrado = contexto.Clientes.Any(e => e.ClienteId == id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Modificar(Clientes cliente)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(cliente).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.ClienteId))
                return Insertar(cliente);

            else
                return Modificar(cliente);

        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var cliente = contexto.Clientes.Find(id);

                if (cliente != null)
                {
                    contexto.Clientes.Remove(cliente);
                    eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return eliminado;
        }

        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes clientes;

            try
            {
                clientes = contexto.Clientes.Find(id);

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return clientes;
        }

        public static List<Clientes> GetClientes()
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Clientes.ToList();
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

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Clientes.Where(criterio).ToList();
            }
            catch(Exception)
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
