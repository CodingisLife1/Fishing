using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fish : MonoBehaviour
{
    public FishData data;

    void Start()
    {
        StartCoroutine(LifeTime());
    }


    IEnumerator LifeTime()
    {
        transform.DOMoveY(transform.position.y + 0.5f, 1);

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }
}
