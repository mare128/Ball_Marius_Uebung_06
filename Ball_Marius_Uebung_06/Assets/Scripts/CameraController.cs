using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Threading;
using System.Diagnostics;

public class CameraController : MonoBehaviour
{

	private Vector3 offset;
	public float speed = 4.0f;
	private bool isZooming;
	private Vector3 mouseOrigin;
	public PlayerController player;
	public bool isRotating;
	Camera camera; 
	public float maxZoom;
	public float minZoom;

	void Start()
	{
		offset = transform.position - player.transform.position;
		camera = UnityEngine.Camera.main;
	}

	void Update() {

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
			{
			player.Move(hit);
			}

		}
		if (Input.GetMouseButton(1))
		{
			mouseOrigin = Input.mousePosition;
			isRotating = true;
		}
		else {
			isRotating = false;
		}
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		if (scroll != 0)
		{
			if (scroll < 0 && minZoom + scroll >= 0 || scroll > 0 && maxZoom - scroll >= 0) {
			maxZoom -= scroll * 3;
			minZoom += scroll * 3;
			camera.fieldOfView += scroll * speed * 3;
		}
		}
	}

	void LateUpdate()
	{
		if (isRotating) {
			float anglex = Input.GetAxis("Mouse X") * speed;
			float angley = Input.GetAxis("Mouse Y") * speed;
			transform.RotateAround(player.transform.position, player.transform.up, anglex);
			transform.Rotate(-angley, 0, 0);
			Vector3 viewPos = camera.WorldToViewportPoint(player.transform.position);
			if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
			{
				transform.Rotate(angley, 0, 0);
			}
			offset = transform.position - player.transform.position;
			//offset = Quaternion.AngleAxis(anglex, player.transform.up) * offset;

		} 

		transform.position = player.transform.position + offset;
	}

}