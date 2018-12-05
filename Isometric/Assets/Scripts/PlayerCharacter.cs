using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    public float Playerspeed;
    private Vector3 targetPosition;
    private bool isMoving;
    const int LEFT_MOUSE_BUTTON = 0;
    const int RIGHT_MOUSE_BUTTON = 1;

    public GameObject Player; 
    

    // Use this for initialization
    void Start () {

        targetPosition = transform.position;
        isMoving = false;
        Player = GameObject.FindWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(LEFT_MOUSE_BUTTON))
        {
            SetTargetPosition();
        }

        if (isMoving)
        {
            MovePlayer();
        }

        if (Input.GetMouseButtonUp(LEFT_MOUSE_BUTTON))
        {
            isMoving = false;
        }
    }

    private void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);

        isMoving = true;
    }

    private void MovePlayer()
    {
        Player.transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Playerspeed * Time.deltaTime);
        if (Player.transform.position == targetPosition)
            isMoving = false;
    }
}
