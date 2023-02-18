using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement3D
{
    Vector3 velocity { get; }
    bool jumpedThisFrame { get; }
}
