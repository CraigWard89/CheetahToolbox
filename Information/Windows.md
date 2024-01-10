# Windows
These are notes on Windows

## General Info

https://renenyffenegger.ch/notes/Windows/

Start Menu Locations
```
C:\ProgramData\Microsoft\Windows\Start Menu\Programs\
C:\Users\craig\AppData\Roaming\Microsoft\Windows\Start Menu\
```

## Investigate

Investigate These Paths as Windows seems to leave entries from uninstalled programs here
```
HKEY_USERS\S-1-5-21-4135085899-3670623898-1780540100-1001\Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache
HKEY_USERS\S-1-5-21-4135085899-3670623898-1780540100-1001\Control Panel\NotifyIconSettings
```
[Title](IShellDispatch3:%253AExplore%2509%2509%25091610743814%2520%25280x60020006%2529%2509shell32.dll%2509C%253A%255CWINDOWS%255Csystem32%255Cshell32.dll%2509COM%2520Method%2509)
[Title](C:/)

## Miscellaneous

When putting `Applications` in to Explorer, it will show the `Applications` folder.<br>
I need to figure out how to modify the files in this folder.<br>
As I believe this is where the `Start Menu` is stored when you click `All Apps`<br>
Sometimes Windows will leave entries in the `Start Menu` even after uninstalling the program.<br>

---
[Back to Readme](https://github.com/CraigCraig/CheetahToolbox/blob/main/README.md)