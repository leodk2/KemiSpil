using Godot;

public class SelectGame : Control
{
   
    public static int Selection { get; set; }
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
            
            Selection = 0;
            GetTree().ChangeScene(Paths.gameScene);
        }
        else if (timeTrial.IsPressed())
        {
            Selection = 1;
            GetTree().ChangeScene(Paths.gameScene);
        }

    }
}