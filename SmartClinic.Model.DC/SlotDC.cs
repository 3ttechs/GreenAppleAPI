/*
 * File Name   : SlotController.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on  DB Tables -> Slot, Patient, UserAdmin
 *               SPs used -> GetPatientSlotList, AddSlot, DeleteSlot, UpdateSlot
 * Created By  : 
 * Created On  : 
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
    public partial class SlotDC //Refer DB Table : Slot
    {
        public int SloID { get; set; }
        public int SesID { get; set; }
        public int DocID { get; set; }
        public int PatID { get; set; }
        public int SlotNO { get; set; }
        public string BillNo { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
    }

    public partial class SlotDC //Refer DB Table : Patient
    {
        public int UsrID { get; set; }
        public string PatName { get; set; }
        public string PatShortName { get; set; }
        public string GuardianName { get; set; }
        public string Occupation { get; set; }
        public string GuardianOccupation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Sex { get; set; }
    }

    public partial class SlotDC //Refer DB Table : UserAdmin
    {
        public char UsrType { get; set; }
        public string usrName { get; set; }
        public string UsrPwd { get; set; }
        public string UsrAddress { get; set; }
        public string UsrPhone1 { get; set; }
        public string UsrPhone2 { get; set; }
        public string UsrEmail { get; set; }
    }
}