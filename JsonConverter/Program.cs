// See https://aka.ms/new-console-template for more information
using JsonConverter.Logic;
using JsonConverter.Model;
using JsonConverter.Model.ItemMaster;
using Newtonsoft.Json;
using System.Reflection.Metadata;

Console.WriteLine("    _____   ______     ___   ____  _____     ______  ________  ____  _____  ________  _______          _     _________    ___   _______     \r\n   |_   _|.' ____ \\  .'   `.|_   \\|_   _|  .' ___  ||_   __  ||_   \\|_   _||_   __  ||_   __ \\        / \\   |  _   _  | .'   `.|_   __ \\    \r\n     | |  | (___ \\_|/  .-.  \\ |   \\ | |   / .'   \\_|  | |_ \\_|  |   \\ | |    | |_ \\_|  | |__) |      / _ \\  |_/ | | \\_|/  .-.  \\ | |__) |   \r\n _   | |   _.____`. | |   | | | |\\ \\| |   | |   ____  |  _| _   | |\\ \\| |    |  _| _   |  __ /      / ___ \\     | |    | |   | | |  __ /    \r\n| |__' |  | \\____) |\\  `-'  /_| |_\\   |_  \\ `.___]  |_| |__/ | _| |_\\   |_  _| |__/ | _| |  \\ \\_  _/ /   \\ \\_  _| |_   \\  `-'  /_| |  \\ \\_  \r\n`.____.'   \\______.' `.___.'|_____|\\____|  `._____.'|________||_____|\\____||________||____| |___||____| |____||_____|   `.___.'|____| |___| \r\n                                                                                                                                            ");


Console.WriteLine($"Type and enter 'exit' anytime to exit application");
string exitCode = String.Empty;

while (exitCode.ToLower() != "exit")
{
    Console.WriteLine($"What would you like to convert? Enter the option number");
    Console.WriteLine($"1: Sales Order");
    Console.WriteLine($"2: Item Master");
    string convertOption = Console.ReadLine();

    if (convertOption == "1")
    {
        Console.WriteLine("Please enter the excel file location path. For example 'C:\\Users\\akhan\\source\\repos\\Files\\shipmentorder001.xlsx'");
        string filePath = Console.ReadLine();


        if (filePath == null)
        {
            Console.WriteLine($"File Path not valid. Please retry again");
        }
        else
        {
            try
            {
                ExcelToJsonConverter excelToJsonConverter = new ExcelToJsonConverter();

                string shipmentData = excelToJsonConverter.ConvertExcelToJson(filePath, 0);
                string positionData = excelToJsonConverter.ConvertExcelToJson(filePath, 1);

                List<ShipmentOrder> shipmentOrder = excelToJsonConverter.GenerateShipmentOrder(shipmentData, positionData);

                Console.WriteLine($"Generating Sales Order JSON");
                Console.WriteLine($"");
                Console.WriteLine($"");
                Console.WriteLine(JsonConvert.SerializeObject(shipmentOrder));

                Console.WriteLine($"");
                Console.WriteLine($"Press Enter to continue");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}. An error occured. Please also make sure your Date and Boolean are correctly entered in the template. Press Enter to try again");
            }
        }
    }
    else if (convertOption == "2") 
    {
        Console.WriteLine("Please enter the excel file location path. For example 'C:\\Users\\akhan\\source\\repos\\Files\\shipmentorder001.xlsx'");
        string filePath = Console.ReadLine();


        if (filePath == null)
        {
            Console.WriteLine($"File Path not valid. Please retry again");
        }
        else
        {
            try
            {
                ExcelToJsonConverter excelToJsonConverter = new ExcelToJsonConverter();

                string itemMasterData = excelToJsonConverter.ConvertExcelToJson(filePath, 0);
                string barcodeData = excelToJsonConverter.ConvertExcelToJson(filePath, 1);

                List<ItemMaster> itemMaster = excelToJsonConverter.GenerateItemMaster(itemMasterData, barcodeData);

                Console.WriteLine($"Generating Item Master JSON");
                Console.WriteLine($"");
                Console.WriteLine($"");
                Console.WriteLine(JsonConvert.SerializeObject(itemMaster));

                Console.WriteLine($"");
                Console.WriteLine($"Press Enter to continue");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}. An error occured. Please also make sure your Date and Boolean are correctly entered in the template. Press Enter to try again");
            }
        }
    }

    exitCode = Console.ReadLine();
}