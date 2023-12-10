using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# region Components
/// <summary>
/// Contains reference to skeleton and generated faces around it
/// Handles mesh information calced off of skeleton
/// </summary>
public class WormBody
{

}

/// <summary>
/// Technically true perlin worm, generated based on settings
/// LinkedList of joint locations, not visibly shown
/// </summary>
public class WormSkeleton
{
    public LinkedList<Vector3> bones;
    public Vector3 headBone;
    public Vector3 tailBone;

    public WormSkeleton(Vector3 mousePos)
    {
        headBone = mousePos;
        bones = new LinkedList<Vector3>();


    }

    public void CalculateWormPath()
    {

    }

}

/// <summary>
/// Worm generation settings
/// </summary>
public class WormSettings
{
    readonly double _lateralSpeed; // sideways speed
    readonly double _twistiness;
    readonly double _segmentLength;
    readonly double _speed;
    readonly double _radius; // half worm thickness
    readonly int _subdivision; // amount of points along the circumference for the walls forming the worm

    public WormSettings(double lateralSpeed, double twistiness,
        double segmentLength, double speed, double radius, int subdivision) 
    { 
        _lateralSpeed = lateralSpeed;
        _twistiness = twistiness;
        _segmentLength = segmentLength;
        _speed = speed;
        _radius = radius;
        _subdivision = subdivision;    
    }
}
#endregion

public class Worm : MonoBehaviour
{
    #region Fields

    [SerializeField] WormBody wBody;
    [SerializeField] WormSkeleton wSkeleton;
    [SerializeField] WormSettings wSettings;

    #endregion

    public Worm(WormSettings settings, Vector3 mousePos)
    {
        wBody = new();
        wSkeleton = new(mousePos);
        wSettings = settings;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
