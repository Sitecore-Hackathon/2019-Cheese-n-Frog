![Dinocore Logo](documentation/images/logo.png?raw=true "Dinocore Logo")

# Dinocore

Sitecore Hackathon 2019 entry by Team **Cheese'n'Frog**

Category: "Best enhancement to JSS to change a JSS component rendering behavior based on user's session data"

Youtube video: **[Dinocore highlights](http://youtube.com/watch?v=xxx)**
   - Create a 2 – 10 minutes video explaining the module’s functionality (A link to youtube video)
   - What problem was solved
   - How did you solve it
   - What is the end result

## What it solves
The solution shows a way to personalise JSS client behaviour based on data from/thru the sitecore server. Personalitation by user context showcased using a simple game and using the highscores as data.

This solution could be adapted to fit other needs but the general pattern remains the same and proves very affective.

---

## What it does
This solution does 2 things: 
1. Client-side it polls a GraphQL endpoint for all relevant highscores based on the current user's highscore. The highscores become visible client-side in the leaderboard.
1. Server-side it leverages JSS, GraphQL and the ContentSearch API to produce a list of relevant highscores for the leaderboard. A GraphQL mutation is used for adding a new highscores to the leaderboard.

---

## How to install
	Precise and Clear Installation Instructions document (1 – 2 pages)
	Dowload package from x...

---

## How to use
Follow these setp after installing the module:
* Point you're browser to **[http://dinocore.sc](http://dinocore.sc)**
![Dinocore screenshot](documentation/images/screenshot.png?raw=true "Dinocore screenshot")
* Click in the game window, directly below the Dinocore logo, to start a new game.
* You can avoid obstacles by jumping. Use the **__left mouse__** button or pressing **__spacebar__** to jump.

While you are running your current highscore will be continously updated and stacked up against the highscores of other players. Keep you're eye on the leaderboard while you race!
