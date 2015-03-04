#pragma strict
static var level:int;
static var level_2_wrong_icon:int;
static var level_3_1:int;
static var level_3_2:int;
static var level_3_3:int;
static var level_3_array:Array;
static var level_3_pattern:Array;
var next:GameObject;


function Start () {
Physics.gravity = Vector3(0, -50.0, 0);
level_3_array=new Array();
level_3_pattern=new Array();
level_2_wrong_icon=Random.Range(1,4);
level_3_1=Random.Range(1,4);
if(level_3_1==1){level_3_2=3;level_3_3=2;}
if(level_3_1==2){level_3_2=1;level_3_3=3;}
if(level_3_1==3){level_3_2=2;level_3_3=1;}
fruit_pattern();

}

function Update () {
if (Input.GetKey ("q")||PlayerPrefs.GetInt("Difficulty")==1){level=1;}
if (Input.GetKey ("w")||PlayerPrefs.GetInt("Difficulty")==2){level=2;next.SetActive(true);}
if (Input.GetKey ("e")||PlayerPrefs.GetInt("Difficulty")==3){level=3;next.SetActive(true);}

}

function fruit_pattern(){
level_3_pattern[0]=level_3_1;
level_3_pattern[1]=level_3_2;
level_3_pattern[2]=level_3_3;
level_3_pattern[3]=level_3_1;
level_3_pattern[4]=level_3_2;
level_3_pattern[5]=level_3_3;
level_3_pattern[6]=level_3_1;
level_3_pattern[7]=level_3_2;
level_3_pattern[8]=level_3_3;
level_3_pattern[9]=level_3_1;
level_3_pattern[10]=level_3_2;
level_3_pattern[11]=level_3_3;
level_3_pattern[12]=level_3_1;
level_3_pattern[13]=level_3_2;
level_3_pattern[14]=level_3_3;
level_3_pattern[15]=level_3_1;
level_3_pattern[16]=level_3_2;
level_3_pattern[17]=level_3_3;
level_3_pattern[18]=level_3_1;
level_3_pattern[19]=level_3_2;

}