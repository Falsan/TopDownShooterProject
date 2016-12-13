using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

    public enum GameStates
    {
        prePlay,
        play,
        pause,
    }

    //int previousState;
    [SerializeField]
    int gameState;
    [SerializeField]
    int stateToBe;

    public static GameStateManager m_instance;

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
        
        gameState = (int)GameStates.prePlay;
        stateToBe = (int)GameStates.prePlay;
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

            //check the enter function of the game state

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
            levelManager = Instantiate(levelManagerRef);
            stateToBe = (int)GameStates.play;
            //previousState = (int)GameStates.prePlay;
        }
    }

    public void ChangeState(GameStates stateToChangeTo)
    {
        stateToBe = (int)stateToChangeTo;
    }

    void OnEnterPrePlay()
    {

    }

    void OnExitPrePlay()
    {
        //previousState = -100;
    }


}
