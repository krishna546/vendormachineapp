using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingmachineapp
{
	class vendingmachine
	{
		static void Main(string[] args)
		{
			vendingmachine obj = new vendingmachine();
			obj.DepositCoins();
		}

		int totalcoinsdeposited = 0;

		//allowing user to deposit coins
		//5-nickel
		//10-dime
		//25-quarter
		public void DepositCoins()
		{
			//int totalcoinsdeposited = 0;

			int selectedcoin;

			bool parsedsuccessfully;
			bool userinputinv = true;

			while (userinputinv)
			{
				Console.WriteLine("Please select the coin you want to deposit: 5-Nickel,10-Dime or 25-Quarter");
				parsedsuccessfully = int.TryParse(Console.ReadLine(),out selectedcoin);
	
				if (parsedsuccessfully == true)
				{
					switch (selectedcoin)
					{
						case 5:
							totalcoinsdeposited += 5;
							userinputinv = false;
							break;
						case 10:
							totalcoinsdeposited += 10;
							userinputinv = false;
							break;
						case 25:
							totalcoinsdeposited += 25;
							userinputinv = false;
							break;
						default:
							Console.WriteLine("Please type a valid input!");
							break;



					}
				}
				else
				{
					Console.WriteLine("Please type a valid number!");

				}
			}

			Console.WriteLine("Your total deposit is " + totalcoinsdeposited + " cents");
			Console.WriteLine("");

			DisplayMenuitems();

		}

		public void DisplayMenuitems()
		{


			var table = new ConsoleTable("Item", "Description", "Cost");
			table.AddRow(1, "Coke", 0.25)
				 .AddRow(20, "Pepsi", "0.35")
				 .AddRow(100, "Sprite", "0.45");

			Console.WriteLine("Items menu");
			Console.WriteLine(table);

			Console.WriteLine("");

			//Console.ReadLine();
			PurchaseItem();

		}

		double totalselecteditems = 0;
		List<string> ordereditems = new List<string>();

		public void PurchaseItem()
		{
			//status
			//1-available
			//0-unavailable
			int cokestatus = 1;
			int Pepsistatus = 1;
			int Spritestatus = 1;

			
			//checking user input if it is valid 
			int selecteditem;

			bool parsedsuccessfullyitem;
			bool userinputinv = true;

			while (userinputinv)
			{
				Console.WriteLine("Please select the item you want to purchase: 1-Coke,20-Pepsi or 100-Sprite");
				parsedsuccessfullyitem = int.TryParse(Console.ReadLine(), out selecteditem);

				if (parsedsuccessfullyitem == true)
				{
					//check item is avilable or not before proceeding

					if ( (selecteditem == 1 && cokestatus == 0) || (selecteditem == 20 && Pepsistatus == 0) || (selecteditem == 100 && Spritestatus == 0))
					{
						Console.WriteLine("Sorry the item is sold out.Please select any other item");
						Console.WriteLine("");
						continue;
					}

	

					switch (selecteditem)
					{
						case 1:
							totalselecteditems += 0.25;
							ordereditems.Add("Coke");
							userinputinv = false;
							break;
						case 20:
							totalselecteditems += 0.35;
							ordereditems.Add("Pepsi");
							userinputinv = false;
							break;
						case 100:
							totalselecteditems += 0.45;
							ordereditems.Add("Sprite");
							userinputinv = false;
							break;
						default:
							Console.WriteLine("Please type a valid input!");
							break;



					}
				}
				else
				{
					Console.WriteLine("Please type a valid number!");

				}
			}


			Purchaseadditionalitems();

		}

		public void Purchaseadditionalitems()
		{

			//checking user input if it is valid 
			int continuepurchase;
			bool parsedsuccessfullyinput;
			bool userinputaddinv = true;


			while (userinputaddinv)
			{
				Console.WriteLine("Do you want to purchase any more items: 1-Yes ,0-No");
				parsedsuccessfullyinput = int.TryParse(Console.ReadLine(), out continuepurchase);

				if (parsedsuccessfullyinput == true)
				{

					switch (continuepurchase)
					{
						case 1:
							userinputaddinv = false;
							PurchaseItem();
							break;
						case 0:
							userinputaddinv = false;
							break;
						default:
							Console.WriteLine("Please type a valid input!");
							break;



					}
				}
				else
				{
					Console.WriteLine("Please type a valid number!");

				}
			}
	
			Console.WriteLine("Your total cost is " + totalselecteditems + " cents");
			Console.WriteLine("");


			Checksufficientfunds();
			

		}

		public void Checksufficientfunds()
		{
			if (totalcoinsdeposited >= totalselecteditems)
			{
				PlaceOrder();
			}
			else
			{
				Console.WriteLine("Sorry the purchase could not be made due to insufficient balance.Your totalcost is " + totalselecteditems + " and your deposit is " + totalcoinsdeposited + " cents");
				Console.WriteLine();
				Console.WriteLine("Sorry for the inconvenience.Please collect your " + totalcoinsdeposited + " cents");
				Console.ReadLine();


			}



		}

		public void PlaceOrder()
		{
			int checkout;
			bool parsedsuccessfullycheckout;
			bool userinputcheckinv = true;


			while (userinputcheckinv)
			{
				Console.WriteLine("Do you want to proceed with the checkout or cancel the request: 1-Proceed,0-Cancel");
				parsedsuccessfullycheckout = int.TryParse(Console.ReadLine(), out checkout);

				if (parsedsuccessfullycheckout == true)
				{
					if (checkout == 1)
					{
						userinputcheckinv = false;

						Console.WriteLine("");
						Console.WriteLine("Your order is successful.Please collect your ordered items");

						ordereditems.ForEach(Console.WriteLine);

						//return balance to the user
						if (totalcoinsdeposited > totalselecteditems)
						{
							double balance = totalcoinsdeposited - totalselecteditems;

							if (balance > 0)
							{
								Console.WriteLine("");
								Console.WriteLine("Please collect your remaining balance of " + balance + " cents");

							}
						}
					}
					else if (checkout == 0)
					{
						userinputcheckinv = false;

						Console.WriteLine("");
						Console.WriteLine("Your transaction is cancelled.Please collect your refund of " + totalcoinsdeposited + " cents");

					}
					else
					{
						Console.WriteLine("The entered choice is " + checkout + " is invalid. Please select either 1 or 0");

					}




					

				}
				else
				{
					Console.WriteLine("Please type a valid number!");

				}
			}

			Console.ReadLine();

		}



	}
}
