![Dinocore Logo](documentation/images/logo.png?raw=true "Dinocore Logo")

![Sitecore Hackathon Logo](documentation/images/hackathon.png?raw=true "Sitecore Hackathon Logo")

# Dinocore

Sitecore Hackathon 2019 entry by Team **Cheese'n'Frog**

Category: "Best enhancement to JSS to change a JSS component rendering behavior based on user's session data"

Youtube video: **[Dinocore presentation](https://youtu.be/5TzPXg7REws)**

---

## What it solves

The solution shows a way to personalize JSS client behaviour based on data from the sitecore server.

Personalization based the on the user context is showcased using a simple game. While playing the game the running highscore is shown within the overall highscore list.

This solution could be adapted to fit other needs but the general pattern remains the same and proves to be very effective.

---

## What it does

This solution does 3 things:

1. Client-side it polls a GraphQL endpoint for all relevant highscores based on the current user's highscore. The highscores become visible client-side in the leaderboard.
2. Server-side it leverages JSS, GraphQL and the ContentSearch API to produce a list of relevant highscores for the leaderboard.
3. Server-side a GraphQL mutation is used for adding a new highscores to the leaderboard.

## BAD PRACTICE WARNING

The GraphQL mutation classes in [DinocoreSchemaProvider.cs](src/dotnet/Feature/Highscores/website/Providers/DinocoreSchemaProvider.cs) add items directly to the sitecore master database. Beware and take appropriate action :)

---

## Pre-requisites

- Sitecore 9.1 Initial Release (rev. 001564)
- Sitecore JSS Server Package for Sitecore 9.1: [Sitecore JavaScript Services Server for Sitecore 9.1 XP 11.0.0 rev. 181031.zip](https://dev.sitecore.net/~/media/28F918CC225547EF9605C9ECD574D007.ashx)

## How to install

1. Install a Sitecore 9.1 Initial Release (rev. 001564) instance named "dinocore" with a host entry named "dinocore.sc"
   1. If you already have a Sitecore instance with a different hostname:
      1. Add a host file entry named "dinocore.sc" to 127.0.0.1
      2. Add a binding to your Sitecore instance ISS website to "dinocore.sc" on port 80
      3. Add this to the configuration of your Sitecore instance Identity Server: `C:\inetpub\wwwroot\YoursitecoreInstance.identityserver\Config\production\Sitecore.IdentityServer.Host.xml`

            ```xml
            <?xml version="1.0" encoding="utf-8" ?>
            <Settings>
              <Sitecore>
                <IdentityServer>
                  <Clients>
                    <DefaultClient>
                      <AllowedCorsOrigins>
                        <dinocore>http://dinocore.sc</dinocore>
                      </AllowedCorsOrigins>
                    </DefaultClient>
                  </Clients>
                </IdentityServer>
              </Sitecore>
            </Settings>
            ```

      4. Recycle the application pool of your Sitecore instance Identity Server.
2. Download and install the Sitecore JSS Server Package for Sitecore 9.1 using the Sitecore Installation Wizard: [Sitecore JavaScript Services Server for Sitecore 9.1 XP 11.0.0 rev. 181031.zip](https://dev.sitecore.net/~/media/28F918CC225547EF9605C9ECD574D007.ashx)
3. Download and install the Dinocore Sitecore package using the Sitecore Installation Wizard: [SCHackathon 2019 - Cheese n Frog - Dinocore-1.0.zip](sc.package/SCHackathon%202019%20-%20Cheese%20n%20Frog%20-%20Dinocore-1.0.zip)
4. Open the Sitecore instance administration: [Sitecore Administration](http://dinocore.sc/sitecore)
5. From the Sitecore Control Panel, rebuild the `sitecore_master_index` using the Indexing Manager.

---

## How to use

Follow these steps after installing the module:

- Point your browser to **[http://dinocore.sc](http://dinocore.sc)**

![Dinocore screenshot](documentation/images/screenshot.png?raw=true "Dinocore screenshot")

- Click in the game window, directly below the Dinocore logo, to start a new game.
- You can avoid obstacles by jumping. Use the **__left mouse__** button or press the **__spacebar__** key to jump.

While you are running, your current highscore will be continuously updated and stacked up against the highscores of other players. Keep your eyes on the leaderboard while you race!

---

## Developer Setup

If you want to play with the code and deploy the solution to your local Sitecore instance.

- Repository path: `D:\_Hackathon\2019-Cheese-n-Frog`
- Sitecore instance path: `C:\inetpub\wwwroot\dinocore.sc`
- Sitecore instance hostname: `dinocore.sc`

Deployment order:

1. Build and deploy all 3 projects in the `Hackathon.Dinocore.sln` solution.
2. Run the Unicorn synchronization.
3. Build and deploy the JSS application in the `/src/jss` folder using:
   1. `jss deploy config`
   2. `jss deploy app -c -d`

---

## Contributors

This Sitecore Hackathon 2019 entry was realized by the hard work of:

- Wessel 't Hoen: [GitHub](https://github.com/wgrthoen)
- Gary Wenneker: [Twitter](https://twitter.com/GaryWenneker) - [GitHub](https://github.com/GaryWenneker) - [Website](https://gary.wenneker.org/)
- Jean-François L'Heureux: [Twitter](https://twitter.com/jflh) - [GitHub](https://github.com/jflheureux) - [Website](https://www.jflh.ca)