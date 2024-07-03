using System.Globalization;

namespace OpenYourEyes;

public class SchoolApp //Classe 
{
    public int studentID = 1;
    public List<Student> Students = new List<Student>();
    public List<Lesson> Lessons = new List<Lesson>();
    public int lessonID = 1;

    public void ListStudents() //Methode pour lister les etudiants
    {
        int index = 0;
        Console.WriteLine("Voici la liste des élèves: ");
        foreach (Student student in Students)
        {
            Console.WriteLine($"{index}. {student.Lastname} {student.Firstname}");
            index++;
        }
    }

    public void ListLesson() // Methode pour lister les lessons
    {
        int index = 0;
        if (Lessons.Count > 0)
        {
            Console.WriteLine("Voici la liste des cours: ");
            foreach (var lesson in Lessons)
            {
                Console.WriteLine($"{index}. {lesson.SubjectName} ");
                index++;
            }
            Console.WriteLine(" ------------------------------------------------");
        }
        else
        {
            Console.WriteLine(" Il n'y a pas de cours. ");
        }
    }

    public void AddStudents() //Methode ajouter les etudiants
    {
        string lastName = null;
        string firstName = null;
        DateTime dateOfBirth = DateTime.MinValue;


        Console.WriteLine("Please enter the student's info: ");
        Console.Write($"Name : ");
        lastName = HasDigit(lastName);

        Console.Write($"First Name : ");
        firstName = HasDigit(firstName);

        Console.Write($"Date of birth : ");

        bool isValid = false;
        while (!isValid)
        {
            isValid = DateTime.TryParseExact(Console.ReadLine(), "d", null, DateTimeStyles.None, out dateOfBirth);

            if (!isValid)
            {
                Console.WriteLine("La date de naissance n'est pas valide. Veuillez recommencer.");
            }
        }

        Student student = new Student(studentID, lastName, firstName, dateOfBirth);
        studentID++;
        Students.Add(student);

        Console.WriteLine(" Student added successfully! ");
    }

    public string? HasDigit(string? name)
    {
        bool hasDigit = true;


        while (hasDigit)
        {
            name = Console.ReadLine();
            hasDigit = name.Any(char.IsDigit);

            if (hasDigit)
            {
                Console.WriteLine("La saisie est incorrecte. Veuillez recommencer.");
            }
        }

        return name;
    }

    public void AddGradeToStudent()
    {
        double gradeValue = 0;
        string appreciation;
        bool isValid = false;
        int index = 0;
        
        

        Student etudiant = SearchStudent();
        
        

        Console.WriteLine("Veuillez entrer le nom de la matiere que vous souhaitez : ");
        
        if (Lessons.Count > 0)
        {
            Lesson lesson = SearchLesson();
            
            Console.WriteLine(("Veuillez entrer la note de l'élève : "));
            while (!isValid)
            {
                isValid = double.TryParse(Console.ReadLine(), out gradeValue);

                if (!isValid)
                {
                    Console.WriteLine(" La note n'est pas valide, veuillez recommencer.");
                }
            }

            Console.WriteLine("Veuillez entrer l'appreciation que vous souhaitez mettre à l'élève: ");
            appreciation = Console.ReadLine();
            Grade note = new Grade(gradeValue, appreciation, lesson.IdNumber);
            etudiant.notes.Add(note); // Permet d'ajouter un élément à une liste 
            Console.WriteLine(" Les notes et l'appreciation ont bien été ajouté!");
        }
        else
        {
            Console.WriteLine(" Veuillez ajouter un cours avant de pouvoir ajouter une note à l'élève. ");
            AddLesson();
        }
    }

    public Lesson SearchLesson()
    {
        int index = 0;
        
        ListLesson();
        Console.WriteLine("Entrez l'index du cours: ");
        index = Convert.ToInt32(Console.ReadLine());
        return Lessons[index];
    }
    public int GetIdByName(string lessonName)
    {
        foreach (Lesson lesson in Lessons)
        {
            if (lessonName == lesson.SubjectName)
            {
                return lesson.IdNumber;
            }
        }

        return -1;
    }

