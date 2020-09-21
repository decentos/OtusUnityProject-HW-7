using UnityEditor;
using UnityEngine;

public class EditorExt : MonoBehaviour
{
    public int Data = 55;

    [MenuItem("Tools/ShowSmething")]
    public static void ShowSmething()
    {
        //GameObject.Find("Obj0").transform.Rotate(100, 100, 100);
    }
}
