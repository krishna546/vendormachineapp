using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingmachineapp
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{

				int totalcoinsdeposited = 0;

			coindepositstart:

				Console.WriteLine("Please select the coin you want to deposit: 5-Nickel,10-Dime or 25-Quarter");
				//int selectedcoin = Convert.ToInt32(Console.ReadLine());

				//checking user input if it is valid
				int selectedcoin;
				bool parsedsuccessfully = int.TryParse(Console.ReadLine(), out selectedcoin);

				if (parsedsuccessfully == false)
				{
					Console.WriteLine("Please type a valid number!");
					Console.WriteLine("");

					goto coindepositstart;
				}



				switch (selectedcoin)
				{
					case 5:
						totalcoinsdeposited += 5;
						break;
					case 10:
						totalcoinsdeposited += 10;
						break;
					case 25:
						totalcoinsdeposited += 25;
						break;
					default:
						Console.WriteLine("The entered choice is " + selectedcoin + " is invalid. Please select 5,10 or 25 cents");
						Console.WriteLine("");
						goto coindepositstart;
				}

				Console.WriteLine("Your total deposit is " + totalcoinsdeposited + " cents");
				Console.WriteLine("");


				double totalselecteditems = 0;

				List<string> ordereditems = new List<string>();

				var table = new ConsoleTable("Item", "Description", "Cost");
				table.AddRow(1, "Coke", 0.25)
					 .AddRow(20, "Pepsi", "0.35")
					 .AddRow(100, "Sprite", "0.45");

				Console.WriteLine("Items menu");
				Console.WriteLine(table);

				Console.WriteLine("");



				//status
				//1-available
				//0-unavailable

				int cokestatus = 1;
				int Pepsistatus = 0;
				int Spritestatus = 1;

			itemselectionstart:

				Console.WriteLine("Please select the item you want to purchase: 1-Coke,20-Pepsi or 100-Sprite");

				//int selecteditem = Convert.ToInt32(Console.ReadLine());

				//checking user input if it is valid 
				int selecteditem;
				bool parsedsuccessfullyitem = int.TryParse(Console.ReadLine(), out selecteditem);

				if (parsedsuccessfullyitem == false)
				{
					Console.WriteLine("Please type a valid number!");
					Console.WriteLine("");

					goto itemselectionstart;
				}

				//check item is avilable or not before proceeding

				if (selecteditem == 1 && cokestatus == 0)
				{
					Console.WriteLine("Sorry the item is sold out.Please select any other item");
					Console.WriteLine("");

					goto itemselectionstart;


				}

				if (selecteditem == 20 && Pepsistatus == 0)
				{
					Console.WriteLine("Sorry the item is sold out.Please select any other item");
					Console.WriteLine("");

					goto itemselectionstart;


				}

				if (selecteditem == 100 && Spritestatus == 0)
				{
					Console.WriteLine("Sorry the item is sold out.Please select any other item");
					Console.WriteLine("");

					goto itemselectionstart;


				}




				switch (selecteditem)
				{
					case 1:
						totalselecteditems += 0.25;
						ordereditems.Add("Coke");
						break;

					case 20:
						totalselecteditems += 0.35;
						ordereditems.Add("Pepsi");
						break;
					case 100:
						totalselecteditems += 0.45;
						ordereditems.Add("Sprite");
						break;
					default:
						Console.WriteLine("The entered choice is " + selecteditem + " is invalid. Please select item no 1,20 or 100");
						Console.WriteLine("");

						goto itemselectionstart;
				}

			continuefurthershopping:

				Console.WriteLine("");

				Console.WriteLine("Do you want to purchase any more items: 1-Yes ,0-No ");
				//int continuepurchase = Convert.ToInt32(Console.ReadLine());

				//checking user input if it is valid 
				int continuepurchase;
				bool parsedsuccessfullyinput = int.TryParse(Console.ReadLine(), out continuepurchase);

				if (parsedsuccessfullyinput == false)
				{
					Console.WriteLine("Please type a valid number!");
					Console.WriteLine("");

					goto continuefurthershopping;
				}


				switch (continuepurchase)
				{
					case 1:
						goto itemselectionstart;
					case 0:
						break;
					default:
						Console.WriteLine("The entered choice is " + continuepurchase + " is invalid. Please select either 1 or 0");
						Console.WriteLine("");

						goto continuefurthershopping;
				}

				Console.WriteLine("Your total cost is " + totalselecteditems + " cents");
				Console.WriteLine("");


				//checksufficientfunds:

				if (totalcoinsdeposited < totalselecteditems)
				{
					Console.WriteLine("Sorry the purchase could not be made due to insufficient balance.Your totalcost is " + totalselecteditems + " and your deposit is " + totalcoinsdeposited + " cents");
					Console.WriteLine();

				validinput:

					Console.WriteLine("Do you want to purchase again or return the deposit: 1-Purchase again,0-Return deposit");
					//int insufficientfund = Convert.ToInt32(Console.ReadLine());


					//checking user input if it is valid 
					int insufficientfund;
					bool parsedsuccessfullyfund = int.TryParse(Console.ReadLine(), out insufficientfund);

					if (parsedsuccessfullyfund == false)
					{
						Console.WriteLine("Please type a valid number!");
						Console.WriteLine("");

						goto validinput;
					}


					switch (insufficientfund)
					{
						case 1:
							totalselecteditems = 0;
							goto itemselectionstart;
						case 0:
							Console.WriteLine("Sorry for the inconvenience.Please collect your " + totalcoinsdeposited + " cents");
							break;
						default:
							Console.WriteLine("The entered choice is " + insufficientfund + " is invalid. Please select either 1 or 0");
							Console.WriteLine("");

							goto validinput;
					}


				}
				else
				{
				checkout:
					Console.WriteLine("");

					Console.WriteLine("Do you want to proceed with the checkout or cancel the request: 1-Proceed,0-Cancel");
					//int checkout = Convert.ToInt32(Console.ReadLine());

					//checking user input if it is valid 
					int checkout;
					bool parsedsuccessfullycheckout = int.TryParse(Console.ReadLine(), out checkout);

					if (parsedsuccessfullycheckout == false)
					{
						Console.WriteLine("Please type a valid number!");
						Console.WriteLine("");

						goto checkout;
					}



					if (checkout == 1)
					{
						Console.WriteLine("");

						Console.WriteLine("Your order is successful.Please collect your ordered items");
						ordereditems.ForEach(Console.WriteLine);


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
						Console.WriteLine("");

						Console.WriteLine("Your transaction is cancelled.Please collect your refund of " + totalcoinsdeposited + " cents");

					}
					else
					{
						Console.WriteLine("The entered choice is " + checkout + " is invalid. Please select either 1 or 0");
						goto checkout;

					}

				}



				Console.WriteLine("");

				Console.WriteLine("Thanks for ordering with us");
				Console.ReadLine();

			}
			catch (Exception e)
			{
			Console.WriteLine("An error occurred in the application.Please find the error trace " + e);
			Console.ReadLine();

			}


		}
	}
}
