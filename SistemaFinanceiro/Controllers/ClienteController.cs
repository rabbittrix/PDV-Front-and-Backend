using Model.Entity;
using Model.Neg;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SistemaFinanceiro.Controllers
{
    public class ClienteController : Controller
    {
        ClienteNeg objClienteNeg;
        public ClienteController()
        {
            objClienteNeg = new ClienteNeg();
        }
        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> lista = objClienteNeg.findAll();
            return View(lista);
        }       

        // GET: Cliente/Create
        [HttpGet]
        public ActionResult Create()
        {
            mensagemInicioRegistrar();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente objCliente)
        {
            mensagemInicioRegistrar();
            objClienteNeg.create(objCliente);
            MensagemErroRegistrar(objCliente);
            ModelState.Clear();
            return View("Create");
           
        }
        //mensagem de erro
        public void MensagemErroRegistrar(Cliente objCliente)
        {

            switch (objCliente.Estado)
            {

                case 1000://campo cpf com letras
                    ViewBag.MensagemErro = "Erro CPF, não insira Letras";
                    break;

                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira Nome do Cliente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 30 caracteres";
                    break;


                case 50://campo cpf vazio
                    ViewBag.MensagemErro = "Insira CPF do Cliente";
                    break;

                case 250://campo cpf vazio
                    ViewBag.MensagemErro = "O CPF tem que ter 11 numeros, apenas numeros";
                    break;


                case 60://endereco vazio
                    ViewBag.MensagemErro = "Insira endereço do Cliente";
                    break;

                case 6://erro no endereço
                    ViewBag.MensagemErro = "Campo endereço não pode ter mais de 50 caracteres";
                    break;

                case 70://campo telefone vazio
                    ViewBag.MensagemErro = "Insira o telefone do cliente";
                    break;

                case 7://campo telefone vazio
                    ViewBag.MensagemErro = "O telefone tem que ter de 8 a 15 digitos";
                    break;

                case 8://erro de duplicidade
                    ViewBag.MensagemErro = "Cliente [" + objCliente.IdCliente + "] já está registrado no sistema";
                    break;

                case 9://erro de duplicidade
                    ViewBag.MensagemErro = "Numero de CPF [" + objCliente.Cpf + "] já está registrado no sistema";
                    break;

                case 99://Cliente Salvo com Sucesso
                    ViewBag.MensagemExito = "Cliente [" + objCliente.Nome + "] foi inserido no sistema";
                    break;

            }

        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados do Cliente e clique em salvar";
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            mensagemInicialAtualizar();
            Cliente objCliente = new Cliente(id);
            objClienteNeg.find(objCliente);
            return View(objCliente);
        }
        [HttpPost]
        public ActionResult Update(Cliente objCliente)
        {
            mensagemInicialAtualizar();
            objClienteNeg.update(objCliente);
            MensagemErroAtualizar(objCliente);
            return View();
            //return Redirect("~/Cliente/Index/");
        }

        //Mensagem erro ao atualizar
        public void MensagemErroAtualizar(Cliente objCliente)
        {

            switch (objCliente.Estado)
            {
               
                case 1000://campo cpf com letras
                    ViewBag.MensagemErro = "Erro CPF, não insira Letras";
                    break;

                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira Nome do Cliente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 30 caracteres";
                    break;


                case 50://campo cpf vazio
                    ViewBag.MensagemErro = "Insira CPF do Cliente";
                    break;

                case 250://campo cpf vazio
                    ViewBag.MensagemErro = "O CPF tem que ter 11 numeros, apenas numeros";
                    break;


                case 60://endereco vazio
                    ViewBag.MensagemErro = "Insira endereço do Cliente";
                    break;

                case 6://erro no endereço
                    ViewBag.MensagemErro = "Campo endereço não pode ter mais de 50 caracteres";
                    break;

                case 70://campo telefone vazio
                    ViewBag.MensagemErro = "Insira o telefone do cliente";
                    break;

                case 7://campo telefone vazio
                    ViewBag.MensagemErro = "O telefone tem que ter de 8 a 15 digitos";
                    break;


                case 99://Atualizado com sucesso
                    ViewBag.MensagemExito = "Dados do Cliente [" + objCliente.IdCliente + "] foi atualizado!";
                    break;

            }

        }
        //mensagem Inicial Atualizar
        public void mensagemInicialAtualizar()
        {
            ViewBag.MensagemInicialAtualizar = "Formulario para Atualizar Dados do Cliente";
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            mensagemInicialEliminar();
            Cliente objCliente = new Cliente(id);
            objClienteNeg.find(objCliente);
            return View(objCliente);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            mensagemInicialEliminar();
            Cliente objCliente = new Cliente(id);
            objClienteNeg.delete(objCliente);
            mostrarMensagemEliminar(objCliente);
            return Redirect("~/Cliente/Index/");
        }

        [HttpGet]
        public ActionResult Eliminar(long id)
        {
            mensagemInicialEliminar();
            Cliente objCliente = new Cliente(id);
            objClienteNeg.find(objCliente);
            return View(objCliente);
        }

        [HttpPost]
        public ActionResult Eliminar(Cliente objCliente)
        {
            mensagemInicialEliminar();
            objClienteNeg.delete(objCliente);
            mostrarMensagemEliminar(objCliente);
            Cliente objCLiente2 = new Cliente();
            return View(objCLiente2);
            //return RedirectToAction("Index");
        }

        //mensagem de erro ao excluir
        private void mostrarMensagemEliminar(Cliente objCliente)
        {

            switch (objCliente.Estado)
            {
                case 1: //ERRO DE EXISTENCIA
                    ViewBag.MensagemErro = "Cliente [" + objCliente.IdCliente + "] Não está registrado no sistema ";
                    break;

                case 33://CLIENTE NAO EXISTE
                    ViewBag.MensagemErro = "Cliente: [" + objCliente.Nome + " ]já foi excluido";
                    break;
                case 34:
                    ViewBag.MensagemErro = "Não se pode apagar o Cliente [" + objCliente.Nome + "] Tem vendas relacionadas ao cliente!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensagemExito = "Cliente [" + objCliente.Nome + "] Foi Excluido!!!";
                    break;

                default:
                    ViewBag.MensagemErro = "===Deu Erro ???===";
                    break;
            }
        }
        public void mensagemInicialEliminar()
        {
            ViewBag.MensagemInicialEliminar = "Formulario de Exclusão";
        }

        public ActionResult Find(long id)
        {
            Cliente objCliente = new Cliente(id);
            objClienteNeg.find(objCliente);

            return View(objCliente);
        }

        [HttpGet]
        public ActionResult BuscarClientes()
        {
            List<Cliente> lista = objClienteNeg.findAll();
            return View(lista);
        }
        [HttpPost]
        public ActionResult BuscarClientes(string txtnome, string txtcpf, long txtcliente = -1)
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
    }
}


