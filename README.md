![Dinocore Logo](documentation/images/logo.png?raw=true "Dinocore Logo")

# Dinocore

Sitecore Hackathon 2019 entry by Team **Cheese'n'Frog**

Category: "Best enhancement to JSS to change a JSS component rendering behavior based on user's session data"

Youtube video: **[Dinocore highlights](http://youtube.com/watch?v=xxx)**

## What it solves
The solution shows a way to personalise JSS client behaviour based on data from the sitecore server. 

Personalisation based the on the user context is showcased using a simple game. While playing the game the running highscore is shown within the overall highscore list.

This solution could be adapted to fit other needs but the general pattern remains the same and proves to be very effective.

---

## What it does
This solution does 2 things: 
1. Client-side it polls a GraphQL end-point for all relevant highscores based on the current user's highscore. The highscores become visible client-side in the leaderboard.
1. Server-side it leverages JSS, GraphQL and the ContentSearch API to produce a list of relevant highscores for the leaderboard. 
1. Server-side a GraphQL mutation is used for adding a new highscores to the leaderboard.

> BAD PRACTICE WARNING

The GraphQL mutation classes in [DinocoreSchemaProvider.cs](src/dotnet/Feature/Highscores/website/Providers/DinocoreSchemaProvider.cs) add directly to the sitecore master database. Beware and take appropriate action :)

---

## How to install
Download and install the sitecore package:
   [Download package](sc.package/SCHackathon 2019 - Cheese n Frog - Dinocore-1.0.zip) from sc.package/SCHackathon 2019 - Cheese n Frog - Dinocore-1.0.zip

---

## How to use
Follow these steps after installing the module:
* Point you're browser to **[http://dinocore.sc](http://dinocore.sc)**
![Dinocore screenshot](documentation/images/screenshot.png?raw=true "Dinocore screenshot")
* Click in the game window, directly below the Dinocore logo, to start a new game.
* You can avoid obstacles by jumping. Use the **__left mouse__** button or pressing **__spacebar__** to jump.

While you are running your current highscore will be continously updated and stacked up against the highscores of other players. Keep you're eye on the leaderboard while you race!
