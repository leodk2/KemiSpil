using Godot;

public class SelectGame : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public int selection;
    Button singleLife;
    Button timeTrial;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        singleLife = GetNode<Button>("SuddenDeath");
        timeTrial = GetNode<Button>("TimeTrial");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

        if (singleLife.IsPressed())
        {

        }
        else if (timeTrial.IsPressed())
        {

        }

    }
}