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
    public class ContactsDetailsController : ControllerBase
    {

        private readonly ILogger<ContactsController> _logger;
        private readonly IMapper _mapper;
        private readonly IContactDetailsManager _contactDetailsManager;
        private readonly IContactManager _contactManager;

        public ContactsDetailsController(ILogger<ContactsController> logger, IMapper mapper, IContactDetailsManager contactDetailsManager,IContactManager contactManager )
        {
            _logger = logger;
            this._mapper = mapper;
            this._contactDetailsManager = contactDetailsManager;
            this._contactManager = contactManager;
        }


        /// <summary>
        /// Add only contacts
        /// </summary>
        /// <param name="contactDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(ContactDetailsDto contactDto)
        {
            //Check ContactId is Exist 
            var isExist = await _contactManager.IsExist(contactDto.ContactId);

            if (!isExist.IsSuccess || !isExist.Data)
            {
                return BadRequest(isExist);
            }

            var contact = _mapper.Map<ContactDetails>(contactDto);
            var result = await _contactDetailsManager.Add(contact);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        /// <summary>
        /// Get only contactDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _contactDetailsManager.Get(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        /// <summary>
        /// Get All contactDetail list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _contactDetailsManager.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        /// <summary>
        /// Delete contactDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _contactDetailsManager.Delete(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}