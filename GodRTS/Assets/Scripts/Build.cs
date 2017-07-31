using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour {

    public GameObject building = null;

    private GameObject buildingInstance = null;
    private Vector3 position = Vector3.zero;
    private bool instantiated = false;
    private bool placed = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (building != null) {

            //get mouse position in world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);

            if (!instantiated) {
                building = Instantiate(building, Camera.current.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                instantiated = true;
            }

            //if mouse button isn't pressed, move building to cursor
            if (instantiated && !Input.GetMouseButton(0)) {

                building.transform.position = hit.point;
            }

            if (instantiated && Input.GetMouseButton(0)) {
                if (!placed) {
                    position = hit.point;
                    placed = true;
                }
                building.transform.LookAt(hit.point);
            }

            if (Input.GetMouseButtonUp(0)) {
                Debug.Log(building.name + " placed at: " + position);
                Instantiate(building, position, building.transform.rotation);
                reset();
            }
        }
    }

    public void PickBuilding(GameObject pickedBuilding) {
        building = pickedBuilding;
    }

    private void reset() {
        Destroy(building.gameObject);
        building = null;
        position = Vector3.zero;
        instantiated = false;
        placed = false;
    }
}
