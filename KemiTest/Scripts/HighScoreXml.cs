using Godot;
using System;
using System.IO;
using System.Xml.Linq;
using System.Xml;

public class HighScoreXml : Node
{

    public static void CreateScoreXml()
    {
        XElement score =
            new XElement("Username", new XAttribute("admin", false),
            new XElement("HighScore", 0),
            new XElement("LongestStreak", 0)
            );
        score.Save("Score.score");

    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if (!System.IO.File.Exists(@"C: /Users/leomi/Documents/GitHub/KemiSpil/KemiTest/Andre ting/Score.score"))
        {
            CreateScoreXml();
            GD.Print("Created new file");
        }
        else
        {
            GD.Print("Did not create a new file");
        }
    }

}
