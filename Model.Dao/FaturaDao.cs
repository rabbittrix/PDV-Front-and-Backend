using System;
using System.Collections.Generic;
using Model.Entity;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class FaturaDao
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public FaturaDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public string create(Fatura objFatura)
        {
            string codigoFatura = "";
            string create = "insert into fatura (data,TAXA,total,numPag)values('" + objFatura.Data + "','" + objFatura.Taxa + "','" + objFatura.Total + "','" + objFatura.NumPago + "') SELECT SCOPE_IDENTITY();";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    codigoFatura = reader[0].ToString();
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
            return codigoFatura;
        }

        public void delete(Fatura objFatura)
        {
            string delete = "delete from fatura where numFatura='" + objFatura.NumFatura + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objFatura.Estado = 1;
               
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Fatura objFatura)
        {
            bool temRegistros;
            string find = "select * from fatura where numFatura='" + objFatura.NumFatura + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader= comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objFatura.Data =  reader[1].ToString();
                    objFatura.Taxa = Convert.ToDouble(reader[2].ToString());
                    objFatura.Total = Convert.ToDouble(reader[3].ToString());
                    objFatura.NumPago = Convert.ToInt32(reader[4].ToString());

                    objFatura.Estado = 99;
                }
                else
                {
                    objFatura.Estado = 1;
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

        public List<Fatura> findAll()
        {
            List<Fatura> listaFaturas = new List<Fatura>();
            string findAll = "select * from fatura";
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();                
                while (reader.Read())
                {
                    Fatura objFatura = new Fatura();
                    objFatura.NumFatura= Convert.ToInt64(reader[0].ToString());
                    objFatura.Data = reader[1].ToString();
                    objFatura.Taxa = Convert.ToDouble(reader[2].ToString());
                    objFatura.Total = Convert.ToDouble(reader[3].ToString());
                    objFatura.NumPago = Convert.ToInt32(reader[4].ToString());
                    listaFaturas.Add(objFatura);
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
            return listaFaturas;
        }

        public void update(Fatura objFatura)
        {
            string update = "update  fatura set data='" + objFatura.Data + "',TAXA='" + objFatura.Taxa + "',total='" + objFatura.Total + "',numPag='" + objFatura.NumPago + "' where numFatura='" + objFatura.NumFatura + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
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
        }

        public bool findFaturaPorNumPago(Fatura objFatura)
        {
            bool temRegistros;
            string find = "select * from fatura where numPag=" + objFatura.NumPago;
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objFatura.Estado = 99;
                }
                else
                {
                    objFatura.Estado = 1;
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

    }
}
