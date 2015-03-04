#pragma strict
var next: GameObject;
var apple: GameObject;
var strawberry: GameObject;
var peach: GameObject;
var blackberry: GameObject;
var raspberry: GameObject;
var blueberry: GameObject;
var l_kolko:GameObject;
var l_kwadrat:GameObject;
var l_trojkat:GameObject;
var s_kolko:GameObject;
var s_kwadrat:GameObject;
var s_trojkat:GameObject;
var p_kolko:GameObject;
var p_kwadrat:GameObject;
var p_trojkat:GameObject;
var apple_score1:GameObject;
var apple_score2:GameObject;
var apple_score3:GameObject;
var strawberry_score1:GameObject;
var strawberry_score2:GameObject;
var strawberry_score3:GameObject;
var peach_score1:GameObject;
var peach_score2:GameObject;
var peach_score3:GameObject;
var blackberry_score1:GameObject;
var blackberry_score2:GameObject;
var blackberry_score3:GameObject;
var raspberry_score1:GameObject;
var raspberry_score2:GameObject;
var raspberry_score3:GameObject;
var blueberry_score1:GameObject;
var blueberry_score2:GameObject;
var blueberry_score3:GameObject;

function Start () {

}

function Update () {
if(level.level==2){next.SetActive(true);symbols_2();}

if(choos_fruit.fruit==1&&level.level==3){next.SetActive(true);apple.SetActive(true);symbols();fruit(1);}
if(choos_fruit.fruit==2&&level.level==3){next.SetActive(true);strawberry.SetActive(true);symbols();fruit(2);}
if(choos_fruit.fruit==3&&level.level==3){next.SetActive(true);peach.SetActive(true);symbols();fruit(3);}
if(choos_fruit.fruit==4&&level.level==3){next.SetActive(true);blackberry.SetActive(true);symbols();fruit(4);}
if(choos_fruit.fruit==5&&level.level==3){next.SetActive(true);raspberry.SetActive(true);symbols();fruit(5);}
if(choos_fruit.fruit==6&&level.level==3){next.SetActive(true);blueberry.SetActive(true);symbols();fruit(6);}
}

function symbols_2(){
if(level.level_2_wrong_icon==1){l_kwadrat.SetActive(true);p_trojkat.SetActive(true);}
if(level.level_2_wrong_icon==2){l_kolko.SetActive(true);p_trojkat.SetActive(true);}
if(level.level_2_wrong_icon==3){l_kwadrat.SetActive(true);p_kolko.SetActive(true);}
}

function symbols(){
if(level.level_3_1==1){l_kolko.SetActive(true);}
if(level.level_3_1==2){l_kwadrat.SetActive(true);}
if(level.level_3_1==3){l_trojkat.SetActive(true);}
if(level.level_3_2==1){s_kolko.SetActive(true);}
if(level.level_3_2==2){s_kwadrat.SetActive(true);}
if(level.level_3_2==3){s_trojkat.SetActive(true);}
if(level.level_3_3==1){p_kolko.SetActive(true);}
if(level.level_3_3==2){p_kwadrat.SetActive(true);}
if(level.level_3_3==3){p_trojkat.SetActive(true);}
}

