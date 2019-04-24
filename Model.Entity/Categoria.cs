namespace Model.Entity
{
    public class Categoria
    {
        private string idCategoria;
        private string nome;
        private string descricao;
        private int estado;

        public string IdCategoria
        {
            get
            {
                return idCategoria;
            }

            set
            {
                idCategoria = value;
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

        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
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

        public Categoria()
        {
       
        }
        public Categoria(string idCategoria, string nome, string descricao)
        {
            this.idCategoria = idCategoria;
            this.Nome = nome;
            this.Descricao = descricao;
        }
        public Categoria(string idCategoria)
        {
            this.idCategoria = idCategoria;
            
        }
    }
}
