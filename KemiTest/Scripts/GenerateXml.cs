using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class GenerateXml
{
    public static string UserName { get; set; }

    private static string filePath;

    /// <summary>
    /// This is the path to the file
    /// </summary>
    public static string FilePath
    {
        get { return filePath; }
        private set
        { filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "Score.score"); }
    }

    public static void GenerateFile()
    {
        //XElement score = new XElement("Username", new XAttribute("admin", false), userName);

        XElement file = new XElement("username", "", new XAttribute("Admin", false));
        Console.WriteLine(file);
        GD.Print(FilePath);
        try
        {
            file.Save("Score.score");
            GD.Print("File created and saved");
        }
        catch (Exception e)
        {
            GD.Print(e);
        }
    }

    /// <summary>
    /// Writes a new score to the score file
    /// </summary>
    /// <param name="score">The score to write. We need to figure out some way to calculate the score</param>
    /// <param name="streak">The longest streak. I'm not sure if we need this but we have it for now</param>
    public static void WriteToFile(int streak, int score = 0)
    {
        try
        {
            XElement doc = XElement.Load(FilePath);
            doc.Element("userName").Add(new XElement("game", new XElement("score", score), new XElement("streak", streak)));
            doc.Save(FilePath);
            GD.Print("File edited and saved");
        }
        catch(Exception e)
        {
            GD.Print(e);
        }
    }

    /// <summary>
    /// Reads from an xml file ordered by a certain paramater. we don't really need this right now.
    /// </summary>
    /// <param name="thingToGet">The thing you want to get from the file</param>
    public static List<XElement> ReadFromFile(string orderBy)
    {
        XDocument doc = XDocument.Load(FilePath);
        IEnumerable<XElement> query = null;
        if (orderBy != null || orderBy != "")
        {
            query = from score in doc.Descendants("username") orderby (int)score.Element(orderBy) select score;
        }
        query.Reverse();
        foreach (var score in query)
        {
            GD.Print(score.Name);
        }
        GD.Print("File read");
        return query.ToList();
    }

    public static List<ScoreStruct> Read()
    {
        XDocument doc = XDocument.Load(FilePath);
        var query = from score in doc.Elements() select score;
        List<ScoreStruct> scores = new List<ScoreStruct>();
        foreach (var item in query)
        {
            GD.Print(Convert.ToInt32(item.Element("score").Value));
            scores.Add(item.ToScoreStruct());
        }
        return scores;
    }
}