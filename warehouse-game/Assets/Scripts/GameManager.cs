using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject boxPrefab;
    public Vector2[] boxPositions;
    public int score = 0;

    private void Awake() {
        instance = this;
        InvokeRepeating("SpawnBox", 0, 0.1f);
    }

    private void SpawnBox() {
        if (Random.value >= 0.05f) return;
        Instantiate(boxPrefab, boxPositions[Random.Range(0, 3)], Quaternion.identity);
    }

    public void BoxDestroyed() {
        score--;
        print(score);
    }
    public void BoxDelivered() {
        score += 10;
        print(score);
    }
}
