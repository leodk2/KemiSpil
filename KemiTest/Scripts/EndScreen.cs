using Godot;
using System;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Collections.Generic;



public class EndScreen : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public Label scoreLabel;
    public Label streakLabel;
    GlobalVariables var;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var = new GlobalVariables();
        GenerateXml.WriteToFile(var.NewStreak, var.Score);
        JsonParser.Serializer = new DataContractJsonSerializer(typeof(List<Score>));
        JsonParser.Stream = new MemoryStream();
        
        scoreLabel = GetNode<Label>("ScoreLabel");
        streakLabel = GetNode<Label>("StreakLabel");
        scoreLabel.Text = var.Score.ToString();
        streakLabel.Text = GlobalVariables.StreakList.ToString();
    }


}
