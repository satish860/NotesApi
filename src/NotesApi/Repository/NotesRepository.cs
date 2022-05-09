﻿using Google.Cloud.Firestore;

namespace NotesApi.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly FirestoreDb Db;
        private readonly CollectionReference collection;

        public NotesRepository(FirestoreDb firestoreDb)
        {
            this.Db = firestoreDb;
            this.collection = Db.Collection("notes");
        }

        public async Task<Notes> CreateNotesasync(Notes notes)
        {
            DocumentReference reference = await collection.AddAsync(notes);
            notes.NotesId = reference.Id;
            notes.CreatedDateTime = DateTime.UtcNow;
            return notes;
        }
    }
}