    public string GetSubjectName(int getMyID)
    {
        foreach (Lesson lesson in Lessons)
        {
            if (getMyID == lesson.IdNumber)
            {
                return lesson.SubjectName;
            }
        }

        return null;
    }

    public void DeleteLesson()
    {
        if (Lessons.Count>0)
        {
            
            Lesson lesson = SearchLesson();
            Lessons.Remove(lesson);

            foreach (Student student in Students) // parcourir la liste des etudiants
            {
                foreach (Grade note in  student.notes ) // pour chaque note d'etudiant parcourir la liste des notes
                {
                    if (note.CourseId == lesson.IdNumber )// pour chaque note regarder si courseId correspond numberId au cours supprimer

                    {
                        student.notes.Remove(note); // supprimer la note

                        Console.WriteLine("Le cours a bien été supprimé! ");
                    }
                }
            }
            
           

        }

        else
        {
            Console.WriteLine(" Erreur, il n'y a aucun cours à supprimer.");
        }

        
        
    }

    public void AddLesson()
    {
        string Subject = null;


        Console.WriteLine("Veuillez saisir le nom du cours : ");
        Console.Write($"Subject : ");
        Subject = HasDigit(Subject);

        Lesson lesson = new Lesson(lessonID, Subject);
        Lessons.Add(lesson);
        lessonID++;

        Console.WriteLine(" Le cours a bien été ajouté!");
    }

    public static double AverageGrade(Student etudiant)
    {
        if (etudiant.notes.Count == 0) return 0;
        double sum = 0;
        foreach (Grade note in etudiant.notes)
        {
            sum += note.Note;
        }

        
        return Math.Round((sum*2) / etudiant.notes.Count, MidpointRounding.AwayFromZero)/2; // Moyenne arrondi au 0,5 le plus proche
        
    }

    public Student SearchStudent()
    {
        string lastNameSearch;
        string firstNameSearch;
        int index = 0;
        
        ListStudents();
        Console.WriteLine("Entrez l'index de l'etudiant: ");
        index = Convert.ToInt32(Console.ReadLine());
        return Students[index];
        

/*
        Console.Write("Please enter the last name of the student: ");
        lastNameSearch = Console.ReadLine();
        Console.Write("Please enter the first name of the student: ");
        firstNameSearch = Console.ReadLine();

        foreach (Student student in Students)
        {
            if (student.Lastname == lastNameSearch && student.Firstname == firstNameSearch)
            {
                return student;
            }
            
        }


        return null;
*/
    }

    public void DisplayStudent()
    {
        Student etudiant = SearchStudent();
        Console.WriteLine(" ------------------------------------------------------------\n");
        Console.WriteLine($"{etudiant.Lastname}");
        Console.WriteLine($"{etudiant.Firstname}");
        Console.WriteLine($"{etudiant.DateDeNaissance:d}\n");
        Console.WriteLine("Résultats scolaires:\n");

        foreach (Grade grade in etudiant.notes)
        {
            Console.WriteLine($"Cours : {GetSubjectName(grade.CourseId)}"); //
            Console.WriteLine($"Note : {grade.Note}");
            Console.WriteLine($"Appreciation : {grade.Appreciation}\n");
        }

        var avg = SchoolApp.AverageGrade(etudiant);
        Console.WriteLine($"La moyenne de l'élève est : {avg} ");
        Console.WriteLine(" ------------------------------------------------------------\n");
    }


    public void AppMenu()
    {
        Console.WriteLine("1.   Students ");
        Console.WriteLine("2.   Lessons  ");
        Console.WriteLine("3.   Quit     ");
    }

    public void StudentMenu()
    {
        Console.WriteLine("1.Student's List");
        Console.WriteLine("2.Add a student");
        Console.WriteLine("3.Search for a student");
        Console.WriteLine("4.Add a student grade");
        Console.WriteLine("5.Main Menu");
    }

    public void LessonMenu()
    {
        Console.WriteLine("1.Lesson list");
        Console.WriteLine("2.Add a lesson");
        Console.WriteLine("3.Delete a lesson");
        Console.WriteLine("4.Main Menu");
    }
}