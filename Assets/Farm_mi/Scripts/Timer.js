#pragma strict
static var timeLeft = 60.0;
var timer: GameObject;

var apple_summary:GameObject;
var strawberry_summary:GameObject;
var peach_summary:GameObject;
var blackberry_summary:GameObject;
var raspberry_summary:GameObject;
var blueberry_summary:GameObject;
var total_points:GameObject;
var flag:int;

function Start () {
 
 timeLeft=60.0;
 flag=1;
    
}

function Update () {
    timeLeft -= Time.deltaTime;
    timer.GetComponent.<UI.Text>().text=timeLeft.ToString("0"); 
    if(timeLeft<0){
    	timer.GetComponent.<UI.Text>().text="0";
    	total();
    	}   	
    
    
}

function total(){
	if(flag==1){
	if(Game.fru==1){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=Game.score_summary.ToString();apple_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Apple",PlayerPrefs.GetInt("GamePoints_Apple")+Game.score_summary);
	}
	if(Game.fru==2){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=Game.score_summary.ToString();strawberry_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Strawberry",PlayerPrefs.GetInt("GamePoints_Strawberry")+Game.score_summary);
	}
	if(Game.fru==3){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=Game.score_summary.ToString();peach_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Peach",PlayerPrefs.GetInt("GamePoints_Peach")+Game.score_summary);
	}
	if(Game.fru==4){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=Game.score_summary.ToString();blackberry_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Blackberry",PlayerPrefs.GetInt("GamePoints_Blackberry")+Game.score_summary);
	}
	if(Game.fru==5){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=Game.score_summary.ToString();raspberry_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Raspberry",PlayerPrefs.GetInt("GamePoints_Raspberry")+Game.score_summary);
	}
	if(Game.fru==6){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=Game.score_summary.ToString();blueberry_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Blueberry",PlayerPrefs.GetInt("GamePoints_Blueberry")+Game.score_summary);
	}
	flag=0;
	}
	PlayerPrefs.Save();
	
}