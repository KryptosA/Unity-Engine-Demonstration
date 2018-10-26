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
