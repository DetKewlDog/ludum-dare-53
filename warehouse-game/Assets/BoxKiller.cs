using UnityEngine;

public class BoxKiller : MonoBehaviour
{
    private GameManager gameManager;
    void Start() {
        gameManager = GameManager.instance;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Box")) return;
        gameManager.BoxDestroyed();
        Destroy(other.gameObject);
    }
}
