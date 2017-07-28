/*
 * File Name   : PatientDC.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Patient, UserAdmin DB Tables. 
 *               SPs used -> AddPatient, GetPatient, UpdatePatient, DeletePatient
 * Created By  : 
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *
 * */

using System;

namespace SmartClinic.Model.DC
{
    public partial class PatientDC
    {
        public int PatID { get; set; }
        public int UsrID { get; set; }
        public string PatName { get; set; }
        public string PatShortName { get; set; }
        public string GuardianName { get; set; }
        public string Occupation { get; set; }
        public string GuardianOccupation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Sex { get; set; }
    }

    public partial class PatientDC 
    {
        public string UsrType { get; set; }
        public string DocID { get; set; }
        public string usrName { get; set; }
        public string UsrPwd { get; set; }
        public string UsrAddress { get; set; }
        public string UsrPhone1 { get; set; }
        public string UsrPhone2 { get; set; }
        public string UsrEmail { get; set; }
    }
}

