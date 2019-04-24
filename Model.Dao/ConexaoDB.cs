using System.Data.SqlClient;

namespace Model.Dao
{
    public class ConexaoDB
    {
        private static ConexaoDB objConexaoDB = null;
        private SqlConnection con;

        private ConexaoDB()
        {
            // CONEXAO LOCAL  
            con = new SqlConnection("Data Source=ROBERTO; Initial Catalog=financeiro; Integrated Security=True");

            //CONEXAO NO SERVIDOR
            //con = new SqlConnection("Data Source=LojaSistema.mssql.somee.com;packet size=4096;user id=hugofreitas_SQLLogin_1;pwd=yuebkwt67d;persist security info=False;initial catalog=financeiro");
        }

        public static ConexaoDB saberEstado()
        {
            if (objConexaoDB == null)
            {
                objConexaoDB = new ConexaoDB();
            }

            return objConexaoDB;
        }


        public SqlConnection getCon()
        {
            return con;
        }

        public void CloseDB()
        {
            objConexaoDB = null;
        }
    }
}
//"Provider=SQLOLEDB, Data Source=Roberto; Initial Catalog=netexco; Integrated Security=True"
