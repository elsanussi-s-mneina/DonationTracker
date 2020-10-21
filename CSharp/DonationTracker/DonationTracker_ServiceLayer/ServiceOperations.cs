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
			try
			{
				IList<DonorDonation> donorDonationsOut =
			  mapper.Map<IList<Integration.DonorDonation>,
						 IList<Service.DonorDonation>>
					 (donorDonationsIn);
				return donorDonationsOut;
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
			try
			{
				IList<Integration.DonorDonation> donorDonations = operations.ReadSubsetOfDonors(offset, limit);
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



		public IList<DonorDonationTotalByDonor> CalculatePerDonorTotalDonationAmount()
		{
			try
			{

				IList<Integration.DonorDonationTotalByDonor> donorDonations2 =
		operations.CalculatePerDonorTotalDonationAmount();

				IList<DonorDonationTotalByDonor> donorDonations =
				  mapper.Map<IList<Integration.DonorDonationTotalByDonor>,
							 IList<Service.DonorDonationTotalByDonor>>
							 (donorDonations2);
				return donorDonations;
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

		public int? GetIDOfMatchingDonor(DonorQuery donorQuery)
		{
			try
			{
				var donorQuery2 =
mapper.Map<Service.DonorQuery, Integration.DonorQuery>(donorQuery);

				return operations.GetIDOfMatchingDonor(donorQuery2);
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

		public decimal CalculateTotalDonationAmount()
		{
			try
			{

				decimal total = operations.CalculateTotalDonationAmount();

				return total;
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
	}
}
