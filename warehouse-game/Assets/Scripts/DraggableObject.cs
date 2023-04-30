using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour
{
    public bool IsBeingDragged = false;

    protected Camera cam;
    protected Rigidbody2D rb;
    protected Vector3 mousePos, originalMousePos, originalPos;
    protected float _distanceToTheGround;
    public AudioClip LandSFX;
    public bool canPlaySFX = false;
    public GameObject ParticlePrefab;

    protected virtual void Awake() => rb = GetComponent<Rigidbody2D>();

    protected void Start() => cam = Camera.main;
    protected void OnMouseDrag() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - originalMousePos;
        rb.velocity = (originalPos + mousePos - rb.transform.position) * 300 * Time.deltaTime;
    }

    private void OnMouseDown() {
        originalMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        originalPos = rb.position;
        IsBeingDragged = true;
    }
    private void OnMouseUp() => IsBeingDragged = false;

    void OnDestroy() {
        if (!canPlaySFX) return;
        Instantiate(ParticlePrefab, transform.position, Quaternion.identity);
        if (Random.value >= 0.1f) return;
        AudioSource audioSource = GameManager.instance.GetComponent<AudioSource>();
        audioSource.clip = LandSFX;
        audioSource.Play();
    }
}