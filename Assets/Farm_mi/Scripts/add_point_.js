#pragma strict
var Sound: GameObject;

function Start () {

}

function Update () {

}
function OnTriggerEnter(coll:Collider){
if(coll.tag == "Player"){
Game.score_summary++;
Sound.audio.Play();
}
}