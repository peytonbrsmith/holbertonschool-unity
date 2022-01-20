using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;



[RequireComponent(typeof(ARRaycastManager))]
public class PlanePicker : MonoBehaviour
{
    public GameObject gamefield;
    public TMP_Text text;
    public GameObject[] _surfaces;
    public NavMeshSurface[] _navMeshSurface;
    public Material _selectedMaterial;
    public Material _defaultMaterial;
    public GameObject selectButtons;

    private GameObject spawnedField;
    private ARRaycastManager _arRaycastManager;
    private ARPlaneManager _arPlaneManager;
    private Vector2 touchPosition;
    private ARPlane chosenPlane;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        _arPlaneManager = GetComponent<ARPlaneManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            //if (spawnedField == null)
            //{
            //    spawnedField = Instantiate(gamefield, hitPose.position, hitPose.rotation);
            //}
            //else
            //{
            //    spawnedField.transform.position = hitPose.position;
            //}

            if (chosenPlane == null)
            {
                foreach (ARRaycastHit hit in hits)
                {
                    chosenPlane = _arPlaneManager.GetPlane(hit.trackableId);
                }
                _arPlaneManager.enabled = false;
                var new_materials = new Material[1];
                new_materials[0] = _selectedMaterial;
                chosenPlane.GetComponent<MeshRenderer>().materials = new_materials;
                selectButtons.SetActive(true);
            }
        }
    }

    public void DisablePlanes()
    {
        foreach (ARPlane plane in _arPlaneManager.trackables)
        {
            if (!(plane.trackableId == chosenPlane.trackableId))
            {
                Destroy(plane.gameObject);
            }
        }
        this.enabled = false;
        _arPlaneManager.enabled = false;
    }

    public void Reset()
    {
        _arPlaneManager.enabled = true;
        selectButtons.SetActive(false);
        var new_materials = new Material[1];
        new_materials[0] = _defaultMaterial;
        chosenPlane.GetComponent<MeshRenderer>().materials = new_materials;
        chosenPlane = null;
    }

    public void StartGame()
    {
        _surfaces[0] = chosenPlane.gameObject;
        BakeAtRuntime();
        chosenPlane.gameObject.GetComponent<MeshRenderer>().enabled = false;
        spawnedField = Instantiate(gamefield, chosenPlane.center, Quaternion.Euler(0,0,0));
    }

    private void BakeAtRuntime()
    {
        _navMeshSurface = new NavMeshSurface[_surfaces.Length];
        for (int i = 0; i < _navMeshSurface.Length; i++)
        {
            if (_surfaces[i].gameObject.GetComponent<NavMeshSurface>() == null)
            {
                _navMeshSurface[i] = _surfaces[i].gameObject.AddComponent<NavMeshSurface>();
            }
            else
            {
                _navMeshSurface[i] = _surfaces[i].gameObject.GetComponent<NavMeshSurface>();
            }
        }
        for (int i = 0; i < _navMeshSurface.Length; i++)
        {
            _navMeshSurface[i].BuildNavMesh();
        }
    }
}
