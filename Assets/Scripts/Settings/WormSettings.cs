using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Worm generation settings
/// </summary>
public class WormSettings
{
    public readonly float _lateralSpeed; // sideways speed
    public readonly float _twistiness;
    public readonly float _segmentLength;
    public readonly float _speed;
    public readonly float _radius; // half worm thickness
    public readonly int _subdivision; // amount of points along the circumference for the walls forming the worm

    public float strength = 1;
    [Range(1, 8)]
    public int numLayers = 1;
    public float baseRoughness = 1;
    public float roughness = 2;
    public float persistence = .5f;
    public Vector3 centre;
    public float minValue;

    /// <summary>
    /// Default worm settings constructor
    /// </summary>
    public WormSettings()
    {
        _lateralSpeed = 2.5f;
        _twistiness = 3.5f;
        _radius = 10f;
        _segmentLength = 5f;
        _speed = 1.0f;
        _subdivision = 4;
    }

    /// <summary>
    /// Custom worm settings constructor
    /// </summary>
    /// <param name="lateralSpeed"></param>
    /// <param name="twistiness"></param>
    /// <param name="segmentLength"></param>
    /// <param name="speed"></param>
    /// <param name="radius"></param>
    /// <param name="subdivision"></param>
    public WormSettings(float lateralSpeed, float twistiness,
        float segmentLength, float speed, float radius, int subdivision)
    {
        _lateralSpeed = lateralSpeed;
        _twistiness = twistiness;
        _segmentLength = segmentLength;
        _speed = speed;
        _radius = radius;
        _subdivision = subdivision;
    }
}
