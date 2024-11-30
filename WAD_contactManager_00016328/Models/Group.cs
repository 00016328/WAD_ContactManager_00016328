namespace WAD_contactManager_00016328.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
