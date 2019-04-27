using Godot;

public class StartMenu : Control
{
    Button startButton;
    Button closeButton;
    Button scoreButton;
 
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        startButton = GetNode<Button>("StartKnap");
        closeButton = GetNode<Button>("AfslutSpilKnap");
        scoreButton = GetNode<Button>("OpenScoreboard");

        
        if (!System.IO.File.Exists(GenerateXml.FilePath))
        {
            GenerateXml.GenerateFile();
        }
    }

    //  Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (startButton.Pressed)
        {
            //selectgame scene
            GetTree().ChangeScene(Paths.selectGame);
        }
        else if (closeButton.IsPressed())
        {
            GetTree().Quit();
        }
        else if (scoreButton.Pressed)
        {
            //Scoreboard scene
            GetTree().ChangeScene(Paths.scoreBoard);
        }
    }
}