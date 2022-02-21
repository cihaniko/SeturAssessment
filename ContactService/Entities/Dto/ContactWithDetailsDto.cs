namespace ContactService.Entities.Dto
{
    public class ContactWithDetailsDto 
    {
        public List<ContactDetailsDto> ContactDetails { get; set; }
        public ContactDto Contact { get; set; }

    }
}
