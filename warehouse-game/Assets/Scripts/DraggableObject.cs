using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour
{
    public bool IsBeingDragged = false;

    protected Camera cam;
    protected Rigidbody2D rb;
    protected Vector3 mousePos, originalMousePos, originalPos;

    protected virtual void Awake() => rb = GetComponent<Rigidbody2D>();

    protected void Start() => cam = Camera.main;
    protected  void OnMouseDrag() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - originalMousePos;
        rb.velocity = (originalPos + mousePos - rb.transform.position) * 300 * Time.deltaTime;
    }

    private void OnMouseDown() {
        originalMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        originalPos = rb.position;
        IsBeingDragged = true;
    }
    private void OnMouseUp() => IsBeingDragged = true;
}