using Godot;
using System;
using System.Collections.Generic;


public class MoleculeGenerator : Node
{
    string[] lengthNames = {"meth{0}", "eth{0}", "prop{0}", "but{0}", "pent{0}", "hex{0}", "hept{0}", "oct{0}", "non{0}", "dec{0}"};
    // height to draw molecule
    int drawHeight = 200;
    // current horizontal position
    int horizontalPosition = 0;
    // spacing between objects
    int padding = 10;
    // length of lines
    int lineLength = 40;
    // spacing between lines when there are 2 or 3
    int multilineSpacing = 20;

    

    // test input data
    int firstBond = 3;
    int CarbonCount = 5;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Random r = new Random();
        firstBond = r.Next(1,4);
        CarbonCount = r.Next(1,11);
        
        for (int i = 0; i < CarbonCount; i++)
        {
            if (i == 0)
            {
                GenerateLabel("CH" + (firstBond == 3 ? "" : (4-firstBond).ToString()));
                GenerateLine(firstBond);
                continue;
            }
            GenerateLabel("CH");
            GenerateLine();
        }
        
        /*
        Random r = new Random();
        for (int i = 0; i < 8; i++)
        {
            GenerateLines(r.Next(1,4));
            GenerateLabel("CH3");
        }
        */
    }

    public void GenerateLabel(string Text)
    {
        horizontalPosition += padding;

        Label txt = new Label();
        txt.Text = Text;
        txt.SetPosition(new Vector2(horizontalPosition, drawHeight));
        AddChild(txt);

        horizontalPosition += padding + (Text.Length*8);

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
            line.SetPoints(new Vector2[] {new Vector2(horizontalPosition, drawHeight + multilineSpacing / 2), new Vector2(horizontalPosition + lineLength, drawHeight + multilineSpacing / 2)});
            AddChild(line);
            line = new Line2D();
            line.SetPoints(new Vector2[] {new Vector2(horizontalPosition, drawHeight - multilineSpacing / 2), new Vector2(horizontalPosition + lineLength, drawHeight - multilineSpacing / 2)});
            AddChild(line);

            horizontalPosition += lineLength + padding;
        }
        else
        {
            horizontalPosition += padding;

            line = new Line2D();
            line.SetPoints(new Vector2[] {new Vector2(horizontalPosition, drawHeight), new Vector2(horizontalPosition + lineLength, drawHeight)});
            AddChild(line);

            // generate 1
            if (lines == 3)
            {
                line = new Line2D();
                line.SetPoints(new Vector2[] {new Vector2(horizontalPosition, drawHeight + multilineSpacing), new Vector2(horizontalPosition + lineLength, drawHeight + multilineSpacing)});
                AddChild(line);
                line = new Line2D();
                line.SetPoints(new Vector2[] {new Vector2(horizontalPosition, drawHeight - multilineSpacing), new Vector2(horizontalPosition + lineLength, drawHeight - multilineSpacing)});
                AddChild(line);
            }

            horizontalPosition += lineLength + padding;
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (Input.IsKeyPressed((int)KeyList.Enter))
            GetTree().ReloadCurrentScene();
    }
}
