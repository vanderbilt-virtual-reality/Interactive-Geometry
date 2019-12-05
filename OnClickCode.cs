

// VERY IMPORTANT - FOLLOW THESE DIRECTIONS TO ATTACH
// 1. Copy and paste this code into proper places within the rest of your button code
// 2. When you look at the button code fields within panel far right on screen, 
// you shoudl now see a new field called myGameObject
// 3. Drag and drop the Shape from the panel on the left into this field



// Start copying here - this should go at the top of the class definition. 
// GameObject whose scalar values to manipulate
public GameObject myGameObject;

// Minimum size values for the GameObject
// This is to make sure that the shape will never be invisible
// Also, negative values just extrude it the other way, which isn't what we want.
static readonly float MIN_Z_VAL = 0.01f;
static readonly float MIN_Y_VAL = 0.01f;
static readonly float MIN_X_VAL = 0.01f;

// End copying here

// Start copying here - PUT THIS CODE INSIDE THE "onClick" methpod
// This line is needed for every script
Vector3 scale = myGameObject.transform.localScale;

// Choose whatever section of code corresponds to each button
// COPY AND PASTE ONLY THE CODE IMMEDIATELY FOLLOWING THE NUMBER YOU WANT
// i.e. if you this is the Decrease Z script / button, don't in

// 1. Increase X
scale.x += Time.deltaTime;

// 2. Decrease X
if (scale.x > MIN_X_VAL)
{
    scale.x -= Time.deltaTime;
}

// 3. Increase Y
scale.y += Time.deltaTime;

// 4. Decrease Y
if (scale.y > MIN_Y_VAL)
{
    scale.y -= Time.deltaTime;
}

// 5. Increase Z
scale.z += Time.deltaTime

// 6. Decrease Z
if (scale.z > MIN_Z_VAL)
{
    scale.z -= Time.deltaTime;
}


// This line is needed for every script
myGameObject.transform.localScale = scale;
// End copying 