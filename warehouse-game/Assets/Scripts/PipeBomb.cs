using UnityEngine;

public class PipeBomb : DraggableObject
{
    protected override void Start() {
        base.Start();
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "StartScreen") Destroy(GetComponent<AudioSource>());
    }

    public void Explode() {
        canPlaySFX = true;
        GameManager.instance.Invoke("GameOver", 2);
    }
}
