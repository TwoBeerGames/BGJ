using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;
    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameStateManager();
            
            return _instance;
        }
    }

    public GameState CurrentGameState { get; private set; }
    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChanged;

    private GameStateManager() {}

    public void SetState(GameState newGameState)
    {
        if (newGameState == CurrentGameState)
            return;
        
        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }
}

//// Source: https://www.youtube.com/watch?v=KPaEnLpu57s
//// In Scripts to Pause add:

// void Awake() 
// {
//     GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
// }

// void OnDestroy() {
//     GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
// }

// private void OnGameStateChanged(GameState newGameState)
// {
//     enabled = newGameState == GameState.Gameplay;
// }
