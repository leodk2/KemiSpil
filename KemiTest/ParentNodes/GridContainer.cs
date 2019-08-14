using Godot;
using System;
using System.Text;



public class GridContainer : Godot.GridContainer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    GlobalVariables variables;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(this.Columns.ToString());
        variables = new GlobalVariables();
        Theme t = new Theme();
        t.f
        foreach (var item in variables.Scores)
        {
            this.AddChild(new Label(){Text=item.Points.ToString()}.AddFontOverride("", ));
        }        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
