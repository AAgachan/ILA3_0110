using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schülerverwaltung
{
    public class TeacherService
    {
        private readonly IMongoCollection<BsonDocument> _teachersCollection;

        public TeacherService(IMongoClient client)
        {
            var database = client.GetDatabase("Schulverwaltung");
            _teachersCollection = database.GetCollection<BsonDocument>("Lehrer");
        }

        public async Task CreateTeacherAsync(BsonDocument teacher)
        {
            try
            {
                await _teachersCollection.InsertOneAsync(teacher);
                Console.WriteLine("Lehrer erfolgreich erstellt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Erstellen des Lehrers: {ex.Message}");
            }
        }

        public async Task<BsonDocument> GetTeacherByNameAsync(string firstName, string lastName)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("FirstName", firstName),
                Builders<BsonDocument>.Filter.Eq("LastName", lastName)
            );

            return await _teachersCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateTeacherAsync(ObjectId teacherId, BsonDocument updatedTeacher)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", teacherId);
                await _teachersCollection.ReplaceOneAsync(filter, updatedTeacher);
                Console.WriteLine("Lehrer erfolgreich aktualisiert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Aktualisieren des Lehrers: {ex.Message}");
            }
        }

        public async Task DeleteTeacherAsync(ObjectId teacherId)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", teacherId);
                await _teachersCollection.DeleteOneAsync(filter);
                Console.WriteLine("Lehrer erfolgreich gelöscht.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Löschen des Lehrers: {ex.Message}");
            }
        }
    }
}
