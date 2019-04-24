using Model.Entity;
using Model.Neg;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaFinanceiro.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaNeg objCategoriaNeg;
        
        public CategoriaController()
        {
            objCategoriaNeg = new CategoriaNeg();
            
        }
        // GET: Categoria
        public ActionResult Index()
        {
            Categoria objCategoria = new Categoria();
            List<Categoria> lista = objCategoriaNeg.findAll();
            mensagemErroServidor(objCategoria);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            mensagemInicioRegistrar();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria objCategoria)
        {
            mensagemInicioRegistrar();
            objCategoriaNeg.create(objCategoria);
            MensagemErrorRegistrar(objCategoria);
            return View("Create");
        }
        //mensagem de erro
        public void MensagemErrorRegistrar(Categoria objCategoria)
        {

            switch (objCategoria.Estado)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensagemErro = "Erro!!! Revise a instrução de inserir";
                    break;
                case 10://campo codigo vacio
                    ViewBag.MensagemErro = "Insira o Código da Categoria";
                    break;
                case 1://error campo codigo
                    ViewBag.MensagemErro = "O código não pode ter mais de 5 numeros";
                    break;
                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o nome do cliente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "Não insira mais de 30 caracteres no campo nome";
                    break;

                case 30://campo descricao vazio
                    ViewBag.MensagemErro = "Insira descrição da categoria";
                    break;

                case 3://erro campo descricao 
                    ViewBag.MensagemErro = "No se permiten mas de 30 caracteres en el campo Categoria";
                    break;
                                    
                case 8://erro de duplicidade
                    ViewBag.MensagemErro = "Categoria [" + objCategoria.IdCategoria + "] já está Registrada no Sistema";
                    break;


                case 99://Categoria inserida com exito
                    ViewBag.MensagemExito = "Categoria [" + objCategoria.IdCategoria + "] foi inserida no sistema";
                    break;

            }

        }
        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados e clique em Salvar";
        }

        public ActionResult Update(string id)
        {
            Categoria objCategoria = new Categoria(id);
            objCategoriaNeg.find(objCategoria);
            mensagemInicioAtualizar();
            return View(objCategoria);
        }
        [HttpPost]
        public ActionResult Update(Categoria objCategoria)
        {
            mensagemInicioAtualizar();
            objCategoriaNeg.update(objCategoria);
            MensagemErrorAtualizar(objCategoria);
            return View();
        }

        //mensagem de erro
        public void MensagemErrorAtualizar(Categoria objCategoria)
        {

            switch (objCategoria.Estado)
            {

                case 1000://campo codigo vacio
                    ViewBag.MensagemErro = "Erro!!! Revise a instrução de inserir";
                    break;
                case 10://campo codigo vacio
                    ViewBag.MensagemErro = "Insira o Código da Categoria";
                    break;
                case 1://error campo codigo
                    ViewBag.MensagemErro = "O código não pode ter mais de 5 numeros";
                    break;
                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o nome do cliente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "Não insira mais de 30 caracteres no campo nome";
                    break;

                case 30://campo descricao vazio
                    ViewBag.MensagemErro = "Insira descrição da categoria";
                    break;

                case 3://erro campo descricao 
                    ViewBag.MensagemErro = "No se permiten mas de 30 caracteres en el campo Categoria";
                    break;

                

                case 99://atualizado com sucesso
                    ViewBag.MensagemExito = "Dados da Categoria [" + objCategoria.IdCategoria + "] Foram Modificados";
                    break;

            }

        }
        public void mensagemInicioAtualizar()
        {
            ViewBag.MensajeInicio = "Insira os dados para alterar a categoria";
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            mensagemInicialEliminar();
            Categoria objCategoria = new Categoria(id);
            objCategoriaNeg.find(objCategoria);
            return View(objCategoria);
        }

        [HttpPost]
        public ActionResult Delete(Categoria objCategoria)
        {
            mensagemInicialEliminar();
            objCategoriaNeg.delete(objCategoria);
            mostrarMensagemEliminar(objCategoria);            
            return View();
            //return RedirectToAction("Index");
        }

        //mensagem de erro ao deletar
        private void mostrarMensagemEliminar(Categoria objCategoria)
        {

            switch (objCategoria.Estado)
            {
                case 1000://campo codigo vazio
                    ViewBag.MensagemErro = "Error!!! Revise a instrução de excluir";
                    break;
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeErro = "Categoria [" + objCategoria.IdCategoria + "] Não está mais no sistema! ";
                    break;

                case 33://CATEGORIA NAO EXISTE
                    ViewBag.MensagemErro = "Categoria: [" + objCategoria.Nome + "] já foi Eliminada";
                    break;
                case 34:
                    ViewBag.MensagemErro = "Não se pode excluir a categoria [" + objCategoria.Nome + "] Tem produtos associados!!!";
                    break;


                case 99: //EXITO
                    ViewBag.MensagemExito = "Categoria [" + objCategoria.Nome + "] Foi Excluida!!!";
                    break;

                default:
                    ViewBag.MensagemErro = "===Deu Erro ???===";
                    break;
            }
        }
        public void mensagemInicialEliminar()
        {
            ViewBag.MensagemInicialEliminar = "Formulario de Eliminação";
        }
       
        //VERIFICAÇÃO DO PRODUTO PARA EXCLUSÃO

        public void mensagemErroServidor(Categoria objCategoria)
        {
            switch (objCategoria.Estado)
            {
                case 1000:
                    ViewBag.MensagemErro = "ERRO DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }


    }
}