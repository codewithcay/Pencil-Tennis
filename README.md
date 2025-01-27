# Pencil-Tennis
This is another Internship Project, a strategic Pen-n-Paper game for two Players
**Rules**
- The field consists of 7 zones, labeled from -3 to +3.
- The ball starts in zone 0.
- Each player starts with a score of 50 points.
- Player Plus aims to move the ball to zone 3; Player Minus aims to move it to zone -3.
- In each turn, players simultaneously choose a natural number not exceeding their score.
- Players must choose a positive number if they have points left.
- The player with the higher number moves the ball towards their goal:
  - Player Plus moves the ball one zone higher (minimum to zone 1) if they win.
  - Player Minus moves the ball one zone lower if they win.
- If the ball reaches zone 3, Player Plus wins; if it reaches zone -3, Player Minus wins.
- If both players choose the same number, the ball does not move.
- The chosen numbers are subtracted from each player's score before the next turn.
- The game also ends if no player has points left:
  - Player Plus wins if the ball is in a positive zone.
  - Player Minus wins if the ball is in a negative zone.
  - If the ball is in zone 0, the game ends in a tie.
- In multiple games, hitting the end line (zone 3 or -3) scores 2 points; otherwise, 1 point. 

![image](https://github.com/user-attachments/assets/b8d82706-79aa-4bb7-9a63-85c83d126dff)


source: https://de.wikipedia.org/wiki/Tennis_(Bleistiftspiel)

**NOTE**
This version is PC vs PC based on random generating numbers, next goal will be to work this out further possibly looking into algorithms and playing PC vs Human
