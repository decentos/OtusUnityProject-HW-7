using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PersonType", menuName = "Person", order = 10)]
public class PersonType : ScriptableObject
{
    [Header("Здоровье")]
    public int Health1;
    [Space]
    public int Health2;
    [HideInInspector] 
    public int Health3;
    [Header("Здоровье дополнительное")]
    public int Health5;
    [Range(0, 100)]
    public int Health6;
    [Tooltip("Это здоровье не испольуется")]
    public int Health7;

    public string Health8;
    [TextArea]
    public string Health9;
}

[Serializable]
public class Weapon
{
    public int Damage;
    //[JsonIgnore]
    public int AttackSpeed;
}