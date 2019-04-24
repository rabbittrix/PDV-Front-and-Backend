using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaFinanceiro.Controllers
{
    [Authorize]
    public class VendaController : Controller
    {

        private VendaNeg objVendaNeg;
        private ClienteNeg objClienteNeg;
        private ProdutoNeg objProdutoNeg;
        private ModoPagoNeg objModoPagoNeg;
        //add agora
        private FaturaNeg objFaturaNeg;
        private DetalheVendaNeg objDetalheVendaNeg;

        public VendaController()
        {
            objVendaNeg = new VendaNeg();
            objClienteNeg = new ClienteNeg();
            objProdutoNeg = new ProdutoNeg();
            objModoPagoNeg = new ModoPagoNeg();
            //add agora
            objFaturaNeg = new FaturaNeg();
            objDetalheVendaNeg = new DetalheVendaNeg();

        }
        [HttpGet]
        public ActionResult ObterClientes()
        {
            List<Cliente> lista = objClienteNeg.findAll();
            return View(lista);
        }

        [HttpPost]//para buscar clientes
        public ActionResult ObterClientes(string txtnome, string txtcpf, long txtcliente = -1)
        {
            if (txtnome == "")
            {
                txtnome = "-1";
            }
            
            if (txtcpf == "")
            {
                txtcpf = "-1";
            }
            Cliente objCliente = new Cliente();
            objCliente.Nome = txtnome;
            objCliente.IdCliente = txtcliente;
            objCliente.Cpf = txtcpf;

            List<Cliente> cliente = objClienteNeg.findAllClientes(objCliente);
            return View(cliente);
        }
       
        [HttpPost]
        public ActionResult Selecionar(string idProduto)
        {
            Produto objProduto = new Produto(idProduto);
            objProdutoNeg.find(objProduto);            
            return Json(objProduto, JsonRequestBehavior.AllowGet);
            
        }     
        
        public void carregarProdutocmb()
        {
            List<Produto> data = objProdutoNeg.findAll();
            SelectList lista = new SelectList(data, "idProduto", "nome");
            ViewBag.ListaProduto = lista;
        }
        public void carregarModoPagocmb()
        {
            List<ModoPago> data = objModoPagoNeg.findAll();
            SelectList lista = new SelectList(data, "numPago", "nome");
            ViewBag.ListaModoPago = lista;
        }

        public ActionResult NovaVenda()
        {
            carregarModoPagocmb();
            carregarProdutocmb();
            return View();
        }


        //ADD DAQUI PRA BAIXO

        [HttpPost]
        public ActionResult SalvarVenda(string Data, string modoPago, string IdCliente, string Total, List<DetalheVenda> ListaDetalhe)
        {
            string mensagem = "";
            double taxa = 0;
            string idVendedor = "01";
            int codigoPago = 0;
            long codigoCliente = 0;
            double total = 0;

            if (Data == "" || modoPago == "" || IdCliente == "" || Total == "")
            {
                if (Data == "") mensagem = "ERRO NA DATA";
                if (modoPago == "") mensagem = "SELECIONE FORMA DE PAGAMENTO";
                if (IdCliente == "") mensagem = "ERRO NO CÓDIGO DO CLIENTE";
                if (Total == "") mensagem = "ERRO NO CAMPO TOTAL";
            }
            else
            {
                codigoPago = Convert.ToInt32(modoPago);
                codigoCliente = Convert.ToInt64(IdCliente);
                total = Convert.ToDouble(Total);

                //REGISTRO DE VENDA
                Venda objVenda = new Venda(total, codigoCliente, idVendedor, Data, taxa);
                string dadosVenda = objVendaNeg.create(objVenda);
                if (dadosVenda == "" || dadosVenda == null)
                {
                    mensagem = "Algum campo da tabela de vendas está nulo, vazio ou com dados incorretos!";
                }
                else
                {
                    Session["idVenda"] = dadosVenda;
                    //REGISTRO DE FATURA
                    Fatura objFatura = new Fatura(Data, taxa, total, codigoPago);
                    string codigoFatura = objFaturaNeg.create(objFatura);
                    if (codigoFatura == "" || codigoFatura == null)
                    {
                        mensagem = "Algum campo da tabela de faturas está nulo, vazio ou com dados incorretos!";
                    }
                    else
                    {

                        foreach (var data in ListaDetalhe)
                        {
                            string idProduto = data.IdProduto.ToString();
                            int quantidade = Convert.ToInt32(data.Quantidade.ToString());
                            double desconto = Convert.ToDouble(data.Desconto.ToString());
                            double subtotal = Convert.ToDouble(data.SubTotal.ToString());
                            DetalheVenda objDetalheVenda = new DetalheVenda(Convert.ToInt64(codigoFatura), Convert.ToInt64(dadosVenda), idProduto, subtotal, desconto, quantidade);
                            objDetalheVendaNeg.create(objDetalheVenda);

                        }
                        mensagem = "VENDA SALVA COM SUCESSO...";
                    }
                }

            }

            return Json(mensagem);
        }

        //AQUI VAI ENTRAR O RELATORIO

              public ActionResult relatorioAtual()
        {
            if (Session["idVenda"].ToString() != null)
            {
                string idVenda = Session["idVenda"].ToString();
                return Redirect("~/Relatorios/frmRelatorioFatura.aspx?idVenda=" + idVenda);
            }
            else
            {
                return View("SalvarVenda");
            }

        }


        public ActionResult DetalhesVenda()
        {
            DetalheVenda objDetalheVenda = new DetalheVenda();
            
            List<DetalheVenda> lista = objDetalheVendaNeg.findAll();
            return View(lista);
        }

        public ActionResult VendaFatura()
        {
            List<Venda> lista = objVendaNeg.findAll();
            return View(lista);
        }

    }
}