#pragma strict

 static var timeLeft = 60.0;
 var timer: GameObject;
 var sloty: GameObject;
 var complete: AudioClip;
 var audio_on: int;
 var apple_summary: GameObject;
 var strawberry_summary: GameObject; 
 var peach_summary: GameObject;
 var blackberry_summary: GameObject;
 var raspberry_summary: GameObject;
 var blueberry_summary: GameObject;
 var total_points: GameObject;
 var flag: int;
  
 function Start (){
 audio_on=1;
 timeLeft=60.0;
 flag=1;
 }

function Update(){
    timeLeft -= Time.deltaTime;
    timer.GetComponent.<UI.Text>().text=timeLeft.ToString("0"); 
    if(timeLeft<0){
    	timer.GetComponent.<UI.Text>().text="0";
    	
    	total();
    	sloty.SetActive(false);
    	if(audio_on){audio.PlayOneShot(complete);audio_on=0;}   	
    }
    if(score_count.all_fruit==fruitgenerator.rand_number){timer.GetComponent.<UI.Text>().text="0";total();}
}
function total(){
	if(flag==1){
	if(choos_fruit.fruit==1){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=score_count.score_total.ToString();apple_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Apple",PlayerPrefs.GetInt("GamePoints_Apple")+score_count.score_total);
	}
	if(choos_fruit.fruit==2){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=score_count.score_total.ToString();strawberry_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Strawberry",PlayerPrefs.GetInt("GamePoints_Strawberry")+score_count.score_total);
	}
	if(choos_fruit.fruit==3){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=score_count.score_total.ToString();peach_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Peach",PlayerPrefs.GetInt("GamePoints_Peach")+score_count.score_total);
	}
	if(choos_fruit.fruit==4){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=score_count.score_total.ToString();blackberry_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Blackberry",PlayerPrefs.GetInt("GamePoints_Blackberry")+score_count.score_total);
	}
	if(choos_fruit.fruit==5){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=score_count.score_total.ToString();raspberry_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Raspberry",PlayerPrefs.GetInt("GamePoints_Raspberry")+score_count.score_total);
	}
	if(choos_fruit.fruit==6){
	total_points.SetActive(true);total_points.GetComponent.<UI.Text>().text=score_count.score_total.ToString();blueberry_summary.SetActive(true);
	PlayerPrefs.SetInt("GamePoints_Blueberry",PlayerPrefs.GetInt("GamePoints_Blueberry")+score_count.score_total);
	}
	flag=0;
	}
	PlayerPrefs.Save();
}