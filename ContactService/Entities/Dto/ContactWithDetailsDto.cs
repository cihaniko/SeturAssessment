namespace ContactService.Entities.Dto
{
    public class ContactWithDetailsDto : ContactDto
    {
        public List<ContactDetailsDto> ContactDetails { get; set; }

    }
}
