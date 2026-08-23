# Puzzle Escape

2D puzzle game built in Unity2D.

In this game, the player can use the environment around the grid to reach the end, each level increases the difficulty or add new tiles.

## Gameplay
<img width="1919" height="901" alt="Screenshot 2026-08-23 202403" src="https://github.com/user-attachments/assets/6735dd1d-aeca-48e4-b91d-fe254f7d6000" />
Setup the path.
Start the level.
Use portals to warp across the grid.
Collect coins.

## System Architecture

Grid Generation (GridManagement.cs & Tile.cs): Generates a scalable grid with chess-like board.

Input (ArrowRotation.cs, etc.): Handles mouse interactions.

Movement (PlayerMovement.cs): Constant-velocity in a straight-line.

Level (OutOfBorder.cs & NextLevel.cs): Manages the level reset and level finish.


## Future Development

More Obstacles and Tools

Level Selector

Coins

Costumes

Visual Improvements

Sounds


## Play

Game Status: In development (Level - 5)

You can try the game right now on [Itch.io](https://oalabadi.itch.io/puzzle-escape)

Developed by: Osama
