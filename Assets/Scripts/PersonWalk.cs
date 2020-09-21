using UnityEngine;

[RequireComponent(typeof(Person))]
[RequireComponent(typeof(Needed))]
[AddComponentMenu("R2D2/Walk")]
[ExecuteAlways]
public class PersonWalk : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.up);
        Debug.Log($"isPlaying = {Application.isPlaying}");
    }
}
