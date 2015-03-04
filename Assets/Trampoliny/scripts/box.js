#pragma strict

var box: GameObject;
var rand: float;

function Start () {
RandomPlace();
}

function Update () {

}

function RandomPlace(){
rand=Random.Range(1,11);
box.transform.position.x=-5+3.5*rand;
}