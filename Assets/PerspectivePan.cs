using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectivePan : MonoBehaviour {
    private Vector3 previousPos;
    public Camera cam;
    public float speed = 20f;
    private float targetZoom;
    private float zoomFactor = 3f;
    [SerializeField] private float zoomLerpSpeed = 10f;
    public float minZoom = 8f;
    public float maxZoom = 21.5f;
    // Start is called before the first frame update
    private void Start()
    {
        targetZoom = cam.fieldOfView;
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0)){
            Vector3 direction = previousPos - cam.ScreenToViewportPoint(Input.mousePosition);
            cam.transform.position += direction * speed;
            previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetZoom, Time.deltaTime * zoomLerpSpeed);
    }
}
