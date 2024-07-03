namespace OpenYourEyes;

public class RunProgram()
{
    public static void Run()
    {
        SchoolApp schoolApp = new SchoolApp();

        Console.WriteLine("Bienvenue sur l'application OpenYourEyes! ");
        Console.WriteLine($"Veuillez selectionner : ");

        bool continuer = true;

        while (continuer)
        {
            schoolApp.AppMenu();

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    while (choice != "5")
                    {
                        schoolApp.StudentMenu();

                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                schoolApp.ListStudents();
                                break;

                            case "2":
                                schoolApp.AddStudents();
                                break;

                            case "3":
                                schoolApp.DisplayStudent();
                                break;

                            case "4":
                                schoolApp.AddGradeToStudent();
                                break;

                            
                        }
                    }


                    break;

                case "2":
                    while (choice != "4")
                    {
                        schoolApp.LessonMenu();

                        choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                schoolApp.ListLesson();
                                break;
                        
                            case "2": 
                                schoolApp.AddLesson();
                                break;
                        
                            case "3":
                                schoolApp.DeleteLesson();
                                break;
                        
                            
                        }
                        
                    }

                    break;


                case "3":
                    continuer = false;
                    Console.WriteLine("Merci d'avoir utilisé l'application OpenYourEyes!");
                    break;

                default:
                    Console.WriteLine("Choix invalide, veuillez choix une option valide.");
                    break;
            }
        }
    }
}