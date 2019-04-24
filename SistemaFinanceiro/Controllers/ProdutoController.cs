using System.Collections.Generic;
using System.Web.Mvc;
using Model.Neg;
using Model.Entity;

namespace SistemaFinanceiro.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        ProdutoNeg objProdutoNeg;
        public ProdutoController()
        {
            objProdutoNeg = new ProdutoNeg();
        }
        // GET: Produto
        public ActionResult Index()
        {

            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nome");
            ViewBag.ListaCategorias = lista;
            
            List<Produto> listaProdutos = objProdutoNeg.findAll();
            return View(listaProdutos);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nome");
            ViewBag.ListaCategorias = lista;
            mensagemInicioRegistrar();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Produto objProduto)
        {
            mensagemInicioRegistrar();
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nome");
            ViewBag.ListaCategorias = lista;
            objProdutoNeg.create(objProduto);
            MensagemErroRegistrar(objProduto);
            return View("Create");
        }

        //mensaje de error
        public void MensagemErroRegistrar(Produto objProduto)
        {

            switch (objProduto.Estado)
            {
                case 1000://campo codigo vazio
                    ViewBag.MensagemErro = "Erro!!! Revise a instrução de Inserir";
                    break;
                case 10://campo codigo vazio
                    ViewBag.MensagemErro = "Insira o código do produto";
                    break;
                case 1://erro campo codigo
                    ViewBag.MensagemErro = "Apenas 5 digitos para o código";
                    break;
                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o nome do Produto";
                    break;

                case 2://error de nome
                    ViewBag.MensagemErro = "Digite um nome até 30 caracteres";
                    break;

                case 30://campo preco unitario vazio
                    ViewBag.MensagemErro = "Insira preco do Produto";
                    break;

                case 3://erro de preco Unitario
                    ViewBag.MensagemErro = "Preco Unitário Inválido";
                    break;

                case 300://erro de preco Unitario
                    ViewBag.MensagemErro = "Preco Unitário Inválido";
                    break;

                case 40://categoria vazia
                    ViewBag.MensagemErro = "Categoria Vazia";
                    break;

                case 4://erro na categoria
                    ViewBag.MensagemErro = "Categoria Inválida";
                    break; 
                                   
                case 8://erro de duplicidade
                    ViewBag.MensagemErro = "Produto [" + objProduto.IdProduto + "] já está inserido no Sistema";
                    break;

                case 99://carrera registrada con exito
                    ViewBag.MensagemExito = "Produto [" + objProduto.IdProduto + "] foi registrado no Sistema";
                    break;

            }

        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os Dados do Produto";
        }

        public ActionResult Update(string id)
        {
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nome");
            ViewBag.ListaCategorias = lista;
            Produto objProduto = new Produto(id);
            objProdutoNeg.find(objProduto);
            mensagemInicioAtualizar();
            return View(objProduto);
        }
        [HttpPost]
        public ActionResult Update(Produto objProduto)
        {
            mensagemInicioAtualizar();
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nome");
            ViewBag.ListaCategorias = lista;
            objProdutoNeg.update(objProduto);
            MensagemErroAtualizar(objProduto);
            return View();
        }

        //mensaje de error
        public void MensagemErroAtualizar(Produto objProduto)
        {

            switch (objProduto.Estado)
            {

                case 1000://campo codigo vazio
                    ViewBag.MensagemErro = "Erro!!! Revise a instrução de Inserir";
                    break;
                case 10://campo codigo vazio
                    ViewBag.MensagemErro = "Insira o código do produto";
                    break;
                case 1://erro campo codigo
                    ViewBag.MensagemErro = "Apenas 5 digitos para o código";
                    break;
                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o nome do Produto";
                    break;

                case 2://error de nome
                    ViewBag.MensagemErro = "Digite um nome até 30 caracteres";
                    break;

                case 30://campo preco unitario vazio
                    ViewBag.MensagemErro = "Insira preco do Produto";
                    break;

                case 3://erro de preco Unitario
                    ViewBag.MensagemErro = "Preco Unitário Inválido";
                    break;

                case 300://erro de preco Unitario
                    ViewBag.MensagemErro = "Preco Unitário Inválido";
                    break;

                case 40://categoria vazia
                    ViewBag.MensagemErro = "Categoria Vazia";
                    break;

                case 4://erro na categoria
                    ViewBag.MensagemErro = "Categoria Inválida";
                    break;



                case 99://atualizada com exito
                    ViewBag.MensagemExito = "Dados do Produto [" + objProduto.IdProduto + "] Foram Modificados";
                    break;

            }

        }
        public void mensagemInicioAtualizar()
        {
            ViewBag.MensagemInicio = "Insira os dados para Atualizar";
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            mensagemInicialEliminar();
            Produto objProduto = new Produto(id);
            objProdutoNeg.find(objProduto);
            return View(objProduto);
        }

        [HttpPost]
        public ActionResult Delete(Produto objProduto)
        {
            mensagemInicialEliminar();
            objProdutoNeg.delete(objProduto);
            mostrarMensagemEliminar(objProduto);
            Produto objProduto2 = new Produto();
            return View(objProduto2);
            //return RedirectToAction("Index");
        }

        //mensagem ao excluir
        private void mostrarMensagemEliminar(Produto objProduto)
        {

            switch (objProduto.Estado)
            {
                case 1000://campo codigo vazio
                    ViewBag.MensagemErro = "Erro!!! Revise a instrução de Inserir";
                    break;
              
                case 1: //ERRO DE EXISTENCIA
                    ViewBag.MensagemErro = "Produto [" + objProduto.IdProduto + "] Não existe no Sistema ";
                    break;

                case 33://PRODUTO NAO EXISTE
                    ViewBag.MensagemErro = "O Produto: [" + objProduto.Nome + "] Já foi excluido";
                    break;
                case 34:
                    ViewBag.MensagemErro = "Não se pode excluir o Produto [" + objProduto.Nome + "] por ter vendas relacionadas!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensagemExito = "Produto [" + objProduto.Nome + "] Foi Excluido!!!";
                    break;

                default:
                    ViewBag.MensajeError = "===???===";
                    break;
            }
        }
        public void mensagemInicialEliminar()
        {
            ViewBag.MensagemInicialEliminar = "Formulario de Exclusão";
        }

        public ActionResult Find(string id)
        {
            Produto objProduto = new Produto(id);
            objProdutoNeg.find(objProduto);
            return View(objProduto);
        }

        [HttpGet]
        public ActionResult BuscarProdutos()
        {
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nome");
            ViewBag.ListaCategorias = lista;

            List<Produto> listas = objProdutoNeg.findAll();
            return View(listas);
        }
        [HttpPost]
        public ActionResult BuscarProdutos(string txtproduto, string txtnome, string ListaCategorias)
        {

            if (txtnome == "")
            {
                txtnome = "-1";
            }
            if (txtproduto == "")
            {
                txtproduto = "-1";
            }
            if (ListaCategorias == "")
            {
                ListaCategorias = "-1";
            }

            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nome");
            ViewBag.ListaCategorias = lista;

            Produto objProduto = new Produto();
            objProduto.Nome = txtnome;
            objProduto.IdProduto = txtproduto;
            objProduto.Categoria = ListaCategorias;

            List<Produto> Produto = objProdutoNeg.findAllProdutos(objProduto);
            mensagemErroServidor(objProduto);
            return View(Produto);
        }

        public void mensagemErroServidor(Produto objProduto)
        {
            switch (objProduto.Estado)
            {
                case 1000:
                    ViewBag.MensajeError = "ERRO DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }

        [HttpGet]
        public ActionResult BuscarProdutosPorCategoria()
        {
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nome");
            ViewBag.ListaCategorias = lista;
            List<Produto> Produto = objProdutoNeg.findAll();            
            return View(Produto);
        }

        [HttpPost]
        public ActionResult BuscarProdutosPorCategoria(string ListaCategorias)
        {
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nome");
            ViewBag.ListaCategorias = lista;

            Produto objProduto = new Produto();
            objProduto.Categoria = ListaCategorias;
            List<Produto> Produto = objProdutoNeg.findAllProdutosPorCategoria(objProduto);
            mensagemErroServidor(objProduto);
            return View(Produto);
        }       

    }
}