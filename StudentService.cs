using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schülerverwaltung
{
    public class StudentService
    {
        private readonly IMongoCollection<BsonDocument> _studentsCollection;

        public StudentService(IMongoClient client)
        {
            var database = client.GetDatabase("Schulverwaltung");
            _studentsCollection = database.GetCollection<BsonDocument>("Schüler");
        }

        public async Task CreateStudentAsync(BsonDocument student)
        {
            try
            {
                await _studentsCollection.InsertOneAsync(student);
                Console.WriteLine("Schüler erfolgreich erstellt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Erstellen des Schülers: {ex.Message}");
            }
        }

        public async Task<BsonDocument> GetStudentByNameAsync(string firstName, string lastName)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("FirstName", firstName),
                Builders<BsonDocument>.Filter.Eq("LastName", lastName)
            );

            return await _studentsCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateStudentAsync(ObjectId studentId, BsonDocument updatedStudent)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", studentId);
                await _studentsCollection.ReplaceOneAsync(filter, updatedStudent);
                Console.WriteLine("Schüler erfolgreich aktualisiert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Aktualisieren des Schülers: {ex.Message}");
            }
        }

        public async Task DeleteStudentAsync(ObjectId studentId)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", studentId);
                await _studentsCollection.DeleteOneAsync(filter);
                Console.WriteLine("Schüler erfolgreich gelöscht.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Löschen des Schülers: {ex.Message}");
            }
        }
    }
}
