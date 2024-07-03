namespace OpenYourEyes;

public class Student
{
    //Attribut et propriété Eleves
    public int DernierIdentifiant { get; set; }

    public string Lastname { get; set; }

    public string Firstname { get; set; }
    
    public DateTime DateDeNaissance { get; set; }
    
    public List<Grade> notes = new List<Grade>();

    //Constructeur élèves
    public Student(int dernierIdentifiant, string lastname, string firstname, DateTime dateDeNaissance)
    {
        DernierIdentifiant = dernierIdentifiant;
        Lastname = lastname;
        Firstname = firstname;
        DateDeNaissance = dateDeNaissance;
        

    }
        
}