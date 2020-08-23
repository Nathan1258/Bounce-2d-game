using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_1 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}