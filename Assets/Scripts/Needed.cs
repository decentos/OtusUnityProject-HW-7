using UnityEngine;

//[AddComponentMenu("Menuha/Needed1")]
//[ExecuteAlways]
public class Needed : MonoBehaviour
{
    public Transform Target;
    public Transform Target2;
    public int TargetInerface { get; set; } = 99;

    //private void Start()
    //{
    //    Debug.Log("ExecuteAlways Start");
    //}

    //private void Update()
    //{
    //    if(Application.isPlaying)
    //        Debug.Log("ExecuteAlways Update isPlaying");
    //    else 
    //        Debug.Log("ExecuteAlways Update");
    //}
}
