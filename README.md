# API Hacking
This is the base repository for the COMP140 API Hacking assignment.

## Proposal

For this project I am going to liaison for the BA team Gambit.
I will attempt to create a API for their game using the C# language and in unity.

For my API project I am going to change the weather state in the game to the current weather at the players physical location IRL.

There are many different weather APIs that I could find, so for my first sprint I aim to have found the most appropriate weather API and try to implement that into the game.

The file that contains my API code is within the RainSpawn.cs file.


##Trello Board:

![text](https://raw.githubusercontent.com/Alli1223/comp140-api-hacking/master/Trello_Board/Screenshot%202016-03-24%2012.48.01.png "Trello board")

![text](https://raw.githubusercontent.com/Alli1223/comp140-api-hacking/master/Trello_Board/Screenshot%202016-04-12%2019.00.44.png "Trello board at the start of the first sprint")

![text](https://raw.githubusercontent.com/Alli1223/comp140-api-hacking/master/Trello_Board/Screenshot%202016-05-02%2021.15.24.png "Trello board at the end of the second sprint")

![text](https://raw.githubusercontent.com/Alli1223/comp140-api-hacking/master/Trello_Board/Final.png "Final sprint")

##References:

http://docs.unity3d.com/ScriptReference/WWW.html

http://wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer

___

##Progress
Using the weather API it can return a text file or an XML file, so I am going to return a XML file and read the current weather from that.

I found that it was much easier to just return a string and use that to determine if it is raining, rather than writing and reading an XML file.

I recently came up with the idea that I could string some APIs together to get the nearest city to the player and use that for the weather information instead. This means that the player will no longer have to specify their Location in the game menu(which is not currently implemented)

I found a way to read XML tags in C#, so I am reading the weather codes tag and setting the weather based on that.

One problem I have ran into is that the UNI has blocked one of the APIs I was using to get the users IP address, however it still works with my home internet.

___
##Final product:
The file that contains my API code is within the RainSpawn.cs file.
The EXE of the game is located within the GitHub directory, however the build version is too large to put on GitHub, so here is a dropbox link to it: https://dl.dropboxusercontent.com/u/11825562/Uni/relics%20localcopy11.zip

___
##Current APIs in use

I used this API to get the weather at a city location:
api.openweathermap.org

I used this API to get the IP of the user:
http://api.ipify.org/

I will then use this API to access which city the user is in:
http://ipinfo.io/
