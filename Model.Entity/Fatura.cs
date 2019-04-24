using System;

namespace Model.Entity
{
    public class Fatura
    {
        private long numFatura;
        private string data;
        private double taxa;
        private double total;
        private Int32 numPago;
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

        public Int32 NumPago
        {
            get
            {
                return numPago;
            }

            set
            {
                numPago = value;
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
        

        public Fatura(string data, double taxa, double total, Int32 numPago)
        {            
            this.data = data;
            this.taxa = taxa;
            this.total = total;
            this.numPago = numPago;
           
        }


        public Fatura()
        {
            
        }
        public Fatura(long numFatura)
        {
            this.NumFatura = numFatura;            
        }
    }
}
