using Godot;
using System;

public class BaseScript : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Label n = new Label();
        n.SetText("owo");
        n.SetPosition(new Vector2(50,50));
        AddChild(n);
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
