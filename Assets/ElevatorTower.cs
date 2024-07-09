using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTower : MonoBehaviour
{
    public Animator wheelAnimator;
    public Transform towerRopeEnd;
    public LineRenderer ropeRenderer;

    public void StartWheelAnimation()
    {
        wheelAnimator.SetBool("IsMoving", true);
    }

    public void StopWheelAnimation()
    {
        wheelAnimator.SetBool("IsMoving", false);
    }

    public void UpdateRope(Vector3 elevatorRopeEndPosition)
    {
        ropeRenderer.SetPosition(0, towerRopeEnd.position);
        ropeRenderer.SetPosition(1, elevatorRopeEndPosition);
    }
}
