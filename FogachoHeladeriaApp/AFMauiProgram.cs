using Microsoft.Extensions.Logging;

namespace FogachoHeladeriaApp
{
    public static class AFMauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<AFApp>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("LondrinaSolid-Regular.ttf", "LondrinaSolid");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
