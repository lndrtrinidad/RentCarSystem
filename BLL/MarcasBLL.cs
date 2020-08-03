using RentCarSystem.DAL;
using RentCarSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentCarSystem.BLL
{
    public class MarcasBLL
    {
        public static Marcas Buscar(int id)
        {
            Marcas marca;
            Contexto contexto = new Contexto();

            try
            {
                marca = contexto.Marcas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return marca;
        }
        public static List<Marcas> GetMarcas()
        {
            List<Marcas> lista = new List<Marcas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Marcas.ToList();
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

