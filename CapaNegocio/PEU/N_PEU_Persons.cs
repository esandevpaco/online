using CapaDatos.PEU;
using CapaEntidades.PEU;
using System.Collections.Generic;

namespace CapaNegocio.PEU
{
    public  class N_PEU_Persons
    {
        private D_PEU_Persons _Persons = new D_PEU_Persons();
        public List<E_PEU_Persons> N_listEmpleados()
        {
            return _Persons.D_ListPerson();
        }
    }
}
