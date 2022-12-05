﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulerUILibrary.DataTransferObjects
{
    public class EmployeeDTO : AccountDTO
    {
        public long Accounts_Id { get; set; }
        public string Role { get; set; }
        public int RoomNumber { get; set; }

        public EmployeeDTO(string username, string email, string password, string role, int roomNumber, IEnumerable<int> appointments)
            : base(username, email, password, appointments)
        {
            Role = role;
            RoomNumber = roomNumber;
        }

        public EmployeeDTO() {}
    }
}
