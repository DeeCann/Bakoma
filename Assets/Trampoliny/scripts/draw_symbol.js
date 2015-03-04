#pragma strict
var kolko: GameObject;
var kwadrat: GameObject;
var trojkat: GameObject;
static var symbol: int;
var symbol_out: int;

function Start () {

symbol=Random.Range(1,4);
kolko=this.transform.FindChild("kolko").gameObject;
kwadrat=this.transform.FindChild("kwadrat").gameObject;
trojkat=this.transform.FindChild("trojkat").gameObject;
if(symbol==1){kolko.SetActive(true);kwadrat.SetActive(false);trojkat.SetActive(false);symbol_out=1;}
if(symbol==2){kolko.SetActive(false);kwadrat.SetActive(true);trojkat.SetActive(false);symbol_out=2;}
if(symbol==3){kolko.SetActive(false);kwadrat.SetActive(false);trojkat.SetActive(true);symbol_out=3;}
if(level.level==1){kolko.SetActive(false);kwadrat.SetActive(false);trojkat.SetActive(false);}
}

function Update () {

}