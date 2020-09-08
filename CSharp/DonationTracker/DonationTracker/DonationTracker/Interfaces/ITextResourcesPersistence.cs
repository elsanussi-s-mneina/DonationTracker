namespace DonationTracker.Desktop
{
    public interface ITextResourcesPersistence
    {
        string ConstructLocalePath(string locale);
        ITextResources ReadFromFile(string filePath);
        ITextResources ReadLocale(string locale);
        void SetupInternationalizationDirectory();
        void WriteToFile(string filePath, ITextResources resources);
    }
}