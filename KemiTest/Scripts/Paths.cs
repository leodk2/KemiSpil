using System.Collections.Generic;

/// <summary>
/// This is where we store all the scenes
/// </summary>
public class Paths
{
    public static string startMenu = "res://ParentNodes/StartMenu.tscn";
    public static string scoreBoard = "res://ParentNodes/Scoreboard.tscn";
    public static string selectGame = "res://ParentNodes/SelectGame.tscn";
    public static string gameScene = "res://ParentNodes/GameScene.tscn";
    public static string endScreen = "res://ParentNodes/EndScreen.tscn";
}

/// <summary>
/// Things that we use between scenes
/// </summary>
public class GlobalVariables
{
    public static float time = 120;
    public int Score { get; set; }
    private static List<int> streakList;

    public static List<int> StreakList
    {
        get
        {
            StreakList.Sort();
            StreakList.Reverse();
            return StreakList;
        }
        set
        {
            GenerateXml.Read();
            value.Sort();
            value.Reverse();
            streakList = value;
        }
    }

    public int NewStreak { get; set; }
}