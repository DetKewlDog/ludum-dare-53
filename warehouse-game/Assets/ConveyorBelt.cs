using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float Speed = 1;
    public bool IsActive = true;

    private Rigidbody2D rb;
    private Vector2 pos, originalPos;

    private void Start() => rb = GetComponent<Rigidbody2D>();

    // Update is called once per frame
    private void FixedUpdate() {
        if (!IsActive) return;
        originalPos = pos = rb.position;
        pos.x += Speed * Time.deltaTime;
        rb.position = pos;
        rb.MovePosition(originalPos);
    }
}
