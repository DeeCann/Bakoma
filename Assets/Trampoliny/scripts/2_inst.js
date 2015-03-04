#pragma strict
var l_kolko:GameObject;
var l_kwadrat:GameObject;
var l_trojkat:GameObject;
var p_kolko:GameObject;
var p_kwadrat:GameObject;
var p_trojkat:GameObject;

function Start () {
if(level.level_2_wrong_icon==1){l_kwadrat.SetActive(true);p_trojkat.SetActive(true);}
if(level.level_2_wrong_icon==2){l_kolko.SetActive(true);p_trojkat.SetActive(true);}
if(level.level_2_wrong_icon==3){l_kwadrat.SetActive(true);p_kolko.SetActive(true);}
yield WaitForSeconds(3);
this.gameObject.SetActive(false);
}

function Update () {

}