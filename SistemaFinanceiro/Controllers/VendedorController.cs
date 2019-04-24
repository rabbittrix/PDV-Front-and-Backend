using System.Collections.Generic;
using System.Web.Mvc;
using Model.Neg;
using Model.Entity;

namespace SistemaFinanceiro.Controllers
{
    public class VendedorController : Controller
    {
        private VendedorNeg objVendedorNeg;
        public VendedorController()
        {
            objVendedorNeg = new VendedorNeg();
        }
        // GET: Vendedor
        public ActionResult Index()
        {
            List<Vendedor> lista = objVendedorNeg.findAll();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Create()
        {
            mensagemInicioRegistrar();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vendedor objVendedor)
        {
            mensagemInicioRegistrar();
            objVendedorNeg.create(objVendedor);
            MensagemErroRegistrar(objVendedor);
            return View("Create");
        }

        public void MensagemErroRegistrar(Vendedor objVendedor)
        {

            switch (objVendedor.Estado)
            {
                case 10://campo codigo vazio
                    ViewBag.MensagemErro = "Insira o código";
                    break;
                case 1://error campo codigo
                    ViewBag.MensagemErro = "Não se permite mais de 5 dígitos para o código";
                    break;
                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira nome do Vendedor";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "Não se permite mais de 30 digitos para nome";
                    break;
                    

                case 50://campo cpf vazio
                    ViewBag.MensagemErro = "Insira CPF do Vendedor";
                    break;
                case 5://erro de cpf
                    ViewBag.MensagemErro = "Digite 11 digitos para o CPF";
                    break;                
                case 60://campo telefone vazio
                    ViewBag.MensagemErro = "Insira o telefone do cliente";
                    break;
                case 6://erro de telefone
                    ViewBag.MensagemErro = "No se permiten mas de 30 caracteres en al campo Teléfono";
                    break;

                case 7://erro de duplicidade
                    ViewBag.MensagemErro = "Vendedor [" + objVendedor.IdVendedor + "] já existe no Sistema";
                    break;

                case 99:// exito
                    ViewBag.MensagemExito = "Vendedor [" + objVendedor.IdVendedor + "]  foi registrado no Sistema";
                    break;
            }

        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados do cliente e clique em salvar";
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            mensagemInicioUpdate();
            Vendedor objVendedor = new Vendedor(id);
            objVendedorNeg.find(objVendedor);
            return View(objVendedor);
        }
        [HttpPost]
        public ActionResult Update(Vendedor objVendedor)
        {
            mensagemInicioUpdate();
            objVendedorNeg.update(objVendedor);
            MensagemErroUpdate(objVendedor);
            return View();
            //return Redirect("~/Cliente/Index/");
        }

        public void MensagemErroUpdate(Vendedor objVendedor)
        {

            switch (objVendedor.Estado)
            {
                case 10://campo codigo vazio
                    ViewBag.MensagemErro = "Insira o código";
                    break;
                case 1://error campo codigo
                    ViewBag.MensagemErro = "Não se permite mais de 5 dígitos para o código";
                    break;
                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira nome do Vendedor";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "Não se permite mais de 30 digitos para nome";
                    break;


                case 50://campo cpf vazio
                    ViewBag.MensagemErro = "Insira CPF do Vendedor";
                    break;
                case 5://erro de cpf
                    ViewBag.MensagemErro = "Digite 11 digitos para o CPF";
                    break;
                case 60://campo telefone vazio
                    ViewBag.MensagemErro = "Insira o telefone do cliente";
                    break;
                case 6://erro de telefone
                    ViewBag.MensagemErro = "No se permiten mas de 30 caracteres en al campo Teléfono";
                    break;



                case 99:// exito
                    ViewBag.MensagemExito = "Vendedor [" + objVendedor.IdVendedor + "] atualizado no Sistema";
                    break;
            }

        }

        public void mensagemInicioUpdate()
        {
            ViewBag.MensagemInicio = "Insira os dados para Editar";
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            mensagemInicialEliminar();
            Vendedor objVendedor = new Vendedor(id);
            objVendedorNeg.find(objVendedor);
            return View(objVendedor);
        }


        [HttpPost]
        public ActionResult Delete(Vendedor objVendedor)
        {
            mensagemInicialEliminar();            
            objVendedorNeg.delete(objVendedor);
            mostrarMensagemErroEliminar(objVendedor);
            return View(objVendedor);
        }
        private void mostrarMensagemErroEliminar(Vendedor objVendedor)
        {

            switch (objVendedor.Estado)
            {
                case 1: //ERRO DE EXISTENCIA
                    ViewBag.MensagemErro = "Vendedor [" + objVendedor.IdVendedor + "] Não está registrado no sistema ";
                    break;

                case 33://VENDEDOR NAO EXISTE
                    ViewBag.MensagemErro = "O vendedor: [" + objVendedor.Nome + " ]já foi excluido";
                    break;
                case 34:
                    ViewBag.MensagemErro = "Não se pode apagar o vendedor [" + objVendedor.Nome + "] Tem vendas associadas no sistema!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensagemExito = "Vendedor [" + objVendedor.Nome + "] Foi Eliminado!!!";
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
            Vendedor objVendedor = new Vendedor(id);
            objVendedorNeg.find(objVendedor);
            //objClienteNeg.find2(objCliente);
            return View(objVendedor);
        }
    }
}