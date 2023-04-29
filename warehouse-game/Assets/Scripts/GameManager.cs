using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject boxPrefab;
    public Vector2[] boxPositions;

    private void Awake() {
        instance = this;
        InvokeRepeating("SpawnBox", 0, 0.1f);
    }

    private void SpawnBox() {
        if (Random.value >= 0.1f) return;
        Instantiate(boxPrefab, boxPositions[Random.Range(0, 6)], Quaternion.identity);
    }

    public void BoxDestroyed() => print("L BOZO YOUR BOX FELL OFF");
}
