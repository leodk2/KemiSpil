using Godot;

public class TekstFelt : LineEdit
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        /*Secret = true;
        SecretCharacter = " ";*/
        GD.Print(GetName());
        GD.Print(InputMap.GetActions());
    }

    private float time = 0;

    public override void _Process(float delta)
    {
        if (Input.IsKeyPressed((int)KeyList.Escape))
        {
            this.Dispose();

            if (Input.IsActionPressed("ui_change_text_one"))
            {
                this.Text += "hej";
            }

            if (Input.IsActionPressed("ui_change_text_two"))
            {
                this.Text += "OwO";
            }
        }
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //
    //  }

    
}