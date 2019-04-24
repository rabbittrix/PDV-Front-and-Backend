using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Produto
    {
        private string idProduto;
        private string nome;
        private double precoUnitario;
        private string categoria;
        private int estado;

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

        [Display(Name = "Código")]
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

        [Display(Name = "Preço Unitário")]
        public double PrecoUnitario
        {
            get
            {
                return precoUnitario;
            }

            set
            {
                precoUnitario = value;
            }
        }

        public string Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        public Produto()
        {
            
        }
        public Produto(string idProduto)
        {
            this.idProduto = idProduto;
        }
        public Produto(string idProduto, string nome, double precoUnitario, string categoria)
        {
            this.idProduto = idProduto;
            Nome = nome;
            PrecoUnitario = precoUnitario;
            Categoria = categoria;
        }
    }
}
