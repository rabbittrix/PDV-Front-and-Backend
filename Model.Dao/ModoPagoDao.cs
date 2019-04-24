using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Dao
{
    public class ModoPagoDao:Obrigatorio<ModoPago>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public ModoPagoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }
        public void create(ModoPago objModoPago)
        {
            string create = "insert into modoPag values('" + objModoPago.Nome + "','" + objModoPago.Outros + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objModoPago.Estado = 1000; 
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(ModoPago objModoPago)
        {
            string delete = "delete from modoPag where numPag='" + objModoPago.NumPago + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objModoPago.Estado = 1000; ;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(ModoPago objModoPago)
        {
            bool temRegistros;
            string find = "select*from modoPag where numPag='" + objModoPago.NumPago + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objModoPago.Nome = reader[1].ToString();
                    objModoPago.Outros = reader[2].ToString();

                    objModoPago.Estado = 99;
                }
                else
                {
                    objModoPago.Estado = 1;
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

        public List<ModoPago> findAll()
        {
            List<ModoPago> listaModoPagos = new List<ModoPago>();
            string find = "select*from modoPag";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ModoPago objModoPago = new ModoPago();
                    objModoPago.NumPago = Convert.ToInt32(reader[0].ToString());
                    objModoPago.Nome = reader[1].ToString();
                    objModoPago.Outros = reader[2].ToString();

                    listaModoPagos.Add(objModoPago);
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

            return listaModoPagos;
        }

        public void update(ModoPago objModoPago)
        {
            string update = "update modoPag set  nome='" + objModoPago.Nome + "',outrosDetalhes='" + objModoPago.Outros + "' where numPag='" + objModoPago.NumPago + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objModoPago.Estado = 1000; ;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}
