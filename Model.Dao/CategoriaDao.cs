using System;
using System.Collections.Generic;
using Model.Entity;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class CategoriaDao:Obrigatorio<Categoria>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public CategoriaDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }



        public void create(Categoria objCategoria)
        {
            string create = "insert into categoria values('" + objCategoria.IdCategoria + "','" + objCategoria.Nome + "','" + objCategoria.Descricao + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objCategoria.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(Categoria objCategoria)
        {
            string delete = "delete from categoria where idCategoria='" + objCategoria.IdCategoria + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
objCategoria.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Categoria objCategoria)
        {
            bool temRegistros;
            string find = "select*from categoria where idCategoria='" + objCategoria.IdCategoria + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objCategoria.Nome = reader[1].ToString();
                    objCategoria.Descricao = reader[2].ToString();

                    objCategoria.Estado = 99;
                }
                else
                {
                    objCategoria.Estado = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return temRegistros;
        }

        public List<Categoria> findAll()
        {
            
            List<Categoria> listaCategorias = new List<Categoria>();
            string find = "select*from categoria";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Categoria objCategoria = new Categoria();
                    objCategoria.IdCategoria = reader[0].ToString();
                    objCategoria.Nome = reader[1].ToString();
                    objCategoria.Descricao = reader[2].ToString();

                    listaCategorias.Add(objCategoria);
                }

            }
            catch (Exception)
            {
                //objCategoria.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaCategorias;
        }

        public void update(Categoria objCategoria)
        {
            string update = "update categoria set  nome='" + objCategoria.Nome + "',descricao='" + objCategoria.Descricao + "' where idCategoria='" + objCategoria.IdCategoria + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objCategoria.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}
