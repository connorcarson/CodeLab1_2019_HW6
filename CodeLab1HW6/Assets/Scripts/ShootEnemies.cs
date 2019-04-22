using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour
{
    private Ray _myRay;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        //initialize ray from enemy
        _myRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //Debug.DrawRay(_myRay.origin, _myRay.direction * 1000f, Color.red);
        
        //initialize raycaseHit
        RaycastHit _myRaycastHit = new RaycastHit();
        
        //if left click
        if (Input.GetMouseButtonDown(0))
        {    
            //and ray is hitting something
            if (Physics.Raycast(_myRay, out _myRaycastHit, 1000f))
            {
                //and that something is an enemy
                if (_myRaycastHit.transform.gameObject == gameObject)
                {
                    //destroy the enemy
                    Destroy(_myRaycastHit.transform.gameObject);
                    //Debug.Log("Hit!");
                }
                //but if it's not an enemy
                else
                {
                    //Debug.Log("Miss!");
                }
            }
        }
    }
}
