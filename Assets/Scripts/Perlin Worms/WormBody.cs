using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Helper class to store vertices
/// </summary>
public class WormDisk
{
    public Vector3 originalBone;
    public Vector3 j1, j2, j3, j4, j5, j6, j7, j8;
    public List<Vector3> joints;
    // clockwise circle startig at 1

    public WormDisk(Vector3 bone)
    {
        originalBone = bone;
        joints = new();
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
    private Mesh wormMesh;
    private List<WormDisk> disks;
    private WormDisk currDisk;
    public int index = 0;
    public int subdivisions = 8; // how many points are generated around a point

    List<Vector3> vArray;
    List<int> tArray;

    public WormBody(WormSkeleton skeleton, WormSettings settings)
    {
        this.skeleton = skeleton;
        this.settings = settings;
        disks = new();
        wormMesh = new();
    }

    /// <summary>
    /// Method creates skins based off of precreated worm skeleton
    /// </summary>
    public void CreateWormBody()
    {
        vArray = new();
        tArray = new();

        // First create disks from each bone should be in order
        foreach (Vector3 bone in skeleton.bones)
        {
            TurnBoneToDisk(bone);
        }

        //Then render the triangles from the disks
        for (int i = 0; i < disks.Count; i++)
        {
            if (i+1 < disks.Count)
            {
                DrawFace(disks[i], disks[i + 1]);
                UnityEngine.Debug.Log("Face Created");
            }
        }

        wormMesh.Clear();
        wormMesh.vertices = vArray.ToArray();
        wormMesh.triangles = tArray.ToArray();
        wormMesh.RecalculateNormals();
    }

    public void DrawFace(WormDisk a, WormDisk b)
    {
        for (int i = 0; i < subdivisions; i++)
        {
            if(i+1 >= subdivisions)
            {
                DrawTriangle(a.joints[i], b.joints[i], b.joints[0]);
                DrawTriangle(a.joints[i], a.joints[0], b.joints[0]);
            }
            else
            {
                DrawTriangle(a.joints[i], b.joints[i], b.joints[i + 1]);
                DrawTriangle(a.joints[i], a.joints[i + 1], b.joints[i + 1]);
            }

            UnityEngine.Debug.Log("Face drawn");
        }
    }

    public void DrawTriangle(Vector3 a, Vector3 b, Vector3 c)
    {

        vArray.Add(a);
        vArray.Add(b);
        vArray.Add(c);

        tArray.Add(index);
        tArray.Add(index + 1);
        tArray.Add(index + 2);

        index += 3;
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

        currDisk.joints.Add(currDisk.j1);
        currDisk.joints.Add(currDisk.j2);
        currDisk.joints.Add(currDisk.j3);
        currDisk.joints.Add(currDisk.j4);
        currDisk.joints.Add(currDisk.j5);
        currDisk.joints.Add(currDisk.j6);
        currDisk.joints.Add(currDisk.j7);
        currDisk.joints.Add(currDisk.j8);

        disks.Add(currDisk);
    }
}
