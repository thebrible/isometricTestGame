using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour {

    public float EnemySpeed;
    private Vector3 targetPosition;
    private Vector3 PlayerPosistion;
    private bool inRange;

    public GameObject Enemy;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        targetPosition = transform.position;
        inRange = false;
        Enemy = GameObject.FindWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Math.Abs(Vector3.Distance(transform.position, Player.transform.position));
        if(distance < 10)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
        SetTargetPosition();

        if(inRange)
        {
            MoveEnemy();
        }
        
		
	}

    private void SetTargetPosition()
    {
        if (inRange)
        {
            targetPosition = Player.transform.position;
        }
        else
        {
            targetPosition = transform.position;
        }
        

    }
    private void MoveEnemy()
    {
        Enemy.transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, EnemySpeed * Time.deltaTime);
    }
}
