namespace Model.Entity
{
    public class DetalheVenda
    {
        private long idDetalheVenda;
        private long numFatura;
        private long idVenda;
        private string idProduto;
        private double subTotal;
        private double desconto;
        private int quantidade;
        private int estado;

        public long NumFatura
        {
            get
            {
                return numFatura;
            }

            set
            {
                numFatura = value;
            }
        }

        public long IdVenda
        {
            get
            {
                return idVenda;
            }

            set
            {
                idVenda = value;
            }
        }
        public string IdProduto
        {
            get
            {
                return idProduto;
            }

            set
            {
                idProduto = value;
            }
        }
        public double SubTotal
        {
            get
            {
                return subTotal;
            }

            set
            {
                subTotal = value;
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

        public int Quantidade
        {
            get
            {
                return quantidade;
            }

            set
            {
                quantidade = value;
            }
        }

        public double Desconto
        {
            get
            {
                return desconto;
            }

            set
            {
                desconto = value;
            }
        }

        public long IdDetalheVenda
        {
            get
            {
                return idDetalheVenda;
            }

            set
            {
                idDetalheVenda = value;
            }
        }

        public DetalheVenda()
        {

        }
        public DetalheVenda(long idDetalheVenda)
        {
            this.idDetalheVenda = idDetalheVenda;
            
        }
        public DetalheVenda(long numFatura, long idVenda, string idProduto,double subTotal,double desconto,int quantidade)
        {
            this.numFatura = numFatura;
            this.idVenda = idVenda;
            this.idProduto = idProduto;
            this.subTotal = subTotal;
            this.desconto = desconto;
            this.quantidade = quantidade;
        }
    }
}
