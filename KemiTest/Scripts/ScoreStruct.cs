using Godot;
using System;
using System.Xml.Linq;
using System.Collections.Generic;

public struct ScoreStruct
{

    public int Score { get; }
    public int Streak { get; }

    public ScoreStruct(int score, int streak)
    {
        Score = score;
        Streak = streak;
    }
    
    public ScoreStruct ConvertFromXml(XElement item)
    {
        return new ScoreStruct(Convert.ToInt32(item.Element("Score").Value), Convert.ToInt32(item.Element("Streak").Value));
    }

}

public static class Extentions
{
    public static ScoreStruct ToScoreStruct(this XElement item) => new ScoreStruct(Convert.ToInt32(item.Element("Score").Value), 
        Convert.ToInt32(item.Element("Streak").Value));

    public static int Sum(this List<int> vs)
    {
        int sum = 0;
        for (int i = 0; i < vs.Count; i++)
        {
            sum += vs[i];
        }
        return sum;
    }
}

