# Description
mhf_displayer is a C# form that shows various useful infomations on display.  

# Download
Go release section and download latest version.

# Build
Drop `mhf_displayer.cfg` to the same place where exe created if you build it yourself.

# Usage
After the game has started, run `mhf_displayer.exe`.  
It's recommended to start displayer while you are in lobby, otherwise it will crash.  
Windows Defender may scan the app only once at the beginning of launch, this is because displayer accesses game memory.  
`mhf_displayer.cfg` file is used to store your config value.  

To access config menu right click somewhere on displays.  
![image](https://user-images.githubusercontent.com/89909040/168278420-a19a9e88-a5c0-4ffb-a93e-81c03ce59a8b.png)  

While you are in config menu, you can move displays(player panel, monster panel etc.)　by drag and drop

To toggle monster, press `LeftAlt`+`F12`. (v1.6: doesn't work (?))  

# Project status

## High-Grade Edition(HGE)
-

## Non High-Grade Edition
- Cannot get monster size value. 

## Known issues
- If nothing happens after starting mhf_displayer, it may be required to install .Net SDK(x86).  
https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- Does not show HP of small monsters.
- Does not work correctly on Great Slaying and Caravan quest.
- Does not show resistance and status values for 3rd and 4th or more large monster(But are there quests where they exist?).
- Cannot get True value of player attack correctly.  
- Somehow changing monster function doesn't work(v1.6)
- Does not work on Hunter's Road quest correctly.

## Todo
- Support for various types of display resolutions.
- Add Japanese support.


# Changelog

## v1.0
- Initial release.

## v1.1
- Added configuration file `mhf_displayer.cfg`.  
- Display position is changeable via config fiile.  
- Added monster name.  
- Added monster attack multiplier.  
- Added monster defence multiplier.  
- Added Hit counts.

## v1.1.1
- Changed size of HP label.  
- Added config file to root folder(for those who want to build themselves).

## v1.2
- Added remaining time.  
- Added time display option to config file.  

## v1.2.1
- Now remaining or elapsed time can be selected through config fiile.  

## v1.3
- Added the ability to display damage dealt by player(experimental). You can disable this function via config file.

## v1.3.1
- Added a label to show player attack value, only works in quest. You can select true or raw value via config file.  
- Added a relaod button to relaod UI.

## v1.3.2
- Changed reload button text to R from C.  
- Added deleted image file.  

## v1.4
- Added `C` button for configuration menu.  
- Added configuration menu. Press `C` buttton to access.  
- All previous displays are divided into 3 panels. You can configure them separately.  
- Fixed a problem where strange HP values were displayed for a moment.  
- Changed to be able to display HP of multiple large monster at same time, up to 4.   
- Added a panel that shows various values of large monster such as poison, sleep. Currently only works for 1st monster.  

## v1.4.1
- Added non-HGE support, but monster info panel is disabled temporary.  
- Fixed a problem where even the buttons disappeared when the player information panel was turned off.

## v1.4.2
- Added a panel that shows resistance of each body parts of large monster. Cueently only works for HGE, and 1st monster.
- Fixed a problem in which information could not be obtained correctly if the displayer is repeatedly started when the game is already running.

## v1.4.3
- Added mosnter size value text(100% base).
- Fixed a problem in which the HP was not displayed correctly when there were multiple large monsters.
- (add) Probably fixed a dll error.

## v1.4.4
- Now dispalyer works on Hunter's Road, but resistance and status values are disabled. It only shows their HP. Besides that you can't know their HP until you enter battle field.
- Changed so that the display of resistance and status values can be toggled when there are multiple large monsters. To toggle, press `LeftAlt`+`F12`. This only works for 1st and 2nd monster. If the monster is selected, it is marked with a star at the beginning of its name.
- Fixed a problem where stun values were not being displayed correctly.

## v1.4.5
- Fixed a problem in which damage notations were displayed even if they were turned off.

## v1.5
- ~~(HGE) Now works on Hunter's road quest.~~
- (nonHGE) Now it shows monster's resistance and status values.
- ~~(nonHGE) Now works on Hunter's road quest.~~

## v1.6
- `mhf_displayer.cfg` file is updated.
- Text font, size and color are now changeable.
- Added right click menu to displayer for opening config menu and closing the app.
- While you are in config menu, you can move displays(player panel, monster panel etc.) by drag and drop.
- Changed config menu UI.
- Deleted `C` and `X` button. 

## v1.6.1
- Probably working correctly on Hunte's Road both HGE and nonHGE.

