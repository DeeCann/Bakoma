#pragma strict

function Start () {

}

function Update () {

}

function OnMouseDown(){

PlayerPrefs.SetString("LoadLevelName", "Game_Board");

Application.LoadLevel("Loader");
}