using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKiller : MonoBehaviour
{
    [SerializeField] float delayTime = 5f;

    void Start()
    {
        Invoke(nameof(DestroyObject), delayTime);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
