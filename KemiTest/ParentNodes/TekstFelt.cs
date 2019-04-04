using Godot;
using System;
using System.Windows.Input;
using System.Windows;

public class TekstFelt : LineEdit
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public static void Print(string str)
    {
      Console.Write(str);
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        /*Secret = true;
        SecretCharacter = " ";*/
        Print(GetName());
    }

    float time = 0;
    public override void _Process(float delta)
    {
      if (Keyboard.IsKeyToggled(Key.Escape))
      {
          this.Dispose();

      }
      time += delta;
      if (time>=4)
      {
        time -= 4;
        Text="UwU";
      }
      else
      {
        Text="OwO";
      }
      
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
