namespace AppTicketV2.ViewModels
{
    public class OperatorViewModel
    {
        public int OperatorID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ParentID { get; set; }
    }
}
