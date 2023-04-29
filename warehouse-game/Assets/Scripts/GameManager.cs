using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boxPrefab;
    public Vector2[] boxPositions;

    private void Start() => InvokeRepeating("SpawnBox", 0, 0.1f);

    private void SpawnBox() {
        if (Random.value >= 0.1f) return;
        Instantiate(boxPrefab, boxPositions[Random.Range(0, 6)], Quaternion.identity);
    }
}
