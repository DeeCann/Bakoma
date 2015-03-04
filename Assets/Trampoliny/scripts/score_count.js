#pragma strict
static var score_total: int;
var score_view:GameObject;
static var move: int;
static var move_slots = new List.<String>();
static var good_points: int;
var apple2: GameObject;
var strawberry2: GameObject;
var peach2: GameObject;
var blackberry2: GameObject;
var raspberry2: GameObject;
var blueberry2: GameObject;
var apple1: GameObject;
var strawberry1: GameObject;
var peach1: GameObject;
var blackberry1: GameObject;
var raspberry1: GameObject;
var blueberry1: GameObject;
static var bonus: int;
static var all_fruit: int;
//var score_txt: string;


function Start () {
all_fruit=0;
bonus=0;
move=0;
score_total=0;
good_points=0;

}

function Update () {
score_view.GetComponent.<UI.Text>().text=score_total.ToString();

if(good_points==5&&level.level==2){
	if(choos_fruit.fruit==1){bonus1(1);}
	if(choos_fruit.fruit==2){bonus1(2);}
	if(choos_fruit.fruit==3){bonus1(3);}
	if(choos_fruit.fruit==4){bonus1(4);}
	if(choos_fruit.fruit==5){bonus1(5);}
	if(choos_fruit.fruit==6){bonus1(6);}
	}
if(good_points==10&&level.level==2){
	if(choos_fruit.fruit==1){bonus2(1);}
	if(choos_fruit.fruit==2){bonus2(2);}
	if(choos_fruit.fruit==3){bonus2(3);}
	if(choos_fruit.fruit==4){bonus2(4);}
	if(choos_fruit.fruit==5){bonus2(5);}
	if(choos_fruit.fruit==6){bonus2(6);}
	}
if(good_points==6&&level.level==3){
	if(choos_fruit.fruit==1){bonus1(1);}
	if(choos_fruit.fruit==2){bonus1(2);}
	if(choos_fruit.fruit==3){bonus1(3);}
	if(choos_fruit.fruit==4){bonus1(4);}
	if(choos_fruit.fruit==5){bonus1(5);}
	if(choos_fruit.fruit==6){bonus1(6);}
	}
if(good_points==9&&level.level==3){
	if(choos_fruit.fruit==1){bonus2(1);}
	if(choos_fruit.fruit==2){bonus2(2);}
	if(choos_fruit.fruit==3){bonus2(3);}
	if(choos_fruit.fruit==4){bonus2(4);}
	if(choos_fruit.fruit==5){bonus2(5);}
	if(choos_fruit.fruit==6){bonus2(6);}
	}

}
function bonus2(fruit: int){
	if(fruit==1&&bonus==0){apple2.SetActive(true);score_total=score_total+2;bonus=1;yield WaitForSeconds(1);apple2.SetActive(false);}
	if(fruit==2&&bonus==0){strawberry2.SetActive(true);score_total=score_total+2;bonus=1;yield WaitForSeconds(1);strawberry2.SetActive(false);}
	if(fruit==3&&bonus==0){peach2.SetActive(true);score_total=score_total+2;bonus=1;yield WaitForSeconds(1);peach2.SetActive(false);}
	if(fruit==4&&bonus==0){blackberry2.SetActive(true);score_total=score_total+2;bonus=1;yield WaitForSeconds(1);blackberry2.SetActive(false);}
	if(fruit==5&&bonus==0){raspberry2.SetActive(true);score_total=score_total+2;bonus=1;yield WaitForSeconds(1);raspberry2.SetActive(false);}
	if(fruit==6&&bonus==0){blueberry2.SetActive(true);score_total=score_total+2;bonus=1;yield WaitForSeconds(1);blueberry2.SetActive(false);}
}
function bonus1(fruit: int){
	if(fruit==1&&bonus==0){apple1.SetActive(true);score_total++;bonus=1;yield WaitForSeconds(1);apple1.SetActive(false);}
	if(fruit==2&&bonus==0){strawberry1.SetActive(true);score_total++;bonus=1;yield WaitForSeconds(1);strawberry1.SetActive(false);}
	if(fruit==3&&bonus==0){peach1.SetActive(true);score_total++;bonus=1;yield WaitForSeconds(1);peach1.SetActive(false);}
	if(fruit==4&&bonus==0){blackberry1.SetActive(true);score_total=score_total+1;bonus=1;yield WaitForSeconds(1);blackberry1.SetActive(false);}
	if(fruit==5&&bonus==0){raspberry1.SetActive(true);score_total=score_total+1;bonus=1;yield WaitForSeconds(1);raspberry1.SetActive(false);}
	if(fruit==6&&bonus==0){blueberry1.SetActive(true);score_total=score_total+1;bonus=1;yield WaitForSeconds(1);blueberry1.SetActive(false);}
}

