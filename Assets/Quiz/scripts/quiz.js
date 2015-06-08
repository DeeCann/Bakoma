
var ok:AudioClip;
var not_ok:AudioClip;

var dataFile: TextAsset;
var lines:int;
var dataParamsList:Array;
var ar:Array;

var data_trudne: TextAsset;
var lines_trudne:int;
var dataParamsList_trudne:Array;
var ar_trudne:Array;

var apple:GameObject;
var straw:GameObject;
var peach:GameObject;
var blue:GameObject;
var rasp:GameObject;
var black:GameObject;
var plus1:GameObject;
var plus2:GameObject;
var minus1:GameObject;
var minus3:GameObject;

var trudnosc:GameObject;

var rand_number:int;
var rand_number_trudne:int;
var rand_a:int;
var flag:int=0;
static var poziom:int=0;

var Pytanie:GameObject;
var odpA:GameObject;
var odpB:GameObject;
var odpC:GameObject;

var flag_poziom:int=0;

var _A:GameObject;
var _B:GameObject;
var _C:GameObject;

var kropka1:GameObject;
var kropka2:GameObject;
var kropka3:GameObject;

var czarny1: GameObject;
var czarny2: GameObject;
var czarny3: GameObject;
var zielony1: GameObject;
var zielony2: GameObject;
var zielony3: GameObject;
var rozowy1: GameObject;
var rozowy2: GameObject;
var rozowy3: GameObject;

var latwe: GameObject;
var trudne: GameObject;

static var answer: int=0;

function Start () {
flag_poziom=0;
Pytanie.SetActive(false);
odpA.SetActive(false);
odpB.SetActive(false);
odpC.SetActive(false);

apple.SetActive(false);
straw.SetActive(false);
peach.SetActive(false);
blue.SetActive(false);
rasp.SetActive(false);
black.SetActive(false);
plus1.SetActive(false);
minus1.SetActive(false);


rand_number=Random.Range(1,100);
rand_number_trudne=Random.Range(1,30);
rand_a=Random.Range(1,4);

dataParamsList= new Array();
ar = new Array();
dataParamsList_trudne= new Array();
ar_trudne = new Array();
lines=0;
lines_trudne=0;
data_to_array();

//question(rand_number,rand_a);
}

function Update () {
if(poziom!=0){
	latwe.SetActive(false);trudne.SetActive(false);trudnosc.SetActive(false);
	czarny1.SetActive(true);czarny2.SetActive(true);czarny3.SetActive(true);
	kropka1.SetActive(true);kropka2.SetActive(true);kropka3.SetActive(true);
	_A.SetActive(true);_B.SetActive(true);_C.SetActive(true);
	Pytanie.SetActive(true);odpA.SetActive(true);odpB.SetActive(true);odpC.SetActive(true);
	}
if(poziom==1&&flag_poziom==0){question(1,rand_number,rand_a);flag_poziom=1;}
if(poziom==2&&flag_poziom==0){question(2,rand_number_trudne,rand_a);flag_poziom=1;}
if(answer==1){rozowy1.SetActive(true);rozowy2.SetActive(false);rozowy3.SetActive(false);check(1);quiz_end();}
if(answer==2){rozowy1.SetActive(false);rozowy2.SetActive(true);rozowy3.SetActive(false);check(2);quiz_end();}
if(answer==3){rozowy1.SetActive(false);rozowy2.SetActive(false);rozowy3.SetActive(true);check(3);quiz_end();}

}

function quiz_end(){
yield WaitForSeconds(5);
answer=0;
poziom=0;

PlayerPrefs.SetString("LoadLevelName","Game_Board");
Application.LoadLevel("Loader");
}

function check(ans:int){
if(flag==0){
flag=1;
yield WaitForSeconds(2);
if(rand_a==1){zielony1.SetActive(true);}
if(rand_a==2){zielony2.SetActive(true);}
if(rand_a==3){zielony3.SetActive(true);}
if(answer==1&&rand_a==1){audio.PlayOneShot(ok);add_point();return;}
if(answer==2&&rand_a==2){audio.PlayOneShot(ok);add_point();return;}
if(answer==3&&rand_a==3){audio.PlayOneShot(ok);add_point();return;}
audio.PlayOneShot(not_ok);remove_point();return;
}}

