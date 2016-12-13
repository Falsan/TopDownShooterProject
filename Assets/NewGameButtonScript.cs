using UnityEngine;
using System.Collections;

public class NewGameButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void NewGame()
    {
        GameStateManager.m_instance.ChangeState(GameStateManager.GameStates.prePlay);
    }
}
