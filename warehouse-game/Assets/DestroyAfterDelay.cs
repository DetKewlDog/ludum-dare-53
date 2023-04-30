using System.Collections;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    void Start() => StartCoroutine(Co());

    IEnumerator Co() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
