using Model.Entity;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Model.Dao
{
   public class ClienteDao : Obrigatorio<Cliente>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public ClienteDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create1(Cliente objCliente)
        {
            string create = "insert into cliente(nome, endereco, telefone, cpf) VALUES ('" + objCliente.Nome + "', '" + objCliente.Endereco + "' , '" + objCliente.Telefone + "', '" + objCliente.Cpf + "' )";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                objCliente.Estado = 1;
                                             
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }


        public void create(Cliente objCliente)
        {
            string create = "sp_cliente_adc" + objCliente.Nome + "," + objCliente.Endereco + "," + objCliente.Telefone + "," + objCliente.Cpf + "";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                objCliente.Estado = 1;

            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }


        public void delete(Cliente objCliente)
        {
            string delete = "delete from cliente where idCliente = '" + objCliente.IdCliente +"' ";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                objCliente.Estado = 1;

            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void update(Cliente objCliente)
        {
            string update = "update cliente set nome='" + objCliente.Nome + "', endereco ='" + objCliente.Endereco + "', telefone='" + objCliente.Telefone + "', cpf='" + objCliente.Cpf + "' where idCliente='" + objCliente.IdCliente + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                objCliente.Estado = 1;

            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Cliente objCliente)
        {
            bool temRegistros;
            string find = "select * from cliente where idCliente  = '" + objCliente.IdCliente + "' "; 
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                    objCliente.Estado = 99;

                }else
                {
                    objCliente.Estado = 1;
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

        public List<Cliente> findAll()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "select * from cliente order by nome";

            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt64(reader[0].ToString());
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                    listaClientes.Add(objCliente);
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

            return listaClientes;
        }





        //OUTRAS IMPLEMENTAÇÕES

        public bool findClientePorcpf(Cliente objCliente)
        {
            bool temRegistros;
            string find = "select*from cliente where cpf='" + objCliente.Cpf + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();

                    objCliente.Estado = 99;

                }
                else
                {
                    objCliente.Estado = 1;
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

        public List<Cliente> findAllCliente(Cliente objCLiente)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "select* from cliente where nome like '%" + objCLiente.Nome + "%' or cpf like '%" + objCLiente.Cpf + "%' or idCliente like '%" + objCLiente.IdCliente + "%' ";
            try
            {
               
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt64(reader[0].ToString());
                    objCliente.Nome = reader[1].ToString();
                   
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                    listaClientes.Add(objCliente);

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

            return listaClientes;

        }
    }
}
