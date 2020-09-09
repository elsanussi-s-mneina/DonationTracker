using AutoMapper;
using DonationTracker.Integration;
using DonationTracker.Service;
using SimpleInjector;

namespace DonationTracker.Desktop
{
    public class MainHelper : IMainHelper
    {
         Container container;

        public MainForm ConstructUsualMainForm()
        {
            return ConstructLocalizedMainForm("en_US");
        }

        private string GetConnectionString()
        {
            string server = "localhost";
            string database = "donation_tracking";
            string uid = "donation_tracker_user";
            string password = "secret1secret";
            return "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        }

        public MainForm ConstructLocalizedMainForm(string locale)
        {
            IMapper ooMapper = SetupObjectToObjectMappings();

            container = new Container();
            container.Register<IDesktopOperations, DesktopOperations>(
                Lifestyle.Singleton);
            container.Register<IServiceOperations, ServiceOperations>(
                Lifestyle.Singleton);
            container.Register<IIntegrationOperations, IntegrationOperations>(
                Lifestyle.Singleton);
            container.Register<IDBConnect>(
                () => new DBConnect(GetConnectionString()),
                Lifestyle.Singleton);
            container.Register<ITextResources, DefaultEnglishTextResources>();

            container.Register<
                ITextResourcesPersistence,
                TextResourcesPersistence>(Lifestyle.Singleton);
            container.Register<IMapper>(() => SetupObjectToObjectMappings(),
                Lifestyle.Singleton);
            container.Verify();

            return new MainForm(
                container.GetInstance <IDesktopOperations>(),
                container.GetInstance<ITextResources>());
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
