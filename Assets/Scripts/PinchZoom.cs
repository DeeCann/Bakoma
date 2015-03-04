using UnityEngine;
using System.Collections;

public class PinchZoom : MonoBehaviour {

	private float clampZoomSpeed = 0.4f;
	private float lerpZoomSpeed = 7.5f;
    private float crossRoadsLerpZoomSpeed = 2.5f;

	public static bool _restetZoom = false;
    public static bool _zoomOutOnCrossroad = false;

	private float normalFOV = 50;
	private float minFOV = 30;
	private float maxFOV = 90;
    private float crossRoadsZoomOut = 75;

	void Update()
	{
		if(_restetZoom) {
			camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, normalFOV, 0.5f);
			if(camera.fieldOfView == normalFOV)
				_restetZoom = false;
		}

        if (_zoomOutOnCrossroad) {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, crossRoadsZoomOut, Time.deltaTime * crossRoadsLerpZoomSpeed);
        }

		if (Input.touchCount == 2)
		{
			_restetZoom = false;

			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
			
			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
			
			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			float tmpFOV = camera.fieldOfView + (deltaMagnitudeDiff * clampZoomSpeed);
			camera.fieldOfView =  Mathf.Clamp(Mathf.Lerp(camera.fieldOfView, tmpFOV, Time.deltaTime * lerpZoomSpeed), minFOV, maxFOV);
		}
	}

	public static void ResetZoom() {
		_restetZoom = true;
        _zoomOutOnCrossroad = false;
	}

    public static void ZoomOutForCrossroads() {
        _zoomOutOnCrossroad = true;
    }
}
