using UnityEngine;

public class BoxKiller : MonoBehaviour
{
    public enum Aftermath { Score, Kill }
    public Aftermath aftermath;
    public Box.BoxColor boxColor;

    private GameManager gameManager;
    void Start() {
        gameManager = GameManager.instance;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Box")) return;
        if (aftermath == Aftermath.Kill) gameManager.BoxDestroyed();
        else if (other.TryGetComponent<Box>(out var box)) {
            if (box.boxColor != boxColor) gameManager.BoxDestroyed();
            else gameManager.BoxDelivered();
        }
        Destroy(other.gameObject);
    }
}
