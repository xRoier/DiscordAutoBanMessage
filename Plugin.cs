using EXILED;
using MEC;

namespace DiscordAutoBanMsg
{
    public class Plugin : EXILED.Plugin
    {
        private EventHandlers EventHandlers;

        public override string getName => "DiscordAutoBanMsg";
        bool isEnabled;
        public ulong banchannel;
        public string language;
        public bool decoremsg;
        public bool replacelowbars;
        public string msgconfigdis;
        public string msgconfigenabled;
        public string msgnodiscordint;
        public string msgnochanneldef;
        public string msgbanneduser;
        public string msgbanissuer;
        public string msgreason;
        public string msgexpires;
        public string langname;
        public string msgconfigreload;
        public string msgnoperm;
        public override void OnEnable()
        {
            isEnabled = Config.GetBool("dabm_enable", true);
            language = Config.GetString("dabm_language");
            LoadTranslations();
            Timing.CallDelayed(1f, () => 
            {
                if (!isEnabled)
                {
                    Log.Info($"{msgconfigdis}");
                    return;
                }
                LoadConfig();
                Log.Info($"{msgconfigenabled}");
                EventHandlers = new EventHandlers(this);
                Events.PlayerBannedEvent += EventHandlers.OnPlayerBan;
                Events.RemoteAdminCommandEvent += EventHandlers.OnRACommand;
            });
        }
        

        public override void OnDisable()
        {
            Events.PlayerBannedEvent -= EventHandlers.OnPlayerBan;
            Events.RemoteAdminCommandEvent -= EventHandlers.OnRACommand;
            EventHandlers = null;
        }

        public void LoadConfig()
        {
            isEnabled = Config.GetBool("dabm_enable", true);
            banchannel = Config.GetULong("dabm_banchannel", 000000000100);
            language = Config.GetString("dabm_language");
            decoremsg = Config.GetBool("dabm_decoremsg", true);
            replacelowbars = Config.GetBool("dabm_reason_replacelowbars", false);
        }

        public override void OnReload()
        {
            LoadConfig();
        }

        public void LoadTranslations()
        {
            switch (language)
            {
                case "en":
                    {
                        langname = "English";
                        msgconfigdis = "Plugin is disabled by config.";
                        msgconfigenabled = "Plugin has been loaded. Language: " + langname;
                        msgnodiscordint = "DiscordIntegration plugin not found.";
                        msgnochanneldef = "The ban channel is undefined.";
                        msgbanissuer = "Banned by";
                        msgbanneduser = "User";
                        msgreason = "Reason";
                        msgexpires = "Expires";
                        msgconfigreload = "Configuration has been reloaded.";
                        msgnoperm = "You don't have permission.";
                        break;
                    }
                case "es":
                    {
                        langname = "Español";
                        msgconfigdis = "El plugin está desactivado en la configuración.";
                        msgconfigenabled = "El plugin ha cargado. Lenguaje: " + langname;
                        msgnodiscordint = "No se ha encontrado el plugin DiscordIntegration.";
                        msgnochanneldef = "El canal de baneos no está definido.";
                        msgbanissuer = "Baneado por";
                        msgbanneduser = "Usuario";
                        msgreason = "Razón";
                        msgexpires = "Expira";
                        msgconfigreload = "La configuración ha sido recargada.";
                        msgnoperm = "No tienes permiso.";
                        break;
                    }
                case "fr":
                    {
                        langname = "Français";
                        msgconfigdis = "Le plugin est désactivé dans les paramètres.";
                        msgconfigenabled = "Le plugin a été chargé. Langue: " + langname;
                        msgnodiscordint = "Plugin DiscordIntegration introuvable.";
                        msgnochanneldef = "Le canal d'interdiction n'est pas défini.";
                        msgbanissuer = "Interdit par";
                        msgbanneduser = "Utilisateur";
                        msgreason = "Raison";
                        msgexpires = "Expire";
                        msgconfigreload = "La configuration a été rechargée";
                        msgnoperm = "Tu n'as pas la permission";
                        break;
                    }
                case "ja":
                    {
                        langname = "Japanese";
                        msgconfigdis = "Plugin is disabled by config.";
                        msgconfigenabled = "Plugin has been loaded. Language: " + langname;
                        msgnodiscordint = "DiscordIntegration plugin not found.";
                        msgnochanneldef = "The ban channel is undefined.";
                        msgbanissuer = "禁止者";
                        msgbanneduser = "ユーザー";
                        msgreason = "理由";
                        msgexpires = "期限";
                        msgconfigreload = "Configuration has been reloaded.";
                        msgnoperm = "You don't have permission.";
                        break;
                    }
                case "ch":
                    {
                        langname = "Chinese";
                        msgconfigdis = "Plugin is disabled by config.";
                        msgconfigenabled = "Plugin has been loaded. Language: " + langname;
                        msgnodiscordint = "DiscordIntegration plugin not found.";
                        msgnochanneldef = "The ban channel is undefined.";
                        msgbanissuer = "被禁止由";
                        msgbanneduser = "用户名";
                        msgreason = "原因";
                        msgexpires = "过期";
                        msgconfigreload = "Configuration has been reloaded.";
                        msgnoperm = "You don't have permission.";
                        break;
                    }
                case "ru":
                    {
                        langname = "Russian";
                        msgconfigdis = "Plugin is disabled by config.";
                        msgconfigenabled = "Plugin has been loaded. Language: " + langname;
                        msgnodiscordint = "DiscordIntegration plugin not found.";
                        msgnochanneldef = "The ban channel is undefined.";
                        msgbanissuer = "Запрещенныйпо";
                        msgbanneduser = "пользователь";
                        msgreason = "причина";
                        msgexpires = "истекает";
                        msgconfigreload = "Configuration has been reloaded.";
                        msgnoperm = "You don't have permission.";
                        break;
                    }
                case "pl":
                    {
                        langname = "Polish";
                        msgconfigdis = "Wtyczka jest wyłączona w ustawieniach.";
                        msgconfigenabled = "Plugin załadowany. Język: " + langname;
                        msgnodiscordint = "Plugin DiscordIntegration nieznaleziony.";
                        msgnochanneldef = "Kanał do banów niezdefiniowany.";
                        msgbanissuer = "Zbanowany przez";
                        msgbanneduser = "Użytkownik";
                        msgreason = "Powód";
                        msgexpires = "Wygasa";
                        msgconfigreload = "Konfiguracja została ponownie załadowana.";
                        msgnoperm = "Nie masz pozwolenia";
                        break;
                    }
                        default:
                    {
                        langname = "English (Default)";
                        msgconfigdis = "Plugin is disabled by config. Language is not defined.";
                        msgconfigenabled = "Plugin has been loaded. Language: " + langname;
                        msgnodiscordint = "DiscordIntegration plugin not found.";
                        msgnochanneldef = "The ban channel is undefined.";
                        msgbanissuer = "Banned by";
                        msgbanneduser = "User";
                        msgreason = "Reason";
                        msgexpires = "Expires";
                        msgconfigreload = "Configuration has been reloaded.";
                        msgnoperm = "You don't have permission.";
                        break;
                    }
            }
        }
    }
}
