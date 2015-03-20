#pragma strict

private var lastClickTime:float=0;
var click:AudioClip;
var parentName: String;

var catchTime:float;

function Start () {
parentName = transform.parent.name;
}

function Update () {
//Debug.Log(score_count.move_slots.Count);
}

function OnMouseDown () {
		
if(Input.GetButtonDown("Fire1")){
if(Time.time-lastClickTime<1){
rigidbody.useGravity = true;
rigidbody.isKinematic = false;
//score_count.move=1;
score_count.move_slots.Add(parentName);
no_move();
audio.PlayOneShot(click);

}
lastClickTime=Time.time;
Debug.Log(lastClickTime);
}
}
function no_move(){
yield WaitForSeconds(3);
score_count.move_slots.Remove(parentName);
}