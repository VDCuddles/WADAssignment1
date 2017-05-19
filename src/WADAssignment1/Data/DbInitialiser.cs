using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WADAssignment1.Data;

namespace WADAssignment1.Models
{
	public static class DbInitialiser
	{
		public static void Initialise(ApplicationDbContext context)
		{
			context.Database.EnsureCreated();
			// Look for any Bags.
			if (context.Bags.Any())
			{
				return; // DB has been seeded
			}

			var suppliers = new Supplier[]
			{
				new Supplier{ContactPhMob=027645661,ContactEmail="derp@hurr.com",Name="Puma"},
				new Supplier{ContactPhMob=027634561,ContactEmail="derp1@hurr.com",Name="Jan Sport"},
				new Supplier{ContactPhMob=027643463,ContactEmail="derp2@hurr.com",Name="Kathmandu"},
				new Supplier{ContactPhMob=027644561,ContactEmail="derp3@hurr.com",Name="Adidas"},
				new Supplier{ContactPhMob=027676541,ContactEmail="derp4@hurr.com",Name="Nike"},
				new Supplier{ContactPhMob=027623471,ContactEmail="derp5@hurr.com",Name="Oakley"},
				new Supplier{ContactPhMob=027345661,ContactEmail="derp6@hurr.com",Name="New Balance"},

			};
			foreach (Supplier e in suppliers)
			{
				context.Suppliers.Add(e);
			}
			context.SaveChanges();


			var bags = new Bag[]
			{
				new Bag{SupplierID = suppliers.Single(s => s.Name == "Puma").ID,Name="Dingus",CategoryName="MensBags", Description="It sucks", Image="images/examplefilepath.jpg", Price=15.00},
				new Bag{SupplierID = suppliers.Single(s => s.Name == "Kathmandu").ID,Name="Dingus1",CategoryName="ChildrensBags", Description="It sucks", Image="images/examplefilepath.jpg", Price=15.00},
				new Bag{SupplierID = suppliers.Single(s => s.Name == "Kathmandu").ID,Name="Dingus2",CategoryName="WomensBags", Description="It sucks", Image="images/examplefilepath.jpg", Price=15.00},
				new Bag{SupplierID = suppliers.Single(s => s.Name == "Oakley").ID,Name="Dingus3",CategoryName="ChildrensBags", Description="It sucks", Image="images/examplefilepath.jpg", Price=15.00},
				new Bag{SupplierID = suppliers.Single(s => s.Name == "Puma").ID,Name="Dingus4",CategoryName="WomensBags", Description="It sucks", Image="images/examplefilepath.jpg", Price=15.00},
				new Bag{SupplierID = suppliers.Single(s => s.Name == "Oakley").ID,Name="Dingus5",CategoryName="MensBags", Description="It sucks", Image="images/examplefilepath.jpg", Price=15.00},
				new Bag{SupplierID = suppliers.Single(s => s.Name == "Puma").ID,Name="Dingus6",CategoryName="WomensBags", Description="It sucks", Image="images/examplefilepath.jpg", Price=15.00}

			};
				foreach (Bag s in bags)
			{
				context.Bags.Add(s);
			}
			context.SaveChanges();


			//var customers = new Customer[]
			//{
			//	new Customer{ContactPhMob=027645661,ContactEmail="derp@hurr.com",ContactAddress="12 Derpingshire Street, New Herpington", Name="Herlingxander the Derped"},
			//	new Customer{ContactPhMob=027645671,ContactEmail="derp1@hurr.com",ContactAddress="12 Derpingshire Street, New Herpington", Name="Herlingxander the Second"},
			//	new Customer{ContactPhMob=027646741,ContactEmail="derp2@hurr.com",ContactAddress="12 Derpingshire Street, New Herpington", Name="Herlingxander the Third"},
			//	new Customer{ContactPhMob=027645341,ContactEmail="derp3@hurr.com",ContactAddress="12 Derpingshire Street, New Herpington", Name="Herlingxander the Fourth"},
			//	new Customer{ContactPhMob=027642351,ContactEmail="derp4@hurr.com",ContactAddress="12 Derpingshire Street, New Herpington", Name="Herlingxander the Fifth"},
			//	new Customer{ContactPhMob=027656578,ContactEmail="derp5@hurr.com",ContactAddress="12 Derpingshire Street, New Herpington", Name="Herlingxander the Sixth"},
			//	new Customer{ContactPhMob=027456641,ContactEmail="derp6@hurr.com",ContactAddress="12 Derpingshire Street, New Herpington", Name="Herlingxander the Seventh"},

			//};
			//foreach (Customer c in customers)
			//{
			//	context.Customers.Add(c);
			//}
			//context.SaveChanges();


			//var orders = new Order[]
			//{
			//	new Order{CustomerID = customers.Single(c => c.Name == "Herlingxander the Fifth").ID,Subtotal=4.5,GST=3,GrandTotal=7.5},
			//	new Order{CustomerID = customers.Single(c => c.Name == "Herlingxander the Derped").ID,Subtotal=4.5,GST=3,GrandTotal=7.5},
			//	new Order{CustomerID = customers.Single(c => c.Name == "Herlingxander the Second").ID,Subtotal=4.5,GST=3,GrandTotal=7.5},
			//	new Order{CustomerID = customers.Single(c => c.Name == "Herlingxander the Third").ID,Subtotal=4.5,GST=3,GrandTotal=7.5},
			//	new Order{CustomerID = customers.Single(c => c.Name == "Herlingxander the Second").ID,Subtotal=4.5,GST=3,GrandTotal=7.5},
			//	new Order{CustomerID = customers.Single(c => c.Name == "Herlingxander the Seventh").ID,Subtotal=4.5,GST=3,GrandTotal=7.5},
			//	new Order{CustomerID = customers.Single(c => c.Name == "Herlingxander the Fifth").ID,Subtotal=4.5,GST=3,GrandTotal=7.5},
			//	new Order{CustomerID = customers.Single(c => c.Name == "Herlingxander the Third").ID,Subtotal=4.5,GST=3,GrandTotal=7.5},

			//};
			//foreach (Order c in orders)
			//{
			//	context.Orders.Add(c);
			//}
			//context.SaveChanges();


		}
	}
}
