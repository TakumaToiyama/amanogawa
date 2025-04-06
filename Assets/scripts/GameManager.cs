using UnityEngine;

    public enum GameState{
        titleScreen, // UI, title, startButton, log, howToPlay
        waitingStart, // waiting start
        play, // game play follow to boat object
        gameOver // game over

    }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Awake()
    {
        Instance = this;
    }

    public GameState currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(currentState);
        switch (currentState) {
            case GameState.titleScreen:
                break;
            case GameState.waitingStart:
                break;
            case GameState.play:
                break;
            case GameState.gameOver:
                break;
        }
    }
}
