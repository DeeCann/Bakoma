using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	private Transform player; 
	private Vector3 relCameraPos;   
	private Vector3 newPos;    
	private float smooth = 2;         
	private float relCameraPosMag;     
	      
	void Start ()
	{
		foreach(GameObject character in GameObject.FindGameObjectsWithTag(Tags.Player)) {
			if(character.GetComponent<PlayerCharacter>().PlayerNumber == 1)
				player = character.transform;
		}

        transform.position = player.position -new Vector3(1.957f, -1.8f, -0.72f);

        relCameraPos = transform.position - player.position;
		relCameraPosMag = relCameraPos.magnitude - 0.5f;
	}
	
	void FixedUpdate ()
	{
        player = Game.GetCurrentPlayer.transform;
        
        Vector3 standardPos = player.position + relCameraPos;
        Vector3 abovePos = player.position + Vector3.up * relCameraPosMag;

        Vector3[] checkPoints = new Vector3[5];

        checkPoints[0] = standardPos;
        checkPoints[1] = Vector3.Lerp(standardPos, abovePos, 0.25f);
        checkPoints[2] = Vector3.Lerp(standardPos, abovePos, 0.5f);
        checkPoints[3] = Vector3.Lerp(standardPos, abovePos, 0.75f);
        checkPoints[4] = abovePos;

        for (int i = 0; i < checkPoints.Length; i++)
        {
            if (ViewingPosCheck(checkPoints[i]))
                break;

           
                newPos = standardPos;
        }
        
        transform.position = Vector3.Lerp(transform.position, newPos, 3 * Time.deltaTime);
        SmoothLookAt();
	}
	
	
	bool ViewingPosCheck (Vector3 checkPos)
	{
		RaycastHit hit;
        
		if(Physics.Raycast(checkPos, player.position - checkPos, out hit, relCameraPosMag)) {
            if (hit.transform != player && hit.transform.tag != Tags.PlayerContextMenu && hit.transform.tag != Tags.Player)
            {
                return false;
            }
		}
        
		newPos = checkPos;
		return true;
	}
	
	
	void SmoothLookAt ()
	{
		Quaternion lookAtRotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
	}

    public static void RayFroCrossRoadsArrow() {
        if (GameInputs.isButtonDown) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
 
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "CrossRoadsArrowField")
                    hit.collider.transform.GetComponent<CrossRoadArrow>().GoIntoMyDirection();
            }
        }

       
    }
}
