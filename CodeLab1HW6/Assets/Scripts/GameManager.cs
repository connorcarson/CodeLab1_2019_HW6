using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverUI;
    
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

    void EnemySpawn()
    {
        GameObject newEnemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"));
        newEnemy.transform.position = new Vector3(Random.Range(-18f, 18f), 0.15f, Random.Range(-18f, 18f));
    }

    public void GameOver()
    {
        //GameOver UI is visible
        GameOverUI.SetActive(true);
        //cursor is visible
        Cursor.visible = true;
        //freeze game time
        Time.timeScale = 0;
    }

    public void StartOver()
    {
        //GameOver UI is invisible
        GameOverUI.SetActive(false);
        //cursor is invisible
        Cursor.visible = false;
        //unfreeze game time
        Time.timeScale = 1;
        //Reload scene
        SceneManager.LoadScene(0);
    }
}
