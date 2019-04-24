using Godot;
using System;

public class CarbonChainParent : MoleculeGenerator
{
    
 

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
    public override void _Process(float delta)
    {
        if (base.spacePressed)
        {
            for (int i = 0; i < this.GetChildCount(); i++)
            {
                this.GetChild(i).Free();
            }
        }
    }
}
