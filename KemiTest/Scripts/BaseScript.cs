using Godot;
using System;

public class BaseScript : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    Node red;
    Node green;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
      red = GetNode("Red");
      green = GetNode("Green");
      GD.Print(GetNode("Red"));
    }

 // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
      
  }
  public override void _Draw()
  {
    
    DrawLine(((Node2D)GetNode("Red")).Position, ((Node2D)GetNode("Green")).Position,new Color(0,0,0), 10, true);

  }


}
