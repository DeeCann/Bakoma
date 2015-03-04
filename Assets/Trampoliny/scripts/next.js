#pragma strict
var kolko:GameObject;
var kwadrat:GameObject;
var trojkat:GameObject;

function Start () {

}

function Update () {
if(level.level==3&&level.level_3_pattern[level.level_3_array.length]==1){kolko.SetActive(true);kwadrat.SetActive(false);trojkat.SetActive(false);}
if(level.level==3&&level.level_3_pattern[level.level_3_array.length]==2){kolko.SetActive(false);kwadrat.SetActive(true);trojkat.SetActive(false);}
if(level.level==3&&level.level_3_pattern[level.level_3_array.length]==3){kolko.SetActive(false);kwadrat.SetActive(false);trojkat.SetActive(true);}
}