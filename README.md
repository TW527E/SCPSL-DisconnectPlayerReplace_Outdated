# Disconnect Player Replace
![EXILED CI](https://github.com/galaxy119/EXILED/workflows/EXILED%20CI/badge.svg?branch=2.0.0)
<a href="https://discord.gg/JQcM2WwYfH">
  <img src="https://img.shields.io/discord/770662699239473162?logo=discord" alt="Chat on Discord">
</a><br>
Made By Canhui Server Enginner Cheng Cheng#7773

# Main Features
When the Player leaves the server, it is automatically replaced by a spectator.

# Default config:
```yaml
DisconnectPlayerReplace:
  is_enabled: true
  only_scp: false
  # Cassie
  is_noisy: true
  # You can find all words at here : https://steamcommunity.com/sharedfiles/filedetails/?id=1577299753
  cassie_message: '%Role% is been charge'
  # When Player Replace Message
  on_player_replace: <color=red>%Role%</color> <color=green> is been Replaced</color>.
```
