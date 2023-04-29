using UnityEngine;

public class Box : MonoBehaviour
{
    public enum BoxColor { Red, Yellow, Green, Purple, Orange, Blue };
    public BoxColor boxColor;
    public Sprite[] Sprites;

    void Awake() {
        boxColor = (BoxColor)Random.Range(0, 6);
        GetComponent<SpriteRenderer>().sprite = Sprites[(int)boxColor];
    }
}
