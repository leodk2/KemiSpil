using Godot;
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class Score
{
    [DataMember]
    public int Points { get; private set; }
    [DataMember]
    public int Streak { get; private set; }

    public List<Score> Scores { get; private set; } = JsonParser.DeserializeJsonFile("Score.score");

    public Score(int score, int streak)
    {
        Points = score;
        Streak = streak;
    }
    


    public void Print(){
        GD.Print($"points: {this.Points}, streak: {this.Streak}");
    }

    public static void Print(List<Score> scores){
        foreach(var score in scores){
            GD.Print($"points: {score.Points}, streak: {score.Streak}");
        }
    }

    public override string ToString(){
        return $"points: {this.Points}, streak: {this.Streak}";
    }

    public static Score ConvertFromXml(XElement item)
    {
        return new Score(Convert.ToInt32(item.Element("Score").Value), Convert.ToInt32(item.Element("Streak").Value));
    }
    public void Print(Score @struct) => GD.Print("Score: {0}, Streak: {1}", @struct.Points, @struct.Streak);
    public void PrintList(List<Score> scoreStructs)
    {
        foreach (var item in scoreStructs)
        {
            GD.Print("Score: {0}, Streak: {1}", item.Points, item.Streak);
        }
    }
}

public static class Extentions
{
    public static Score ToScoreStruct(this XElement item) => new Score(Convert.ToInt32(item.Element("Score").Value), 
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

