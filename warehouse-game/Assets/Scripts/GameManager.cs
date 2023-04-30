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
    public GameObject GameOverScreen;
    public GameObject[] disableOnGameover;

    private void Awake() {
        instance = this;
        InvokeRepeating("SpawnObject", 0, 0.1f);
    }

    private void SpawnObject() {
        if (Random.value >= 0.05f + Time.timeSinceLevelLoad / 1000) return;
        Instantiate(Random.value >= 0.2f ? boxPrefab : pipeBombPrefab, boxPositions[Random.Range(0, 3)], Quaternion.identity);
    }

    public void BoxDestroyed() => UpdateScore(--score);
    public void BoxDelivered() => UpdateScore(++score);
    void UpdateScore(int score) {
        if (scoreText == null) return;
        score = this.score = Mathf.Max(0, score);
        scoreText.text = $"Score: {score}";
    }

    public void GameOver() {
        if (GameOverScreen == null) return;
        foreach (var go in disableOnGameover) go.SetActive(false);
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
