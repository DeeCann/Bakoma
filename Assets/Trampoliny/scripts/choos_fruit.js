#pragma strict
var GUI_apple:GameObject;
var GUI_strawberry: GameObject;
var GUI_peach: GameObject;
var GUI_blackberry: GameObject;
var GUI_raspberry: GameObject;
var GUI_blueberry: GameObject;
var apple_bcg: GameObject;
var strawberry_bcg: GameObject;
var peach_bcg: GameObject;
static var fruit:int;



function Start () {

}

function Update () {

if (Input.GetKey ("1")||fruit==1||PlayerPrefs.GetString("MiniGameFruit")=="Apple"){
fruit=1;apple();GUI_apple.SetActive(true);GUI_strawberry.SetActive(false);GUI_peach.SetActive(false);GUI_blackberry.SetActive(false);GUI_raspberry.SetActive(false);GUI_blueberry.SetActive(false);
apple_bcg.SetActive(true);strawberry_bcg.SetActive(false);peach_bcg.SetActive(false);}

if (Input.GetKey ("2")||fruit==2||PlayerPrefs.GetString("MiniGameFruit")=="Strawberry"){
fruit=2;strawberry();GUI_apple.SetActive(false);GUI_strawberry.SetActive(true);GUI_peach.SetActive(false);GUI_blackberry.SetActive(false);GUI_raspberry.SetActive(false);GUI_blueberry.SetActive(false);
apple_bcg.SetActive(false);strawberry_bcg.SetActive(true);peach_bcg.SetActive(false);}

if (Input.GetKey ("3")||fruit==3||PlayerPrefs.GetString("MiniGameFruit")=="Peach"){
fruit=3;peach();GUI_apple.SetActive(false);GUI_strawberry.SetActive(false);GUI_peach.SetActive(true);GUI_blackberry.SetActive(false);GUI_raspberry.SetActive(false);GUI_blueberry.SetActive(false);
apple_bcg.SetActive(false);strawberry_bcg.SetActive(false);peach_bcg.SetActive(true);}

if (Input.GetKey ("4")||fruit==4||PlayerPrefs.GetString("MiniGameFruit")=="Blackberry"){
fruit=4;blackberry();GUI_apple.SetActive(false);GUI_strawberry.SetActive(false);GUI_peach.SetActive(false);GUI_blackberry.SetActive(true);GUI_raspberry.SetActive(false);GUI_blueberry.SetActive(false);
apple_bcg.SetActive(false);strawberry_bcg.SetActive(true);peach_bcg.SetActive(false);}

if (Input.GetKey ("5")||fruit==5||PlayerPrefs.GetString("MiniGameFruit")=="Raspberry"){
fruit=5;raspberry();GUI_apple.SetActive(false);GUI_strawberry.SetActive(false);GUI_peach.SetActive(false);GUI_blackberry.SetActive(false);GUI_raspberry.SetActive(true);GUI_blueberry.SetActive(false);
apple_bcg.SetActive(false);strawberry_bcg.SetActive(true);peach_bcg.SetActive(false);}

if (Input.GetKey ("6")||fruit==6||PlayerPrefs.GetString("MiniGameFruit")=="Blueberry"){
fruit=6;blueberry();GUI_apple.SetActive(false);GUI_strawberry.SetActive(false);GUI_peach.SetActive(false);GUI_blackberry.SetActive(false);GUI_raspberry.SetActive(false);GUI_blueberry.SetActive(true);
apple_bcg.SetActive(false);strawberry_bcg.SetActive(true);peach_bcg.SetActive(false);}

}

