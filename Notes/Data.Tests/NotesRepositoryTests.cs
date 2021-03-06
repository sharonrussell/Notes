﻿using System.Collections.Generic;
using System.Linq;
using Data.NHibernate;
using Notes;
using NUnit.Framework;

namespace Data.Tests
{
    [TestFixture]
    public class NotesRepositoryTests
    {
        private INotesRepository _notesRepository;

        private INHibernateHelper _nHibernateHelper;

        [SetUp]
        public void SetUp()
        {
            _nHibernateHelper = new TestNHibernateHelper();

            _notesRepository = new NotesRepository(_nHibernateHelper);
        }

        [Test]
        public void When_AddingNote_Should_SaveToDB()
        {
            _notesRepository.AddNote("test note");

            Note note;

            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    note = session.Get<Note>(1);
                    transaction.Commit();
                }
            }

            Assert.That(note, Is.Not.Null);
            Assert.That(note.Text, Is.EqualTo("test note"));
        }

        [Test]
        public void When_DeletingNote_Should_DeleteFromDB()
        {
            Note note;

            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    note = new Note
                    {
                        Text = "some text"
                    };

                    session.Save(note);
                    transaction.Commit();
                }
            }

            _notesRepository.DeleteNote(1);

            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    note = session.Get<Note>(1);
                    transaction.Commit();
                }
            }

            Assert.That(note, Is.Null);
        }

        [Test]
        public void When_GettingAllNotes_Should_GetFromDB()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var note = new Note
                    {
                        Text = "test note"
                    };

                    session.Save(note);
                    transaction.Commit();
                }
            }

            IEnumerable<Note> notes = _notesRepository.GetAllNotes().ToList();

            Assert.That(notes, Is.Not.Null);
            Assert.That(notes.First(o => o.Text.Equals("test note")).Text, Is.EqualTo("test note"));
        }

        [Test]
        public void When_GettingNote_Should_SaveToDB()
        {
            Note note;

            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    note = new Note
                    {
                        Text = "test note"
                    };

                    session.Save(note);
                    transaction.Commit();
                }
            }

            note = _notesRepository.GetNote(note.Id);

            Assert.That(note, Is.Not.Null);
            Assert.That(note.Text, Is.EqualTo("test note"));
        }

        [Test]
        public void When_EditingNote_Should_EditNoteInDB()
        {
            Note note;

            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    note = new Note
                    {
                        Text = "test note",
                        Id = 1
                    };

                    session.Save(note);
                    transaction.Commit();
                }
            }

            _notesRepository.EditNote(note.Id, "new text");

            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    note = session.Get<Note>(note.Id);
                    transaction.Commit();
                }
            }

            Assert.That(note.Text, Is.EqualTo("new text"));
        }
    }
}