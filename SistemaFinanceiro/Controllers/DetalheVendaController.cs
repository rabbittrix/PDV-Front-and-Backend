using Model.Entity;
using Model.Neg;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaFinanceiro.Controllers
{
    public class DetalheVendaController : Controller
    {
        private DetalheVendaNeg objDetalheVendaNeg;
        private FaturaNeg objFaturaNeg;
        private VendaNeg objVendaNeg;
        public DetalheVendaController()
        {
            objDetalheVendaNeg = new DetalheVendaNeg();
            objFaturaNeg = new FaturaNeg();
            objVendaNeg = new VendaNeg();
        }
        // GET: DetalheVenda
        public ActionResult Index()
        {
            List<DetalheVenda> lista = objDetalheVendaNeg.findAll();
            return View(lista);
        }

        public ActionResult Eliminar(long idVenda,long idFatura)
        {
            DetalheVenda objDetalheVenda = new DetalheVenda();
            objDetalheVenda.IdVenda = idVenda;
            objDetalheVenda.NumFatura = idFatura;
            objDetalheVendaNeg.delete(objDetalheVenda);
            
            
            //eliminar venda
            Venda objVenda = new Venda(idVenda);
            objVendaNeg.delete(objVenda);

            //eliminar fatura
            Fatura objFatura = new Fatura(idFatura);
            objFaturaNeg.delete(objFatura);

            return View();
        }
    }
}