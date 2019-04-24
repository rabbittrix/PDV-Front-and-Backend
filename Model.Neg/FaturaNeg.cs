using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Neg
{
    public class FaturaNeg
    {
        private FaturaDao objFaturaDao;
        private DetalheVendaDao objDetalheFaturaDao;
        public FaturaNeg()
        {
            objFaturaDao = new FaturaDao();
            objDetalheFaturaDao = new DetalheVendaDao();
        }

        public string create(Fatura objFatura)
        {
            bool verificacao = true;

            //inicio verificacao numFatura retorna estado=!
            string numf = objFatura.NumFatura.ToString();
            int num = 0;
            if (numf == null)
            {
                objFatura.Estado = 10;
            }else
            {
                try
                {
                    num = Convert.ToInt32(objFatura.NumFatura);
                    verificacao = num > 0 && num < 9999;
                    if (!verificacao)
                    {
                        objFatura.Estado = 1;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            //fim


            //inicio verifica data estado=2
            string data = objFatura.Data;
            
            if (data == null)
            {
                objFatura.Estado = 20;
               
            }
            else
            {
                data=objFatura.Data.Trim();
                verificacao = data.Length>0&&data.Length<30;
                if (!verificacao)
                {
                    objFatura.Estado = 2;
                   
                }
            }
            //fim

            //inicio verifica taxa estado=3
            string taxa = objFatura.Taxa.ToString();
            double taxas = 0;
            if (taxa == null)
            {
                objFatura.Estado = 30;
            }else
            {
                try
                {
                    taxas = Convert.ToDouble(objFatura.Taxa);
                    verificacao = taxas >= 0 &&taxas< 99;
                    if (!verificacao)
                    {
                        objFatura.Estado = 3;
                    }
                }
                catch (Exception)
                {

                    objFatura.Estado=300;
                }
            }
            //fim

            //inicio verifica total estado=4
            string total = objFatura.Total.ToString();
            double tot = 0;
            if (total == null)
            {
                objFatura.Estado = 40;
                
            }else
            {
                try
                {
                    tot = Convert.ToDouble(objFatura.Total);
                    verificacao = tot >= 0 && tot < 99999999;
                    if (!verificacao)
                    {
                        objFatura.Estado = 4;
                       
                    }
                }
                catch (Exception)
                {

                    objFatura.Estado = 400;
                   
                }
            }
            //fim


            //inicio verificacao total estado=5
            string nump = objFatura.NumPago.ToString();
            int numpag = 0;
            if (nump == null)
            {
                objFatura.Estado = 50;
                
            }
            else
            {
                try
                {
                    numpag = Convert.ToInt32(objFatura.NumPago);
                    verificacao = numpag >= 0 && numpag < 99999999;
                    if (!verificacao)
                    {
                        objFatura.Estado = 5;
                       
                    }
                }
                catch (Exception)
                {

                    objFatura.Estado = 500;
                   
                }
            }
            //fim

            //inicio verifica de duplicidade estado=6
            Fatura objFaturaAux = new Fatura();
            objFaturaAux.NumFatura = objFatura.NumFatura;
            verificacao = !objFaturaDao.find(objFaturaAux);
            if (!verificacao)
            {
                objFatura.Estado = 6;
                
            }

            //se tudo tiver ok
            objFatura.Estado = 99;
            return objFaturaDao.create(objFatura);
            
        }

        public void update(Fatura objFatura)
        {
            bool verificacao = true;
            //inicio verificacion fecha estado=2
            string data = objFatura.Data.ToString();

            if (data == null)
            {
                objFatura.Estado = 20;
                return;
            }
            else
            {
                data = objFatura.Data.Trim();
                verificacao = data.Length > 0 && data.Length < 30;
                if (!verificacao)
                {
                    objFatura.Estado = 2;
                    return;
                }
            }
            //fim

            //inicio verifica taxa estado=3
            string taxa = objFatura.Taxa.ToString();
            double taxas = 0;
            if (taxa == null)
            {
                objFatura.Estado = 30;
            }
            else
            {
                try
                {
                    taxas = Convert.ToDouble(objFatura.Taxa);
                    verificacao = taxas > 0 && taxas < 99;
                    if (!verificacao)
                    {
                        objFatura.Estado = 3;
                    }
                }
                catch (Exception)
                {

                    objFatura.Estado = 300;
                }
            }
            //fim

            //inicio verifica total estado=4
            string total = objFatura.Total.ToString();
            double tot = 0;
            if (total == null)
            {
                objFatura.Estado = 40;

            }
            else
            {
                try
                {
                    tot = Convert.ToDouble(objFatura.Total);
                    verificacao = tot >= 0 && tot < 99999999;
                    if (!verificacao)
                    {
                        objFatura.Estado = 4;

                    }
                }
                catch (Exception)
                {

                    objFatura.Estado = 400;

                }
            }
            //fim


            //inicio verificacao total estado=5
            string nump = objFatura.NumPago.ToString();
            int numpag = 0;
            if (nump == null)
            {
                objFatura.Estado = 50;

            }
            else
            {
                try
                {
                    numpag = Convert.ToInt32(objFatura.NumPago);
                    verificacao = numpag >= 0 && numpag < 99999999;
                    if (!verificacao)
                    {
                        objFatura.Estado = 5;

                    }
                }
                catch (Exception)
                {

                    objFatura.Estado = 500;

                }
            }
            //fim


            //se tudo tiver ok atualize
            objFatura.Estado = 99;
            objFaturaDao.update(objFatura);
            return;
        }

        public void delete(Fatura objFatura)
        {
            bool verificacao = true;
            //verifica existencia
            Fatura objFaturaAux = new Fatura();
            objFaturaAux.NumFatura = objFatura.NumFatura;
            verificacao = objFaturaDao.find(objFaturaAux);
            if (!verificacao)
            {
                objFatura.Estado = 33;
                return;
            }

            //verifica existencia de Detalhe
            DetalheVenda objDetalheVenda = new DetalheVenda();
            objDetalheVenda.NumFatura = objFatura.NumFatura;
            verificacao = !objDetalheFaturaDao.findPorNumFatura(objDetalheVenda);
            if (!verificacao)
            {
                objFatura.Estado = 34;
                return;
            }
            objFatura.Estado = 99;
            objFaturaDao.delete(objFatura);
            return;
        }
      
        public bool find(Fatura objFatura)
        {
            return objFaturaDao.find(objFatura);
        }

        public List<Fatura> findAll()
        {
            return objFaturaDao.findAll();
        }
    }
}
