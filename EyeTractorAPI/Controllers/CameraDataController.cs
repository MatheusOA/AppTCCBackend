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
        public async Task<ActionResult<IEnumerable<DateEvent>>> GetMessages()
        {
            int userId = int.Parse(_userService.GetIdByRequest(Request));
            List<CameraData> cameraDatas = await _context.CameraData.Where(x => x.UserId == userId).ToListAsync();

            return ConvertCameraDataToDataEvents(cameraDatas);
        }

        public List<DateEvent> ConvertCameraDataToDataEvents(List<CameraData> cameraDatas)
        {
            List<DateEvent> eventos = new List<DateEvent>();
            
            if (cameraDatas == null)
            {
                return null;
            }

            foreach (CameraData cameraData in cameraDatas)
            {
                int tPosition = cameraData.EventDate.IndexOf('T');
                string date = cameraData.EventDate.Substring(0, tPosition);

                DateEvent foundDate = eventos.Find(x => x.Date == date);
                DateEvent currentDate = foundDate ?? new DateEvent(date);

                if (cameraData.EventType == "distracao")
                {
                    currentDate.Distraction++;
                }
                else
                {
                    currentDate.Fatigue++;
                }

                if (foundDate == null)
                {
                    eventos.Add(currentDate);
                }
            }

            return eventos;
        }
    }
}
