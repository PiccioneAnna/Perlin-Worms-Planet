using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// Loosely based off of https://github.com/SunnyValleyStudio/Perlin-Worms-Unity-tutorial/blob/main/Scripts/PerlinWorm.cs
/// <summary>
/// Technically true perlin worm, generated based on settings
/// List of joint locations, not visibly shown
/// </summary>
public class WormSkeleton
{
    #region Fields
    public List<Vector3> bones;
    public Vector3 headBone;
    public Vector3 tailBone;
    public Vector3 convergancePoint; // point where worm heads towards, set to center of sphere, should be other side of mesh
    public bool isFinished; // is finished generating
    public float weight = 0.6f;
    public float distanceMargin = 3f;
    public WormSettings settings;

    public WormNoiseFilter filter;
    private Vector3 currentDirection;
    private Vector3 currentPosition;

    #endregion

    public WormSkeleton(Vector3 mousePos, Vector3 converg = default(Vector3))
    {
        headBone = mousePos;
        bones = new List<Vector3>();
        convergancePoint = converg;
        isFinished = false;
    }

    // Calculates the entirety of the worms path
    public void CalculateWormPath()
    {
        // Start at headbone and continue digging until max segments reached or other side of mesh reached
        currentPosition = headBone;
        bones.Add(currentPosition);

        while (!isFinished)
        {
            currentPosition = MoveTowardsConvergencePoint();
            bones.Add(currentPosition);
            UnityEngine.Debug.Log(currentPosition);
        }
    }

    #region Private Movement Functions

    private Vector3 MoveTowardsConvergencePoint()
    {
        Vector3 direction = GetPerlinNoiseDirection();
        var directionToConvergancePoint = (convergancePoint - currentPosition).normalized;
        var endDirection = (direction * (1 - weight) + directionToConvergancePoint * weight).normalized;
        currentPosition += endDirection;
        CheckDistanceToConvergence();
        return currentPosition;
    }

    private Vector3 Move()
    {
        Vector3 direction = GetPerlinNoiseDirection();
        currentPosition += direction;
        return currentPosition;
    }

    /// <summary>
    /// Returns the perlin noise direction based on current pos
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPerlinNoiseDirection()
    {
        float noise = filter.Evaluate(currentPosition);
        float degrees = WormHelper.RangeMap(noise, 0, 1, -90, 90);
        currentDirection = (Quaternion.AngleAxis(degrees, Vector3.forward) * currentDirection).normalized;
        return currentDirection;
    }

    /// <summary>
    /// Checks whether the worm is close enough to the point to stop generating
    /// </summary>
    private void CheckDistanceToConvergence()
    {
        if (Vector3.Distance(convergancePoint, currentPosition) <= distanceMargin)
        {
            isFinished = true;
            tailBone = currentPosition;
        }
    }

    #endregion
}
