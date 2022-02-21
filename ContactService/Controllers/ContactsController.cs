using AutoMapper;
using ContactService.Business.ContactDetailsService;
using ContactService.Business.ContactService;
using ContactService.Entities.Concrete;
using ContactService.Entities.Dto;
using ContactService.Utilities.Result;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ContactsController : ControllerBase
    {

        private readonly ILogger<ContactsController> _logger;
        private readonly IMapper _mapper;
        private readonly IContactManager _contactManager;
        private readonly IContactDetailsManager _contactDetailsManager;

        public ContactsController(ILogger<ContactsController> logger, IMapper mapper, IContactManager contactManager, IContactDetailsManager contactDetailsManager)
        {
            _logger = logger;
            this._mapper = mapper;
            this._contactManager = contactManager;
            this._contactDetailsManager = contactDetailsManager;
        }


        /// <summary>
        /// Add only contacts
        /// </summary>
        /// <param name="contactDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            var result = await _contactManager.Add(contact);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        /// <summary>
        /// Get only contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _contactManager.Get(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        /// <summary>
        /// Get All contact list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _contactManager.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        /// <summary>
        /// Delete contact with details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _contactManager.Delete(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactWithDetails(string id)
        {

            var result = await _contactManager.Get(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            ContactWithDetailsDto contact = new();
            contact.Contact = _mapper.Map<ContactDto>(result.Data);


            var resultDetails = _contactDetailsManager.GetListByContactId(id);
            if (resultDetails.IsSuccess)
            {

                var contactDetailList = resultDetails.Data.ToList();
                contact.ContactDetails = new List<ContactDetailsDto>();
                foreach (var item in contactDetailList)
                {
                    contact.ContactDetails.Add(_mapper.Map<ContactDetailsDto>(item));
                }

            }
            return Ok(new ResultModel<ContactWithDetailsDto>() { IsSuccess = true, Data = contact, Message = "asd" });

        }
    }
}