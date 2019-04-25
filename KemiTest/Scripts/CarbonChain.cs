using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public struct CarbonChain
{
    // other stuff
    private static readonly string[] lengthNames = { "meth{0}", "eth{0}", "prop{0}", "but{0}", "pent{0}", "hex{0}", "hept{0}", "oct{0}", "non{0}", "dec{0}" };
    private static readonly string[] extraNames = { "mono", "di", "tri", "tetra" };
    private static readonly string[] suffixes = { "an", "en", "yl" };


    // fields
    public string Name { get; }
    public int Length { get; }
    public int FirstBond { get; }
    public List<CarbonChain> SubChains { get; }
    public int PositionIndex { get; }

    private static string GenerateName(int length, int firstBond, List<CarbonChain> subChains = null)
    {
        // temp. variable to be modified. Generates name of the "base" chain (this chain)
        string generatedName = String.Format(lengthNames[length - 1], suffixes[firstBond - 1]);
        string namePrefix = "";
        if (subChains != null)
        {
            // groups subchains by names and put them in seperate lists
            List<List<CarbonChain>> sortedSubChains = subChains.GroupBy(x => x.Name).Select(x => x.ToList()).ToList();

            // loop list of lists
            foreach (List<CarbonChain> chainGroup in sortedSubChains)
            {
                // stores where in the original chain these subchains are placed.
                List<int> indexes = new List<int>();
                // loops list of chains and add the original placement index of this chain to indexes
                foreach (CarbonChain chain in chainGroup)
                {
                    if (chain.PositionIndex != 0)
                        indexes.Add(chain.PositionIndex);
                    //indexes.Add(subChains.IndexOf(chain));
                }
                // adds and formats indexes and names.
                namePrefix += String.Join(",", indexes) + "-" + extraNames[chainGroup.Count - 1] + chainGroup[0].Name + "-";
                //generatedName = generatedName.Insert(0, String.Join(",", indexes) + "-" + extraNames[chainGroup.Count - 1] + chainGroup[0].Name + "-");
                indexes.Clear();

            }
            return namePrefix.Substring(0, namePrefix.Length - 1) + generatedName;
        }
        return generatedName;
    }

    public CarbonChain(int length, int firstBond, List<CarbonChain> subChains)
    {
        // assign name
        Name = GenerateName(length, firstBond, subChains);

        // assign rest.
        Length = length;
        FirstBond = firstBond;
        SubChains = subChains;
        PositionIndex = 0;

    }

    public CarbonChain(int length, int firstBond, int positionIndex)
    {
        Name = GenerateName(length, firstBond);
        Length = length;
        FirstBond = firstBond;
        PositionIndex = positionIndex;
        SubChains = null;
    }
}
