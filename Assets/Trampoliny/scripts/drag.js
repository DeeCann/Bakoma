var screenSpace:Vector3;
var offset:Vector3;
    var object: GameObject;
    var prefab : Transform;
    var clone: Object;
    var vec3: Vector3;
    var curPosition: Vector3;
    var parent:String;
 
    var startPosition:Vector3;
    var rand_tramp: int;
    var rand_lejek: int;
    var col_flag:int=0;
    var coll: Collision;
    var rand_n_lejek: int;
    var rand_n_tramp: int;
    
    function Start(){
    rand_n_lejek=Random.Range(1,4);
    rand_n_tramp=Random.Range(2,6);
    
    object=this.gameObject;
    vec3=this.transform.position;
    prefab=this.transform;
    if(object.name=="wooden-platform-thin"){
    	for(var i:int=0;i<rand_n_tramp;i++){
    		if(i%2==0){
    		rand_tramp=Random.Range(5,30);   		       
        	clone=Instantiate (prefab, Vector3(-7+(i*10),-10,0), Quaternion.Euler(rand_tramp,90,0));}
    		if(i%2==1){
    		rand_tramp=Random.Range(-30,-5);   		       
        	clone=Instantiate (prefab, Vector3(-7+(i*10),-10,0), Quaternion.Euler(rand_tramp,90,0));}
    		
        	
        }
        Destroy(this.gameObject);	   
    }
    if(object.name=="woodentray"){
    	for(var j:int=0;j<rand_n_lejek;j++){
    		rand_lejek=Random.Range(-45,45);   		       
        	clone=Instantiate (prefab, Vector3(j*15,-4,0), Quaternion.Euler(rand_lejek,90,0));
        	
        }
        Destroy(this.gameObject);	   
    }
    //if(object.name.Contains("woodentray")){
    //	for(var j:int=0;j<rand_n_tramp;j++){
    	
    //	}
    //}
   	
    }
   
    
   
    function OnMouseDown(){
    	rand_tramp=Random.Range(-30,30);
    	rand_lejek=Random.Range(-45,45);
		
    	object=this.gameObject;
    	vec3=this.transform.position;
    	prefab=this.transform;
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
          
        offset = transform.position - Camera.main.ScreenToWorldPoint(Vector3(Input.mousePosition.x,Input.mousePosition.y, screenSpace.z));
        
        object.layer=0;
        //if(prefab.parent!=teller.transform){
        //clone.transform.parent=prefab.parent;}
        
        
       
    }
     

     
    function OnMouseDrag () {
		if(score_count.move_slots.Count==0){
        var curScreenSpace = Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);    
        curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
        transform.position = curPosition;
        }
    }
    function OnMouseUp(){

  
  
    }
    
    function OnCollisionEnter (col : Collision){
    
    }