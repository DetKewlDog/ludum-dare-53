using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    Camera cam;
    Vector3 offset = new Vector3(0, 0, 10);
    void Start() {
        Cursor.visible = false;
        cam = Camera.main;
    }
    void Update() => transform.position = cam.ScreenToWorldPoint(Input.mousePosition) + offset;
}
