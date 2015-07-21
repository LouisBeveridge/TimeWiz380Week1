var target : Transform;
var distance = 10.0;

var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -20;
var yMaxLimit = 80;

private var x = 0.0;
private var y = 0.0;

@script AddComponentMenu("Camera-Control/Mouse Orbit")

function Start () {

	//hide cursor
	Screen.showCursor = false;

    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;

	// Make the rigid body not change rotation
   	if (GetComponent.<Rigidbody>())
		GetComponent.<Rigidbody>().freezeRotation = true;
}

function LateUpdate () {

/* // Dead zone bs
var deadzone = 0.25f;
    Vector2 stickInput = new Vector2(Input.GetAxis(“Horizontal”), Input.GetAxis(“Vertical”));
    if(stickInput.magnitude < deadzone)
        stickInput = Vector2.zero;
    else
        stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));
//dead zone bs */


    if (target) {
        x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
         x -= Input.GetAxisRaw("RightStickHor") * xSpeed * 0.05;
        y += Input.GetAxis("RightStickVert") * ySpeed * 0.05;
 		
 		y = ClampAngle(y, yMinLimit, yMaxLimit);
 		       
        var rotation = Quaternion.Euler(y, x, 0);
        var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
        
        transform.rotation = rotation;
        transform.position = position;
        
      //  print("X rot: " + Input.GetAxis("RightStickHor") + "  |   Y rot: " + Input.GetAxis("RightStickVert"));
    }
}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)
		angle += 360;
	if (angle > 360)
		angle -= 360;
	return Mathf.Clamp (angle, min, max);
}