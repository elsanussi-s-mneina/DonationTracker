using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;
using System.Collections.ObjectModel;

namespace DonationTracker.Desktop
{
    // This is just an example, from a sample.
    public class MyPoco
    {
        public string Text { get; set; }
        public bool Check { get; set; }
    }

    public class DonorAdditionWindow : Form
    {
        private readonly DesktopOperations operations;

        public DonorAdditionWindow(DesktopOperations operations)
        {
            this.operations = operations;
            XamlReader.Load(this);

			var collection = operations.ReadAllDonors();

			var grid = new GridView { DataStore = collection };

			grid.Columns.Add(new GridColumn
			{
				DataCell = new TextBoxCell { Binding = Binding.Property<Model.DonorDonation, string>(r => r.FirstName) },
				HeaderText = "First Name"
			});

			grid.Columns.Add(new GridColumn
			{
				DataCell = new TextBoxCell { Binding = Binding.Property<Model.DonorDonation, string>(r => r.LastName) },
				HeaderText = "Last Name"
			});

			grid.Columns.Add(new GridColumn
			{
				DataCell = new TextBoxCell { Binding = Binding.Property<Model.DonorDonation, string>(r => r.DonationAmount.ToString()) },
				HeaderText = "Amount"
			});

			Content = grid;

		}
	}
}
