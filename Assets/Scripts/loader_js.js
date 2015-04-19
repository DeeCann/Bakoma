#pragma strict

function Start () {
Screen.orientation = ScreenOrientation.Landscape;
loader();
}

function Update () {

}

function loader(){
yield WaitForSeconds(1);
Application.LoadLevel(PlayerPrefs.GetString("LoadLevelName"));
}