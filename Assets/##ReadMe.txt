Sam Robichaud
NSCC 2024

The intent of this project is to create simple framework to build and playtest levels for the  [Game Development II] course. The objective is to have a simple way to construct and playtest levels without requiring extra coding.

All scenes must be present in build order
Must enter PlayMode From "MainMenu" Scene

Features:

- Built in FPS controller
- End Level Trigger: Gameplay levels have a trigger present that will change to the next level in the Build order when trigger by the player (walking into it). Trigger can be modified
- SpawnPoint: On level change, player position and rotation will be set to match the "SpawnPoint" object (one present in each level). Can be moved and rotated, (will only accept rotations in the Y position)
- Debug Keys to test level: Pressing { or } in play mode will change the scene to the previous or next scene in the build order.
- Randomly Changing MainMenu and GameEnd bakcgrounds, can be customized via the UI asset "Background" for each scene
- Level Info "CanvasGameplay" that contains info about that specific level, at current time values must be entered manually.
- Full menu system, including pause menu.
 