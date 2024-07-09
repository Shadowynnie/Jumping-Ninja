using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float waitTime = 5f;
    public Transform towerRopeEnd;
    public Transform elevatorRopeEnd;
    public ElevatorTower elevatorTower;

    private Vector3 nextPoint;

    void Start()
    {
        nextPoint = pointA.position;
        StartCoroutine(MoveElevator());
    }

    IEnumerator MoveElevator()
    {
        while (true)
        {
            // Move towards the next point
            while (Vector3.Distance(transform.position, nextPoint) > 0.1f)
            {
                elevatorTower.StartWheelAnimation(); // Start wheel animation
                transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
                UpdateRope();
                yield return null;
            }

            // Stop the wheel animation and wait at the point
            elevatorTower.StopWheelAnimation();
            yield return new WaitForSeconds(waitTime);

            // Set the next point
            nextPoint = nextPoint == pointA.position ? pointB.position : pointA.position;
        }
    }

    void UpdateRope()
    {
        elevatorTower.UpdateRope(elevatorRopeEnd.position);
    }
}
