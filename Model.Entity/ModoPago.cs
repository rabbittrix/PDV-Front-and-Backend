using System;

namespace Model.Entity
{
    public class ModoPago
    {
        private Int32 numPago;
        private string nome;
        private string outros;
        private int estado;

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

        public string Outros
        {
            get
            {
                return outros;
            }

            set
            {
                outros = value;
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
        public ModoPago()
        {

        }
        public ModoPago(Int32 numPago, string nome, string outros)
        {
            this.NumPago = numPago;
            this.Nome = nome;
            this.Outros = outros;
        }
       
        public ModoPago(Int32 numPago)
        {
            this.NumPago = numPago;
           
        }
    }
}
