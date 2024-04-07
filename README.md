# 2.5D CHARACTER CONTROLLER by Pabron
***
a tool that comes with a ready-to-go isometric topdown 2D character in the 3D environment. Designed for controller. However, it works with any input using Unity Input Manager.
> Similar games are; Don't Starve, Cult of The Lamb, Paper Mario
---
### HOW DOES IT WORK?
* It reads 2 axis movement from "Horizontal" and "Vertical" axis
* Simply adds velocity to Player's rigid body. Speed can be edited through the inspector panel
* Tracks the ground to jump, dash, and roll. Upon landing, it refreshes the jumper count which can be edited through the inspector panel. _Jumps can be kept short when the button is released during action._ Also decides to either dash or roll according to the state of _isDashing_.
* Activates the trail renderer while dashing.

###### USEFUL LINKS
[Coroutine & IEnumerator](https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html "Unity Documentation")
---
### WHAT'S NEXT?
* Run
* 2D character Sprite and Animations
* State system
* Particle system for various states

##### MAYBE
* hanging functionality
* melee and ranged combat
* health, energylike things
