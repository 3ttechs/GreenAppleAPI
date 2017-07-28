/*
 * File Name   : DiagnosisDC.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Diagnosis DB Table. SPs used -> AddDiagnosis, GetDiagnosis, UpdateDiagnosis, DeleteDiagnosis
 * Created By  : 
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *
 * */
namespace SmartClinic.Model.DC
{
    public class DiagnosisDC
    {
        public int DID { get; set; }
        public int SloID { get; set; }
        public string Illness { get; set; }
        public string DoctorComments { get; set; }
        public string Prescription { get; set; }
        public string DiscussionTemplate { get; set; }
        public string PostAction { get; set; }
    }
}