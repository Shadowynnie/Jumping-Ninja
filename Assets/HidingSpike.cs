using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpike : MonoBehaviour
{
    public int spikeDamage = 1000;
    public Transform hiddenPosition; // The initial hidden position
    public Transform emergePosition; // The position where the spike emerges
    public float speed = 2f; // Speed of the spike movement
    public float waitTime = 2f; // Time to wait before changing states

    private Vector3 targetPosition;
    //private bool isEmerging = false;

    private void Start()
    {
        // Initially, set the spike to the hidden position
        transform.position = hiddenPosition.position;
        targetPosition = hiddenPosition.position;

        // Start the cycle of emerging and hiding
        StartCoroutine(EmergeHideCycle());
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
    }

    private IEnumerator EmergeHideCycle()
    {
        while (true)
        {
            // Emerge
            targetPosition = emergePosition.position;
            yield return new WaitUntil(() => transform.position == emergePosition.position);
            yield return new WaitForSeconds(waitTime);

            // Hide
            targetPosition = hiddenPosition.position;
            yield return new WaitUntil(() => transform.position == hiddenPosition.position);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
