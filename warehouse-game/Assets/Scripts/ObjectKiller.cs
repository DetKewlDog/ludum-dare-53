using UnityEngine;

public class ObjectKiller : MonoBehaviour
{
    public enum KillerType { Score, Kill, Mailbox }
    public KillerType killerType;
    public Box.BoxColor boxColor;

    private GameManager gameManager;
    void Start() {
        gameManager = GameManager.instance;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PipeBomb")) {
            if (killerType == KillerType.Mailbox) gameManager.BoxDelivered();
            else other.GetComponent<PipeBomb>().Explode();
            Destroy(other.gameObject);
            return;
        }

        if (!other.CompareTag("Box")) return;
        var box = other.GetComponent<Box>();
        if (killerType == KillerType.Kill || box.boxColor != boxColor) {
            if (killerType == KillerType.Kill) box.canPlaySFX = true;
            gameManager.BoxDestroyed();
        }
        else gameManager.BoxDelivered();
        if (killerType != KillerType.Mailbox) Destroy(other.gameObject);
    }
}
