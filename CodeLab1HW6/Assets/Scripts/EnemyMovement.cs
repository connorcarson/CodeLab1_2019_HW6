using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speedMultiplier;
    public float maxRayDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        //move enemy forward always
        transform.Translate(Vector3.forward * speedMultiplier * Time.deltaTime);
        
        //initialize ray shooting out from enemy
        Ray enemyRay = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(enemyRay.origin, enemyRay.direction * maxRayDistance, Color.green);

        if (Physics.Raycast(enemyRay, maxRayDistance))
        {
            int turnProbability = Random.Range(0, 100);
            if (turnProbability <= 50)
            {
                transform.Rotate(0f, 90f, 0f);
            }
            else
            {
                transform.Rotate(0f, -90f, 0f);
            }
        }
    }
}
