namespace Model.Entity
{
    public class Vendedor
    {
        private string idVendedor;
        private string nome;
        
        private string cpf;
        private string telefone;
        private int estado;

        public string IdVendedor
        {
            get
            {
                return idVendedor;
            }

            set
            {
                idVendedor = value;
            }
        }

      

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }

        public string Telefone
        {
            get
            {
                return telefone;
            }

            set
            {
                telefone = value;
            }
        }

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public Vendedor()
        {
            
        }
        public Vendedor(string idVendedor)
        {
            this.idVendedor = idVendedor;
        }
        public Vendedor(string idVendedor,  string cpf, string telefone)
        {
            this.idVendedor = idVendedor;
            this.Cpf = cpf;
            this.Telefone = telefone;
        }
    }
}
