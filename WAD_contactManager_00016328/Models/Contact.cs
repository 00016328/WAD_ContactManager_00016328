using System.Text.RegularExpressions;

namespace WAD_contactManager_00016328.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int GroupId { get; set; } // foreign key
        public Group Group { get; set; }
    }
}
