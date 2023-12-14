using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager class for all perlin worms
/// </summary>
public class KingWorm : MonoBehaviour
{
    [SerializeField]
    public List<Worm> worms;
    public MeshFilter meshFilter;

    public Material material;
    public Color outterWormColor;
    public Color innerWormColor;

    KingWorm instance;

    [SerializeField] public Worm wormTest;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().sharedMaterial = material;
        gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = innerWormColor;
        gameObject.AddComponent<MeshFilter>();
        meshFilter = gameObject.GetComponent<MeshFilter>();

        worms = new List<Worm>();
        instance = this;

        wormTest = new Worm(new WormSettings(), new Vector3(213.237f,170.23f,123.20f));
        wormTest.wSkeleton.CalculateWormPath();
        wormTest.SetBody(innerWormColor, outterWormColor);
        wormTest.wBody.CreateWormBody();

        meshFilter.mesh = wormTest.wBody.GetMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Class handles new worm generation
    /// </summary>
    public void DropWorm(Vector3 rootPos, GameObject mesh)
    {

    }

    void OnDrawGizmosSelected()
    {
        if (wormTest == null) { return; }

        List<Vector3> bones = wormTest.wSkeleton.bones;

        if(bones.Count % 2 != 0) { bones.Remove(bones[bones.Count - 1]); }

        Vector3[] points = bones.ToArray();

        if(points.Length % 2 != 0 ) { return; } // returns if not even - shouldn't happen after above check

        Gizmos.color = Color.blue;
        Gizmos.DrawLineList(points);
    }
}
