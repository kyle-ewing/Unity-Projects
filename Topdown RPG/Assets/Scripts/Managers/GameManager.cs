using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public static GameManager instance { get; private set; }
        
    [SerializeField]
    private bool dontDestroyOnLoad = true;

    [SerializeField] 
    private GameState startingState;

    public GameState GameState { get; private set; }
    public LevelManager LevelManager;
    public PlayerManager PlayerManager;
    public UIManager UIManager;
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            throw new System.Exception("An instance of this singleton already exists.");
        }
        else
        {
            instance = this;
        }
        
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(this);
        }

        GameState = Instantiate(startingState);
        LevelManager.gameState = GameState;
        PlayerManager.gameState = GameState;
        UIManager.gameState = GameState;

    }
    
    
    
    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
