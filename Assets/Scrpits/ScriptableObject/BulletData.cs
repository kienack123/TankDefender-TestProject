using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData", order = 1)]
public class BulletData : ScriptableObject
{
    public string Name;
    public BulletType BulletType;
    public float Damage;
    public float Force;
    [TextArea]
    public string Desc;
    public Material BulletShape;
}

public enum BulletType
{
    BulletA,
    BulletB,
    BulletC
}