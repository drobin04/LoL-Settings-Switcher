# LoL-Settings-Switcher

![Main](/LoL-Settings-Switcher/img/main.png)

Youtube Video - https://www.youtube.com/watch?v=UebHuESrPwU

This app has the following features: 

* Account Switcher
    * Allows you to store the active logon authentication cookie for a session for multiple accounts, and switch between them, for multiple league of legends accounts.
    * Functions by copying out the AppData / Local / Riot Games / Riot Client directory to a separate folder, once per each active account.
        * Haven't spent enough time to accurately distinguish which file(s) in this folder are important for the logon, but copying the whole folder does work, so this is what we're doing for now.
    * In effect, this allows you to effortlessly swap between multiple League of Legends accounts without having to retype in your password for each account every time you switch. 
* Settings Locker
    * Allows you to lock your keybinding settings / other in game settings for League of Legends, so that when switching between accounts, you will carry your settings from one account to another.
    * Also causes your settings from the first account to overwrite subsequent accounts, providing you a way to transfer settings from one account to another. 
    * Functions by locking/unlocking the 'game.cfg' and 'persistedsettings.json' files in your C:\Riot Games\Config\ directory, which will force your settings from one account to another.

## Usage

### Account Switcher Setup

1. Open the application
    * When prompted, select a working directory for the game settings files for the accounts to be stored in
2. Open league of legends and sign into an account
3. Click 'Add', and enter a nickname for this account to appear in the accounts dropdown. The riot client folder for this account will be copied to the working directory.
4. For further accounts, click 'Sign Out To Add New'. 
    * The Riot Client will be closed, and you will be able to log into a new account without expiring the token for the old login
    * this works by deleting the riot client settings folder that was copied previously. 
    * If you don't use this step, and instead click 'Sign Out', it expires your authentication token and the copied login won't work anymore. 
5. For further accounts, repeat steps 2-4. 
6. To sign into / switch between accounts, select the account from the dropdown and then select 'Load'.
    * The account will be copied to the current riot client settings, and the league client will be closed (if open) and then relaunched, and should now be logged into that account. 


### Settings Locker / Transfer

To use: 
- Log into one account you want to move settings FROM, play a game / use practice tool so that game stores settings into the local files
- Open this app and press 'Lock Settings'. 
- Log into other account and queue into your match and your settings should be copied. 

You can then unlock your settings and tweak as needed. 


# Setup

Download and run [the setup files](/installer/Release/Lol-Settings-Switcher.zip) to install the application. 

On first launch, the application will prompt you to select a working directory, which is used to copy the riot client files for each account logon. 
