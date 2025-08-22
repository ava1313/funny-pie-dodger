# FunnyPieDodger

A silly little 2D dodging game built with Unity.

## Overview

In **FunnyPieDodger** you play as a hungry character desperately trying to avoid falling pies.  
Each second you survive earns you points — and a dash of smug satisfaction.  
If a pie hits you, the game ends with a humorous message and you can start over to try for a higher score.

## Controls

* Move left and right using the **A/D** keys or the **←/→** arrow keys.  
* Dodge the pies for as long as possible.  
* When you get pied, press **R** to restart the game.

## Project structure

The Unity project has a minimal structure, stored in the `Assets` folder:

```
funny_game/
└── Assets/
    └── Scripts/
        ├─┐ GameManager.cs    # Handles score tracking, UI updates and game over logic
        ├─┐ PlayerController.cs  # Moves the player and detects collisions
        ├─┐ SpawnManager.cs    # Spawns obstacles at random positions
        └─┐ Obstacle.cs       # Makes the pies fall and destroys them off ‑screen
```

You are free to add additional folders (for example `Scenes/` and `Prefabs/`) when opening the project in the Unity Editor.

## Setting up the scene

This repository contains only the code files. To play the game, create a simple scene in Unity (tested with Unity 2021.3 LTS but newer versions should also work):

1. **Create the scene**: In the Unity editor, choose **File → New Scene** and save it as `MainScene` in `Assets/Scenes/`.
2. **Create the player**:
   * Drag a sprite (e.g. a coloured square or any humorous graphic) into the scene at position `(0, ‑3, 0)`.
   * Add a **BoxCollider2D** component and set `Is Trigger` to **true**.
   * Add a **Rigidbody2D** component (set its `Body Type` to **Kinematic** if you want manual control only).
   * Attach the `PlayerController` script to this object.
   * Optionally adjust the `moveSpeed` and `xBound` values in the Inspector to tune movement speed and screen bounds.
3. **Create the obstacle prefab**:
   * Create a new sprite (e.g. a pie graphic) in the scene and add a **BoxCollider2D** (also set as trigger).
   * Attach the `Obstacle` script.
   * Drag this object into your `Assets` folder to create a **Prefab**. Delete the original from the scene.
   * Give the prefab the tag **Obstacle**.
4. **Set up managers**:
   * Create an empty GameObject named **GameManager** and attach the `GameManager` script.
   * Add a **Canvas** to the scene with a `Screen Space – Overlay` render mode. Inside the canvas, add three **Text** objects for displaying the score (`scoreText`), game over message (`gameOverText`) and restart prompt (`restartText`). Assign these fields to the `GameManager` script via the Inspector.
   * Create another empty GameObject named **SpawnManager** and attach the `SpawnManager` script. Drag the obstacle prefab into the `obstaclePrefab` field. Adjust `spawnInterval`, `xRange` and `ySpawn` as desired.
5. **Save the scene** and press **Play**. Dodge the pies and enjoy the silliness.

## Building the game

Once your scene is set up and tested, you can build a standalone PC version:

1. Open **File → Build Settings…**.
2. Add `MainScene` to the build if it is not already listed.
3. Select **PC, Mac & Linux Standalone** as the target platform and pick **Windows** (or your preferred platform).
4. Click **Build** and choose an output folder. Unity will produce a compiled game you can share with friends.

## Contribution

This project is intentionally simple and silly. Feel free to fork it, add your own art, sound effects, or extra mechanics. Have fun and keep dodging those pies!
