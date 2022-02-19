using AutoMapper;
using ContactService.Business.ContactDetailsService;
using ContactService.Business.ContactService;
using ContactService.Entities.Concrete;
using ContactService.Entities.Dto;
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

        public ContactsController(ILogger<ContactsController> logger, IMapper mapper, IContactManager contactManager)
        {
            _logger = logger;
            this._mapper = mapper;
            this._contactManager = contactManager;
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
    }
}