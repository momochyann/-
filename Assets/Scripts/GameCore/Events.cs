using System.Collections.Generic;
using UnityEngine;
using static Types;

public enum GameState
{
    Start,
    play,
    end
}
// The Game Events used across the Game.
// Anytime there is a need for a new event, it should be added here.

public static class Events
{
    public static HandleResultEvent HandleResultEvent = new HandleResultEvent();
    public static SceneEvent SceneEvent = new SceneEvent();
    public static GameStateChangeEvent GameStateChangeEvent = new GameStateChangeEvent();
    public static InputEvent InputEvent = new InputEvent();
    public static SeriportReciveEvent SeriportReciveEvent = new SeriportReciveEvent();
    public static RedArmyStateEvent redArmyStateEvent = new RedArmyStateEvent();

}

public class HandleResultEvent : GameEvent 
{

}
public class RedArmyStateEvent : GameEvent
{
    public RedArmyState redArmyState;
}

public class SceneEvent : GameEvent
{
    public int index;
}
public class SeriportReciveEvent : GameEvent
{
    public byte[] data;
}
public class GameStateChangeEvent : GameEvent
{
    public GameState gameState;
}
public class InputEvent : GameEvent
{
    public string inputKey;
}
public class ArivePointEvent : GameEvent 
{
    public int actionIndex;
}