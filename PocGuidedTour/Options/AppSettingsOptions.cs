namespace PocGuidedTour.Options;

public class AppSettingsOptions
{
    public const string Tour1 = "Tour1";
    public List<TourItem> Steps { get; set; } = new();

    public class TourItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int TourStepSequence { get; set; }
        public string ElementSelector => GetElementSelectorFormated();
        public string Url { get; set; }

        public string GetElementSelectorFormated()
        {
            return $"[data-tour-step-{TourStepSequence}]";
        }
    }

    private AppSettingsOptions()
    {
    }

    private static AppSettingsOptions instance = null;

    public static AppSettingsOptions Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AppSettingsOptions();
            }

            return instance;
        }
    }
}