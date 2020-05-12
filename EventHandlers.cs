using System;
using EXILED;
using MEC;
using DiscordIntegration_Plugin;


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
						ProcessSTT.SendData($"\n> ~~-------------------------------------------~~" +
$"\n> {plugin.msgbanneduser}: {ev.Details.OriginalName} " +
$"\n> SteamID64: {ev.Details.Id} " +
$"\n> {plugin.msgbanissuer}: {ev.Details.Issuer} " +
$"\n> {plugin.msgreason}: {reason} " +
$"\n> {plugin.msgexpires}: {FormattedDate} " +
$"\n> ~~-------------------------------------------~~", plugin.banchannel);
					} else
					{
						ProcessSTT.SendData($"\n{plugin.msgbanneduser}: {ev.Details.OriginalName} " +
$"\nSteamID64: {ev.Details.Id} " +
$"\n{plugin.msgbanissuer}: {ev.Details.Issuer} " +
$"\n{plugin.msgreason}: {reason} " +
$"\n{plugin.msgexpires}: {FormattedDate} ", plugin.banchannel);
					}
			});
			return;
		}
	}
}
