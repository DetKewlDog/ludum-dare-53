using UnityEngine;

public class Box : MonoBehaviour
{
    [System.Serializable]
    public class BoxVariant {
        public BoxColor boxColor;
        public Sprite[] sprites;
    }
    public enum BoxColor { Blue, Yellow, Red };
    public BoxVariant[] boxVariants = new BoxVariant[3];
    public Vector2[] sizes;
    [Space]
    public BoxColor boxColor;

    void Awake() {
        boxColor = (BoxColor)Random.Range(0, 3);
        var sprites = boxVariants[(int)boxColor].sprites;
        int index = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[index];
        GetComponent<BoxCollider2D>().size = sizes[index];
    }
}
