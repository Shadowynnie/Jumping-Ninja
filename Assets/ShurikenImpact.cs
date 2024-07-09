using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{

    void Start()
    {
        Invoke("EndEffect", 0.5f);
    }

    void EndEffect()
    {
        Destroy(gameObject);
    }
}
