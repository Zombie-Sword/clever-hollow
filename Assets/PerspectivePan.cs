using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectivePan : MonoBehaviour {
    private Vector3 previousPos;
    public Camera cam;
    public float speed;
    // Start is called before the first frame update

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0)){
            Vector3 direction = previousPos - cam.ScreenToViewportPoint(Input.mousePosition);
            cam.transform.position += direction * speed;
            previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
