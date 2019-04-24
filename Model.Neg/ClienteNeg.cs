using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ClienteNeg
    {
        private ClienteDao objClienteDao;

        public ClienteNeg()
        {
            objClienteDao = new ClienteDao();

        }

        public void create(Cliente objCliente)
        {
            bool verificacao = true;

            string nome = objCliente.Nome;
            if (nome == null)
            {
                objCliente.Estado = 20;
                return;
            }
            else
            {
                nome = objCliente.Nome.Trim();
                verificacao = nome.Length <= 30 && nome.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }

               

            }
            //end validar nome

            //inicio da validação do cpf
            string cpf = objCliente.Cpf;
            if (cpf == null)
            {
                objCliente.Estado = 50;
                return;
            }
            else
            {
                cpf = objCliente.Cpf.Trim();
                verificacao = cpf.Length <= 12 && cpf.Length > 10;
                if (!verificacao)
                {
                    objCliente.Estado = 250;
                    return;
                }

            }

                //fim da validãção do cpf

                //begin validar endereco retorna estado=6
                string endereco = objCliente.Endereco;
            if (endereco == null)
            {
                objCliente.Estado = 60;
                return;
            }
            else
            {
                endereco = objCliente.Endereco.Trim();
                verificacao = endereco.Length <= 50 && endereco.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 6;
                    return;
                }

            }
            //end validar endereco

            //begin validar telefone retorna estado=7
            string telefone = objCliente.Telefone;
            if (telefone == null)
            {
                objCliente.Estado = 70;
                return;
            }
            else
            {
                telefone = objCliente.Telefone.Trim();
                verificacao = telefone.Length <= 15 && telefone.Length > 7;
                if (!verificacao)
                {
                    objCliente.Estado = 7;
                    return;
                }

            }
            //end validar telefone

            //begin verificar duplicidade retorna estado=8
            Cliente objClienteAux = new Cliente();
            objClienteAux.IdCliente = objCliente.IdCliente;
            verificacao = !objClienteDao.find(objClienteAux);
            if (!verificacao)
            {
                objCliente.Estado = 8;
                return;
            }
            //end validar duplicidade

            //begin verificar duplicidade cpf retorna estado=8
            Cliente objCliente1 = new Cliente();
            objCliente1.Cpf = objCliente.Cpf;
            verificacao = !objClienteDao.findClientePorcpf(objCliente1);
            if (!verificacao)
            {
                objCliente.Estado = 9;
                return;
            }
           

            //se nao tem erro
            objCliente.Estado = 99;
            objClienteDao.create1(objCliente);
            return;
        }

        //end validar duplicidade cpf

        public void update(Cliente objCliente)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string codigo = objCliente.IdCliente.ToString();
            long id = 0;
            if (codigo == null)
            {
                objCliente.Estado = 10;
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objCliente.IdCliente);
                    verificacao = codigo.Length > 0 && codigo.Length < 999999;


                    if (!verificacao)
                    {
                        objCliente.Estado = 1;
                        return;
                    }
                }
                catch (Exception e)
                {
                    objCliente.Estado = 100;
                    return;
                }

            }
            //end validar codigo


            //begin validar nome retorna estado=2
            string nome = objCliente.Nome;
            if (nome == null)
            {
                objCliente.Estado = 20;
                return;
            }
            else
            {
                nome = objCliente.Nome.Trim();
                verificacao = nome.Length <= 30 && nome.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }

            }
            //end validar nome




            //inicio da validação do cpf
            string cpf = objCliente.Cpf;
            if (cpf == null)
            {
                objCliente.Estado = 50;
                return;
            }
            else
            {
                cpf = objCliente.Cpf.Trim();
                verificacao = cpf.Length <= 12 && cpf.Length > 10;
                if (!verificacao)
                {
                    objCliente.Estado = 250;
                    return;
                }

            }

            //fim da validãção do cpf



            //begin validar endereço retorna estado=6
            string endereco = objCliente.Endereco;
            if (endereco == null)
            {
                objCliente.Estado = 60;
                return;
            }
            else
            {
                endereco = objCliente.Endereco.Trim();
                verificacao = endereco.Length <= 50 && endereco.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 6;
                    return;
                }

            }
            //end validar endereco

            //begin validar telefone retorna estado=7
            string telefone = objCliente.Telefone;
            if (telefone == null)
            {
                objCliente.Estado = 70;
                return;
            }
            else
            {
                telefone = objCliente.Telefone.Trim();
                verificacao = telefone.Length <= 30 && telefone.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 7;
                    return;
                }

            }
            //end validar telefone

         

            //se nao tem erro
            objCliente.Estado = 99;
            objClienteDao.update(objCliente);
            return;
        }

        public void delete(Cliente objCliente)
        {
            bool verificacao = true;
            //verificando se existe
            Cliente objClienteAux = new Cliente();
            objClienteAux.IdCliente = objCliente.IdCliente;
            verificacao = objClienteDao.find(objClienteAux);
            if (!verificacao)
            {
                objCliente.Estado = 33;
                return;
            }


            objCliente.Estado = 99;
            objClienteDao.delete(objCliente);
            return;
        }

        public bool find(Cliente objCliente)
        {
            return objClienteDao.find(objCliente);
        }

        public List<Cliente> findAll()
        {
            return objClienteDao.findAll();
        }
        public List<Cliente> findAllClientes(Cliente objCLiente)
        {
            return objClienteDao.findAllCliente(objCLiente);
        }
    }
}
