using UnityEngine;

public class VersionText : MonoBehaviour
{
    void Start() => GetComponent<UnityEngine.UI.Text>().text = $"Version v{Application.version}";
}
