using Godot;
using System;

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
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
