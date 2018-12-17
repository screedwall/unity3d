using Assets.SeaBattle.Scripts;
using Assets.SeaBattle.Scripts.Utils;
using Assets.SeaBattle.Scripts.Utils.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public PlayerController FirstPlayer;
    public PlayerController SecondPlayer;
    public GameState GameState;

    private PlayerController CurrentPlayer;

	// Use this for initialization
	void Start () {
        GameState = GameState.PauseState;

        Messenger.Subscribe<ClickMessage>(OnGridClick);
	}

    private void OnGridClick(ClickMessage message)
    {

    }
}

public enum GameState
{
    PauseState,
    GameState
}