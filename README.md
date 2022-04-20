# Description
mhf_displayer is a C# form that shows various useful infomations on display.  

D3D has an overlay function, if you have enough knowledge you can do similar things with that, like Lvdew.  
## Notes
I'm working on for non HGE version, almost done but unable to find poinster of values such as poison, sleep etc.

# Download
Go release section and download latest version.

# Build
If you feel you want to build the project youeself, place `mhf_displayer.cfg` to the same place where exe created.

# Usage
After game has started, run `mhf_displayer.exe`.  
It's recommended to start it while you are in lobby, otherwise the game will crash.  
Windows Defender may try to scan app only once at the beginning of launch.  
This is because mhf_displayer accesses game memory.  

Press `X` button to shutdown the app.  
Press `C` button to open configuration menu.

`mhf_displayer.cfg` file is used to store your config value.  

# Known issues
- Cannot get True value of player attack correctly.  
- When you try to run displayer multiple times while game is runnning, displayer cannot load correct values. (Apr:20)    
- If nothing happens after starting mhf_displayer, it may be required to install .Net SDK(x86).  
https://dotnet.microsoft.com/en-us/download/dotnet/6.0


# Changelog

## v1.0
Initial release.

## v1.1
Added configuration file `mhf_displayer.cfg`.  
Display position is changeable via config fiile.  
Added monster name.  
Added monster attack multiplier.  
Added monster defence multiplier.  
Added Hit counts.

## v1.1.1
Changed size of HP label.  
Added config file to root folder(for those who want to build themselves).

## v1.2
Added remaining time.  
Added time display option to config file.  

## v1.2.1
Now remaining or elapsed time can be selected through config fiile.  

## v1.3
Added the ability to display damage dealt by player(experimental). You can disable this function via config file.

## v1.3.1
Added a label to show player attack value, only works in quest. You can select true or raw value via config file.  
Added a relaod button to relaod UI.

## v1.3.2
Changed reload button text to R from C.  
Added deleted image file.  

## v1.4
Added `C` button for configuration menu.  
Added configuration menu. Press `C` buttton to access.  
All previous displays are divided into 3 panels. You can configure them separately.  
Fixed a problem where strange HP values were displayed for a moment.  
Changed to be able to display HP of multiple large monster at same time, up to 4.   
Added a panel that shows various values of large monster such as poison, sleep. Currently only works for 1st monster.  

## v1.4.1
Added non-HGE support, but monster info panel is disabled temporary.  
Fixed a problem where even the buttons disappeared when the player information panel was turned off.

