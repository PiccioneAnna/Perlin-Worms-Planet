using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Helper class to store vertices
/// </summary>
public class WormDisk
{
    public Vector3 originalBone;
    public Vector3 j1, j2, j3, j4, j5, j6, j7, j8;
    // clockwise circle startig at 1

    public WormDisk(Vector3 bone)
    {
        originalBone = bone;
    }
}

/// <summary>
/// Contains reference to skeleton and generated faces around it
/// Handles mesh information calced off of skeleton
/// </summary>
public class WormBody
{
    public WormSkeleton skeleton;
    public WormSettings settings;
    private List<WormDisk> disks;
    private WormDisk currDisk;
    public int subdivisions = 8; // how many points are generated around a point

    public WormBody(WormSkeleton skeleton, WormSettings settings)
    {
        this.skeleton = skeleton;
        this.settings = settings; 
    }

    /// <summary>
    /// Method creates skins based off of precreated worm skeleton
    /// </summary>
    public void CreateWormBody()
    {
        // First create disks from each bone should be in order
        foreach (Vector3 bone in skeleton.bones)
        {
            TurnBoneToDisk(bone);
        }
    }

    public void GetTriangles(Vector3 boneA, Vector3 boneB)
    {

    }

    /// <summary>
    /// Creates a disk from a vector3 bone position
    /// </summary>
    /// <param name="bone"></param>
    public void TurnBoneToDisk(Vector3 bone)
    {
        float radius = settings._radius;
        currDisk = new WormDisk(bone);
        currDisk.j1 = new Vector3(0, radius, 0);
        currDisk.j2 = new Vector3(radius, radius, 0);
        currDisk.j3 = new Vector3(radius, 0, 0);
        currDisk.j4 = new Vector3(radius, -radius, 0);
        currDisk.j5 = new Vector3(0, -radius, 0);
        currDisk.j6 = new Vector3(-radius, -radius, 0);
        currDisk.j7 = new Vector3(-radius, 0, 0);
        currDisk.j8 = new Vector3(-radius, radius, 0);

        disks.Add(currDisk);
    }
}
