using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
namespace Schülerverwaltung
{
    public class ClassActions
    {
        public static async Task HandleClassActions(ClassService classService)
        {
            Console.Clear();
            Console.WriteLine("Klassenverwaltung");
            Console.WriteLine("1. Klasse hinzufügen");
            Console.WriteLine("2. Klasse anzeigen");
            Console.WriteLine("3. Klasse aktualisieren");
            Console.WriteLine("4. Klasse löschen");
            Console.WriteLine("5. Zurück zum Hauptmenü");
            Console.Write("Wähle eine Aktion: ");

            var actionChoice = Console.ReadLine();
            Console.Clear();

            switch (actionChoice)
            {
                case "1":
                    await AddClass(classService);
                    break;
                case "2":
                    await ReadClass(classService);
                    break;
                case "3":
                    await UpdateClass(classService);
                    break;
                case "4":
                    await DeleteClass(classService);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Ungültige Aktion. Bitte erneut versuchen.");
                    break;
            }
        }

        public static async Task AddClass(ClassService classService)
        {
            Console.Write("Klassenname: ");
            string className = Console.ReadLine();

            Console.Write("Schuljahr: ");
            int schoolYear = int.Parse(Console.ReadLine());

            Console.Write("Lehrer-ID: ");
            string teacherId = Console.ReadLine();

            var classData = new BsonDocument
            {
                { "ClassName", className },
                { "SchoolYear", schoolYear },
                { "TeacherId", teacherId },
                { "StudentIds", new BsonArray() }
            };

            await classService.CreateClassAsync(classData);
        }

        public static async Task ReadClass(ClassService classService)
        {
            Console.Write("Klassenname: ");
            string className = Console.ReadLine();

            var classData = await classService.GetClassByNameAsync(className);
            if (classData != null)
            {
                Console.WriteLine($"Klasse gefunden: {classData["ClassName"]}");
                Console.WriteLine($"Schuljahr: {classData["SchoolYear"]}");
                Console.WriteLine($"Lehrer-ID: {classData["TeacherId"]}");
            }
            else
            {
                Console.WriteLine("Klasse nicht gefunden.");
            }
        }

        public static async Task UpdateClass(ClassService classService)
        {
            Console.Write("Klassenname: ");
            string className = Console.ReadLine();

            var classData = await classService.GetClassByNameAsync(className);
            if (classData != null)
            {
                Console.WriteLine($"Bearbeite Klasse: {className}");
                Console.Write("Neuer Klassenname (leer lassen, um es nicht zu ändern): ");
                string newClassName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newClassName)) classData["ClassName"] = newClassName;

                Console.Write("Neues Schuljahr (leer lassen, um es nicht zu ändern): ");
                int newSchoolYear;
                if (int.TryParse(Console.ReadLine(), out newSchoolYear)) classData["SchoolYear"] = newSchoolYear;

                await classService.UpdateClassAsync(classData["_id"].AsObjectId, classData);
            }
            else
            {
                Console.WriteLine("Klasse nicht gefunden.");
            }
        }

        public static async Task DeleteClass(ClassService classService)
        {
            Console.Write("Klassenname: ");
            string className = Console.ReadLine();

            var classData = await classService.GetClassByNameAsync(className);
            if (classData != null)
            {
                Console.WriteLine($"Lösche Klasse: {className}");
                await classService.DeleteClassAsync(classData["_id"].AsObjectId);
            }
            else
            {
                Console.WriteLine("Klasse nicht gefunden.");
            }
        }
    }
}