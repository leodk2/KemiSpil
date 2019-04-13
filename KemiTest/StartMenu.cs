using Godot;

public class StartMenu : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    Button startButton;
    Button closeButton;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        startButton = GetNode<Button>("StartKnap");
        closeButton = GetNode<Button>("AfslutSpilKnap");
    }

    //  Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (startButton.Pressed)
        {
            GetTree().ChangeScene("res://ParentNodes/StartMenu.tres");
        }
        else if (closeButton.IsPressed())
        {
            GetTree().Quit();
        }
    }
}