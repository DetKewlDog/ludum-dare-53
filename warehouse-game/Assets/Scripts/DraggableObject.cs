using UnityEngine;
using UnityEngine.SceneManagement;

public class DraggableObject : MonoBehaviour
{
    public bool IsBeingDragged = false;

    protected Camera cam;
    protected Rigidbody2D rb;
    protected Vector3 mousePos, originalMousePos, originalPos;
    protected float _distanceToTheGround;
    public AudioClip LandSFX, ThrowSFX, PickSFX, DropSFX;
    public bool canPlaySFX = false;
    public GameObject ParticlePrefab;
    private float velocity;
    private OutlineObject outlineObject;

    protected virtual void Awake() {
        rb = GetComponent<Rigidbody2D>();
        outlineObject = GetComponent<OutlineObject>();
    }

    protected virtual void Start() => cam = Camera.main;
    protected void OnMouseDrag() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - originalMousePos;
        rb.velocity = (originalPos + mousePos - rb.transform.position) * 300 * Time.deltaTime;
        velocity = rb.velocity.magnitude / 300;
        outlineObject.OnMouseEnter();
    }

    private void OnMouseDown() {
        originalMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        originalPos = rb.position;
        IsBeingDragged = true;
        GameManager.instance.PlaySound(PickSFX);
    }
    private void OnMouseUp() {
        IsBeingDragged = false;
         GameManager.instance.PlaySound(DropSFX);
        var v = rb.velocity.magnitude;
        if (v >= 5 && velocity < 5) {
            GameManager.instance.PlaySound(ThrowSFX);
        }
        velocity = v;
        outlineObject.OnMouseExit();
    }

    void OnDestroy() {
        if (!canPlaySFX || SceneManager.GetActiveScene().name == "StartScreen") return;
        Instantiate(ParticlePrefab, transform.position, Quaternion.identity);
        if (Random.value >= 0.1f) return;
        GameManager.instance.PlaySound(LandSFX);
    }
}