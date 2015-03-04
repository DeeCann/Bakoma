#pragma strict
var floor:GameObject;
var fruit:GameObject;
var score: int;
var level_3_fruit: int;
var parentName:String;



function Start () {
parentName = transform.parent.name;
score=0;
}

function Update () {

}

function OnCollisionEnter (collision:Collision)



{

    if(collision.collider.gameObject.name == "floor"){
    	score_count.move_slots.Remove(parentName);
    	score_count.all_fruit++;
    	if(level.level==1){
        	fruit.active=false;
       		score_count.score_total++;	
       		
        }
        if(level.level==2){
        	if(this.GetComponent(draw_symbol).symbol_out==1&&this.active==true){
        		if(this.GetComponent(draw_symbol).symbol_out!=level.level_2_wrong_icon){score_count.score_total++;score_count.good_points++;score_count.bonus=0;}else score_count.good_points=0;
        		}
        	if(this.GetComponent(draw_symbol).symbol_out==2&&this.active==true){
        		if(this.GetComponent(draw_symbol).symbol_out!=level.level_2_wrong_icon){score_count.score_total++;score_count.good_points++;score_count.bonus=0;}else score_count.good_points=0;
        		}
        	if(this.GetComponent(draw_symbol).symbol_out==3&&this.active==true){
        		if(this.GetComponent(draw_symbol).symbol_out!=level.level_2_wrong_icon){score_count.score_total++;score_count.good_points++;score_count.bonus=0;}else score_count.good_points=0;
        		}
        	fruit.active=false;
        }
        if(level.level==3){
        	if(this.GetComponent(draw_symbol).symbol_out==1&&this.active==true){
        		level_3_fruit=1;
        		level.level_3_array.Add(level_3_fruit);
        		if(level.level_3_pattern[level.level_3_array.length-1]==level_3_fruit){score_count.score_total++;score_count.good_points++;score_count.bonus=0;}else {score_count.good_points=0;level.level_3_array.Clear();}
        		}
        	if(this.GetComponent(draw_symbol).symbol_out==2&&this.active==true){
        		level_3_fruit=2;
        		level.level_3_array.Push(level_3_fruit);
        		if(level.level_3_pattern[level.level_3_array.length-1]==level_3_fruit){score_count.score_total++;score_count.good_points++;score_count.bonus=0;}else {score_count.good_points=0;level.level_3_array.Clear();}
        		}
        	if(this.GetComponent(draw_symbol).symbol_out==3&&this.active==true){
        		level_3_fruit=3;
        		level.level_3_array.Push(level_3_fruit);
        		if(level.level_3_pattern[level.level_3_array.length-1]==level_3_fruit){score_count.score_total++;score_count.good_points++;score_count.bonus=0;}else {score_count.good_points=0;level.level_3_array.Clear();}
        		}
        	fruit.active=false;
        	
        }
    }
    if(collision.collider.gameObject.name == "out_floor"){fruit.active=false;score_count.all_fruit++;score_count.move_slots.Remove(parentName);}
}
