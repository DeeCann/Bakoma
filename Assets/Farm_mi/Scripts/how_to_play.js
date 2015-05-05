#pragma strict
var maska: GameObject;
var timer: GameObject;

function Start () {

}

function Update () {

}

function OnMouseDown(){
if(this.gameObject.name=="1-pc"){
	maska.SetActive(false);
}
if(this.gameObject.name=="2-pc"){
	maska.SetActive(false);
	timer.SetActive(true);
}
}