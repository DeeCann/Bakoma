using UnityEngine;
using System.Collections;

public class CrossRoad : MonoBehaviour {

	private bool _deactivateShowTexture = false;

	public void ActivateRouteArrow(GameObject playerCurrentField, GameObject playerReference) {
        GameObject.FindGameObjectWithTag("FinishArrowCamera").GetComponent<Camera>().enabled = true;
		transform.GetChild(0).GetComponent<CrossRoadArrow>().SetMyParentCharacterReference = playerReference;
		transform.GetChild(0).GetComponent<CrossRoadArrow>().SetMyParentFieldReference = transform.parent.gameObject;
        transform.GetChild(0).GetComponent<CrossRoadArrow>().CanListen = true;
		transform.GetChild(0).renderer.enabled = true;


		StartCoroutine("ShowTexture");
		transform.GetChild(0).animation.PlayQueued("CrossRoadsArrowUp", QueueMode.CompleteOthers);
		transform.GetChild(0).animation.PlayQueued("CrossRoadsArrowFlow", QueueMode.CompleteOthers);
		transform.LookAt ( new Vector3(playerCurrentField.transform.position.x,transform.position.y, playerCurrentField.transform.position.z ), transform.parent.up);
	}

	public void DectivateRouteArrow() {
        GameObject.FindGameObjectWithTag("FinishArrowCamera").GetComponent<Camera>().enabled = false;
		_deactivateShowTexture = true;
		transform.GetChild(0).collider.enabled = false;
        transform.GetChild(0).GetComponent<CrossRoadArrow>().CanListen = false;
		StartCoroutine("HideTexture");
	}

	private IEnumerator ShowTexture() {
		Color fieldColor = transform.GetChild(0).renderer.material.color;
		while(fieldColor.a < 0.49f) {
			fieldColor.a = Mathf.Lerp(fieldColor.a, 0.5f, Time.deltaTime * 3);
			transform.GetChild(0).renderer.material.SetColor("_Color", fieldColor);

			if(fieldColor.a > 0.3f) {
				transform.GetChild(0).collider.enabled = true;
			}

			if(_deactivateShowTexture)
				yield break;

			yield return null;
		}
	} 

	private IEnumerator HideTexture() {
		Color fieldColor = transform.GetChild(0).renderer.material.color;
		while(fieldColor.a > 0.01f) {
			fieldColor.a = Mathf.Lerp(fieldColor.a, 0, Time.deltaTime * 6);
			transform.GetChild(0).renderer.material.SetColor("_Color", fieldColor);
			yield return null;
		}
		_deactivateShowTexture = false;

	} 
}
