# copy-snake-game
Making a snake game that was used on nokia old phones

Gameplay : https://youtu.be/iVktIHrlNtw
![eatingapple](https://github.com/user-attachments/assets/3680087f-cb29-4db9-ae5d-5a70be963cc7)

![speedincrease](https://github.com/user-attachments/assets/588970d5-5fbe-428a-9cb8-b1fcd3d52f4e)

![die](https://github.com/user-attachments/assets/5ba1def1-6504-4ad2-ab80-1fbdd56ccf91)

Features

* Movement is grid based, moves every second.   
* When snake head touches spawned apple, it gets destroyed, and then a body part gets spawned to the last position of the whole body.
* Score system, keeps track of current run eaten apples, starts from 0
* Touching a body part or the boundaries resets the player to the start position, resets the score, destroys all body parts, except head.
* Every seventh apple eaten the game speed by 1/10th second , until the game reaches the maximum of game speed of a 1/10th second from the beginning of 1 second.   
    
Known issues:
The game was made in mind that the resolution would be 1080x1920
So if the resolution of the phone is larger of smaller the buttons or the score can be placed out of place.

Download apk : https://github.com/chocshall/copy-snake-game/releases/tag/v1.0.0

Latest version v1.0.0.



Unity version: Unity 6.3 LTS (6000.3.2f1)

Download: https://unity.com/releases/editor/archive

When installing Unity, add:

Required Modules

* Windows Build Support
* Android Build Support
* WebGL Build Support
* Microsoft Visual studio Community 2022

Build:

* git for windows
* https://github.com/chocshall/copy-snake-game.git
* cd copy-snake-game
* when loaded on unity press scenes and click on scene
