#pragma strict
var sound: AudioClip;

function Start () {

}

function Update () {

}
function OnTriggerEnter(coll:Collider){
if(coll.tag == "Player"){
Game.score_summary++;
audio.clip=sound;
audio.Play();
}
}