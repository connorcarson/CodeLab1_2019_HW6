using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speedMultiplier;
    public float maxRayDistance;

    private Collider _player;
    
    // Start is called before the first frame update
    void Start()
    {
        //initialize player collider
        _player = Camera.main.GetComponent<Collider>();
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

        //if enemyRay hits something
        if (Physics.Raycast(enemyRay, maxRayDistance))
        {
            int turnProbability = Random.Range(0, 100);
            
            if (turnProbability <= 50)
            {
                //turn right half the time
                transform.Rotate(0f, 90f, 0f);
            }
            else
            {
                //turn left half the time
                transform.Rotate(0f, -90f, 0f);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == _player)
        {
            print("You got hurt!");
        }
    }
}
