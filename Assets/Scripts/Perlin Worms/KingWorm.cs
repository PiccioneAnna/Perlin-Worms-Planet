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
    KingWorm instance;

    [SerializeField] public Worm wormTest;

    // Start is called before the first frame update
    void Start()
    {
        worms = new List<Worm>();
        instance = this;

        wormTest = new Worm(new WormSettings(), new Vector3(213.237f,170.23f,123.20f));
        wormTest.wSkeleton.CalculateWormPath();
        wormTest.SetBody();
        wormTest.wBody.CreateWormBody();
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

        Vector3[] points = wormTest.wSkeleton.bones.ToArray();

        Gizmos.color = Color.blue;
        Gizmos.DrawLineList(points);
    }




}
