#pragma strict

import System.Collections.Generic;

var slot_0 : GameObject;
var slot_1 : GameObject;
var slot_2 : GameObject;
var slot_3 : GameObject;
var slot_4 : GameObject;
var slot_5 : GameObject;
var slot_6 : GameObject;
var slot_7 : GameObject;
var slot_8 : GameObject;
var slot_9 : GameObject;
var slot_10 : GameObject;
var slot_11 : GameObject;
var slot_12 : GameObject;
var slot_13 : GameObject;
var slot_14 : GameObject;
var slot_15 : GameObject;
var slot_16 : GameObject;
var slot_17 : GameObject;
var slot_18 : GameObject;
var slot_19 : GameObject;

static var rand_number: int;
var usedNumbers = new List.<int>();
var notDone: boolean=true;
var i: int;




function Start () {
i=0;
Generate();
slot_on();
}

function Update () {

}

function Generate(){
rand_number=Random.Range(10,16);

while(notDone){
	if(usedNumbers.Count>=rand_number-1){

	 	notDone=false;
	}
 	var newNumber: int=Random.Range(0,20);
 	while(usedNumbers.Contains(newNumber)){
 		newNumber=Random.Range(0,20);
 		
 	}
 usedNumbers.Add(newNumber);
 }




for(i=0;i<usedNumbers.Count;i++){

}


}

function slot_on(){
for(i=0;i<usedNumbers.Count;i++){
	//eval("slot_"+usedNumbers[i]+".SetActive(true)");
	if(usedNumbers[i]==0){slot_0.SetActive(true);}
	if(usedNumbers[i]==1){slot_1.SetActive(true);}
	if(usedNumbers[i]==2){slot_2.SetActive(true);}
	if(usedNumbers[i]==3){slot_3.SetActive(true);}
	if(usedNumbers[i]==4){slot_4.SetActive(true);}
	if(usedNumbers[i]==5){slot_5.SetActive(true);}
	if(usedNumbers[i]==6){slot_6.SetActive(true);}
	if(usedNumbers[i]==7){slot_7.SetActive(true);}
	if(usedNumbers[i]==8){slot_8.SetActive(true);}
	if(usedNumbers[i]==9){slot_9.SetActive(true);}
	if(usedNumbers[i]==10){slot_10.SetActive(true);}
	if(usedNumbers[i]==11){slot_11.SetActive(true);}
	if(usedNumbers[i]==12){slot_12.SetActive(true);}
	if(usedNumbers[i]==13){slot_13.SetActive(true);}
	if(usedNumbers[i]==14){slot_14.SetActive(true);}
	if(usedNumbers[i]==15){slot_15.SetActive(true);}
	if(usedNumbers[i]==16){slot_16.SetActive(true);}
	if(usedNumbers[i]==17){slot_17.SetActive(true);}
	if(usedNumbers[i]==18){slot_18.SetActive(true);}
	if(usedNumbers[i]==19){slot_19.SetActive(true);}
	
}
}

