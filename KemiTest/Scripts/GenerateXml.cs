using Godot;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

public class GenerateXml
{
    public static string UserName { get; set; }
    /// <summary>
    /// This is the path to the file
    /// </summary>
    public static string Path { get { return Path; } private set { Path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),"Score.score"); } } 

    public static void GenerateFile(string userName)
    {
        XElement score = new XElement("Username", new XAttribute("admin", false), userName);
        score.Save("Score.score");
        GD.Print("File created and saved");
    }
    /// <summary>
    /// Writes a new score to the score file
    /// </summary>
    /// <param name="score">The score to write. We need to figure out some way to calculate the score</param>
    /// <param name="streak">The longest streak. I'm not sure if we need this but we have it for now</param>
    public static void WriteToFile(int score, int streak)
    {
        XDocument doc = XDocument.Load(System.IO.Path.Combine(Path, "Score.score"));
        doc.Root.Element("UserName").Add(new XElement("Score", score), new XElement("Streak", streak));
        doc.Save(Path);
        GD.Print("File edited and saved");
    }
    /// <summary>
    /// Reads from an xml file
    /// </summary>
    /// <param name="thingToGet">The thing you want to get from the file</param>
    public static IEnumerable<XElement> ReadFromFile(string thingToGet)
    {
        XDocument doc = XDocument.Load(Path);
        IEnumerable<XElement> query = from score in doc.Descendants("Username") orderby (int)score.Element(thingToGet) select score;
        query.Reverse();
        foreach (var score in query)
        {
            GD.Print(score.Name);
        }
        GD.Print("File read");
        return query;
    }
}