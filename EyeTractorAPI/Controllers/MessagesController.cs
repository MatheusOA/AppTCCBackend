using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EyeTractorAPI.Models;
using Microsoft.AspNetCore.Authorization;
using EyeTractorAPI.Services;
using AutoMapper;
using Microsoft.Extensions.Primitives;

namespace EyeTractorAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private DataContext _context { get; }
        private IUserService _userService { get; }
        private IMapper _mapper { get; }

        public MessagesController(DataContext context,
            IMapper mapper,
            IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Messages>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        // POST: api/Messages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Messages>> PostMessages([FromBody]CreateMessageModel model)
        {
            string userId = _userService.GetIdByRequest(Request);

            var message = _mapper.Map<Messages>(model);

            message.UserId = int.Parse(userId);
            message.CreationDateTime = DateTime.Now;

            _context.Messages.Add(message);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return CreatedAtAction(nameof(GetMessages), new { id = message.Id }, message);
        }

        private bool MessagesExists(long id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}
