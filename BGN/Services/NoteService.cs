using BGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BGN.Services
{
    public class NoteService
    {
        private readonly List<Note> _notes;

        public NoteService()
        {
            _notes = new List<Note>();
        }

        public Note AddNote(Note note)
        {
            try
            {
                note.Id = _notes.Any() ? _notes.Max(n => n.Id) + 1 : 1;
                _notes.Add(note);
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem retrieving the list of notes.", ex);
            }
        }

        public List<Note> GetAllNotes()
        {
            try
            {
                return _notes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Operation failed.", ex);
            }
        }

        public Note GetNoteById(int id)
        {
            try
            {
                return _notes.FirstOrDefault(n => n.Id == id);

                //if (note == null)
                //{
                //    throw new Exception($"No note found with the id {id}.");
                //}
            }
            catch (NullReferenceException ex)
            {
                throw new Exception($"Null reference exception occurred while trying to retrieve the note with id {id}.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception($"Invalid operation exception occurred while trying to retrieve the note with id {id}.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred while trying to retrieve the note with id {id}.", ex);
            }
        }

        public Note UpdateNote(Note updatedNote)
        {
            try
            {
                var existingNote = _notes.FirstOrDefault(n => n.Id == updatedNote.Id);
                if (existingNote == null)
                {
                    return null;
                }
                existingNote.Title = updatedNote.Title;
                existingNote.Content = updatedNote.Content;
                return existingNote;
            }
            catch (NullReferenceException ex)
            {
                throw new Exception("An error occurred while updating the note. The note could not be found.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("An error occurred while updating the note. The operation was invalid.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unknown error occurred while updating the note.", ex);
            }
        }

        public bool DeleteNote(int id)
        {
            try
            {
                var note = _notes.FirstOrDefault(n => n.Id == id);
                if (note == null)
                {
                    return false;
                }
                _notes.Remove(note);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to delete the note with ID {id}.", ex);
            }
        }
    }
}