function add_point(){
var rand=Random.Range(1,7);
Debug.Log("rand"+rand);
if(poziom==1){
switch (rand)
{
case 1:PlayerPrefs.SetInt("GamePoints_Apple",PlayerPrefs.GetInt("GamePoints_Apple")+1);plus_point(1);Debug.Log("plus1");break;
case 2:PlayerPrefs.SetInt("GamePoints_Strawberry",PlayerPrefs.GetInt("GamePoints_Strawberry")+1);plus_point(2);Debug.Log("plus2");break;
case 3:PlayerPrefs.SetInt("GamePoints_Peach",PlayerPrefs.GetInt("GamePoints_Peach")+1);plus_point(3);Debug.Log("plus3");break;
case 4:PlayerPrefs.SetInt("GamePoints_Blackberry",PlayerPrefs.GetInt("GamePoints_Blackberry")+1);plus_point(4);Debug.Log("plus4");break;
case 5:PlayerPrefs.SetInt("GamePoints_Raspberry",PlayerPrefs.GetInt("GamePoints_Raspberry")+1);plus_point(5);Debug.Log("plus5");break;
case 6:PlayerPrefs.SetInt("GamePoints_Blueberry",PlayerPrefs.GetInt("GamePoints_Blueberry")+1);plus_point(6);Debug.Log("plus6");break;
}}
if(poziom==2){
switch (rand)
{
case 1:PlayerPrefs.SetInt("GamePoints_Apple",PlayerPrefs.GetInt("GamePoints_Apple")+2);plus_point(1);Debug.Log("plus1");break;
case 2:PlayerPrefs.SetInt("GamePoints_Strawberry",PlayerPrefs.GetInt("GamePoints_Strawberry")+2);plus_point(2);Debug.Log("plus2");break;
case 3:PlayerPrefs.SetInt("GamePoints_Peach",PlayerPrefs.GetInt("GamePoints_Peach")+2);plus_point(3);Debug.Log("plus3");break;
case 4:PlayerPrefs.SetInt("GamePoints_Blackberry",PlayerPrefs.GetInt("GamePoints_Blackberry")+2);plus_point(4);Debug.Log("plus4");break;
case 5:PlayerPrefs.SetInt("GamePoints_Raspberry",PlayerPrefs.GetInt("GamePoints_Raspberry")+2);plus_point(5);Debug.Log("plus5");break;
case 6:PlayerPrefs.SetInt("GamePoints_Blueberry",PlayerPrefs.GetInt("GamePoints_Blueberry")+2);plus_point(6);Debug.Log("plus6");break;
}}
}
function plus_point(fruit:int){
//Pytanie.SetActive(false);
//odpA.SetActive(false);
//odpB.SetActive(false);
//odpC.SetActive(false);
if(poziom==1){
plus1.SetActive(true);
switch(fruit)
{
case 1:apple.SetActive(true); break;
case 2:straw.SetActive(true);break;
case 3:peach.SetActive(true);break;
case 4:black.SetActive(true);break;
case 5:rasp.SetActive(true);break;
case 6:blue.SetActive(true);break;

}}
if(poziom==2){
plus2.SetActive(true);
switch(fruit)
{
case 1:apple.SetActive(true); break;
case 2:straw.SetActive(true);break;
case 3:peach.SetActive(true);break;
case 4:black.SetActive(true);break;
case 5:rasp.SetActive(true);break;
case 6:blue.SetActive(true);break;

}}

}

