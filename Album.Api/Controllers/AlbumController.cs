using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Album.Api.Models;
using Album.Api.Database;
using Album.Api.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

namespace Album.Api.Controllers
{
    [EnableCors("cors-policy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly AlbumService _service;
        private readonly ILogger<AlbumController> _logger;

        public AlbumController(
                                AlbumService service,
                                ILogger<AlbumController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/Album
        [EnableCors("cors-policy")]
        [HttpGet]
        public ActionResult<IEnumerable<AlbumModel>> GetAlbums()
        {
            try
            {
                return _service.GetAlbums();
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, "Get all albums");

            }
            return BadRequest("An error occured returning the album object");
        }

        // GET: api/Album/5
        [EnableCors("cors-policy")]
        [HttpGet("{id}")]
        public ActionResult<AlbumModel> GetAlbum(int id)
        {
            var album = _service.GetAlbum(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Album/update/5
        [EnableCors("cors-policy")]
        [HttpPut("{id}")]
        public IActionResult UpdateAlbum(int id, AlbumModel album)
        {
            if (id != album.Id)
            {
                return BadRequest();
            }

            _service.UpdateAlbum(id, album);
            return NoContent();
        }

        // POST: api/Album/create
        [EnableCors("cors-policy")]
        [HttpPost]
        public ActionResult<AlbumModel> SaveAlbum(AlbumModel album)
        {
            _service.CreateAlbum(album);

            return CreatedAtAction("GetAlbum", new { id = album.Id }, album);
        }

        // DELETE: api/Album/delete/5
        [EnableCors("cors-policy")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            var album = _service.DeleteAlbum(id);
            if (album == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
