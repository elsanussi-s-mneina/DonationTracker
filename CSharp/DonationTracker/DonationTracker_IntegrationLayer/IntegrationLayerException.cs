using System;
namespace DonationTracker.Integration
{
	public class IntegrationLayerException : Exception
	{
		public IntegrationLayerException(Exception exception)
			: base("Something went wrong at the integration layer", exception)
		{
		}
	}
}
