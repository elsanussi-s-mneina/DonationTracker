using AutoMapper;
using DonationTracker.Desktop.Model;
using DonationTracker.Integration;
using DonationTracker.Service;

namespace DonationTracker.Desktop
{
    public class MainHelper : IMainHelper
    {
        public MainHelper()
        {
        }

        public MainForm ConstructUsualMainForm()
        {
            return ConstructLocalizedMainForm("en_US");
        }

        public MainForm ConstructLocalizedMainForm(string locale)
        {
            IMapper ooMapper = SetupObjectToObjectMappings();
            return new MainForm(
                        new DesktopOperations
                        (new ServiceOperations
                        (new IntegrationOperations
                        (new DBConnect())), ooMapper),
                        new TextResourcesPersistence().ReadLocale(locale));
        }

        public void SetupInternationalization()
        {
            var textResourcesPersistence = new TextResourcesPersistence();
            textResourcesPersistence.SetupInternationalizationDirectory();
        }

        public IMapper SetupObjectToObjectMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Desktop.Model.DonorDonation, Service.DonorDonation>();
                cfg.CreateMap<Service.DonorDonation, Desktop.Model.DonorDonation>();
                cfg.CreateMap<Service.DonorDonationTotalByDonor, Desktop.Model.DonorDonationTotalByDonor>();
            });

            // only during development, validate your mappings; remove it before release
            configuration.AssertConfigurationIsValid();

            var mapper = configuration.CreateMapper();
            return mapper;
        }
    }
}
