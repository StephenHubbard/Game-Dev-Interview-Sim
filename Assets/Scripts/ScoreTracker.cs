using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class ScoreTracker : MonoBehaviour
{
    GameSession gameSession;
    Vector3 oldPos;
    float totalDistance = 0;

    void Start()
    {
        oldPos = transform.position;
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0)
        {
            Vector3 distanceVector = transform.position - oldPos;
            float distanceThisFrame = distanceVector.magnitude;
            totalDistance += distanceThisFrame;
            oldPos = transform.position;
            gameSession.gameScore = totalDistance * 10;
        }
    }
}
