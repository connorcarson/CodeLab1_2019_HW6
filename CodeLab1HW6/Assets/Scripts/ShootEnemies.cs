using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour
{
    private Ray _myRay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        _myRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //Debug.DrawRay(_myRay.origin, _myRay.direction * 1000f, Color.red);
        
        RaycastHit _myRaycastHit = new RaycastHit();
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_myRay, out _myRaycastHit, 1000f))
            {
                if (_myRaycastHit.transform.gameObject == gameObject)
                {
                    Destroy(_myRaycastHit.transform.gameObject);
                    Debug.Log("Hit!");
                }
                else
                {
                    Debug.Log("Miss!");
                }
            }
        }
    }
}
