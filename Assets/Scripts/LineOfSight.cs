using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public GameObject Player;
    private bool playerDetected = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerDirection = Player.transform.position - transform.position;

        // Debug log for angle calculation
        float angle = Vector3.Angle(transform.forward, PlayerDirection);
        Debug.Log($"Angle to player: {angle}");

        if (Mathf.Abs(angle) < 45)
        {
            Debug.Log("Player Detected");
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }

    // This method will now return the correct detection state
    public bool Detected()
    {
        return playerDetected;
    }
}
