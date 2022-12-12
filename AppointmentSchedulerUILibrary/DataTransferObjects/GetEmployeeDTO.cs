namespace AppointmentSchedulerUILibrary.DataTransferObjects
{
    public class GetEmployeeDTO
    {
        public long Accounts_Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int RoomNumber { get; set; }

        public GetEmployeeDTO(long accounts_Id, string username, string email, string role, int roomNumber)
        {
            Accounts_Id = accounts_Id;
            Username = username;
            Email = email;
            Role = role;
            RoomNumber = roomNumber;
        }

        public override string ToString()
        {
            return $" {Username}, {Role}, {Email}, {RoomNumber}";
        }
    }


}

