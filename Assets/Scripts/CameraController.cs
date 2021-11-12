 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.XR.ARFoundation;
 using UnityEngine.XR.ARSubsystems;

 public class CameraController : MonoBehaviour
 {
     public ARRaycastManager arRaycast;

     // Update is called once per frame
     void Update()
     {
         
         if (Input.touchCount > 0)
         {
             Touch touch = Input.GetTouch(0);
             List<ARRaycastHit> hits = new List<ARRaycastHit>();
             if (arRaycast.Raycast(touch.position, hits, TrackableType.Planes))
             {
                 Pose hit = hits[0].pose;
                 GameObject.Find("Player").GetComponent<PlayerController>().AddWayPoint(hit.position);
             }
         }
     }
 }
