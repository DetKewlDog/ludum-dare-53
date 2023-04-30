using UnityEngine;

public class Box : DraggableObject
{
    [System.Serializable]
    public class BoxVariant {
        public Sprite[] sprites;
    }
    public enum BoxColor { Yellow, Blue, Red };
    public BoxVariant[] boxVariants = new BoxVariant[3];
    public Vector2[] sizes;
    [Space]
    public BoxColor boxColor;

    protected override void Awake() {
        base.Awake();
        if (boxVariants.Length > 0) {
            boxColor = (BoxColor)Random.Range(0, 3);
            int boxVariantIndex = Random.Range(0, 3);
            var sprites = boxVariants[boxVariantIndex].sprites;
            GetComponent<SpriteRenderer>().sprite = sprites[(int)boxColor];
            GetComponent<BoxCollider2D>().size = sizes[boxVariantIndex];
        }
    }
}