function remove_point(){
if(poziom==1){
if(PlayerPrefs.GetInt("GamePoints_Apple")>0){PlayerPrefs.SetInt("GamePoints_Apple",PlayerPrefs.GetInt("GamePoints_Apple")-1);minus_point(1);Debug.Log("minus1");return;}
if(PlayerPrefs.GetInt("GamePoints_Strawberry")>0){PlayerPrefs.SetInt("GamePoints_Strawberry",PlayerPrefs.GetInt("GamePoints_Strawberry")-1);minus_point(2);Debug.Log("minus2");return;}
if(PlayerPrefs.GetInt("GamePoints_Peach")>0){PlayerPrefs.SetInt("GamePoints_Peach",PlayerPrefs.GetInt("GamePoints_Peach")-1);minus_point(3);Debug.Log("minus3");return;}
if(PlayerPrefs.GetInt("GamePoints_Blackberry")>0){PlayerPrefs.SetInt("GamePoints_Blackberry",PlayerPrefs.GetInt("GamePoints_Blackberry")-1);minus_point(4);Debug.Log("minus4");return;}
if(PlayerPrefs.GetInt("GamePoints_Raspberry")>0){PlayerPrefs.SetInt("GamePoints_Raspberry",PlayerPrefs.GetInt("GamePoints_Raspberry")-1);minus_point(5);Debug.Log("minus5");return;}
if(PlayerPrefs.GetInt("GamePoints_Blueberry")>0){PlayerPrefs.SetInt("GamePoints_Blueberry",PlayerPrefs.GetInt("GamePoints_Blueberry")-1);minus_point(6);Debug.Log("minus6");return;}
}
if(poziom==2){
for(var i:int=0;i<3;i++){
if(PlayerPrefs.GetInt("GamePoints_Apple")>0){PlayerPrefs.SetInt("GamePoints_Apple",PlayerPrefs.GetInt("GamePoints_Apple")-1);Debug.Log("minus1");continue;}
if(PlayerPrefs.GetInt("GamePoints_Strawberry")>0){PlayerPrefs.SetInt("GamePoints_Strawberry",PlayerPrefs.GetInt("GamePoints_Strawberry")-1);Debug.Log("minus2");continue;}
if(PlayerPrefs.GetInt("GamePoints_Peach")>0){PlayerPrefs.SetInt("GamePoints_Peach",PlayerPrefs.GetInt("GamePoints_Peach")-1);Debug.Log("minus3");continue;}
if(PlayerPrefs.GetInt("GamePoints_Blackberry")>0){PlayerPrefs.SetInt("GamePoints_Blackberry",PlayerPrefs.GetInt("GamePoints_Blackberry")-1);Debug.Log("minus4");continue;}
if(PlayerPrefs.GetInt("GamePoints_Raspberry")>0){PlayerPrefs.SetInt("GamePoints_Raspberry",PlayerPrefs.GetInt("GamePoints_Raspberry")-1);Debug.Log("minus5");continue;}
if(PlayerPrefs.GetInt("GamePoints_Blueberry")>0){PlayerPrefs.SetInt("GamePoints_Blueberry",PlayerPrefs.GetInt("GamePoints_Blueberry")-1);Debug.Log("minus6");continue;}
}minus_point(1);
}
}



function minus_point(fruit:int){
//Pytanie.SetActive(false);
//odpA.SetActive(false);
//odpB.SetActive(false);
//odpC.SetActive(false);
if(poziom==1){
minus1.SetActive(true);
switch(fruit)
{
case 1:apple.SetActive(true); break;
case 2:straw.SetActive(true);break;
case 3:peach.SetActive(true);break;
case 4:black.SetActive(true);break;
case 5:rasp.SetActive(true);break;
case 6:blue.SetActive(true);break;

}}
if(poziom==2){
minus3.SetActive(true);
}
}

function question(trud:int,rand :int, rand_a:int){
ar=dataParamsList[rand];
ar_trudne=dataParamsList_trudne[rand];

if(trud==1){
Pytanie.GetComponent.<UI.Text>().text=ar[0];
if(rand_a==1){
odpA.GetComponent.<UI.Text>().text=ar[1];
odpB.GetComponent.<UI.Text>().text=ar[2];
odpC.GetComponent.<UI.Text>().text=ar[3];}
if(rand_a==2){
odpA.GetComponent.<UI.Text>().text=ar[2];
odpB.GetComponent.<UI.Text>().text=ar[1];
odpC.GetComponent.<UI.Text>().text=ar[3];}
if(rand_a==3){
odpA.GetComponent.<UI.Text>().text=ar[3];
odpB.GetComponent.<UI.Text>().text=ar[2];
odpC.GetComponent.<UI.Text>().text=ar[1];}
}
if(trud==2){
Pytanie.GetComponent.<UI.Text>().text=ar_trudne[0];
if(rand_a==1){
odpA.GetComponent.<UI.Text>().text=ar_trudne[1];
odpB.GetComponent.<UI.Text>().text=ar_trudne[2];
odpC.GetComponent.<UI.Text>().text=ar_trudne[3];}
if(rand_a==2){
odpA.GetComponent.<UI.Text>().text=ar_trudne[2];
odpB.GetComponent.<UI.Text>().text=ar_trudne[1];
odpC.GetComponent.<UI.Text>().text=ar_trudne[3];}
if(rand_a==3){
odpA.GetComponent.<UI.Text>().text=ar_trudne[3];
odpB.GetComponent.<UI.Text>().text=ar_trudne[2];
odpC.GetComponent.<UI.Text>().text=ar_trudne[1];}
}
}




function data_to_array(){
var returnChar = "\n"[0];
var commaChar = ";"[0];


var dataLines = dataFile.text.Split(returnChar);
for(var dataLine in dataLines){
	lines++;
	var dataParams = dataLine.Split(commaChar);
	dataParamsList.Add(dataParams);
	}
	
var dataLines_trudne = data_trudne.text.Split(returnChar);
for(var dataLine_trudne in dataLines_trudne){
	lines_trudne++;
	var dataParams_trudne = dataLine_trudne.Split(commaChar);
	dataParamsList_trudne.Add(dataParams_trudne);
	}

}