function apple(){
    for(var apple_ : GameObject in GameObject.FindGameObjectsWithTag("apple"))
    {
    if(apple_.name == "apple-medium-poly")
    {
    	apple_.SetActive(true);
    }
    }
    for(var strawberry_ : GameObject in GameObject.FindGameObjectsWithTag("strawberry"))
    {
    if(strawberry_.name == "strawberry-mp")
    {
    	strawberry_.SetActive(false);
    }
    }
    for(var peach_ : GameObject in GameObject.FindGameObjectsWithTag("peach"))
    {
    if(peach_.name == "Peach2-MP")
    {
    	peach_.SetActive(false);
    }
    }
      for(var blackberry_ : GameObject in GameObject.FindGameObjectsWithTag("blackberry"))
    {
    if(blackberry_.name == "blackberry")
    {
    	blackberry_.SetActive(false);
    }
    }
      for(var raspberry_ : GameObject in GameObject.FindGameObjectsWithTag("raspberry"))
    {
    if(raspberry_.name == "raspberry")
    {
    	raspberry_.SetActive(false);
    }
    }
      for(var blueberry_ : GameObject in GameObject.FindGameObjectsWithTag("blueberry"))
    {
    if(blueberry_.name == "blueberry")
    {
    	blueberry_.SetActive(false);
    }
    }
}
function strawberry(){
	for(var apple_ : GameObject in GameObject.FindGameObjectsWithTag("apple"))
    {
    if(apple_.name == "apple-medium-poly")
    {
    	apple_.SetActive(false);
    }
    }
    for(var strawberry_ : GameObject in GameObject.FindGameObjectsWithTag("strawberry"))
    {
    if(strawberry_.name == "strawberry-mp")
    {
    	strawberry_.SetActive(true);
    }
    }
    for(var peach_ : GameObject in GameObject.FindGameObjectsWithTag("peach"))
    {
    if(peach_.name == "Peach2-MP")
    {
    	peach_.SetActive(false);
    }
    }
      for(var blackberry_ : GameObject in GameObject.FindGameObjectsWithTag("blackberry"))
    {
    if(blackberry_.name == "blackberry")
    {
    	blackberry_.SetActive(false);
    }
    }
      for(var raspberry_ : GameObject in GameObject.FindGameObjectsWithTag("raspberry"))
    {
    if(raspberry_.name == "raspberry")
    {
    	raspberry_.SetActive(false);
    }
    }
      for(var blueberry_ : GameObject in GameObject.FindGameObjectsWithTag("blueberry"))
    {
    if(blueberry_.name == "blueberry")
    {
    	blueberry_.SetActive(false);
    }
    }
}
function peach(){
	for(var apple_ : GameObject in GameObject.FindGameObjectsWithTag("apple"))
    {
    if(apple_.name == "apple-medium-poly")
    {
    	apple_.SetActive(false);
    }
    }
    for(var strawberry_ : GameObject in GameObject.FindGameObjectsWithTag("strawberry"))
    {
    if(strawberry_.name == "strawberry-mp")
    {
    	strawberry_.SetActive(false);
    }
    }
    for(var peach_ : GameObject in GameObject.FindGameObjectsWithTag("peach"))
    {
    if(peach_.name == "Peach2-MP")
    {
    	peach_.SetActive(true);
    }
    }
      for(var blackberry_ : GameObject in GameObject.FindGameObjectsWithTag("blackberry"))
    {
    if(blackberry_.name == "blackberry")
    {
    	blackberry_.SetActive(false);
    }
    }
      for(var raspberry_ : GameObject in GameObject.FindGameObjectsWithTag("raspberry"))
    {
    if(raspberry_.name == "raspberry")
    {
    	raspberry_.SetActive(false);
    }
    }
      for(var blueberry_ : GameObject in GameObject.FindGameObjectsWithTag("blueberry"))
    {
    if(blueberry_.name == "blueberry")
    {
    	blueberry_.SetActive(false);
    }
    }
}
function blackberry(){
	for(var apple_ : GameObject in GameObject.FindGameObjectsWithTag("apple"))
    {
    if(apple_.name == "apple-medium-poly")
    {
    	apple_.SetActive(false);
    }
    }
    for(var strawberry_ : GameObject in GameObject.FindGameObjectsWithTag("strawberry"))
    {
    if(strawberry_.name == "strawberry-mp")
    {
    	strawberry_.SetActive(false);
    }
    }
    for(var peach_ : GameObject in GameObject.FindGameObjectsWithTag("peach"))
    {
    if(peach_.name == "Peach2-MP")
    {
    	peach_.SetActive(false);
    }
    }
      for(var blackberry_ : GameObject in GameObject.FindGameObjectsWithTag("blackberry"))
    {
    if(blackberry_.name == "blackberry")
    {
    	blackberry_.SetActive(true);
    }
    }
      for(var raspberry_ : GameObject in GameObject.FindGameObjectsWithTag("raspberry"))
    {
    if(raspberry_.name == "raspberry")
    {
    	raspberry_.SetActive(false);
    }
    }
      for(var blueberry_ : GameObject in GameObject.FindGameObjectsWithTag("blueberry"))
    {
    if(blueberry_.name == "blueberry")
    {
    	blueberry_.SetActive(false);
    }
    }
}
function raspberry(){
	for(var apple_ : GameObject in GameObject.FindGameObjectsWithTag("apple"))
    {
    if(apple_.name == "apple-medium-poly")
    {
    	apple_.SetActive(false);
    }
    }
    for(var strawberry_ : GameObject in GameObject.FindGameObjectsWithTag("strawberry"))
    {
    if(strawberry_.name == "strawberry-mp")
    {
    	strawberry_.SetActive(false);
    }
    }
    for(var peach_ : GameObject in GameObject.FindGameObjectsWithTag("peach"))
    {
    if(peach_.name == "Peach2-MP")
    {
    	peach_.SetActive(false);
    }
    }
      for(var blackberry_ : GameObject in GameObject.FindGameObjectsWithTag("blackberry"))
    {
    if(blackberry_.name == "blackberry")
    {
    	blackberry_.SetActive(false);
    }
    }
      for(var raspberry_ : GameObject in GameObject.FindGameObjectsWithTag("raspberry"))
    {
    if(raspberry_.name == "raspberry")
    {
    	raspberry_.SetActive(true);
    }
    }
      for(var blueberry_ : GameObject in GameObject.FindGameObjectsWithTag("blueberry"))
    {
    if(blueberry_.name == "blueberry")
    {
    	blueberry_.SetActive(false);
    }
    }
}
function blueberry(){
	for(var apple_ : GameObject in GameObject.FindGameObjectsWithTag("apple"))
    {
    if(apple_.name == "apple-medium-poly")
    {
    	apple_.SetActive(false);
    }
    }
    for(var strawberry_ : GameObject in GameObject.FindGameObjectsWithTag("strawberry"))
    {
    if(strawberry_.name == "strawberry-mp")
    {
    	strawberry_.SetActive(false);
    }
    }
    for(var peach_ : GameObject in GameObject.FindGameObjectsWithTag("peach"))
    {
    if(peach_.name == "Peach2-MP")
    {
    	peach_.SetActive(false);
    }
    }
      for(var blackberry_ : GameObject in GameObject.FindGameObjectsWithTag("blackberry"))
    {
    if(blackberry_.name == "blackberry")
    {
    	blackberry_.SetActive(false);
    }
    }
      for(var raspberry_ : GameObject in GameObject.FindGameObjectsWithTag("raspberry"))
    {
    if(raspberry_.name == "raspberry")
    {
    	raspberry_.SetActive(false);
    }
    }
      for(var blueberry_ : GameObject in GameObject.FindGameObjectsWithTag("blueberry"))
    {
    if(blueberry_.name == "blueberry")
    {
    	blueberry_.SetActive(true);
    }
    }
}