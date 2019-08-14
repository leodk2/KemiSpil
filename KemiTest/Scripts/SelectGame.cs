using Godot;

public class SelectGame : Control {

    public static GameType Selection { get; set; }
    Button singleLife;
    Button timeTrial;

    Button backButton;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready () {
        singleLife = GetNode<Button> ("SuddenDeath");
        timeTrial = GetNode<Button> ("TimeTrial");
        backButton = GetNode<Button> ("Back");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process (float delta) {

        if (singleLife.IsPressed ()) {

            Selection = GameType.SingleLife;
            GetTree ().ChangeScene (Paths.gameScene);
        } else if (timeTrial.IsPressed ()) {
            Selection = GameType.TimeTrail;
            GetTree ().ChangeScene (Paths.gameScene);
        } else if (backButton.IsPressed ()) {
            GetTree ().ChangeScene (Paths.startMenu);
        }

    }
}