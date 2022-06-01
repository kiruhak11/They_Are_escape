using System;
using UnityEngine;
using System.Collections;
using Photon.Pun;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	public float rotationY = 0F;
    private PhotonView PV;
    public MouseLook _mouseLook;
    // public Animator anim;
    private float slowMouseX;
    private void Awake()
    {
        PV = GetComponent<PhotonView>();

         if (!PV.IsMine)
         {
             _mouseLook.enabled = false;
         }
    }

    void Update ()
    {
        // float mouseX = Input.GetAxis("Mouse X");
        // slowMouseX = Mathf.Lerp(slowMouseX, mouseX, 10 * Time.deltaTime);
        // anim.SetFloat("MouseX", slowMouseX);
        if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * Time.deltaTime * (PlayerCam.sens * 10);
			
			rotationY += Input.GetAxis("Mouse Y") * Time.deltaTime * (PlayerCam.sens * 10);
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * (PlayerCam.sens * 10), 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * Time.deltaTime * (PlayerCam.sens * 10);
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
	}
	
	void Start ()
	{
        if (PV.IsMine)
        {
            // Make the rigid body not change rotation
            if (GetComponent<Rigidbody>())
                GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
}