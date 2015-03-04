#pragma strict
var inbox:AudioClip;

function Start () {

}

function Update () {

}
function OnCollisionEnter (collision:Collision){
audio.PlayOneShot(inbox);
score_count.move=0;
}