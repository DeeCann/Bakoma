#pragma strict
var maska_1: GameObject;
var maska_2: GameObject;
var timer: GameObject;

function Start () {

}

function Update () {

}

function OnMouseDown(){
if(this.gameObject.name=="1-pc"){
	maska_1.SetActive(false);
	maska_2.SetActive(true);
}
if(this.gameObject.name=="2-pc"){
	maska_2.SetActive(false);
	timer.SetActive(true);
}
}