using System;
using System.Collections.Generic;
using Model.Dao;
using Model.Entity;

namespace Model.Neg
{
    public class VendaNeg
    {
        private VendaDao objVendaDao;
        private DetalheVendaDao objDetalheVendaDao;
        public VendaNeg()
        {
            objVendaDao = new VendaDao();
            objDetalheVendaDao = new DetalheVendaDao();
        }

        public string create(Venda objVenda)
        {
            bool verificacao = true;                 
                        
            //inicio verificacao total estado=2
            string total = objVenda.Total.ToString();
            double total1 = 0;
            if (total == null)
            {
                objVenda.Estado = 20;
                
            }else
            {
                try
                {
                    total1 = Convert.ToDouble(objVenda.Total);
                    verificacao = total1 > 0 && total1 < 999999999999999;

                    if (!verificacao)
                    {
                        objVenda.Estado = 2;
                        
                    }
                }
                catch (Exception e)
                {
                    objVenda.Estado = 200;
                    
                }
            }
            //fim verificacao total            


            //inicio verificacao data estado=4
            string data = objVenda.Data.ToString();
            
            if (data == null)
            {
                objVenda.Estado = 40;
                
            }else
            {
                data = objVenda.Data.Trim();
                verificacao = data.Length > 0 && data.Length < 30;          
                if (!verificacao)
                {
                    objVenda.Estado = 4;
                    
                }
            }
            //fim verificacao de data

           //se tudo tiver ok salve
            objVenda.Estado = 99;
           return  objVendaDao.create(objVenda);
           
        }

        public void update(Venda objVenda)
        {
            bool verificacao = true;

            //inicio verificacao total estado=2
            string total = objVenda.Total.ToString();
            double total1 = 0;
            if (total == null)
            {
                objVenda.Estado = 20;

            }
            else
            {
                try
                {
                    total1 = Convert.ToDouble(objVenda.Total);
                    verificacao = total1 > 0 && total1 < 999999999999999;

                    if (!verificacao)
                    {
                        objVenda.Estado = 2;

                    }
                }
                catch (Exception e)
                {
                    objVenda.Estado = 200;

                }
            }
            //fim verificacao total            


            //inicio verificacao data estado=4
            string data = objVenda.Data.ToString();

            if (data == null)
            {
                objVenda.Estado = 40;

            }
            else
            {
                data = objVenda.Data.Trim();
                verificacao = data.Length > 0 && data.Length < 30;
                if (!verificacao)
                {
                    objVenda.Estado = 4;

                }
            }
            //fim verificacao de data

            //se Tudo tiver ok pode editar
            objVenda.Estado = 99;
            objVendaDao.update(objVenda);
            return;
        }

        public void delete(Venda objVenda)
        { 
            bool verificacao = true;

            //inicio verificacao de existencia
            /*Venda objVendaAux = new Venda();
            objVendaAux.IdVenda = objVenda.IdVenda;
            verificacao = objVendaDao.find(objVendaAux);
            if (!verificacao)
            {
                objVenda.Estado = 33;
                return;
            }*/


            //VERIFICAR DEPOIS SE EXISTE DETALHE DE VENDAS RELACIONADO
            DetalheVenda objDetalheVenda = new DetalheVenda();
            objDetalheVenda.IdVenda = objVenda.IdVenda;
            verificacao = !objDetalheVendaDao.findPorIdVenda(objDetalheVenda);
            if (!verificacao)
            {
                objVenda.Estado = 34;
                return;
            }


            //se tudo tiver ok pode deletar
            objVenda.Estado = 99;
            objVendaDao.delete(objVenda);
            return;
        }

        public bool find(Venda objVenda)
        {
            return objVendaDao.find(objVenda);
        }
        public List<Venda> findAll()
        {
            return objVendaDao.findAll();
        }        

        }
}
