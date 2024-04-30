# 2.5D CHARACTER CONTROLLER
***
a tool that comes with a ready-to-go isometric top-down 2D character in the 3D environment. Designed for controller. However, it works with any input using Unity Input Manager. Most of the features are editable from the inspector.
> Similar games are; Don't Starve, Cult of The Lamb, Paper Mario
###### TECHNOLOGY
> Unity, C#
---
###FEATURES
* 2 Axis movement
* Jump, Multiple Jump (Editable)
* Run
* Dash
* Roll
* Ground Detection
* 3D Collider
* State Tracker (Dashing, Rolling, Grounded, Moving, Running, Idle, Falling, Jumping; 4 Side Movement Rotation Track)
* Sprite Updater (According to the current movement rotation)
* Trail Renderer (While Dashing)
---
### HOW DOES IT WORK?
* It reads 2 axis movement from "Horizontal" and "Vertical" axis
* Simply adds velocity to Player's rigid body. Speed can be edited through the inspector panel
* Tracks the ground to jump, dash, and roll. Upon landing, it refreshes the jumper count which can be edited through the inspector panel. _Jumps can be kept short when the button is released during action._ Also decides to either dash or roll according to the state of _isGrounded_. Uses key button "Dash" to invoke either dash or roll.
* Activates the trail renderer while dashing.
---
### INSTRUCTIONS
* Create a new GameObject that represents your character.
* Add rigid body, collider, trail renderer and attach _Movement_ script.
* Create another collider that represents the feet of your character. Place it below your character wisely. Then, attach _CheckGround_ script to the feet object.
* Attach required object references in the inspector.
* Adjust Input Manager. Make sure you have key references for the following fields; Horizontal, Vertical axis; Dash, Jump.
* Create a new Tag, "Ground" and tag it to your terrain or any surface you want your character to move on.
* It should work now.

###### USEFUL LINKS
> [Coroutine & IEnumerator](https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html "Unity Documentation")
> [Animator](https://docs.unity3d.com/ScriptReference/Animator.html)

***
### WHAT'S NEXT?
* 2D character Sprites and Animations
* Particle system for various states

##### MAYBE
* hanging functionality
* wallride
* melee and ranged combat
* health, energylike things
