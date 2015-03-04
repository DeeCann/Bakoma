#pragma strict
var galaz1: GameObject;
var galaz2: GameObject;
var galaz3: GameObject;

var kwiatek1: GameObject;
var kwiatek2: GameObject;
var kwiatek3: GameObject;

var obs_number: int;
var usedNumbers = new List.<int>();
var notDone: boolean=true;
var i: int;

function Start () {
obs_number=Random.Range(0,3);
i=0;
rand_obstacles();
obs_on();
}

function Update () {

}

function rand_obstacles(){
while(notDone){
	if(usedNumbers.Count>=obs_number-1){

	 	notDone=false;
	}
 	var newNumber: int=Random.Range(1,4);
 	while(usedNumbers.Contains(newNumber)){
 		newNumber=Random.Range(1,4);
 		
 	}
 usedNumbers.Add(newNumber);
 }
}

function obs_on(){
for(i=0;i<usedNumbers.Count;i++){
	if(choos_fruit.fruit==1){eval("galaz"+usedNumbers[i]+".SetActive(true)");}
	if(choos_fruit.fruit==2){eval("kwiatek"+usedNumbers[i]+".SetActive(true)");}
	if(choos_fruit.fruit==3){eval("galaz"+usedNumbers[i]+".SetActive(true)");}
	if(choos_fruit.fruit==4){eval("kwiatek"+usedNumbers[i]+".SetActive(true)");}
	if(choos_fruit.fruit==5){eval("kwiatek"+usedNumbers[i]+".SetActive(true)");}
	if(choos_fruit.fruit==6){eval("kwiatek"+usedNumbers[i]+".SetActive(true)");}
}
}