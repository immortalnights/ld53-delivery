using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public float panSpeed = 20f;
  public float scrollSpeed = 20f;

  // Update is called once per frame
  void Update()
  {
    Vector3 pos = transform.position;

    if (Input.GetKey("w"))
    {
      pos.z += panSpeed * Time.deltaTime;
    }
    else if (Input.GetKey("s"))
    {
      pos.z -= panSpeed * Time.deltaTime;
    }

    if (Input.GetKey("a"))
    {
      pos.x -= panSpeed * Time.deltaTime;
    }
    else if (Input.GetKey("d"))
    {
      pos.x += panSpeed * Time.deltaTime;
    }

    float scroll = Input.GetAxis("Mouse ScrollWheel");
    pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

    transform.position = pos;
  }
}
