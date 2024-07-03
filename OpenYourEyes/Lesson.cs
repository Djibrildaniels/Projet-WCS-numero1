namespace OpenYourEyes;

public class Lesson
{
    //Attribut & Propriété Course
    public int IdNumber { get; set; }
    public string SubjectName { get; set; }
    

    //Constructeur Cours
    public Lesson(int idNumber, string subjectName)
    {
        IdNumber = idNumber;
        SubjectName = subjectName;
    }

    
}