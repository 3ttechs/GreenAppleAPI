/*
 * File Name   : SessionDC.cs
 * Project     : SmartClinic
 * Description : For CRUD operations on Session DB Table. 
 *               SPs used -> GetNextSlotNo, AddSession, GetSession, UpdateSession, DeleteSession
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
    public partial class SessionDC
    {
        public int SesID { get; set; }
        public int DocID { get; set; }
        public int LocID { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public int Recurring { get; set; }
        public int MaxSlot { get; set; }
        public int AvailableSlot { get; set; }
        public string LocName { get; set; }
    }
}
