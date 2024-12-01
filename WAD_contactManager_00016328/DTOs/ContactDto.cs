namespace WAD_contactManager_00016328.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Group information
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
