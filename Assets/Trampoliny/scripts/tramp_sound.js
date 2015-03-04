#pragma strict
var tramp:AudioClip;

function Start () {

}

function Update () {

}
function OnCollisionEnter (collision:Collision){
audio.PlayOneShot(tramp);

}