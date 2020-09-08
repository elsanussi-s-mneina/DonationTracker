using AutoMapper;

namespace DonationTracker.Desktop
{
    public interface IMainHelper
    {
        MainForm ConstructLocalizedMainForm(string locale);
        MainForm ConstructUsualMainForm();
        void SetupInternationalization();
        IMapper SetupObjectToObjectMappings();
    }
}