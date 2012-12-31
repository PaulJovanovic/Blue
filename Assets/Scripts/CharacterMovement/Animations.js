// "Animations.js" -- Animation controller script

//

function Start () { 

    animation.wrapMode = WrapMode.Loop; 

//  animation["jump"].wrapMode = WrapMode.Once; 

//  animation["sit"].wrapMode = WrapMode.Once;

    animation.Stop(); 

    Idle();

} 

 

function Walk() {

    animation.CrossFade("walk", 0.3);

}

 

function Run () { 

      animation.CrossFade("run", 0.3); 

}

 

function Idle () {

    animation.CrossFade("idle", 0.3);

}

  

function Jump () {

    animation.CrossFade("jump", 0.3);

}