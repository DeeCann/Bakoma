#pragma strict
var modul01:GameObject;
var modul02:GameObject;
var modul03:GameObject;
var modul04:GameObject;
var modul05:GameObject;
var modul06:GameObject;
var modul07:GameObject;
var modul08:GameObject;
var modul09:GameObject;
var modul10:GameObject;

var usedNumbers = new List.<int>();
var notDone: boolean=true;


var rand_number:int;


function Start () {
generate_array();
row_modules();
}

function Update () {


}
function generate_array(){
while(notDone){
	if(usedNumbers.Count>=rand_number-1){

	 	notDone=false;
	}
 	var newNumber: int=Random.Range(1,11);
 	while(usedNumbers.Contains(newNumber)){
 		newNumber=Random.Range(1,11);
 		
 	}
 usedNumbers.Add(newNumber);
 }

for(var i:int=0;i<usedNumbers.Count;i++){
Debug.Log(usedNumbers[i]);
}
}

function row_modules(){
for(var ii:int=0;ii<usedNumbers.Count;ii++){
	if(usedNumbers[ii]==1){modul01.SetActive(true);Instantiate(modul01, Vector3(-10+10*ii,0,0),Quaternion.identity);}
	if(usedNumbers[ii]==2){modul02.SetActive(true);Instantiate(modul02, Vector3(-10+10*ii,0,0),Quaternion.identity);}
	if(usedNumbers[ii]==3){modul03.SetActive(true);Instantiate(modul03, Vector3(-10+10*ii,0,0),Quaternion.identity);}
	if(usedNumbers[ii]==4){modul04.SetActive(true);Instantiate(modul04, Vector3(-10+10*ii,0,0),Quaternion.identity);}
	if(usedNumbers[ii]==5){modul05.SetActive(true);Instantiate(modul05, Vector3(-10+10*ii,0,0),Quaternion.identity);}
	if(usedNumbers[ii]==6){modul06.SetActive(true);Instantiate(modul06, Vector3(-10+10*ii,0,0),Quaternion.identity);}
	if(usedNumbers[ii]==7){modul07.SetActive(true);Instantiate(modul07, Vector3(-10+10*ii,0,0),Quaternion.identity);}
	if(usedNumbers[ii]==8){modul08.SetActive(true);Instantiate(modul08, Vector3(-10+10*ii,0,0),Quaternion.identity);}
	if(usedNumbers[ii]==9){modul09.SetActive(true);Instantiate(modul09, Vector3(-10+10*ii,0,0),Quaternion.identity);}
	if(usedNumbers[ii]==10){modul10.SetActive(true);Instantiate(modul10, Vector3(-10+10*ii,0,0),Quaternion.identity);}
	
}
}