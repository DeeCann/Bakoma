#pragma strict
InvokeRepeating("unfreeze", 2, 5.0);

function Start () {

}

function Update () {

}
function unfreeze(){
score_count.move_slots.Clear();
}