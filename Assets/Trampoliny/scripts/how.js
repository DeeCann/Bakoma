#pragma strict
var maska:GameObject;
var slots: GameObject;
var box: GameObject;
var tramp: GameObject;
var lejek: GameObject;
var timer: GameObject;
var apple_2:GameObject;
var strawberry_2:GameObject;
var peach_2:GameObject;
var blackberry_2:GameObject;
var raspberry_2:GameObject;
var blueberry_2:GameObject;
var apple_3:GameObject;
var strawberry_3:GameObject;
var peach_3:GameObject;
var blackberry_3:GameObject;
var raspberry_3:GameObject;
var blueberry_3:GameObject;
var przeszkody:GameObject;
var tekst:GameObject;

function Start () {

}

function Update () {

}
function OnMouseDown(){

if(this.gameObject.name=="how1"){
	maska.SetActive(false);
	tekst.SetActive(false);
}

if(this.gameObject.name=="how3"){
	slots.SetActive(true);
	box.SetActive(true);
	tramp.SetActive(true);
	lejek.SetActive(true);
	timer.SetActive(true);
	przeszkody.SetActive(true);
	instruction();
	this.gameObject.SetActive(false);
	}else this.gameObject.active=false;
}

function instruction(){
	if(level.level==1){return;}
	if(level.level==2){
		if(choos_fruit.fruit==1){apple_2.SetActive(true);}
		if(choos_fruit.fruit==2){strawberry_2.SetActive(true);}
		if(choos_fruit.fruit==3){peach_2.SetActive(true);}
		if(choos_fruit.fruit==4){blackberry_2.SetActive(true);}
		if(choos_fruit.fruit==5){raspberry_2.SetActive(true);}
		if(choos_fruit.fruit==6){blueberry_2.SetActive(true);}
		}
	if(level.level==3){
		if(choos_fruit.fruit==1){apple_3.SetActive(true);}
		if(choos_fruit.fruit==2){strawberry_3.SetActive(true);}
		if(choos_fruit.fruit==3){peach_3.SetActive(true);}
		if(choos_fruit.fruit==4){blackberry_3.SetActive(true);}
		if(choos_fruit.fruit==5){raspberry_3.SetActive(true);}
		if(choos_fruit.fruit==6){blueberry_3.SetActive(true);}
		}
}