#pragma strict

var one: GameObject;
var two: GameObject;
var flag: float;
var side: int;

function Start () {
flag=4;
side=0;
}

function Update () {
flag-=Time.deltaTime;
if(flag<0){
	flag=4;
	side++;
	}
if(side>1){side=0;}

if(side==0){
//one.GetComponent(SpriteRenderer).color=new Color(1f,1f,1f,flag);
//two.GetComponent(SpriteRenderer).color=new Color(1f,1f,1f,1-flag);
one.GetComponent(SpriteRenderer).color=new Color(1f,1f,1f,0);
two.GetComponent(SpriteRenderer).color=new Color(1f,1f,1f,1);

}
if(side==1){
//one.GetComponent(SpriteRenderer).color=new Color(1f,1f,1f,1-flag);
//two.GetComponent(SpriteRenderer).color=new Color(1f,1f,1f,flag);
one.GetComponent(SpriteRenderer).color=new Color(1f,1f,1f,1);
two.GetComponent(SpriteRenderer).color=new Color(1f,1f,1f,0);
}
}

