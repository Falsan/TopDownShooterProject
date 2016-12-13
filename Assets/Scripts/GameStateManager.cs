using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

    public enum GameStates
    {
        mainMenu,
        prePlay,
        play,
        pause,
        endGame
    }

    //int previousState;
    [SerializeField]
    int gameState;
    [SerializeField]
    int stateToBe;

    //int stageCounter;

    public static GameStateManager m_instance;

    [SerializeField]
    GameObject mainMenuRef;

    [SerializeField]
    GameObject mainMenu;

    [SerializeField]
    GameObject levelManagerRef;

    [SerializeField]
    GameObject levelManager;

	// Use this for initialization
	void Start () {

        if (m_instance == null)
        {
            m_instance = this;
        }
        else if(m_instance != this)
        {
            Destroy(gameObject);
        }

        gameState = -245;//(int)GameStates.mainMenu;
        stateToBe = (int)GameStates.mainMenu;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(stateToBe != gameState)
        {
            //check the exit function of the game state

            if(gameState == (int)GameStates.prePlay)
            {
                OnExitPrePlay();
            }
            if(gameState == (int)GameStates.mainMenu)
            {
                OnExitMainMenu();
            }

            //check the enter function of the game state
            if(stateToBe == (int)GameStates.endGame)
            {
                Application.Quit();
            }
            if(stateToBe == (int)GameStates.mainMenu)
            {
                OnEnterMainMenu();
            }
            if(stateToBe == (int)GameStates.prePlay)
            {
                OnEnterPrePlay();
            }
            if(stateToBe == (int)GameStates.play)
            {
                
            }

            //change the state to be equal
            gameState = stateToBe;
        }
        else
        {
            UpdateState();
        }
	}

    void UpdateState()
    {
        if(gameState == (int)GameStates.prePlay)
        {
            if (LevelManager.m_instance == null)
            {
                levelManager = Instantiate(levelManagerRef);
                //stateToBe = (int)GameStates.play;
            }
            if(LevelManager.m_instance.stage == 0)
            {
                //make the level
                //set to play
            }
            //previousState = (int)GameStates.prePlay;
        }
    }

    public void ChangeState(GameStates stateToChangeTo)
    {
        stateToBe = (int)stateToChangeTo;
    }

    public void NextStage(int stageToBe)
    {
        LevelManager.m_instance.stage = stageToBe;
        stateToBe = (int)GameStates.prePlay;
    }

    void OnEnterMainMenu()
    {
        mainMenu = Instantiate(mainMenuRef);
    }

    void OnExitMainMenu()
    {

    }

    void OnEnterPrePlay()
    {

    }

    void OnExitPrePlay()
    {
        //previousState = -100;
    }


}
