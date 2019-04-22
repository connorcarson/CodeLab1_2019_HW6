using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        //spawn i number of enemies
        for (int i = 0; i < 10; i++)
        {
            EnemySpawn();
        }

        //mouse cursor invisible
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemySpawn()
    {
        GameObject newEnemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"));
        newEnemy.transform.position = new Vector3(Random.Range(-18f, 18f), 0.15f, Random.Range(-18f, 18f));
    }
}
