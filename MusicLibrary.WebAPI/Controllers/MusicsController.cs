using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business.Abstract;
using MusicLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLibrary.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicsController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        // get getall add update delete

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = this._musicService.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = this._musicService.Get(id);

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Music music)
        {
            var result = this._musicService.Add(music);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

    }
}
