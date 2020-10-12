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
    public class CameraDataController : ControllerBase
    {
        private DataContext _context { get; }
        private IUserService _userService { get; }
        private IMapper _mapper { get; }

        public CameraDataController(DataContext context,
            IMapper mapper,
            IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CameraData>>> GetMessages()
        {
            int userId = int.Parse(_userService.GetIdByRequest(Request));

            return await _context.CameraData.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
