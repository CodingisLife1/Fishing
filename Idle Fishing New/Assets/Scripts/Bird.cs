using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        StartCoroutine(LifeTime());
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, 2.5f * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        Init.Instance.boosts.BirdRandomBoost();
        Destroy(gameObject);
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(9);

        Destroy(gameObject);
    }
}
