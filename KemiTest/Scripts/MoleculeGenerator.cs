using Godot;
using System;

public class MoleculeGenerator : Node
{
    //Names of the molecules
    private string[] lengthNames = { "meth{0}", "eth{0}", "prop{0}", "but{0}", "pent{0}", "hex{0}", "hept{0}", "oct{0}", "non{0}", "dec{0}" };

    private string[] suffixes = { "an", "en", "yl" };

    // height to draw molecule
    private int drawHeight = 200;

    // current horizontal position
    private int horizontalPosition = 0;

    // spacing between objects
    private int padding = 10;

    // length of lines
    private int lineLength = 40;

    // spacing between lines when there are 2 or 3
    private int multilineSpacing = 20;

    public string MoleculeName { get; private set; }

    // test input data
    private int firstBond = 3;

    private int CarbonCount = 5;

    private Label label;
    private LineEdit lineEdit;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Random r = new Random();
        firstBond = r.Next(1, 4);
        CarbonCount = r.Next(1, 11);

        label = GetNode<Label>("Label");
        lineEdit = GetNode<LineEdit>("TekstFelt");

        MoleculeName = string.Format(lengthNames[r.Next(0, lengthNames.Length + 1)], suffixes[r.Next(0, suffixes.Length + 1)]);

        label.Text = MoleculeName.Capitalize();

        for (int i = 0; i < CarbonCount; i++)
        {
            if (i == 0)
            {
                GenerateLabel("CH" + (firstBond == 3 ? "" : (4 - firstBond).ToString()));
                GenerateLine(firstBond);
                continue;
            }
            else if (i == CarbonCount - 1)
            {
                GenerateLabel("CH3");
                continue;
            }
            GenerateLabel("CH");
            GenerateLine();
        }
    }

    public void GenerateLabel(string Text)
    {
        horizontalPosition += padding;

        Label txt = new Label();
        txt.Text = Text;
        txt.SetPosition(new Vector2(horizontalPosition, drawHeight));
        AddChild(txt);

        horizontalPosition += padding + (Text.Length * 8);
    }

    public void GenerateLine(int lines = 1)
    {
        if (lines < 1 || lines > 3)
            return;

        Line2D line;

        if (lines == 2)
        {
            horizontalPosition += padding;

            line = new Line2D();
            line.SetPoints(new Vector2[] { new Vector2(horizontalPosition, drawHeight + multilineSpacing / 2), new Vector2(horizontalPosition + lineLength, drawHeight + multilineSpacing / 2) });
            AddChild(line);
            line = new Line2D();
            line.SetPoints(new Vector2[] { new Vector2(horizontalPosition, drawHeight - multilineSpacing / 2), new Vector2(horizontalPosition + lineLength, drawHeight - multilineSpacing / 2) });
            AddChild(line);

            horizontalPosition += lineLength + padding;
        }
        else
        {
            horizontalPosition += padding;

            line = new Line2D();
            line.SetPoints(new Vector2[] { new Vector2(horizontalPosition, drawHeight), new Vector2(horizontalPosition + lineLength, drawHeight) });
            AddChild(line);

            // generate 1
            if (lines == 3)
            {
                line = new Line2D();
                line.SetPoints(new Vector2[] { new Vector2(horizontalPosition, drawHeight + multilineSpacing), new Vector2(horizontalPosition + lineLength, drawHeight + multilineSpacing) });
                AddChild(line);
                line = new Line2D();
                line.SetPoints(new Vector2[] { new Vector2(horizontalPosition, drawHeight - multilineSpacing), new Vector2(horizontalPosition + lineLength, drawHeight - multilineSpacing) });
                AddChild(line);
            }

            horizontalPosition += lineLength + padding;
        }
    }

    //  Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
        if (Input.IsKeyPressed((int)KeyList.Space))
        {
            GetTree().ReloadCurrentScene();
        }
        if ((lineEdit.Text.ToLower() == MoleculeName.ToLower()) && Input.IsKeyPressed((int)KeyList.Enter))
        {
            label.Text = "Godt klaret";
        }
    }
}