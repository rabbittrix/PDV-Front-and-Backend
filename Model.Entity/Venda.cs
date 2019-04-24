namespace Model.Entity
{
    public class Venda
    {
        private long idVenda;
        private double total;        
        private long idCliente;
        private string idVendedor;        
        private string data;
        private double taxa;
        private int estado;

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

       

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
        

        public long IdCliente
        {
            get
            {
                return idCliente;
            }

            set
            {
                idCliente = value;
            }
        }

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

       
        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
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

        public double Taxa
        {
            get
            {
                return taxa;
            }

            set
            {
                taxa = value;
            }
        }

        public Venda()
        {
            
        }
        public Venda(double total, long idCliente, string idVendedor, string data, double taxa)
        {            
            this.total = total;           
            this.idCliente = idCliente;
            this.idVendedor = idVendedor;
            this.taxa = taxa;
            this.data = data;
        }
        public Venda(long idVenta)
        {
            this.idVenda = idVenta;          
        }
    }
}
