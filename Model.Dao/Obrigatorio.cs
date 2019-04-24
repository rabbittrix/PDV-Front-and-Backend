using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public interface Obrigatorio<qualquerClasse>
    {
        void create(qualquerClasse obj);
        void delete(qualquerClasse obj);
        void update(qualquerClasse obj);
        bool find(qualquerClasse obj);
        List<qualquerClasse> findAll();
    }
}
