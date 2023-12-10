using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class handles mouse related interactions based on what mode we in
/// </summary>
public class MouseManager : MonoBehaviour
{
    #region Fields

    [Header("General")]
    public GameObject _planet;
    public LayerMask _worldLayer;
    public Vector3 _currMousePos;
    private Vector3 _prevMousePos;
    private Vector3 _mousePosDelta;

    // Raycast variables
    private Vector3 _raycastDirection;
    private Vector3 _raycastPoint;
    private Vector3 _raycastDistance;
    private RaycastHit _hit;
    private GameObject _hitObject;

    [Header("Other Managers")]
    public KingWorm kingWorm;

    [Header("Game State")]
    public bool isWorms; // can u click and drop worm
    public bool isFreeRotate = true; // can u click and rotate around

    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        _currMousePos = _prevMousePos = _mousePosDelta = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Planet rotation
        if (isFreeRotate && Input.GetMouseButton(1)) 
        {
            DragObject(_planet);             
        }
    }

    #region Raycast

    /// <summary>
    /// Send out a raycast and return information if called
    /// </summary>
    private void SendRaycast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // start ray from main cam
        _raycastDirection = Camera.main.transform.forward;

        // Ray hit something in defined space
        if(Physics.Raycast(ray, out _hit, _worldLayer))
        {
            _raycastPoint = _hit.point;
            _hitObject = _hit.transform.gameObject; // should return mesh 

            // Call worm generation
            kingWorm.DropWorm(_raycastPoint, _hitObject);
        }
    }

    #endregion

    #region Object Rotation

    /// <summary>
    /// Enables drag behavior on a target gameobject
    /// </summary>
    /// <param name="target"></param>
    private void DragObject(GameObject target)
    {
        _mousePosDelta = Input.mousePosition - _prevMousePos;
        _prevMousePos = Input.mousePosition;

        if(Vector3.Dot(target.transform.up, Vector3.up) >= 0)
        {
            target.transform.Rotate(target.transform.up, -Vector3.Dot(_mousePosDelta, Camera.main.transform.right), Space.World);
        }
        else
        {
            target.transform.Rotate(target.transform.up, Vector3.Dot(_mousePosDelta, Camera.main.transform.right), Space.World);
        }

        target.transform.Rotate(Camera.main.transform.right, Vector3.Dot(_mousePosDelta, Camera.main.transform.up), Space.World);
    }

    #endregion
}
