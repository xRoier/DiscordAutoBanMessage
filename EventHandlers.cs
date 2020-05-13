using System;
using EXILED;
using MEC;
using System.Collections.Generic;
using System.Linq;
using EXILED.Extensions;

namespace DiscordAutoBanMsg
{
    public class EventHandlers
    {
        public Plugin plugin;
		public string reason;
		public EventHandlers(Plugin plugin) => this.plugin = plugin;

		public void OnPlayerBan(PlayerBannedEvent ev)
		{
			if (ev.Details.Id.Contains(".")) return;
			if (plugin.replacelowbars)
			{
				reason = ev.Details.Reason.Replace("_"," ");
			}
			else
			{
				reason = ev.Details.Reason;
			}
			DateTime ExpireDate = new DateTime(ev.Details.Expires).AddHours(2);
			string FormattedDate = ExpireDate.ToString("dd/MM/yyyy HH:mm");
			Timing.CallDelayed(0.5f, () =>
			{
				if (plugin.banchannel == 000000000100)
				{
					Log.Info($"{plugin.msgnochanneldef}");
					return;
				}
					if (plugin.decoremsg)
					{
					DiscordIntegration_Plugin.ProcessSTT.SendData($"\n> ~~-------------------------------------------~~" +
$"\n> {plugin.msgbanneduser}: {ev.Details.OriginalName} " +
$"\n> SteamID64: {ev.Details.Id} " +
$"\n> {plugin.msgbanissuer}: {ev.Details.Issuer} " +
$"\n> {plugin.msgreason}: {reason} " +
$"\n> {plugin.msgexpires}: {FormattedDate} " +
$"\n> ~~-------------------------------------------~~", plugin.banchannel);
					} else
					{
					DiscordIntegration_Plugin.ProcessSTT.SendData($"\n{plugin.msgbanneduser}: {ev.Details.OriginalName} " +
$"\nSteamID64: {ev.Details.Id} " +
$"\n{plugin.msgbanissuer}: {ev.Details.Issuer} " +
$"\n{plugin.msgreason}: {reason} " +
$"\n{plugin.msgexpires}: {FormattedDate} ", plugin.banchannel);
					}
			});
			return;
		}

		public void OnRACommand(ref RACommandEvent ev)
		{
			List<string> args = ev.Command.Split(' ').ToList();
			ReferenceHub sender = ev.Sender.SenderId == "SERVER CONSOLE" || ev.Sender.SenderId == "GAME CONSOLE" ? PlayerManager.localPlayer.GetPlayer() : Player.GetPlayer(ev.Sender.SenderId);
			string cmd = args[0].ToLower();
			if (cmd == "dabm")
			{
				if (!sender.CheckPermission("dabm.reload") || !sender.CheckPermission(".*"))
				{
					ev.Sender.RAMessage($"{plugin.msgnoperm}");
					return;
				}
				plugin.LoadConfig();
				Timing.CallDelayed(0.5f, () => 
				{
					plugin.LoadTranslations();
				});
				ev.Sender.RAMessage($"{plugin.msgconfigreload}");
				Log.Info($"{plugin.msgconfigreload}");
				return;
			}
		}

	}
}