function fruit(fruit:int){
if(fruit==1){
	if(score_count.good_points==0){apple_score1.SetActive(true);apple_score2.SetActive(false);apple_score3.SetActive(false);}
	if(score_count.good_points==1){apple_score1.SetActive(false);apple_score2.SetActive(true);apple_score3.SetActive(false);}
	if(score_count.good_points==2){apple_score1.SetActive(false);apple_score2.SetActive(false);apple_score3.SetActive(true);}
	if(score_count.good_points==3){apple_score1.SetActive(true);apple_score2.SetActive(false);apple_score3.SetActive(false);}
	if(score_count.good_points==4){apple_score1.SetActive(false);apple_score2.SetActive(true);apple_score3.SetActive(false);}
	if(score_count.good_points==5){apple_score1.SetActive(false);apple_score2.SetActive(false);apple_score3.SetActive(true);}
	if(score_count.good_points==6){apple_score1.SetActive(true);apple_score2.SetActive(false);apple_score3.SetActive(false);}
	if(score_count.good_points==7){apple_score1.SetActive(false);apple_score2.SetActive(true);apple_score3.SetActive(false);}
	if(score_count.good_points==8){apple_score1.SetActive(false);apple_score2.SetActive(false);apple_score3.SetActive(true);}
	if(score_count.good_points==9){apple_score1.SetActive(true);apple_score2.SetActive(false);apple_score3.SetActive(false);}
	if(score_count.good_points==10){apple_score1.SetActive(false);apple_score2.SetActive(true);apple_score3.SetActive(false);}
	if(score_count.good_points==11){apple_score1.SetActive(false);apple_score2.SetActive(false);apple_score3.SetActive(true);}
	if(score_count.good_points==12){apple_score1.SetActive(true);apple_score2.SetActive(false);apple_score3.SetActive(false);}
	if(score_count.good_points==13){apple_score1.SetActive(false);apple_score2.SetActive(true);apple_score3.SetActive(false);}
	if(score_count.good_points==14){apple_score1.SetActive(false);apple_score2.SetActive(false);apple_score3.SetActive(true);}
	if(score_count.good_points==15){apple_score1.SetActive(true);apple_score2.SetActive(false);apple_score3.SetActive(false);}
	if(score_count.good_points==16){apple_score1.SetActive(false);apple_score2.SetActive(true);apple_score3.SetActive(false);}
	if(score_count.good_points==17){apple_score1.SetActive(false);apple_score2.SetActive(false);apple_score3.SetActive(true);}
	if(score_count.good_points==18){apple_score1.SetActive(true);apple_score2.SetActive(false);apple_score3.SetActive(false);}
	if(score_count.good_points==19){apple_score1.SetActive(false);apple_score2.SetActive(true);apple_score3.SetActive(false);}
	}
if(fruit==2){
	if(score_count.good_points==0){strawberry_score1.SetActive(true);strawberry_score2.SetActive(false);strawberry_score3.SetActive(false);}
	if(score_count.good_points==1){strawberry_score1.SetActive(false);strawberry_score2.SetActive(true);strawberry_score3.SetActive(false);}
	if(score_count.good_points==2){strawberry_score1.SetActive(false);strawberry_score2.SetActive(false);strawberry_score3.SetActive(true);}
	if(score_count.good_points==3){strawberry_score1.SetActive(true);strawberry_score2.SetActive(false);strawberry_score3.SetActive(false);}
	if(score_count.good_points==4){strawberry_score1.SetActive(false);strawberry_score2.SetActive(true);strawberry_score3.SetActive(false);}
	if(score_count.good_points==5){strawberry_score1.SetActive(false);strawberry_score2.SetActive(false);strawberry_score3.SetActive(true);}
	if(score_count.good_points==6){strawberry_score1.SetActive(true);strawberry_score2.SetActive(false);strawberry_score3.SetActive(false);}
	if(score_count.good_points==7){strawberry_score1.SetActive(false);strawberry_score2.SetActive(true);strawberry_score3.SetActive(false);}
	if(score_count.good_points==8){strawberry_score1.SetActive(false);strawberry_score2.SetActive(false);strawberry_score3.SetActive(true);}
	if(score_count.good_points==9){strawberry_score1.SetActive(true);strawberry_score2.SetActive(false);strawberry_score3.SetActive(false);}
	if(score_count.good_points==10){strawberry_score1.SetActive(false);strawberry_score2.SetActive(true);strawberry_score3.SetActive(false);}
	if(score_count.good_points==11){strawberry_score1.SetActive(false);strawberry_score2.SetActive(false);strawberry_score3.SetActive(true);}
	if(score_count.good_points==12){strawberry_score1.SetActive(true);strawberry_score2.SetActive(false);strawberry_score3.SetActive(false);}
	if(score_count.good_points==13){strawberry_score1.SetActive(false);strawberry_score2.SetActive(true);strawberry_score3.SetActive(false);}
	if(score_count.good_points==14){strawberry_score1.SetActive(false);strawberry_score2.SetActive(false);strawberry_score3.SetActive(true);}
	if(score_count.good_points==15){strawberry_score1.SetActive(true);strawberry_score2.SetActive(false);strawberry_score3.SetActive(false);}
	if(score_count.good_points==16){strawberry_score1.SetActive(false);strawberry_score2.SetActive(true);strawberry_score3.SetActive(false);}
	if(score_count.good_points==17){strawberry_score1.SetActive(false);strawberry_score2.SetActive(false);strawberry_score3.SetActive(true);}
	if(score_count.good_points==18){strawberry_score1.SetActive(true);strawberry_score2.SetActive(false);strawberry_score3.SetActive(false);}
	if(score_count.good_points==19){strawberry_score1.SetActive(false);strawberry_score2.SetActive(true);strawberry_score3.SetActive(false);}
	}
if(fruit==3){
	if(score_count.good_points==0){peach_score1.SetActive(true);peach_score2.SetActive(false);peach_score3.SetActive(false);}
	if(score_count.good_points==1){peach_score1.SetActive(false);peach_score2.SetActive(true);peach_score3.SetActive(false);}
	if(score_count.good_points==2){peach_score1.SetActive(false);peach_score2.SetActive(false);peach_score3.SetActive(true);}
	if(score_count.good_points==3){peach_score1.SetActive(true);peach_score2.SetActive(false);peach_score3.SetActive(false);}
	if(score_count.good_points==4){peach_score1.SetActive(false);peach_score2.SetActive(true);peach_score3.SetActive(false);}
	if(score_count.good_points==5){peach_score1.SetActive(false);peach_score2.SetActive(false);peach_score3.SetActive(true);}
	if(score_count.good_points==6){peach_score1.SetActive(true);peach_score2.SetActive(false);peach_score3.SetActive(false);}
	if(score_count.good_points==7){peach_score1.SetActive(false);peach_score2.SetActive(true);peach_score3.SetActive(false);}
	if(score_count.good_points==8){peach_score1.SetActive(false);peach_score2.SetActive(false);peach_score3.SetActive(true);}
	if(score_count.good_points==9){peach_score1.SetActive(true);peach_score2.SetActive(false);peach_score3.SetActive(false);}
	if(score_count.good_points==10){peach_score1.SetActive(false);peach_score2.SetActive(true);peach_score3.SetActive(false);}
	if(score_count.good_points==11){peach_score1.SetActive(false);peach_score2.SetActive(false);peach_score3.SetActive(true);}
	if(score_count.good_points==12){peach_score1.SetActive(true);peach_score2.SetActive(false);peach_score3.SetActive(false);}
	if(score_count.good_points==13){peach_score1.SetActive(false);peach_score2.SetActive(true);peach_score3.SetActive(false);}
	if(score_count.good_points==14){peach_score1.SetActive(false);peach_score2.SetActive(false);peach_score3.SetActive(true);}
	if(score_count.good_points==15){peach_score1.SetActive(true);peach_score2.SetActive(false);peach_score3.SetActive(false);}
	if(score_count.good_points==16){peach_score1.SetActive(false);peach_score2.SetActive(true);peach_score3.SetActive(false);}
	if(score_count.good_points==17){peach_score1.SetActive(false);peach_score2.SetActive(false);peach_score3.SetActive(true);}
	if(score_count.good_points==18){peach_score1.SetActive(true);peach_score2.SetActive(false);peach_score3.SetActive(false);}
	if(score_count.good_points==19){peach_score1.SetActive(false);peach_score2.SetActive(true);peach_score3.SetActive(false);}
	}
if(fruit==4){
	if(score_count.good_points==0){blackberry_score1.SetActive(true);blackberry_score2.SetActive(false);blackberry_score3.SetActive(false);}
	if(score_count.good_points==1){blackberry_score1.SetActive(false);blackberry_score2.SetActive(true);blackberry_score3.SetActive(false);}
	if(score_count.good_points==2){blackberry_score1.SetActive(false);blackberry_score2.SetActive(false);blackberry_score3.SetActive(true);}
	if(score_count.good_points==3){blackberry_score1.SetActive(true);blackberry_score2.SetActive(false);blackberry_score3.SetActive(false);}
	if(score_count.good_points==4){blackberry_score1.SetActive(false);blackberry_score2.SetActive(true);blackberry_score3.SetActive(false);}
	if(score_count.good_points==5){blackberry_score1.SetActive(false);blackberry_score2.SetActive(false);blackberry_score3.SetActive(true);}
	if(score_count.good_points==6){blackberry_score1.SetActive(true);blackberry_score2.SetActive(false);blackberry_score3.SetActive(false);}
	if(score_count.good_points==7){blackberry_score1.SetActive(false);blackberry_score2.SetActive(true);blackberry_score3.SetActive(false);}
	if(score_count.good_points==8){blackberry_score1.SetActive(false);blackberry_score2.SetActive(false);blackberry_score3.SetActive(true);}
	if(score_count.good_points==9){blackberry_score1.SetActive(true);blackberry_score2.SetActive(false);blackberry_score3.SetActive(false);}
	if(score_count.good_points==10){blackberry_score1.SetActive(false);blackberry_score2.SetActive(true);blackberry_score3.SetActive(false);}
	if(score_count.good_points==11){blackberry_score1.SetActive(false);blackberry_score2.SetActive(false);blackberry_score3.SetActive(true);}
	if(score_count.good_points==12){blackberry_score1.SetActive(true);blackberry_score2.SetActive(false);blackberry_score3.SetActive(false);}
	if(score_count.good_points==13){blackberry_score1.SetActive(false);blackberry_score2.SetActive(true);blackberry_score3.SetActive(false);}
	if(score_count.good_points==14){blackberry_score1.SetActive(false);blackberry_score2.SetActive(false);blackberry_score3.SetActive(true);}
	if(score_count.good_points==15){blackberry_score1.SetActive(true);blackberry_score2.SetActive(false);blackberry_score3.SetActive(false);}
	if(score_count.good_points==16){blackberry_score1.SetActive(false);blackberry_score2.SetActive(true);blackberry_score3.SetActive(false);}
	if(score_count.good_points==17){blackberry_score1.SetActive(false);blackberry_score2.SetActive(false);blackberry_score3.SetActive(true);}
	if(score_count.good_points==18){blackberry_score1.SetActive(true);blackberry_score2.SetActive(false);blackberry_score3.SetActive(false);}
	if(score_count.good_points==19){blackberry_score1.SetActive(false);blackberry_score2.SetActive(true);blackberry_score3.SetActive(false);}
	}
if(fruit==5){
	if(score_count.good_points==0){raspberry_score1.SetActive(true);raspberry_score2.SetActive(false);raspberry_score3.SetActive(false);}
	if(score_count.good_points==1){raspberry_score1.SetActive(false);raspberry_score2.SetActive(true);raspberry_score3.SetActive(false);}
	if(score_count.good_points==2){raspberry_score1.SetActive(false);raspberry_score2.SetActive(false);raspberry_score3.SetActive(true);}
	if(score_count.good_points==3){raspberry_score1.SetActive(true);raspberry_score2.SetActive(false);raspberry_score3.SetActive(false);}
	if(score_count.good_points==4){raspberry_score1.SetActive(false);raspberry_score2.SetActive(true);raspberry_score3.SetActive(false);}
	if(score_count.good_points==5){raspberry_score1.SetActive(false);raspberry_score2.SetActive(false);raspberry_score3.SetActive(true);}
	if(score_count.good_points==6){raspberry_score1.SetActive(true);raspberry_score2.SetActive(false);raspberry_score3.SetActive(false);}
	if(score_count.good_points==7){raspberry_score1.SetActive(false);raspberry_score2.SetActive(true);raspberry_score3.SetActive(false);}
	if(score_count.good_points==8){raspberry_score1.SetActive(false);raspberry_score2.SetActive(false);raspberry_score3.SetActive(true);}
	if(score_count.good_points==9){raspberry_score1.SetActive(true);raspberry_score2.SetActive(false);raspberry_score3.SetActive(false);}
	if(score_count.good_points==10){raspberry_score1.SetActive(false);raspberry_score2.SetActive(true);raspberry_score3.SetActive(false);}
	if(score_count.good_points==11){raspberry_score1.SetActive(false);raspberry_score2.SetActive(false);raspberry_score3.SetActive(true);}
	if(score_count.good_points==12){raspberry_score1.SetActive(true);raspberry_score2.SetActive(false);raspberry_score3.SetActive(false);}
	if(score_count.good_points==13){raspberry_score1.SetActive(false);raspberry_score2.SetActive(true);raspberry_score3.SetActive(false);}
	if(score_count.good_points==14){raspberry_score1.SetActive(false);raspberry_score2.SetActive(false);raspberry_score3.SetActive(true);}
	if(score_count.good_points==15){raspberry_score1.SetActive(true);raspberry_score2.SetActive(false);raspberry_score3.SetActive(false);}
	if(score_count.good_points==16){raspberry_score1.SetActive(false);raspberry_score2.SetActive(true);raspberry_score3.SetActive(false);}
	if(score_count.good_points==17){raspberry_score1.SetActive(false);raspberry_score2.SetActive(false);raspberry_score3.SetActive(true);}
	if(score_count.good_points==18){raspberry_score1.SetActive(true);raspberry_score2.SetActive(false);raspberry_score3.SetActive(false);}
	if(score_count.good_points==19){raspberry_score1.SetActive(false);raspberry_score2.SetActive(true);raspberry_score3.SetActive(false);}
	}
if(fruit==6){
	if(score_count.good_points==0){blueberry_score1.SetActive(true);blueberry_score2.SetActive(false);blueberry_score3.SetActive(false);}
	if(score_count.good_points==1){blueberry_score1.SetActive(false);blueberry_score2.SetActive(true);blueberry_score3.SetActive(false);}
	if(score_count.good_points==2){blueberry_score1.SetActive(false);blueberry_score2.SetActive(false);blueberry_score3.SetActive(true);}
	if(score_count.good_points==3){blueberry_score1.SetActive(true);blueberry_score2.SetActive(false);blueberry_score3.SetActive(false);}
	if(score_count.good_points==4){blueberry_score1.SetActive(false);blueberry_score2.SetActive(true);blueberry_score3.SetActive(false);}
	if(score_count.good_points==5){blueberry_score1.SetActive(false);blueberry_score2.SetActive(false);blueberry_score3.SetActive(true);}
	if(score_count.good_points==6){blueberry_score1.SetActive(true);blueberry_score2.SetActive(false);blueberry_score3.SetActive(false);}
	if(score_count.good_points==7){blueberry_score1.SetActive(false);blueberry_score2.SetActive(true);blueberry_score3.SetActive(false);}
	if(score_count.good_points==8){blueberry_score1.SetActive(false);blueberry_score2.SetActive(false);blueberry_score3.SetActive(true);}
	if(score_count.good_points==9){blueberry_score1.SetActive(true);blueberry_score2.SetActive(false);blueberry_score3.SetActive(false);}
	if(score_count.good_points==10){blueberry_score1.SetActive(false);blueberry_score2.SetActive(true);blueberry_score3.SetActive(false);}
	if(score_count.good_points==11){blueberry_score1.SetActive(false);blueberry_score2.SetActive(false);blueberry_score3.SetActive(true);}
	if(score_count.good_points==12){blueberry_score1.SetActive(true);blueberry_score2.SetActive(false);blueberry_score3.SetActive(false);}
	if(score_count.good_points==13){blueberry_score1.SetActive(false);blueberry_score2.SetActive(true);blueberry_score3.SetActive(false);}
	if(score_count.good_points==14){blueberry_score1.SetActive(false);blueberry_score2.SetActive(false);blueberry_score3.SetActive(true);}
	if(score_count.good_points==15){blueberry_score1.SetActive(true);blueberry_score2.SetActive(false);blueberry_score3.SetActive(false);}
	if(score_count.good_points==16){blueberry_score1.SetActive(false);blueberry_score2.SetActive(true);blueberry_score3.SetActive(false);}
	if(score_count.good_points==17){blueberry_score1.SetActive(false);blueberry_score2.SetActive(false);blueberry_score3.SetActive(true);}
	if(score_count.good_points==18){blueberry_score1.SetActive(true);blueberry_score2.SetActive(false);blueberry_score3.SetActive(false);}
	if(score_count.good_points==19){blueberry_score1.SetActive(false);blueberry_score2.SetActive(true);blueberry_score3.SetActive(false);}
	}
}