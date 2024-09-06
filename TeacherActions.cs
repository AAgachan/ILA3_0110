using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
namespace Schülerverwaltung
{
    public class TeacherActions
    {
        public static async Task HandleTeacherActions(TeacherService teacherService)
        {
            Console.Clear();
            Console.WriteLine("Lehrerverwaltung");
            Console.WriteLine("1. Lehrer hinzufügen");
            Console.WriteLine("2. Lehrer anzeigen");
            Console.WriteLine("3. Lehrer aktualisieren");
            Console.WriteLine("4. Lehrer löschen");
            Console.WriteLine("5. Zurück zum Hauptmenü");
            Console.Write("Wähle eine Aktion: ");

            var actionChoice = Console.ReadLine();
            Console.Clear();

            switch (actionChoice)
            {
                case "1":
                    await AddTeacher(teacherService);
                    break;
                case "2":
                    await ReadTeacher(teacherService);
                    break;
                case "3":
                    await UpdateTeacher(teacherService);
                    break;
                case "4":
                    await DeleteTeacher(teacherService);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Ungültige Aktion. Bitte erneut versuchen.");
                    break;
            }
        }

        public static async Task AddTeacher(TeacherService teacherService)
        {
            Console.Write("Vorname des Lehrers: ");
            string firstName = Console.ReadLine();

            Console.Write("Nachname des Lehrers: ");
            string lastName = Console.ReadLine();

            Console.Write("Geburtsdatum des Lehrers (yyyy-MM-dd): ");
            
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Geschlecht des Lehrers: ");
            string gender = Console.ReadLine();

            Console.Write("Fach des Lehrers: ");
            string subject = Console.ReadLine();

            var teacher = new BsonDocument
            {
                { "FirstName", firstName },
                { "LastName", lastName },
                { "DateOfBirth", dateOfBirth },
                { "Gender", gender },
                { "Subject", subject }
            };

            await teacherService.CreateTeacherAsync(teacher);
        }

        public static async Task ReadTeacher(TeacherService teacherService)
        {
            Console.Write("Vorname des Lehrers: ");
            string firstName = Console.ReadLine();

            Console.Write("Nachname des Lehrers: ");
            string lastName = Console.ReadLine();

            var teacher = await teacherService.GetTeacherByNameAsync(firstName, lastName);
            if (teacher != null)
            {
                Console.WriteLine($"Lehrer gefunden: {teacher["FirstName"]} {teacher["LastName"]}");
                Console.WriteLine($"Geburtsdatum: {teacher["DateOfBirth"]}");
                Console.WriteLine($"Geschlecht: {teacher["Gender"]}");
                Console.WriteLine($"Fach: {teacher["Subject"]}");
            }
            else
            {
                Console.WriteLine("Lehrer nicht gefunden.");
            }
        }

        public static async Task UpdateTeacher(TeacherService teacherService)
        {
            Console.Write("Vorname des Lehrers: ");
            string firstName = Console.ReadLine();

            Console.Write("Nachname des Lehrers: ");
            string lastName = Console.ReadLine();

            var teacher = await teacherService.GetTeacherByNameAsync(firstName, lastName);
            if (teacher != null)
            {
                Console.WriteLine($"Bearbeite Lehrer: {firstName} {lastName}");
                Console.Write("Neuer Vorname (leer lassen, um es nicht zu ändern): ");
                string newFirstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newFirstName)) teacher["FirstName"] = newFirstName;

                Console.Write("Neuer Nachname (leer lassen, um es nicht zu ändern): ");
                string newLastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newLastName)) teacher["LastName"] = newLastName;

                Console.Write("Neues Geburtsdatum (yyyy-MM-dd, leer lassen, um es nicht zu ändern): ");
                string newDateOfBirth = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDateOfBirth)) teacher["DateOfBirth"] = DateTime.Parse(newDateOfBirth);

                Console.Write("Neues Geschlecht (leer lassen, um es nicht zu ändern): ");
                string newGender = Console.ReadLine();
                if (!string.IsNullOrEmpty(newGender)) teacher["Gender"] = newGender;

                Console.Write("Neues Fach (leer lassen, um es nicht zu ändern): ");
                string newSubject = Console.ReadLine();
                if (!string.IsNullOrEmpty(newSubject)) teacher["Subject"] = newSubject;

                await teacherService.UpdateTeacherAsync(teacher["_id"].AsObjectId, teacher);
            }
            else
            {
                Console.WriteLine("Lehrer nicht gefunden.");
            }
        }

        public static async Task DeleteTeacher(TeacherService teacherService)
        {
            Console.Write("Vorname des Lehrers: ");
            string firstName = Console.ReadLine();

            Console.Write("Nachname des Lehrers: ");
            string lastName = Console.ReadLine();

            var teacher = await teacherService.GetTeacherByNameAsync(firstName, lastName);
            if (teacher != null)
            {
                Console.WriteLine($"Lösche Lehrer: {firstName} {lastName}");
                await teacherService.DeleteTeacherAsync(teacher["_id"].AsObjectId);
            }
            else
            {
                Console.WriteLine("Lehrer nicht gefunden.");
            }
        }
    }
}