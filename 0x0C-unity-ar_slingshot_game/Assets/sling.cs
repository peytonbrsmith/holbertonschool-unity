using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sling : MonoBehaviour
{
    public Text text;
    public GameObject center;
    private Camera cam;
    public GameObject ammo;
    public GameObject chamber;
    public int magazine = 5;
    private Collider _collider;
    public bool _isFiring = false;
    public int score = 0;
    public GameObject uicanvas;
    public GameObject restartscreen;

    void Start()
    {
        cam = Camera.main;
        _collider = cam.GetComponent<Collider>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.mousePresent && Input.GetMouseButton(0))
        {
            touchPosition = Input.mousePosition;
            return true;
        }
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
        try
        {
            chamber = gameObject.transform.GetChild(0).gameObject;
        }
        catch
        {

        }
        // check collision
        if (_isFiring && Input.touchCount == 0 && !Input.GetMouseButton(0) && chamber != null)
        {
            // fire the ammo
            chamber.GetComponent<Rigidbody>().AddForce(center.transform.position * (transform.position.z * 100), ForceMode.Impulse);
            chamber.transform.SetParent(null);
            chamber = null;
            _isFiring = false;
            transform.position = center.transform.position;
            StartCoroutine(reload());
        }
        if (Input.touchCount > 0 || Input.mousePresent)
        {
            Vector3 point = new Vector3();
            if (!TryGetTouchPosition(out Vector2 touchPosition))
                return;
            var reduced = new Vector2((float)touchPosition.x / Screen.width, (float)touchPosition.y / Screen.height);
            //text.text = reduced.ToString();
            //point = cam.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, cam.nearClipPlane));
            //point = cam.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, cam.nearClipPlane));
            //point = GetMousePositionInPlaneOfLauncher();
            var ray = cam.ScreenPointToRay(touchPosition);

            Physics.Raycast(ray, out var hit, Mathf.Infinity);
            point = hit.point;
            transform.position = new Vector3(point.x, point.y, point.z + 0.1f);
            _isFiring = true;
        }

    }

    //Vector3 GetMousePositionInPlaneOfLauncher()
    //{
    //    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    float d;
    //    if (_plane.Raycast(r, out d))
    //    {
    //        Vector3 v = r.GetPoint(d);
    //        return v;
    //    }

    //    throw new UnityException("Mouse position ray not intersecting launcher plane");
    //}

    //void OnCollisionExit(Collision collisionInfo)
    //{
    //    Debug.Log("test");
    //    if (collisionInfo.collider.tag == "loaded")
    //    {
    //        _isFiring = true;
    //    }
    //}
    //void OnCollisionEnter(Collision collisionInfo)
    //{
    //    if (collisionInfo.collider.tag == "loaded")
    //    {
    //        _isFiring = false;
    //    }
    //}
    //void OnTriggerStay(Collider collisionInfo)
    //{
    //    Debug.Log(collisionInfo.tag);
    //}

    IEnumerator reload()
    {
        if (magazine > 0)
        {
            magazine -= 1;
            yield return new WaitForSeconds(1);
            Instantiate(ammo, transform);
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        restartscreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
