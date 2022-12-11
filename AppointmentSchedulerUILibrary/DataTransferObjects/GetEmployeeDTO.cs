namespace AppointmentSchedulerUILibrary.DataTransferObjects
{
    public class GetEmployeeDTO
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int RoomNumber { get; set; }

        public GetEmployeeDTO(long id, string username, string email, string role, int roomNumber)
        {
            Id = id;
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

