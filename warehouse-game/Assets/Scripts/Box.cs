using UnityEngine;

public class Box : DraggableObject
{
    [System.Serializable]
    public class BoxVariant {
        public BoxColor boxColor;
        public Sprite[] sprites;
    }
    public enum BoxColor { Blue, Yellow, Red, PipeBomb };
    public BoxVariant[] boxVariants = new BoxVariant[3];
    public Vector2[] sizes;
    [Space]
    public BoxColor boxColor;

    protected override void Awake() {
        base.Awake();
        if (boxVariants.Length > 0) {
            boxColor = (BoxColor)Random.Range(0, 3);
            var sprites = boxVariants[(int)boxColor].sprites;
            int index = Random.Range(0, sprites.Length);
            GetComponent<SpriteRenderer>().sprite = sprites[index];
            GetComponent<BoxCollider2D>().size = sizes[index];
        }
    }
}
