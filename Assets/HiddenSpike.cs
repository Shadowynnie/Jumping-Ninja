using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpike : MonoBehaviour
{
    public int spikeDamage = 1000;
    public Transform hiddenPosition; // The initial hidden position
    public Transform emergePosition; // The position where the spike emerges
    public float speed = 2f; // Speed of the spike movement
    private bool isEmerging = false;

    private Vector3 targetPosition;

    private void Start()
    {
        // Initially, set the spike to the hidden position
        transform.position = hiddenPosition.position;
        targetPosition = hiddenPosition.position;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(spikeDamage);
        }
        Debug.Log(hitInfo);
        //hitInfo.enabled = false;
    }

    private void Update()
    {
        // Move the spike towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (isEmerging && transform.position == emergePosition.position)
        {
            isEmerging = false;
        }
    }

    public void Emerge()
    {
        // Start emerging
        isEmerging = true;
        targetPosition = emergePosition.position;
    }
}
