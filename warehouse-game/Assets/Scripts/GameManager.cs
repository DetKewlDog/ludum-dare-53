using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject boxPrefab;
    public GameObject pipeBombPrefab;
    public Vector2[] boxPositions;
    public int score = 0;
    Vector2 pos;
    public UnityEngine.UI.Text scoreText;

    private void Awake() {
        instance = this;
        InvokeRepeating("SpawnObject", 0, 0.1f);
    }

    private void SpawnObject() {
        if (Random.value >= 0.05f) return;
        Instantiate(Random.value >= 0.1f ? boxPrefab : pipeBombPrefab, boxPositions[Random.Range(0, 3)], Quaternion.identity);
    }

    public void BoxDestroyed() => UpdateScore(--score);
    public void BoxDelivered() => UpdateScore(++score);
    void UpdateScore(int score) {
        score = Mathf.Max(0, score);
        scoreText.text = $"Score: {score}";
    }
}
