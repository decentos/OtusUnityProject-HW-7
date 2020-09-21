using System;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;
public class Person : MonoBehaviour
{
    public const int LevelMax = 100;

    public PersonTypeData Type;
    [SerializeField]
    private float CurrentHp = 1;
    [Space]
    [Space]
    [Space]
    [Space]
    [Space]
    [Space]
    [Space]
    [Space]
    [Space]
    [Range(0, LevelMax)]
    public int Level = 0;
    [Header("Доп данные")]
    [Tooltip("Точка нахождения мыслей героя")]
    public Point Point;
    public AnimationCurve Curves;

    [Header("инфа")]
    [TextArea(10, 20)]
    public string ТекстовоеПоле;

    //[ContextMenuItem("MaxLvl", "RandomProfile")]
    //public int MaxLevel;

    [ContextMenu("Randomize profile")]
    public void RandomProfile()
    {
        CurrentHp = Random.value;
        Level = Random.Range(1, Type.HP);
    }

    private void Update()
    {
        90.Log("byaf");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawSphere(transform.position, 2);
        Gizmos.DrawIcon(transform.position, "Z");
    }
}

[Serializable]
public class Point
{
    public int X;
    public int Y;
}

public static class LogExt
{
    [Conditional("DEBUG")]
    public static void Log(this object x, string s) =>
        UnityEngine.Debug.Log(x + ": " + s);
}
