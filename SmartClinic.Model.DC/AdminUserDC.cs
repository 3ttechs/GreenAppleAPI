/*
 * File Name   : AdminUserDC.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on UserAdmin DB Table. SPs used -> AddUserAdmin, GetUserAdmin, UpdateUserAdmin, DeleteUserAdmin
 * Created By  : Chandra
 * Created On  : 
 * Modification:
 *              ModifiedBy          Date          Reason
 *              ----------          ----          ------
 *
 * */

using System;
namespace SmartClinic.Model.DC
{
    public class AdminUserDC
    {
        public int UsrID { get; set; }
        public string usrName { get; set; }
        public char UsrType { get; set; }
        public int DocID { get; set; }
        public string UsrPwd { get; set; }
        public string UsrAddress { get; set; }
        public string UsrPhone1 { get; set; }
        public string UsrPhone2 { get; set; }
        public string UsrEmail { get; set; }

        public int Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
