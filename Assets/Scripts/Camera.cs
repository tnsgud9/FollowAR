using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Camera : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public GameObject playerPrefab;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(touch.position, hits, TrackableType.Planes) && Manager.instance.player )
            {

                Pose hit = hits[0].pose;
                if (Manager.instance.player == null)
                {
                    GameObject player = Instantiate(playerPrefab, hit.position, transform.rotation);
                    Manager.instance.player = player;
                }
                Manager.instance.player.GetComponent<Player>().addWaypoint(hit.position);

            }
        }
    }
}
