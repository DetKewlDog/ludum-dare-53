using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    SpriteRenderer sr;
    void Awake() => sr = GetComponent<SpriteRenderer>();
    void OnMouseEnter() => sr.material.shader = Shader.Find("Custom/SpriteOutline");
    void OnMouseExit() => sr.material.shader = Shader.Find("Sprites/Default");
}
