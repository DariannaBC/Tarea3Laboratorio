using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea3Laboratorio.Entidades;
using Tarea3Laboratorio.DAL;
using System.Linq.Expressions;


namespace Tarea3Laboratorio.BLL
{
   public  class UsuarioBLL
    {
        public static bool Guardar(Usuario usuario)
        {
            if (!Existe(usuario.UsuarioID))
                return Insertar(usuario);
            else
                return Modificar(usuario);
        }

        private static bool Insertar(Usuario usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Usuario.Add(usuario);
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

        public static bool Modificar(Usuario usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var usuario = contexto.Usuario.Find(id);
                if (usuario != null)
                {
                    contexto.Usuario.Remove(usuario);
                    paso = contexto.SaveChanges() > 0;
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

            return paso;
        }

        public static Usuario Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuario usuario;
            try
            {
                usuario = contexto.Usuario.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return usuario;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Usuario.Any(e => e.UsuarioID == id);
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

        public static bool ExisteAlias(string buscaralias)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Usuario.Any(e => e.Alias == buscaralias);
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

        public static List<Usuario> GetList(Expression<Func<Usuario, bool>> criterio)
        {
            List<Usuario> lista = new List<Usuario>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Usuario.Where(criterio).ToList();
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
