#pragma strict
var lejek:AudioClip;

function Start () {

}

function Update () {

}
function OnCollisionEnter (collision:Collision){
audio.PlayOneShot(lejek);

}