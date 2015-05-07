#pragma strict
var score: UnityEngine.UI.Image;
var score_numb: GameObject;
static var score_summary: int;

static var fru: int;

var apple_score: Sprite;
var straw_score: Sprite;
var peach_score: Sprite;
var black_score: Sprite;
var rasp_score: Sprite;
var blue_score: Sprite;



function Start () {
score_summary=0;
}

function Update () {
if(Input.GetKey("1")||PlayerPrefs.GetString("MiniGameFruit")=="Apple"){
score.sprite=apple_score;
fruit_disable(1);fru=1;
}
if(Input.GetKey("2")||PlayerPrefs.GetString("MiniGameFruit")=="Strawberry"){
score.sprite=straw_score;
fruit_disable(2);fru=2;
}
if(Input.GetKey("3")||PlayerPrefs.GetString("MiniGameFruit")=="Peach"){
score.sprite=peach_score;
fruit_disable(3);fru=3;
}
if(Input.GetKey("4")||PlayerPrefs.GetString("MiniGameFruit")=="Blackberry"){
score.sprite=black_score;
fruit_disable(4);fru=4;
}
if(Input.GetKey("5")||PlayerPrefs.GetString("MiniGameFruit")=="Raspberry"){
score.sprite=rasp_score;
fruit_disable(5);fru=5;
}
if(Input.GetKey("6")||PlayerPrefs.GetString("MiniGameFruit")=="Blueberry"){
score.sprite=blue_score;
fruit_disable(6);fru=6;
}
score_numb.GetComponent.<UI.Text>().text=score_summary.ToString();

}

function fruit_disable(fruit : int){
if(fruit==1){
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Apple"))
{
    go.active = true;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Straw"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Peach"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Black"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Rasp"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Blue"))
{
    go.active = false;
}
}

if(fruit==2){
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Apple"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Straw"))
{
    go.active = true;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Peach"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Black"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Rasp"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Blue"))
{
    go.active = false;
}
}

if(fruit==3){
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Apple"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Straw"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Peach"))
{
    go.active = true;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Black"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Rasp"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Blue"))
{
    go.active = false;
}
}

if(fruit==4){
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Apple"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Straw"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Peach"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Black"))
{
    go.active = true;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Rasp"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Blue"))
{
    go.active = false;
}
}

if(fruit==5){
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Apple"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Straw"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Peach"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Black"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Rasp"))
{
    go.active = true;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Blue"))
{
    go.active = false;
}
}

if(fruit==6){
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Apple"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Straw"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Peach"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Black"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Rasp"))
{
    go.active = false;
}
for(var go : GameObject in GameObject.FindGameObjectsWithTag("MiniGame_Blue"))
{
    go.active = true;
}
}

}