using System;
using System.Collections.Generic;
using AutoMapper;
using DonationTracker.Integration;
namespace DonationTracker.Service
{
    public class ServiceOperations : IServiceOperations
    {
        private readonly IIntegrationOperations operations;
        private readonly IMapper mapper;

        public ServiceOperations(IIntegrationOperations operations)
        {
            this.operations = operations;
            mapper = SetupObjectToObjectMappings();
        }

        public IMapper SetupObjectToObjectMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Integration.DonorDonation, Service.DonorDonation>();
                cfg.CreateMap<Service.DonorDonation, Integration.DonorDonation>();
                cfg.CreateMap<Integration.DonorDonationTotalByDonor, Service.DonorDonationTotalByDonor>();
                cfg.CreateMap<Integration.DonorQuery, Service.DonorQuery>();
            });

            // only during development, validate your mappings; remove it before release
            configuration.AssertConfigurationIsValid();

            var mapper = configuration.CreateMapper();
            return mapper;
        }

        public void AddDonor(DonorDonation donation)
        {
            try
            {
                var donation2 =
                  mapper.Map<Service.DonorDonation, Integration.DonorDonation>
                    (donation);
                operations.AddDonor(donation2);
            }
            catch (IntegrationLayerException exception)
            {
                throw new ServiceLayerException(exception);
            }
            catch (Exception exception)
            {
                throw new ServiceLayerException("Something went wrong at the service layer", exception);
            }
        }

        private IList<DonorDonation> ConvertDonorDonationsFrom(IList<Integration.DonorDonation> donorDonationsIn)
        {
            IList<DonorDonation> donorDonationsOut =
              mapper.Map<IList<Integration.DonorDonation>,
                         IList<Service.DonorDonation>>
                     (donorDonationsIn);
            return donorDonationsOut;
        }

        public IList<DonorDonation> ReadAllDonors()
        {
            try
            {

                IList<Integration.DonorDonation> donorDonations =
                operations.ReadAllDonors();

                return ConvertDonorDonationsFrom(donorDonations);
            }
            catch (IntegrationLayerException exception)
            {
                throw new ServiceLayerException(exception);
            }
            catch (Exception exception)
            {
                throw new ServiceLayerException("Something went wrong at the service layer", exception);
            }

        }


        public IList<DonorDonation> ReadSubsetOfDonors(int offset, int limit)
        {
            IList<Integration.DonorDonation> donorDonations = operations.ReadSubsetOfDonors(offset, limit);
            return ConvertDonorDonationsFrom(donorDonations);
        }



        public IList<DonorDonationTotalByDonor> CalculatePerDonorTotalDonationAmount()
        {
            IList<Integration.DonorDonationTotalByDonor> donorDonations2 =
                operations.CalculatePerDonorTotalDonationAmount();

            IList<DonorDonationTotalByDonor> donorDonations =
              mapper.Map<IList<Integration.DonorDonationTotalByDonor>,
                         IList<Service.DonorDonationTotalByDonor>>
                         (donorDonations2);
            return donorDonations;
        }

        public int? GetIDOfMatchingDonor(DonorQuery donorQuery)
        {
            var donorQuery2 =
            mapper.Map<Service.DonorQuery, Integration.DonorQuery>(donorQuery);

            return operations.GetIDOfMatchingDonor(donorQuery2);
        }

        public decimal CalculateTotalDonationAmount()
        {
            decimal total = operations.CalculateTotalDonationAmount();

            return total;
        }
    }
}
