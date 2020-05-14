# DiscordAutoBanMessage

A Add-on for **[DiscordIntegration](https://github.com/galaxy119/DiscordIntegration)** that automatically send a message to a specified Discord channel with the information of a ban.

# Config
| Config | Type | Description |
| ------ | ------ | ------ |
| dabm_enable | boolean | **true by default.** Enables or disables the plugin. |
| dabm_language | String | **en by default.** en/es/fr/ja/ch/ru/pl change language of the message. |
| dabm_banchannel | ulong | **required** specifies the Channel ID of the Discord ban channel (Example: 656790333320855562) |
| dabm_decoremsg | boolean | **true by default.** Decorate the message of the ban a little bit with a couple of lines at the beginning and end of the message. |
| dabm_reason_replacelowbars | boolean | **false by default.** Useful for entering spaces in the ban reason using oban, replacing the low bars with spaces. |

# Command
| Command | Permission | Description |
| ------ | ------ | ------ |
| dabm | dabm.reload | Reload config in round. |

# Installation

**[EXILED](https://github.com/galaxy119/EXILED) and [DiscordIntegration](https://github.com/galaxy119/DiscordIntegration) must be installed for this to work.**

Place the "DiscordAutoBanMessage.dll" file in your Plugins folder.
Windows: %appdata%/Plugins
Linux: ../.config/Plugins/
