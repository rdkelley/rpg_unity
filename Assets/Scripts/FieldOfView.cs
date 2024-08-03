using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public GameObject Player; 
    
    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerDirection = transform.position - Player.transform.position;

        if (Mathf.Abs(Vector3.Angle(transform.forward, PlayerDirection)) < 45)
        {
            Debug.Log("Player Detected"); 
        }
    }
}
