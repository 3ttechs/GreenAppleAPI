/*
 * File Name   : UsersPatientDC.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Patient, UserAdmin DB Tables. SPs used -> GetPatientList, GetUserPatientList
 * Created By  : Tony Jacob
 * Created On  : 12May2016
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinic.Model.DC
{
    //Note : Some properties from Patient DB table and all properties from UserAdmin have been omitted for the time being
    //       They could be added later, if required
    public class UsersPatientDC
    {
        public int PatID { get; set; }
        public string PatName { get; set; }
    }
}