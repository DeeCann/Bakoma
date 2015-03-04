#pragma strict
 var fruit:GameObject;
 var freeze:float;
 

function Start () {
freeze=-8.6;

}

function Update () {

if (fruit.transform.position.y<freeze)
{
 rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
 
}
else 
{
rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
}
}