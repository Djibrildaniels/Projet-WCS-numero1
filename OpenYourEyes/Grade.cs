namespace OpenYourEyes;

public class Grade // Classe Notes
{
    //Attribut & Propriétés
    public double Note { get; set; }
    public string Appreciation { get; set; }
    public int CourseId { get; set; }
   

    //Constructeur
    public Grade(double note, string appreciation, int courseId)
    {
        Note = note;
        Appreciation = appreciation;
        CourseId = courseId;
    }

    
    
}