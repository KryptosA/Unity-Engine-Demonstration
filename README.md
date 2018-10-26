# Unity-Engine-Demonstration
This is a very basic demonstration of the unity engine and implenting basic first person camera and map models along with very basic ai pathing
This demonstration is written in C# using visual studio and te unity engine.
## Getting Started
Unity is the only requirement to run the program as it has no executable file. I would recommend visual studio to view the code as well as there are many scripts in this demo.
### Game World
The game demo is set in a science fiction setting in a base and it is a small facility with openable doors and a gun to shoot. The textures and assets are from the unity store and the code received a lot of help from guides on youtube.
## The Player Scripts
There are 3 scripts that govern the player: Player Motor, Manager, and Controller.
### PlayerMotor
This script controls the player camera directly and calls fucntions from the rigidbody object to perform movements.
The void function Start gets the component itself form unity and functions in this class then modify it to move.
```
rb = GetComponent<Rigidbody>();
...
void PerformMovement()
{
    if (velocity != Vector3.zero)
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
```

Using the same rigidbody component and euler angles the camera can then be modified to rotate using the mouse as in a traditional first person shooter. Euler angles can be described as the orientation of a rigid body within a 3D space.
```
rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
```
### PlayerManager
This is just a singleton with the gameobject of the player in it. You only want one instance to exist of the player at anytime.
### PlayerController
The axis rotations and player movement values are calculated and applied to variables sent back to the player motor script.
The raw input for the movement of the player is acquired from the keyboard inputs "WASD" and thena velocity is applied to them.
```
float _xMov = Input.GetAxisRaw("Horizontal");
float _zMov = Input.GetAxisRaw("Vertical");
```
The movement of the camera angles up and down have to be handled differently as opposed to left and right. The camera object itself is tilting in relation to the mouse movements so they have to be reversed to reflect that in the code.
```
float _xRot = Input.GetAxisRaw("Mouse Y");
Vector3 _cameraRotation = new Vector3(-_xRot, 0f, 0f) * lookSensitivity;
```
### Gun
The gun script functions with raycasting to shoot a particle that then collides with an object that will take damage if it has the corresponding target tag.
```
RaycastHit hit;
if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
{
    Debug.Log(hit.transform.name);

    Target target = hit.transform.GetComponent<Target>();

    if (target != null)
    {
        target.TakeDamage(damage);
    }
}
```
### EnemyController
This script contains the information for the navigation mesh and pathing for the enemy artificial intelligence of the game.
The enemy only attempts to chase the player when the player enters a specified radius outlined by a red sphere gizmo.
```
Gizmos.color = Color.red;
Gizmos.DrawWireSphere(transform.position, lookRadius);
```
### DoorAnim
The door animations were acquired from the map pack that is featured in this demonstration. The animations are played upon entering a trigger where the door raises and closes respectively.
The animation component is acquired from the parent door class.
```
void OnTriggerEnter(Collider other)
{
    doorAnim.SetBool("character_nearby", true);
    Debug.Log("true");
}

void OnTriggerExit(Collider other)
{
    doorAnim.SetBool("character_nearby", false);
    Debug.Log("false");
}
```
### CursorLock
When playing first person shooters you often don't really think about the cursor and it's relation to a full screen game.
The cursor needs to be locked into place and a simple script that locks the cursor in place until the escape key was pressed was implemented to prevent any accidental left clicks when playing the game and shooting.
```
Cursor.lockState = CursorLockMode.Locked;
```
