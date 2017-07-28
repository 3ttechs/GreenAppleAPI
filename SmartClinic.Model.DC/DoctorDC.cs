/*
 * File Name   : DoctorDC.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Doctor DB Table. 
 *               SPs used -> GetAllDoctors
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
    public partial class DoctorDC
    {
        public int DocID { get; set; }
        public string DocName { get; set; }
    }
}

