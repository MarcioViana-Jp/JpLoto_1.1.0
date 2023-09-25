namespace JpLoto.Application.Settings
{
    [Serializable]
    public class AppConfiguration
    {
        public AppSetting? AppSetting { get; set; }
        //public PrinterSetting? PrinterSetting { get; set; } = null;
        public CorsSetting? CorsSetting { get; set; }
        public SmtpSetting? SmtpSetting { get; set; }
        //public AppConfiguration(AppSetting setting, PrinterSetting printer, CorsSetting cors, SmtpSetting smtp)
        public AppConfiguration(AppSetting setting, CorsSetting cors, SmtpSetting smtp)
        {
            AppSetting = setting;
            //PrinterSetting = printer;
            CorsSetting = cors;
            SmtpSetting = smtp;
        }
    }
}

