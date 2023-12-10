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

    // Start is called before the first frame update
    void Start()
    {
        worms = new List<Worm>();
        instance = this;
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






}
