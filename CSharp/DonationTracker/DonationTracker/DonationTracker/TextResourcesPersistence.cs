using System.IO;

namespace DonationTracker.Desktop
{
  public class TextResourcesPersistence
  {
    const string internationalizationDirectoryPath = "internationalization";

    public TextResourcesPersistence()
    {
    }

    public ITextResources ReadFromFile(string filePath)
    {
      string[] lines = File.ReadAllLines(filePath);
      return new TextResources(lines);
    }

    public void WriteToFile(string filePath, ITextResources resources)
    {
      File.WriteAllLines(filePath, resources.AsLines);
    }

    public void SetupInternationalizationDirectory()
    {
      if (!Directory.Exists(internationalizationDirectoryPath))
      {
        Directory.CreateDirectory(internationalizationDirectoryPath);
      }

      // Use english US as default locale
      string enUSPath = ConstructLocalePath("en_US");

      if (!File.Exists(enUSPath))
      {
        WriteToFile(enUSPath, new TextResources());
      }
    }

    public string ConstructLocalePath(string locale)
    {
      return Path.Combine(internationalizationDirectoryPath, locale + ".txt");
    }

    public ITextResources ReadLocale(string locale)
    {
      string resourcesPath = ConstructLocalePath(locale);
      ITextResources result;

      try
      {
        result = ReadFromFile(resourcesPath);
      }
      catch (IOException)
      {
        result = new TextResources();
      }

      return result;
    }
  }
}
