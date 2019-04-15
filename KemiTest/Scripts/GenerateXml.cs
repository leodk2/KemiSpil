using Godot;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

public static class GenerateXml
{
    public static void GenerateFile(string userName)
    {
        XElement score = new XElement("Username", new XAttribute("admin", false), userName);
        score.Save("Score.score");
        GD.Print("Done");
    }
    /// <summary>
    /// Writes a new score to the score file
    /// </summary>
    /// <param name="path">The path to the xml file</param>
    /// <param name="score">The score to write. We need to figure out some way to calculate the score</param>
    /// <param name="longestStreak">The longest streak. I'm not sure if we need this but we have it for now</param>
    public static void WriteToFile(string @path, int score, int longestStreak)
    {
        XDocument doc = XDocument.Load(path);
        doc.Root.Element("UserName").Add(new XElement("Score", score), new XElement("Longest streak", longestStreak));
        doc.Save(path);
    }
    /// <summary>
    /// Reads from an xml file
    /// </summary>
    /// <param name="path">The Path to the file</param>
    /// <param name="thingToGet">The thing you want to get from the file</param>
    public static void ReadFromFile(string @path, string thingToGet)
    {
        XDocument doc = XDocument.Load(path);
        IEnumerable<XElement> query = from score in doc.Descendants("Username") orderby (int)score.Element(thingToGet) select score;
        query.Reverse();
        foreach (var score in query)
        {
            GD.Print(score.Name);
        }

    }
}