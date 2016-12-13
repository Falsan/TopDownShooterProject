using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public static LevelManager m_instance;

    public int stage;

    [SerializeField]
    GameObject testLevelReference;
    [SerializeField]
    GameObject playerReference;

    [SerializeField]
    GameObject testEnemyRef;

    [SerializeField]
    List<GameObject> enemyPool;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject loadedLevel;

	// Use this for initialization
	void Start () {

        if (m_instance == null)
        {
            m_instance = this;
        }
        else if (m_instance != this)
        {
            Destroy(gameObject);
        }

        createTestEnvironment();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void createTestEnvironment()
    {
        loadedLevel = testLevelReference;
        Instantiate(loadedLevel);

        player = playerReference;
        Instantiate(player);
        Vector3 playerPosition = new Vector3(0.0f, 0.0f, 0.0f);
        player.transform.position = playerPosition;
        Vector3 spawnPos = new Vector3(-1.984097f, -0.01800001f, 0.0f);
        enemyPool.Add(Instantiate(testEnemyRef));

        enemyPool[0].transform.position = spawnPos;

        
    }
}
