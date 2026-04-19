using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    public GameObject objectToPlace; // <-- Faites glisser votre prefab ici dans l'Inspecteur
    private GameObject spawnedObject;
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // Détection du touché sur l'écran
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Raycast depuis l'écran vers les plans détectés
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                // Crée ou déplace l'objet à l'endroit tapé
                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                }
            }
        }
    }
}
void Update()
{
    // Pour mobile : touch
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    {
        RaycastFromPosition(Input.GetTouch(0).position);
    }
    // Pour l'éditeur : clic gauche de la souris
    else if (Input.GetMouseButtonDown(0))
    {
        RaycastFromPosition(Input.mousePosition);
    }
}

private void RaycastFromPosition(Vector2 screenPosition)
{
    if (arRaycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon))
    {
        Pose hitPose = hits[0].pose;
        if (spawnedObject == null)
            spawnedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
        else
            spawnedObject.transform.position = hitPose.position;

        StartCoroutine(AnalyzeScene());
    }
}