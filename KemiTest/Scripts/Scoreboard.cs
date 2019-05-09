using Godot;
using System;
using System.Linq;
using System.Xml.Linq;

public class Scoreboard : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";


    ItemList list;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        list = GetNode<ItemList>("Table");
        list.MaxColumns++;
        ReadXml();
    }


    public void ReadXml()
    {
        XElement doc = XElement.Load("res://Score.score");
        var query = from el in doc.Elements("game") select el;
        
        foreach (var item in query)
        {
            //prints for debugging purpuses
            GD.Print(item.Element("score").Value);
            GD.Print(item.Element("streak").Value);
            //Adds the times to the table
            list.AddItem(item.Element("score").Value);
            list.AddItem(item.Element("streak").Value);
            item.ToScoreStruct();

            
        }


    }



//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
