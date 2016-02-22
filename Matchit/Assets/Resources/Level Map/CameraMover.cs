using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	public float moveSensitivityX = 1.0f;
	public float moveSensitivityY = 1.0f;
	public bool updateZoomSensitivity = true;
	public float orthoZoomSpeed = 0.05f;
	public float minZoom = 1.0f;
	public float maxZoom = 20.0f;

	public float mapWidth = 40.0f;
	public float mapHeight = 40.0f;

	public float inertiaDuration = 1.0f;
	public float minimumScrollVelocity = 100.0f;
	
	private Camera thecamera;

	private float horizontalExtent, verticalExtent;
	private float minX, maxX, minY, maxY;
	private float scrollVelocity = 0.0f;
	private float timeTouchPhaseEnded;
	private Vector2 scrollDirection = Vector2.zero;

	// Use this for initialization
	void Start () {
		thecamera = Camera.main;
		maxZoom = 0.5f * (mapWidth / thecamera.aspect);

		if (mapWidth > mapHeight) {
			maxZoom = 0.5f * mapHeight;
		}
		CalculateMapBounds ();
	}
	
	// Update is called once per frame
	void Update () {
		if (updateZoomSensitivity) {
			moveSensitivityX = thecamera.orthographicSize / 5.0f;
			moveSensitivityY = thecamera.orthographicSize / 5.0f;
		}

		Touch[] touches = Input.touches;

		if (touches.Length < 1) {
			if(scrollVelocity != 0.0f) {
				float timer = (Time.time - timeTouchPhaseEnded) / inertiaDuration;
				float frameVelocity = Mathf.Lerp(scrollVelocity, 0.0f, timer);
				thecamera.transform.position += -(Vector3)scrollDirection.normalized * (frameVelocity * 0.05f) * Time.deltaTime;

				if(timer >= 1.0f) {
					scrollVelocity = 0.0f;
				}
			
			}
		}

		if (touches.Length > 0) {
			//single touch (move)
			if(touches.Length == 1) {
				if(touches[0].phase == TouchPhase.Began) {
					scrollVelocity = 0.0f;
				}
				else if(touches[0].phase == TouchPhase.Moved) {
					Vector2 delta = touches[0].deltaPosition;

					float positionX = -delta.x * moveSensitivityX * Time.deltaTime;
					float positionY = -delta.y * moveSensitivityY * Time.deltaTime;

					thecamera.transform.position += new Vector3(positionX, positionY, 0);

					scrollDirection = touches[0].deltaPosition.normalized;
					scrollVelocity = touches[0].deltaPosition.magnitude / touches[0].deltaTime;

					if(scrollVelocity <= minimumScrollVelocity) {
						scrollVelocity = 0.0f;
					}
				}
				else if (touches[0].phase == TouchPhase.Ended) {
					timeTouchPhaseEnded = Time.time;
				}
			}

			//double touch (zoom)
			if(touches.Length == 2) {
				Vector2 cameraViewSize = new Vector2(thecamera.pixelWidth, thecamera.pixelHeight);
				Touch touchOne = touches[0];
				Touch touchTwo = touches[1];

				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
				Vector2 touchTwoPrevPos = touchTwo.position - touchTwo.deltaPosition;

				float prevTouchDeltaMag = (touchOnePrevPos - touchTwoPrevPos).magnitude;
				float touchDeltaMag = (touchOne.position - touchTwo.position).magnitude;

				float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;

				thecamera.transform.position += thecamera.transform.TransformDirection((touchOnePrevPos - touchTwoPrevPos - cameraViewSize) * thecamera.orthographicSize / cameraViewSize.y);

				thecamera.orthographicSize += deltaMagDiff * orthoZoomSpeed;

				thecamera.orthographicSize = Mathf.Clamp (thecamera.orthographicSize, minZoom, maxZoom);

				thecamera.transform.position -= thecamera.transform.TransformDirection((touchOne.position + touchTwo.position - cameraViewSize) * thecamera.orthographicSize / cameraViewSize.y);
			
				CalculateMapBounds ();
			}
		
		}
	}


	void CalculateMapBounds() {
		verticalExtent = thecamera.orthographicSize;
		horizontalExtent = verticalExtent * thecamera.aspect;

		minX = horizontalExtent - mapWidth / 2.0f;
		maxX = mapWidth / 2.0f - horizontalExtent;
		minY = verticalExtent - mapHeight / 2.0f;
		maxY = mapHeight / 2.0f - verticalExtent;
	}

	void LateUpdate() {
		Vector3 limitedCameraPosition = thecamera.transform.position;
		limitedCameraPosition.x = Mathf.Clamp (limitedCameraPosition.x, minX, maxX);
		limitedCameraPosition.y = Mathf.Clamp (limitedCameraPosition.y, minY, maxY);
		thecamera.transform.position = limitedCameraPosition;

	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube (Vector3.zero, new Vector3 (mapWidth, mapHeight, 0));
	}

}
