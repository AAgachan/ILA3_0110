using MongoDB.Bson;
using MongoDB.Driver;
using Schülerverwaltung;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schülerverwaltung
{
    public class ClassService
    {
        private readonly IMongoCollection<BsonDocument> _classesCollection;

        public ClassService(IMongoClient client)
        {
            var database = client.GetDatabase("Schulverwaltung");
            _classesCollection = database.GetCollection<BsonDocument>("Klasse");
        }

        public async Task CreateClassAsync(BsonDocument classData)
        {
            try
            {
                await _classesCollection.InsertOneAsync(classData);
                Console.WriteLine("Klasse erfolgreich erstellt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Erstellen der Klasse: {ex.Message}");
            }
        }

        public async Task<BsonDocument> GetClassByNameAsync(string className)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("ClassName", className);
            return await _classesCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateClassAsync(ObjectId classId, BsonDocument updatedClass)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", classId);
                await _classesCollection.ReplaceOneAsync(filter, updatedClass);
                Console.WriteLine("Klasse erfolgreich aktualisiert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Aktualisieren der Klasse: {ex.Message}");
            }
        }

        public async Task DeleteClassAsync(ObjectId classId)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", classId);
                await _classesCollection.DeleteOneAsync(filter);
                Console.WriteLine("Klasse erfolgreich gelöscht.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Löschen der Klasse: {ex.Message}");
            }
        }
    }
}
