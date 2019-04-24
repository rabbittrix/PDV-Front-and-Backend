using System.Collections.Generic;
using System.Web.Mvc;
using Model.Neg;
using Model.Entity;

namespace SistemaFinanceiro.Controllers
{
    public class ModoPagoController : Controller
    {
        private ModoPagoNeg objModoPagoNeg;
        public ModoPagoController()
        {
            objModoPagoNeg = new ModoPagoNeg();
        }
        // GET: ModoPago
        public ActionResult Index()
        {
            List<ModoPago> lista = objModoPagoNeg.findAll();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            mensagemInicioRegistrar();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ModoPago objModoPago)
        {
            mensagemInicioRegistrar();
            objModoPagoNeg.create(objModoPago);
            MensagemErroRegistrar(objModoPago);
            return View("Create");
        }
        

        public void MensagemErroRegistrar(ModoPago objModoPago)
        {

            switch (objModoPago.Estado)
            {
                case 1000:
                    ViewBag.MensagemErro = "Erro!!! Revise instrução inserir";
                    break;
                
                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira nome do Modo pGT";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 30 caracteres";
                    break;

                case 30://campo descricao vazio
                    ViewBag.MensagemErro = "Insira a descrição";
                    break;

                case 3://campo desc invalido
                    ViewBag.MensagemErro = "Nao se pode inserir mais de 30 caracteres";
                    break;

                case 8://erro de duplicidade
                    ViewBag.MensagemErro = "Modo de Pagamento [" + objModoPago.NumPago + "] já está Registrada no Sistema";
                    break;


                case 99://registrando
                    ViewBag.MensagemExito = "Modo de Pagamento [" + objModoPago.Nome + "] foi registrado no Sistema";
                    break;

            }

        }
        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados e clique em Salvar";
        }

        public ActionResult Update(int id)
        {
            ModoPago objModoPago = new ModoPago(id);
            objModoPagoNeg.find(objModoPago);
            mensagemInicioAtualizar();
            return View(objModoPago);
        }
        [HttpPost]
        public ActionResult Update(ModoPago objModoPago)
        {
            mensagemInicioAtualizar();
            objModoPagoNeg.update(objModoPago);
            MensagemErroAtualizar(objModoPago);
            return View();
        }

        //mensaje de error
        public void MensagemErroAtualizar(ModoPago objModoPago)
        {

            switch (objModoPago.Estado)
            {
                case 1000:
                    ViewBag.MensagemErro = "Erro!!! Revise instrução inserir";
                    break;

                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira nome do Modo pGT";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 30 caracteres";
                    break;

                case 30://campo descricao vazio
                    ViewBag.MensagemErro = "Insira a descrição";
                    break;

                case 3://campo desc invalido
                    ViewBag.MensagemErro = "Nao se pode inserir mais de 30 caracteres";
                    break;


                case 99://Atualizado com sucesso
                    ViewBag.MensagemExito = "Dados do modo de pagamento [" + objModoPago.NumPago + "] Foram Atualizados";
                    break;

            }

        }
        public void mensagemInicioAtualizar()
        {
            ViewBag.MensagemInicio = "Insira os Dados e Clique em Editar";
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            mensagemInicialEliminar();
            ModoPago objModoPago = new ModoPago(id);
            objModoPagoNeg.find(objModoPago);
            return View(objModoPago);
        }

        [HttpPost]
        public ActionResult Delete(ModoPago objModoPago)
        {
            mensagemInicialEliminar();
            objModoPagoNeg.delete(objModoPago);
            mostrarMensagemEliminar(objModoPago);
            return View();
            
        }

        //Mensagem ao apagar
        private void mostrarMensagemEliminar(ModoPago objModoPago)
        {

            switch (objModoPago.Estado)
            {
                case 1000:
                    ViewBag.MensagemErro = "Erro!!! Revise instrução inserir";
                    break;

                case 1: //ERRO DE EXISTENCIA
                    ViewBag.MensagemErro = "ModoPago [" + objModoPago.NumPago + "] Não está registrado no sistema ";
                    break;

                case 33://CLIENTE NÃO EXISTE
                    ViewBag.MensagemErro = "ModoPago: [" + objModoPago.Nome + "]Já foi Excluido";
                    break;
                case 34:
                    ViewBag.MensagemErro = "Não pode excluir [" + objModoPago.Nome + "] tem fatura associada!!!";
                    break;

                case 99: //EXITO
                    ViewBag.MensagemExito = "ModoPago [" + objModoPago.Nome + "] Foi Excluido!!!";
                    break;

                default:
                    ViewBag.MensajeError = "===???===";
                    break;
            }
        }
        public void mensagemInicialEliminar()
        {
            ViewBag.MensagemInicialEliminar = "Formulario de Eliminacion";
        }
        public ActionResult Find(int id)
        {
            ModoPago objModoPago = new ModoPago(id);
            objModoPagoNeg.find(objModoPago);
           
            return View(objModoPago);
        }

    }
}