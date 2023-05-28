using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Prepare,
    Fight
}

public class GameStateController : MonoBehaviour
{
    public static GameStateController inst;
    public GameState State;

    [SerializeField]
    private Button startButton;

    public event Action OnGameStarted;
    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartFight);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartFight);
    }

    public void StartFight()
    {
        State = GameState.Fight;
        OnGameStarted?.Invoke();
    }
}
