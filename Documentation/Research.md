# RnD

scorecardresearch.com gathers data of windows for market research, could be blocked for more privacy.

assets.msn.com is used for getting news/weather and stuff for widgets and edge
can be blocked. but will make it so widget doesn't work on windows at all

edge.microsoft.com Provide data for browser features such as tracking protection, certification revocation list, spellcheck dictionaries and more

bingapis.com basically what i could find is that edge sends what urls you visit to here for Bing
can be block wont cause any problem.

activity.windows.com go [here](https://support.microsoft.com/en-us/windows/-windows-activity-history-and-your-privacy-2b279964-44ec-8c2f-e0c2-6779b07d2cbd) for more info what its sent here 
can be block for more privacy.

Msftconnecttest.com is a website created by Microsoft to assess the network connectivity of users and ensure that their experience with Microsoft Teams and other Microsoft services is seamless.

could be blocked i guess.

[connection endpoints enterprise](https://learn.microsoft.com/en-us/windows/privacy/manage-windows-11-endpoints) could be intresting to look through

[connection endpoints none enterpriese](https://learn.microsoft.com/en-us/windows/privacy/windows-11-endpoints-non-enterprise-editions)

```txt
HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\SharedAccess\Parameters\FirewallPolicy\FirewallRules
pretty self explaning. is the firewall rules aka if its allowed through
HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\LowRegistry\Audio\PolicyConfig\PropertyStore\
pretty sure this for the audio control
HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FeatureUsage\
telemetry
HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone\NonPackaged
keep tracking when used the mic or when stop using it
and other stuff
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\
HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall
In here you can remove it from showing up on installed apps on windows
```

it would be really really nice to get a cleaner to remove old discord registry paths. as there is a lot of them as they make new once for every new version they push. aka there is a lot of them :)
not even gonna list them as there is to many



👍 👎 💯
