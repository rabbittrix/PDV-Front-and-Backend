using System.Collections.Generic;
using Model.Dao;
using Model.Entity;

namespace Model.Neg
{
    public class VendedorNeg
    {
        private VendedorDao objVendedorDao;
        
        public VendedorNeg()
        {
            objVendedorDao = new VendedorDao();
           
        }

        public void create(Vendedor objVendedor)
        {
            bool verificacao = true;

            //inicio verificacao de idVendedor estado=1
            string codigo = objVendedor.IdVendedor;
            if (codigo == null)
            {
                objVendedor.Estado = 10;
                return;
            }else
            {
                codigo = objVendedor.IdVendedor.Trim();
                verificacao = codigo.Length > 0 && codigo.Length <= 5;
                if (!verificacao)
                {
                    objVendedor.Estado = 1;
                    return;
                }
            }
           

            //inicio verificacao de nome estado=2
            string nome = objVendedor.Nome;
            if (nome == null)
            {
                objVendedor.Estado = 20;
                return;
            }
            else
            {
                nome = objVendedor.Nome.Trim();
                verificacao = nome.Length > 0 && nome.Length <= 30;
                if (!verificacao)
                {
                    objVendedor.Estado = 2;
                    return;
                }
            }
            


            //inicio verificar cpf estado=5
            string cpf = objVendedor.Cpf;
            if (cpf == null)
            {
                objVendedor.Estado = 50;
                return;
            }
            else
            {
                cpf = objVendedor.Cpf.Trim();
                verificacao = cpf.Length > 10 && cpf.Length <= 11;
                if (!verificacao)
                {
                    objVendedor.Estado = 5;
                    return;
                }
            }
            


            //telefone verificar estado=6
            string tel = objVendedor.Telefone;
            if (tel == null)
            {
                objVendedor.Estado = 60;
                return;
            }
            else
            {
                tel = objVendedor.Telefone.Trim();
                verificacao = tel.Length > 0 && tel.Length <= 30;
                if (!verificacao)
                {
                    objVendedor.Estado = 6;
                    return;
                }
            }
            

            //inicio verificar duplicidade estado=7
            Vendedor objVendedorAux = new Vendedor();
            objVendedorAux.IdVendedor = objVendedor.IdVendedor;
            verificacao = !objVendedorDao.find(objVendedorAux);
            if (!verificacao)
            {
                objVendedor.Estado = 7;
                return;
            }
            

            // se tudo ok
            objVendedor.Estado = 99;
            objVendedorDao.create(objVendedor);
            return;

        }

        public void update(Vendedor objVendedor)
        {
            bool verificacao = true;


            //inicio verificacao de nome estado=2
            string nome = objVendedor.Nome;
            if (nome == null)
            {
                objVendedor.Estado = 20;
                return;
            }
            else
            {
                nome = objVendedor.Nome.Trim();
                verificacao = nome.Length > 0 && nome.Length <= 30;
                if (!verificacao)
                {
                    objVendedor.Estado = 2;
                    return;
                }
            }



            //inicio verificar cpf estado=5
            string cpf = objVendedor.Cpf;
            if (cpf == null)
            {
                objVendedor.Estado = 50;
                return;
            }
            else
            {
                cpf = objVendedor.Cpf.Trim();
                verificacao = cpf.Length > 10 && cpf.Length <= 11;
                if (!verificacao)
                {
                    objVendedor.Estado = 5;
                    return;
                }
            }



            //telefone verificar estado=6
            string tel = objVendedor.Telefone;
            if (tel == null)
            {
                objVendedor.Estado = 60;
                return;
            }
            else
            {
                tel = objVendedor.Telefone.Trim();
                verificacao = tel.Length > 0 && tel.Length <= 30;
                if (!verificacao)
                {
                    objVendedor.Estado = 6;
                    return;
                }
            }


            //se tudo tiver ok
            objVendedor.Estado = 99;
            objVendedorDao.update(objVendedor);
            return;

        }

        public void delete(Vendedor objVendedor)
        {
            bool verificacao = true;
           

            Vendedor objVendedorAux = new Vendedor();
            objVendedorAux.IdVendedor = objVendedor.IdVendedor;
            verificacao = objVendedorDao.find(objVendedorAux);
            if (!verificacao)
            {
                objVendedor.Estado = 33;
                return;
            }

            //verificação se tem venda relacionada
            //POR VERIFICAÇÃO AQUI
            

            objVendedor.Estado = 99;
            objVendedorDao.delete(objVendedor);
            return;
        }

        public bool find(Vendedor objVendedor)
        {
            return objVendedorDao.find(objVendedor);
        }

        public List<Vendedor> findAll()
        {
            return objVendedorDao.findAll();
        }

    }
}
