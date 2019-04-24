using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ProdutoNeg
    {
        private ProdutoDao objProdutoDao;
       
        public ProdutoNeg()
        {
            objProdutoDao = new ProdutoDao();
           
        }
        public void create(Produto objProduto)
        {
            bool verificacao = true;
            //inicio verificacao de codigo estado=1
            string codigo = objProduto.IdProduto;
            if (codigo == null)
            {
                objProduto.Estado = 10;
                return;
            }
            else
            {
                codigo = objProduto.IdProduto.Trim();
                verificacao = codigo.Length > 0 && codigo.Length <= 5;
                if (!verificacao)
                {
                    objProduto.Estado = 1;
                    return;
                }
            }
            //fim verificacao de codigo

            //inicio verificacion de nome estado=2
            string nome = objProduto.Nome;
            if (nome == null)
            {
                objProduto.Estado = 20;
                return;
            }
            else
            {
                nome = objProduto.Nome.Trim();
                verificacao = nome.Length > 0 && nome.Length <= 30;
                if (!verificacao)
                {
                    objProduto.Estado = 2;
                    return;
                }
            }
            //fim 


            //inicio verificacao de preco estado=3
            string precoUni = objProduto.PrecoUnitario.ToString();
            double preUni = 0;
            if (nome == null)
            {
                objProduto.Estado = 30;
                return;
            }
            else
            {
                try
                {
                    preUni = Convert.ToDouble(objProduto.PrecoUnitario);
                    verificacao = preUni > 0 && preUni <= 9999999;
                    if (!verificacao)
                    {
                        objProduto.Estado = 3;
                        return;
                    }
                }
                catch (Exception)
                {
                    objProduto.Estado = 300;
                    return;
                }

            }
            //fim


            //inicio verificacao de categoria estado=4
            string categoria = objProduto.Categoria;
            if (categoria == null)
            {
                objProduto.Estado = 40;
                return;
            }
            else
            {
                categoria = objProduto.Categoria.Trim();
                verificacao = categoria.Length > 0 && categoria.Length <= 30;
                if (!verificacao)
                {
                    objProduto.Estado = 4;
                    return;
                }
            }
            //fim

            //verificacao de duplicidade estado=5
            Produto objProdutoAux = new Produto();
            objProdutoAux.IdProduto = objProduto.IdProduto;
            verificacao = !objProdutoDao.find(objProdutoAux);
            if (!verificacao)
            {
                objProduto.Estado = 5;
                return;
            }
            //fim


            //se tudo tiver ok salva
            objProduto.Estado = 99;
            objProdutoDao.create(objProduto);
            return;
        }

        public void update(Produto objProduto)
        {
            bool verificacao = true;

            //inicio verificacion de nome estado=2
            string nome = objProduto.Nome;
            if (nome == null)
            {
                objProduto.Estado = 20;
                return;
            }
            else
            {
                nome = objProduto.Nome.Trim();
                verificacao = nome.Length > 0 && nome.Length <= 30;
                if (!verificacao)
                {
                    objProduto.Estado = 2;
                    return;
                }
            }
            //fim 


            //inicio verificacao de preco estado=3
            string precoUni = objProduto.PrecoUnitario.ToString();
            double preUni = 0;
            if (nome == null)
            {
                objProduto.Estado = 30;
                return;
            }
            else
            {
                try
                {
                    preUni = Convert.ToDouble(objProduto.PrecoUnitario);
                    verificacao = preUni > 0 && preUni <= 9999999;
                    if (!verificacao)
                    {
                        objProduto.Estado = 3;
                        return;
                    }
                }
                catch (Exception)
                {
                    objProduto.Estado = 300;
                    return;
                }

            }
            //fim


            //inicio verificacao de categoria estado=4
            string categoria = objProduto.Categoria;
            if (categoria == null)
            {
                objProduto.Estado = 40;
                return;
            }
            else
            {
                categoria = objProduto.Categoria.Trim();
                verificacao = categoria.Length > 0 && categoria.Length <= 30;
                if (!verificacao)
                {
                    objProduto.Estado = 4;
                    return;
                }
            }
            //fim

            //tudo ok edite
            objProduto.Estado = 99;
            objProdutoDao.update(objProduto);
            return;
        }

        public void delete(Produto objProduto)
        {
            bool verificacao = true;
            //verificacion de existencia estado=33
            Produto objProdutoAux = new Produto();
            objProdutoAux.IdProduto = objProduto.IdProduto;
            verificacao = objProdutoDao.find(objProdutoAux);
            if (!verificacao)
            {
                objProduto.Estado = 33;
                return;
            }
            

            //verificacao de detalhe venda estado=34
           //POR AQUI DEPOIS O CODIGO DE DETALHE VENDAS

            //todo ok
            objProduto.Estado = 99;
            objProdutoDao.delete(objProduto);
            return;

        }

        public bool find(Produto objProduto)
        {
            return objProdutoDao.find(objProduto);
        }

        public List<Produto> findAll()
        {
            return objProdutoDao.findAll();
        }

        public List<Produto> findPrecoProduto(Produto objProduto)
        {
            return objProdutoDao.findPrecoProduto(objProduto);
        }

        public List<Produto> findAllProdutos(Produto objProduto)
        {
            return objProdutoDao.findAllProdutos(objProduto);
        }
        public List<Produto> findAllProdutosPorCategoria(Produto objProduto)
        {
            return objProdutoDao.findAllProdutosPorCategoria(objProduto);
        }
    }
}
