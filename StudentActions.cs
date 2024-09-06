using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
namespace Schülerverwaltung
{
    public class StudentActions
    {
        public static async Task HandleStudentActions(StudentService studentService)
        {
            Console.Clear();
            Console.WriteLine("Schülerverwaltung");
            Console.WriteLine("1. Schüler hinzufügen");
            Console.WriteLine("2. Schüler anzeigen");
            Console.WriteLine("3. Schüler aktualisieren");
            Console.WriteLine("4. Schüler löschen");
            Console.WriteLine("5. Zurück zum Hauptmenü");
            Console.Write("Wähle eine Aktion: ");

            var actionChoice = Console.ReadLine();
            Console.Clear();

            switch (actionChoice)
            {
                case "1":
                    await AddStudent(studentService);
                    break;
                case "2":
                    await ReadStudent(studentService);
                    break;
                case "3":
                    await UpdateStudent(studentService);
                    break;
                case "4":
                    await DeleteStudent(studentService);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Ungültige Aktion. Bitte erneut versuchen.");
                    break;
            }
        }

        public static async Task AddStudent(StudentService studentService)
        {
            Console.Write("Vorname des Schülers: ");
            string firstName = Console.ReadLine();

            Console.Write("Nachname des Schülers: ");
            string lastName = Console.ReadLine();

            Console.Write("Geburtsdatum des Schülers (yyyy-MM-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Geschlecht des Schülers: ");
            string gender = Console.ReadLine();

            Console.Write("Klassenname für den Schüler: ");
            string className = Console.ReadLine();

            var student = new BsonDocument
            {
                { "FirstName", firstName },
                { "LastName", lastName },
                { "DateOfBirth", dateOfBirth },
                { "Gender", gender },
                { "ClassName", className }
            };

            await studentService.CreateStudentAsync(student);
        }

        public static async Task ReadStudent(StudentService studentService)
        {
            Console.Write("Vorname des Schülers: ");
            string firstName = Console.ReadLine();

            Console.Write("Nachname des Schülers: ");
            string lastName = Console.ReadLine();

            var student = await studentService.GetStudentByNameAsync(firstName, lastName);
            if (student != null)
            {
                Console.WriteLine($"Schüler gefunden: {student["FirstName"]} {student["LastName"]}");
                Console.WriteLine($"Geburtsdatum: {student["DateOfBirth"]}");
                Console.WriteLine($"Geschlecht: {student["Gender"]}");
                Console.WriteLine($"Klasse: {student["ClassName"]}");
            }
            else
            {
                Console.WriteLine("Schüler nicht gefunden.");
            }
        }

        public static async Task UpdateStudent(StudentService studentService)
        {
            Console.Write("Vorname des Schülers: ");
            string firstName = Console.ReadLine();

            Console.Write("Nachname des Schülers: ");
            string lastName = Console.ReadLine();

            var student = await studentService.GetStudentByNameAsync(firstName, lastName);
            if (student != null)
            {
                Console.WriteLine($"Bearbeite Schüler: {firstName} {lastName}");
                Console.Write("Neuer Vorname (leer lassen, um es nicht zu ändern): ");
                string newFirstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newFirstName)) student["FirstName"] = newFirstName;

                Console.Write("Neuer Nachname (leer lassen, um es nicht zu ändern): ");
                string newLastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newLastName)) student["LastName"] = newLastName;

                Console.Write("Neues Geburtsdatum (yyyy-MM-dd, leer lassen, um es nicht zu ändern): ");
                string newDateOfBirth = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDateOfBirth)) student["DateOfBirth"] = DateTime.Parse(newDateOfBirth);

                Console.Write("Neues Geschlecht (leer lassen, um es nicht zu ändern): ");
                string newGender = Console.ReadLine();
                if (!string.IsNullOrEmpty(newGender)) student["Gender"] = newGender;

                Console.Write("Neue Klasse (leer lassen, um es nicht zu ändern): ");
                string newClassName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newClassName)) student["ClassName"] = newClassName;

                await studentService.UpdateStudentAsync(student["_id"].AsObjectId, student);
            }
            else
            {
                Console.WriteLine("Schüler nicht gefunden.");
            }
        }

        public static async Task DeleteStudent(StudentService studentService)
        {
            Console.Write("Vorname des Schülers: ");
            string firstName = Console.ReadLine();

            Console.Write("Nachname des Schülers: ");
            string lastName = Console.ReadLine();

            var student = await studentService.GetStudentByNameAsync(firstName, lastName);
            if (student != null)
            {
                Console.WriteLine($"Lösche Schüler: {firstName} {lastName}");
                await studentService.DeleteStudentAsync(student["_id"].AsObjectId);
            }
            else
            {
                Console.WriteLine("Schüler nicht gefunden.");
            }
        }

    }    
}