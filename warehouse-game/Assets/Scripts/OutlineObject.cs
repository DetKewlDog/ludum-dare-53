using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    SpriteRenderer sr;
    void Awake() => sr = GetComponent<SpriteRenderer>();
    public void OnMouseEnter() => sr.material.shader = Shader.Find("Custom/SpriteOutline");
    public void OnMouseExit() => sr.material.shader = Shader.Find("Sprites/Default");
}
