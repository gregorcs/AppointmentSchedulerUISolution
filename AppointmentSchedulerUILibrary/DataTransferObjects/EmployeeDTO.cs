namespace AppointmentSchedulerUILibrary.DataTransferObjects
{
    public class EmployeeDTO : AccountDTO
    {
        public long Accounts_Id { get; set; }
        public string Role { get; set; }
        public int RoomNumber { get; set; }

        public EmployeeDTO(string username, string email, string password, string role, int roomNumber, int[] appointments)
            : base(username, email, password, appointments)
        {
            Role = role;
            RoomNumber = roomNumber;
        }

        public EmployeeDTO() { }
    }
}
