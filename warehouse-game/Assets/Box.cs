using UnityEngine;
using UnityEngine.EventSystems;

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
    Camera cam;
    Vector3 offset = new Vector3(0, 0, 10);
    Rigidbody2D rb;
    Vector3 force = Vector3.zero, mousePos;
    LineRenderer line;

    void Awake() {
        boxColor = (BoxColor)Random.Range(0, 3);
        var sprites = boxVariants[(int)boxColor].sprites;
        int index = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[index];
        GetComponent<BoxCollider2D>().size = sizes[index];
        rb = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
    }

    void Start() => cam = Camera.main;

    private void OnMouseDrag() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition) + offset;
        rb.AddForce((mousePos - transform.position) * 5 + Vector3.down * 5);
        line.SetPosition(0, transform.position);
        line.SetPosition(1, mousePos);
    }

    private void OnMouseDown() => line.positionCount = 2;

    private void OnMouseUp() => line.positionCount = 0;
}
