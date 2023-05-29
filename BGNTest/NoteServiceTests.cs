using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGN.Models;
using BGN.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BGNTest
{
   
    [TestClass]
    public class NoteServiceTests
    {
        private NoteService? _noteService;

        [TestInitialize]
        public void TestInitialize()
        {
            _noteService = new NoteService();
        }

        [TestMethod]
        public void AddNote_ShouldAddNote()
        {
            var note = new Note { Title = "Test Note", Content = "Test Content" };
            var addedNote = _noteService.AddNote(note);
            Assert.IsNotNull(addedNote);
            Assert.AreEqual(note.Title, addedNote.Title);
            Assert.AreEqual(note.Content, addedNote.Content);
        }

        [TestMethod]
        public void GetAllNotes_ShouldReturnAllNotes()
        {
            var note1 = new Note { Title = "Note 1", Content = "Content 1" };
            var note2 = new Note { Title = "Note 2", Content = "Content 2" };
            _noteService.AddNote(note1);
            _noteService.AddNote(note2);
            var allNotes = _noteService.GetAllNotes();
            Assert.AreEqual(2, allNotes.Count());
            Assert.IsTrue(allNotes.Any(n => n.Title == note1.Title));
            Assert.IsTrue(allNotes.Any(n => n.Title == note2.Title));
        }

        [TestMethod]
        public void GetNoteById_ShouldReturnCorrectNote()
        {
            var note = new Note { Title = "Test Note", Content = "Test Content" };
            var addedNote = _noteService.AddNote(note);
            var retrievedNote = _noteService.GetNoteById(addedNote.Id);
            Assert.IsNotNull(retrievedNote);
            Assert.AreEqual(addedNote.Id, retrievedNote.Id);
        }

        [TestMethod]
        public void UpdateNote_ShouldUpdateNote()
        {
            var note = new Note { Title = "Test Note", Content = "Test Content" };
            var addedNote = _noteService.AddNote(note);
            var updatedNote = new Note { Id = addedNote.Id, Title = "Updated Title", Content = "Updated Content" };
            var result = _noteService.UpdateNote(updatedNote);
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedNote.Title, result.Title);
            Assert.AreEqual(updatedNote.Content, result.Content);
        }

        [TestMethod]
        public void DeleteNote_ShouldDeleteNote()
        {
            var note = new Note { Title = "Test Note", Content = "Test Content" };
            var addedNote = _noteService.AddNote(note);
            var result = _noteService.DeleteNote(addedNote.Id);
            Assert.IsTrue(result);
            Assert.IsNull(_noteService.GetNoteById(addedNote.Id));
        }
    }

}
