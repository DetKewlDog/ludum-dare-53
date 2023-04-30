using UnityEngine;

public class PipeBomb : DraggableObject
{
    public void Explode() {
        canPlaySFX = true;
        GameManager.instance.Invoke("GameOver", 2);
    }
}
