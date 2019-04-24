using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Dao
{
    public class DetalheVendaDao
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public DetalheVendaDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(DetalheVenda objDetalheVenda)
        {
            string create = "insert into detalheVenda(numFatura,idVenda,subTotal,idProduto,quantidade) values('" + objDetalheVenda.NumFatura + "','" + objDetalheVenda.IdVenda + "','" + objDetalheVenda.SubTotal + "','" + objDetalheVenda.IdProduto + "','" + objDetalheVenda.Quantidade + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                objDetalheVenda.Estado = 1;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
        public void delete(DetalheVenda objDetalheVenda)
        {
            string delete = "delete from detalheVenda where idVenda='"+ objDetalheVenda.IdVenda+ "'and numFatura='"+ objDetalheVenda.NumFatura+ "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                objDetalheVenda.Estado=1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

        }
        public bool findPorNumFatura(DetalheVenda objDetalheVenda)
        {
            bool temRegistros;
            string find = "select*from detalheVenda where numFatura='" + objDetalheVenda.NumFatura + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objDetalheVenda.Estado = 99;
                }
                else
                {
                    objDetalheVenda.Estado = 1;
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
        public bool find(DetalheVenda objDetalheVenda)
        {
            bool temRegistros;
            string find = "select*from detalheVenda where idDetalhe='" + objDetalheVenda.IdDetalheVenda + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objDetalheVenda.NumFatura=Convert.ToInt64(reader[1].ToString());
                    objDetalheVenda.IdVenda= Convert.ToInt64(reader[2].ToString());
                    objDetalheVenda.SubTotal = Convert.ToDouble(reader[3].ToString());
                    objDetalheVenda.IdProduto = reader[4].ToString();
                    objDetalheVenda.Desconto = Convert.ToDouble(reader[5].ToString());
                    objDetalheVenda.Quantidade = Convert.ToInt32(reader[6].ToString());

                    objDetalheVenda.Estado = 99;
                }else
                {
                    objDetalheVenda.Estado = 1;
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
        public List<DetalheVenda> findAll()
        {
            List<DetalheVenda> lista = new List<DetalheVenda>();
            string findAll = "select*from detalheVenda";
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
               
                while (reader.Read())
                {
                    DetalheVenda objDetalheVenda = new DetalheVenda();
                    objDetalheVenda.IdDetalheVenda = Convert.ToInt64(reader[0].ToString());
                    objDetalheVenda.NumFatura = Convert.ToInt64(reader[1].ToString());
                    objDetalheVenda.IdVenda = Convert.ToInt64(reader[2].ToString());
                    objDetalheVenda.SubTotal = Convert.ToDouble(reader[3].ToString());
                    objDetalheVenda.IdProduto = reader[4].ToString();
                    //objDetalheVenda.Desconto = Convert.ToDouble(reader[5].ToString());
                    objDetalheVenda.Quantidade = Convert.ToInt32(reader[5].ToString());
                    lista.Add(objDetalheVenda);
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

            return lista;
        }
        public bool findPorIdVenda(DetalheVenda objDetalheVenda)
        {
            bool temRegistros;
            string find = "select*from detalheVenda where idVenda='" + objDetalheVenda.IdVenda + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objDetalheVenda.Estado = 99;
                }
                else
                {
                    objDetalheVenda.Estado = 1;
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
        public bool findDetalheVendaPorProdutoId(DetalheVenda objDetalheVenda)
        {
            bool temRegistros;
            string find = "select*from detalheVenda where idProduto='" + objDetalheVenda.IdProduto + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objDetalheVenda.Estado = 99;
                }
                else
                {
                    objDetalheVenda.Estado = 1;
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
        public List<DetalheVenda> detalhesPorIdVenda(DetalheVenda objDetalheVenda)
        {
            List<DetalheVenda> lista = new List<DetalheVenda>();


            string find = "select*from detalheVenda where idVenda='" + objDetalheVenda.IdVenda + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                
                while (reader.Read())
                {                    
                    DetalheVenda objDetalheVendas = new DetalheVenda();
                    objDetalheVendas.IdDetalheVenda = Convert.ToInt64(reader[0].ToString());
                    objDetalheVendas.NumFatura = Convert.ToInt64(reader[1].ToString());
                    objDetalheVendas.IdVenda = Convert.ToInt64(reader[2].ToString());
                    objDetalheVendas.SubTotal = Convert.ToDouble(reader[3].ToString());
                    objDetalheVendas.IdProduto = reader[4].ToString();
                    objDetalheVendas.Desconto = Convert.ToDouble(reader[5].ToString());
                    objDetalheVendas.Quantidade = Convert.ToInt32(reader[6].ToString());

                    lista.Add(objDetalheVendas);
                    
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

            return lista ;
        }

    }
}
