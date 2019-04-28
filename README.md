![Dinocore Logo](documentation/images/logo.png?raw=true "Dinocore Logo")

# Dinocore

Sitecore Hackathon 2019 entry by Team **Cheese'n'Frog**

Category: "Best enhancement to JSS to change a JSS component rendering behavior based on user's session data"

Youtube video: **[Dinocore highlights](http://youtube.com/watch?v=xxx)**

---

## What it solves

The solution shows a way to personalise JSS client behaviour based on data from the sitecore server. 

Personalisation based the on the user context is showcased using a simple game. While playing the game the running highscore is shown within the overall highscore list.

This solution could be adapted to fit other needs but the general pattern remains the same and proves to be very effective.

---

## What it does

This solution does 3 things:

1. Client-side it polls a GraphQL endpoint for all relevant highscores based on the current user's highscore. The highscores become visible client-side in the leaderboard.
1. Server-side it leverages JSS, GraphQL and the ContentSearch API to produce a list of relevant highscores for the leaderboard.
1. Server-side a GraphQL mutation is used for adding a new highscores to the leaderboard.

## BAD PRACTICE WARNING

The GraphQL mutation classes in [DinocoreSchemaProvider.cs](src/dotnet/Feature/Highscores/website/Providers/DinocoreSchemaProvider.cs) add items directly to the sitecore master database. Beware and take appropriate action :)

---

## Pre-requisites

- Sitecore 9.1 Initial Release (rev. 001564)
- Sitecore JSS Server Package for Sitecore 9.1: [Sitecore JavaScript Services Server for Sitecore 9.1 XP 11.0.0 rev. 181031.zip](https://dev.sitecore.net/~/media/28F918CC225547EF9605C9ECD574D007.ashx)

## How to install

1. Install a Sitecore 9.1 Initial Release (rev. 001564) instance named "dinocore" with a host entry named "dinocore.sc"
   1. If you already have a Sitecore instance with a different name:
      1. Add a host file entry named "dinocore.sc" to 127.0.0.1
      2. Add a binding to your Sitecore instance ISS website to "dinocore.sc"
2. Download and install the Sitecore JSS Server Package for Sitecore 9.1 using the Sitecore Installation Wizard: [Sitecore JavaScript Services Server for Sitecore 9.1 XP 11.0.0 rev. 181031.zip](https://dev.sitecore.net/~/media/28F918CC225547EF9605C9ECD574D007.ashx)
3. Download and install the Dinocore Sitecore package using the Sitecore Installation Wizard: [SCHackathon 2019 - Cheese n Frog - Dinocore-1.0.zip](sc.package/SCHackathon%202019%20-%20Cheese%20n%20Frog%20-%20Dinocore-1.0.zip)
4. Open the Sitecore instance administration: [Sitecore Administration](http://dinocore.sc/sitecore)
5. From the Sitecore Control Panel, rebuild the `sitecore_master_index` using the Indexing Manager.

---

## How to use

Follow these steps after installing the module:

* Point your browser to **[http://dinocore.sc](http://dinocore.sc)**
![Dinocore screenshot](documentation/images/screenshot.png?raw=true "Dinocore screenshot")
* Click in the game window, directly below the Dinocore logo, to start a new game.
* You can avoid obstacles by jumping. Use the **__left mouse__** button or press the **__spacebar__** key to jump.

While you are running, your current highscore will be continuously updated and stacked up against the highscores of other players. Keep your eyes on the leaderboard while you race!
