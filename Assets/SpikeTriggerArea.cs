using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTriggerArea : MonoBehaviour
{
    public HiddenSpike hiddenSpike;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hiddenSpike.Emerge();
        }
    }
}

