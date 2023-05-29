using BGN.Models;
using BGN.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace BGN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : Controller
    {
        private readonly NoteService _noteService;

        public NotesController(NoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpGet]
        public ActionResult<List<Note>> Get() =>
        _noteService.GetAllNotes();
        
        [HttpGet("{id}")]
        public ActionResult<Note> Get(int id)
        {
            var note = _noteService.GetNoteById(id);
            if (note == null)
            {
                return NotFound();
            }
            return note;
        }
        [HttpPost]
        public ActionResult<Note> Post(Note note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _noteService.AddNote(note);
            return CreatedAtAction(nameof(Get), new { id = note.Id }, note);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, NoteUpdateDto updatedNoteDto)
        {
            try
            {
                var existingNote = _noteService.GetNoteById(id);
                if (existingNote == null)
                {
                    return NotFound();
                }

                // Here, I converted NoteUpdateDto to Note as I wouldn't want the user to input the ID when making updates
                var updatedNote = new Note
                {
                    Id = existingNote.Id,
                    Title = updatedNoteDto.Title,
                    Content = updatedNoteDto.Content
                };

                _noteService.UpdateNote(updatedNote);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //public IActionResult Put(int id, Note note)
        //{
        //    if (id != note.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var updatedNote = _noteService.UpdateNote(note);
        //    if (updatedNote == null)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _noteService.DeleteNote(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
