using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Neg
{
    public class DetalheVendaNeg
    {
        private DetalheVendaDao objDetalheVendaDao;
        public DetalheVendaNeg()
        {
            objDetalheVendaDao = new DetalheVendaDao();
        }
        public void create(DetalheVenda objDetalheVenda)
        {
            bool verificacao = true;

            //inicio verificacion de cantidaa estado=1
            int quant = 0;
            string quantidade = objDetalheVenda.Quantidade.ToString();
            if (quantidade == null)
            {
                objDetalheVenda.Estado = 10;
                return;
            }
            else
            {
                try
                {
                    quant = Convert.ToInt32(objDetalheVenda.Quantidade);
                    verificacao = quant > 0 && quant < 999999;
                    if (!verificacao)
                    {
                        objDetalheVenda.Estado = 1;
                        return;
                    }
                }
                catch (Exception e)
                {
                    objDetalheVenda.Estado = 100;
                    return;
                }

            }
            //fim
            objDetalheVenda.Estado = 99;
            objDetalheVendaDao.create(objDetalheVenda);
            return;

        }

        public List<DetalheVenda> detalhesPorIdVenda(DetalheVenda objDetalheVenda)
        {
            return objDetalheVendaDao.detalhesPorIdVenda(objDetalheVenda);
        }
        public void delete(DetalheVenda objDetalheVenda)
        {            
            objDetalheVendaDao.delete(objDetalheVenda);
        }
        public List<DetalheVenda> findAll()
        {
            return objDetalheVendaDao.findAll();
        }


    }
}
