#pragma strict
var outbox: AudioClip;

function Start () {

}

function Update () {

}

function OnCollisionEnter (collision:Collision){
audio.PlayOneShot(outbox);
score_count.move=0;
}