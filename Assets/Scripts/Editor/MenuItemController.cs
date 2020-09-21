using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if DEBUG
using UnityEditor;
#endif

public class MenuItemController : MonoBehaviour
{
    #region Editor
#if DEBUG
    [MenuItem("Window/Create1000TestObjects", priority = 10700)]
    static void Create1000TestObjects()
    {
        var go = new GameObject();
        for (int i = 0; i < 1000; i++)
        {
            Instantiate(go);
        }
    }
#endif
    #endregion  
}
