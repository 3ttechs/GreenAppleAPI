using System.Collections.Generic;

namespace SmartClinic.Repository
{
    public interface iRepository<SmartClinicRep>
    {
    //    int AddSmartClinicInt(SmartClinicRep obj);
        bool AddSmartClinic(SmartClinicRep obj);
        bool UpdateSmartClinic(SmartClinicRep obj);
        bool DeleteSmartClinic(SmartClinicRep obj);
        List<SmartClinicRep> GetObject(int id);
    }
}
