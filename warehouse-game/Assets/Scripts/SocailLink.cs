using UnityEngine;

public class SocailLink : MonoBehaviour
{
    public string link;
    public void Trigger() => Application.OpenURL(link);
}
