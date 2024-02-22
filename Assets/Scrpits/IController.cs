using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    public float Damage { get; set; }
    public float Force { get; set; }


    public void Fire();

}
