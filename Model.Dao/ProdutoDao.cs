using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ProdutoDao:Obrigatorio<Produto>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public ProdutoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }
        public void create(Produto objProduto)
        {
            string create = "insert into produto values('" + objProduto.IdProduto + "','" + objProduto.Nome + "','" + objProduto.PrecoUnitario + "','" + objProduto.Categoria + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objProduto.Estado = 1000;                
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(Produto objProduto)
        {
            string delete = "delete from produto where idProduto='" + objProduto.IdProduto + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objProduto.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Produto objProduto)
        {
            bool temRegistros;
            string find = "select*from produto where idProduto='" + objProduto.IdProduto + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objProduto.Nome = reader[1].ToString();
                    objProduto.PrecoUnitario =Convert.ToDouble(reader[2].ToString());
                    objProduto.Categoria = reader[3].ToString();
                    
                    objProduto.Estado = 99;
                }
                else
                {
                    objProduto.Estado = 1;
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

        public List<Produto> findAll()
        {
            List<Produto> listaVendedores = new List<Produto>();
            string find = "select*from produto order by nome asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Produto objProduto = new Produto();
                    objProduto.IdProduto = reader[0].ToString();
                    objProduto.Nome = reader[1].ToString();
                    objProduto.PrecoUnitario = Convert.ToDouble(reader[2].ToString());
                    objProduto.Categoria = reader[3].ToString();
                    listaVendedores.Add(objProduto);
                }

            }
            catch (Exception)
            {
                Produto objProducto2 = new Produto();
                objProducto2.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaVendedores;
        }

        public void update(Produto objProduto)
        {
            string update = "update produto set  nome='" + objProduto.Nome + "',precoUnitario='" + objProduto.PrecoUnitario + "',idCategoria='" + objProduto.Categoria + "' where idProduto='" + objProduto.IdProduto + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objProduto.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool findProdutoPorCategoriaId(Produto objProduto)
        {
            bool temRegistros;
            string find = "select*from produto where IdCategoria='" + objProduto.Categoria + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objProduto.Estado = 99;
                }
                else
                {
                    objProduto.Estado = 1;
                }
            }
            catch (Exception u)
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

        public List<Produto> findAllProdutos(Produto objProduto)
        {
            List<Produto> listaProdutos = new List<Produto>();
          
            string findAll = "select* from produto where nome like '%" + objProduto.Nome + "%' or idProduto like '%" + objProduto.IdProduto + "%' or idCategoria like '%" + objProduto.Categoria + "%'";
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Produto objProdutos = new Produto();
                    objProdutos.IdProduto = reader[0].ToString();
                    objProdutos.Nome = reader[1].ToString();
                    objProdutos.PrecoUnitario = Convert.ToDouble(reader[2].ToString());
                    objProdutos.Categoria = reader[3].ToString();
                    listaProdutos.Add(objProdutos);

                }
            }
            catch (Exception)
            {

                objProduto.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaProdutos;

        }
        public List<Produto> findAllProdutosPorCategoria(Produto objProduto)
        {
            List<Produto> listaProdutos = new List<Produto>();
            string findAll = "select*from produto where idCategoria='" + objProduto.Categoria + "'";

           
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Produto objProdutos = new Produto();
                    objProdutos.IdProduto = reader[0].ToString();
                    objProdutos.Nome = reader[1].ToString();
                    objProdutos.PrecoUnitario = Convert.ToDouble(reader[2].ToString());
                    objProdutos.Categoria = reader[3].ToString();

                    listaProdutos.Add(objProdutos);

                }
            }
            catch (Exception)
            {

                objProduto.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaProdutos;

        }

        public List<Produto> findPrecoProduto(Produto objProdutos)
        {
            List<Produto> listaVendedores = new List<Produto>();
            string find = "select*from produto where idProduto='"+ objProdutos.IdProduto + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Produto objProduto = new Produto();
                    objProduto.IdProduto = reader[0].ToString();
                    objProduto.Nome = reader[1].ToString();
                    objProduto.PrecoUnitario = Convert.ToDouble(reader[2].ToString());
                    objProduto.Categoria = reader[3].ToString();
                    listaVendedores.Add(objProduto);
                }

            }
            catch (Exception)
            {
                Produto objProduto2 = new Produto();
                objProduto2.Estado = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaVendedores;
        }

    }
}
