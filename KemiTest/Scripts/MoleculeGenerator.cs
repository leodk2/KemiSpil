using Godot;
using System;
using System.Collections.Generic;

public class MoleculeGenerator : Node
{
    #region GlobalVariables

    /// <summary>
    /// This is a temporary way to set the score
    /// </summary>
    public int Score { get { return Score; } private set { Streak *= 10; } }

    /// <summary>
    /// This is just the number of correct answers in a row
    /// </summary>
    public int Streak { get; set; }

    private int time = 120;

    //Names of the molecules
    private string[] formats = { "meth{0}", "eth{0}", "prop{0}", "but{0}", "pent{0}", "hex{0}", "hept{0}", "oct{0}", "non{0}", "dec{0}" };

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

    private Label nameLabel;
    private LineEdit lineEdit;
    private Timer Timer;
    private Label TimerLabel;
    private Node2D CarbonChainRoot;

    #endregion GlobalVariables

    #region GenerateMolecule

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

    /// <summary>
    /// Generates the carbon chains and names
    /// </summary>
    public void GenerateCarbonChains()
    {
        CarbonChain c1 = new CarbonChain(1, 1, 2);
        CarbonChain c2 = new CarbonChain(1, 1, 4);
        CarbonChain c = new CarbonChain(6, 2, new List<CarbonChain>() { c1, c2 });
        GD.Print(c.Name);

        CarbonChain p1 = new CarbonChain(1, 1, 2);
        CarbonChain p2 = new CarbonChain(2, 1, 3);
        CarbonChain p = new CarbonChain(5, 3, new List<CarbonChain>() { p1, p2 });
        GD.Print(p.Name);

        Random r = new Random();
        firstBond = r.Next(1, 4);
        CarbonCount = r.Next(1, 11);

        MoleculeName = GenerateName(firstBond, CarbonCount);
        nameLabel.Text = MoleculeName.Capitalize();

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

    /// <summary>
    /// Generates the name of the molecule
    /// </summary>
    /// <param name="firstbond"> the bonds in the first link</param>
    /// <param name="carbonCount">the number of carbon atoms in the molecule</param>
    /// <returns>the name of the molecule</returns>
    private string GenerateName(int firstbond, int carbonCount) => string.Format(formats[carbonCount - 1], suffixes[firstbond - 1]);

    private void ClearCarbonParent()
    {
        for (int i = 0; i < CarbonChainRoot.GetChildCount(); i++)
        {
            CarbonChainRoot.GetChild(i).Free();
            CarbonChainRoot.RemoveChild(CarbonChainRoot.GetChild(i));
        }
    }

    #endregion GenerateMolecule

    #region GodotNative

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        nameLabel = GetNode<Label>("NameLabel");
        Timer = GetNode<Timer>("Timer");
        TimerLabel = GetNode<Label>("TimerLabel");
        lineEdit = GetNode<LineEdit>("TekstFelt");
        CarbonChainRoot = GetNode<Node2D>("CarbonChainParent");
        GD.Print(nameLabel.Text);

        switch (SelectGame.Selection)
        {
            case 0:
                TimerLabel.Hide();
                break;

            case 1:
                Timer.SetWaitTime(time);

                Timer.Start();
                break;
        }

        lineEdit.GrabFocus();
        lineEdit.Text = "";

        GenerateCarbonChains();
    }

    private bool answered = false;

    //  Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        TimerLabel.Text = Timer.WaitTime.ToString();
        if ((lineEdit.Text.ToLower() == MoleculeName) && Input.IsKeyPressed((int)KeyList.Enter) && !answered)
        {
            nameLabel.Text = "Godt klaret";
            answered = true;
            Streak++;
        }
        else if ((lineEdit.Text.ToLower() != MoleculeName) && Input.IsKeyPressed((int)KeyList.Enter) && !answered)
        {
            nameLabel.Text = "Bedre held naeste gang";
            answered = true;
            Streak = 0;
        }

        //reloads the scene
        if (Input.IsActionJustPressed("ui_select") && answered)
        {
            ClearCarbonParent();
            GenerateCarbonChains();
            lineEdit.Text = "";
            time += 30;
            answered = false;
        }

        //quits the game
        if (Input.IsKeyPressed((int)KeyList.Escape))
        {
            GetTree().Quit();
        }
    }

    #endregion GodotNative
}