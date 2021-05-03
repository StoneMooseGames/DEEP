using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
  public Camera playerCamera;
  Vector3 cameraLocationOffset = new Vector3(0, 0, -15);

  void Start()
  {
        playerCamera = Camera.main;
    // at start disable Spriterendering for this, because the sprite is there
    // only to mark the spot for the camera.
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
  }

  void Update() {}

  private void OnTriggerEnter2D( Collider2D other )
  {
    // when something enters the collider (Collider is as trigger atm) move camera to the gameobject
    // where the collider is.
    if ( other.name == "Player" )
    {
      playerCamera.transform.position = this.gameObject.transform.position + cameraLocationOffset;
    }
  }
}
