using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour
{
    protected Camera cam;
    protected Vector3 offset = new Vector3(0, 0, 10);
    protected Rigidbody2D rb;
    protected Vector3 force = Vector3.zero, mousePos, originalMousePos, originalPos;
    protected LineRenderer line;

    protected virtual void Awake() {
        rb = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
    }

    protected void Start() => cam = Camera.main;
    protected  void OnMouseDrag() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - originalMousePos;
        rb.velocity = (originalPos + mousePos - rb.transform.position) * 500 * Time.deltaTime;
    }

    private void OnMouseDown() {
        originalMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        originalPos = rb.position;
    }
}