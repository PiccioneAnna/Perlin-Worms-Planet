using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

/// <summary>
/// Manager class for all perlin worms
/// </summary>
public class KingWorm : MonoBehaviour
{
    [SerializeField]
    public List<Worm> worms;
    private GameObject currentWormChild;
    private MeshFilter currMeshFilter;

    public Material material;
    public Color outterWormColor;
    public Color innerWormColor;

    KingWorm instance;

    // Start is called before the first frame update
    void Start()
    {
        worms = new List<Worm>();
        instance = this;
    }

    /// <summary>
    /// Class handles new worm generation
    /// </summary>
    public void DropWorm(Vector3 rootPos)
    {
        CreateWormObject(rootPos);

        Worm worm = new Worm(new WormSettings(), new Vector3(213.237f, 170.23f, 123.20f));
        worm.wSkeleton.CalculateWormPath();
        worm.SetBody(innerWormColor, outterWormColor);
        worm.wBody.CreateWormBody();

        currentWormChild.GetComponent<MeshFilter>().mesh = worm.wBody.GetMesh();

        worms.Add(worm);
    }

    public void CreateWormObject(Vector3 pos)
    {
        GameObject wormChild = new GameObject("Worm Child");
        wormChild.transform.position = Vector3.zero;
        wormChild.transform.SetParent(transform);
        wormChild.AddComponent<MeshRenderer>();
        wormChild.GetComponent<MeshRenderer>().sharedMaterial = material;
        wormChild.GetComponent<MeshRenderer>().sharedMaterial.color = innerWormColor;
        wormChild.AddComponent<MeshFilter>();
        currMeshFilter = gameObject.GetComponent<MeshFilter>();
        currentWormChild = wormChild;
    }
    void OnDrawGizmosSelected()
    {
        if(worms.Count == 0) { return; }

        foreach (Worm worm in worms)
        {
            if (worm == null) { return; }

            List<Vector3> bones = worm.wSkeleton.bones;

            if (bones.Count % 2 != 0) { bones.Remove(bones[bones.Count - 1]); }

            Vector3[] points = bones.ToArray();

            if (points.Length % 2 != 0) { return; } // returns if not even - shouldn't happen after above check

            Gizmos.color = Color.blue;
            Gizmos.DrawLineList(points);
        }
    }
}
