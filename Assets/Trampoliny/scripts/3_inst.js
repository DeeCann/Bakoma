#pragma strict
var l_kolko:GameObject;
var l_kwadrat:GameObject;
var l_trojkat:GameObject;
var s_kolko:GameObject;
var s_kwadrat:GameObject;
var s_trojkat:GameObject;
var p_kolko:GameObject;
var p_kwadrat:GameObject;
var p_trojkat:GameObject;

function Start () {
if(level.level_3_1==1){l_kolko.SetActive(true);}
if(level.level_3_1==2){l_kwadrat.SetActive(true);}
if(level.level_3_1==3){l_trojkat.SetActive(true);}
if(level.level_3_2==1){s_kolko.SetActive(true);}
if(level.level_3_2==2){s_kwadrat.SetActive(true);}
if(level.level_3_2==3){s_trojkat.SetActive(true);}
if(level.level_3_3==1){p_kolko.SetActive(true);}
if(level.level_3_3==2){p_kwadrat.SetActive(true);}
if(level.level_3_3==3){p_trojkat.SetActive(true);}
yield WaitForSeconds(3);
this.gameObject.SetActive(false);
}

function Update () {
}