using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageConsoleUI
    {
        private readonly GarageLogic.GarageManagement m_Garage = new GarageManagement();
        private readonly VehicleCreator m_VehicleCreator = new VehicleCreator();
        private bool m_WantToExist = false;

        public static void PrintLogo()
        {
            Console.Clear();
            Console.Write(@"
======================================================================
 _______       ___       _______         ___       _______   _______
|       |     /   \     |       |       /   \     |       | |
|    ___     /_____\    |______/       /_____\    |    ___  |_______
|       |   /       \   |      \      /       \   |       | |
|       |  /         \  |       \    /         \  |       | |
|_______| /           \ |        \  /           \ |_______| |_______

======================================================================
");
        }

        public void StartProgram()
        {
            while (!m_WantToExist)
            {
                PrintLogo();
                printMenu();
                int userChoice = getAndCheckUserChoice(1, 8);
                string choice = Enum.GetName(typeof(eMenuOptions), userChoice);
                eMenuOptions menuOptions = (eMenuOptions)Enum.Parse(typeof(eMenuOptions), choice);

                switch (menuOptions)
                {
                    case eMenuOptions.AddVehicle:
                        {
                            addOptionNewVehicle();
                            break;
                        }

                    case eMenuOptions.DisplayLicenses:
                        {
                            getList();
                            break;
                        }

                    case eMenuOptions.changeVehicleStatus:
                        {
                            changeVehicleStatus();
                            break;
                        }

                    case eMenuOptions.InflatingWheelToMax:
                        {
                            fillToMaxWheel();
                            break;
                        }

                    case eMenuOptions.FuelVehicle:
                        {
                            vehicleFuel();
                            break;
                        }

                    case eMenuOptions.CharageVehicle:
                        {
                            chargeVehicel();
                            break;
                        }

                    case eMenuOptions.ShowVehicleDetails:
                        {
                            printVehicleDetails();
                            break;
                        }

                    case eMenuOptions.Exit:
                        {
                            wantToExit();
                            return;
                        }

                    default:
                        throw new ArgumentException();
                }

                Console.WriteLine("Please press any key to show Menu...");
                Console.ReadLine();
            }
        }

        private void wantToExit()
        {
            m_WantToExist = true;
        }

        private void addOptionNewVehicle()
        {
            Console.Clear();
            int userChoice = 0;
            Console.WriteLine("Hi please enter you choice: ");
            List<string> catalogueOfVehicles = m_VehicleCreator.GetVehiclesCollection();
            for (int i = 0; i < catalogueOfVehicles.Count; i++)
            {
                Console.WriteLine("<{0}> {1}", i + 1, catalogueOfVehicles[i]);
            }

            userChoice = getAndCheckUserChoice(1, catalogueOfVehicles.Count);
            generateVehicle(catalogueOfVehicles[userChoice - 1]);
        }

        private void generateVehicle(string i_Vehicle)
        {
            try
            {
                Vehicle vehicleToGenerate;
                GarageVehicleUtils vehicleDetails = getVehicleDetailsAndGenerate();
                vehicleToGenerate = m_VehicleCreator.GetVehicle(vehicleDetails.ModelName, vehicleDetails.LicenseNumber, i_Vehicle, vehicleDetails.Energy);
                getVehicleDetailsToProgress(vehicleToGenerate);
                addToGarge(vehicleToGenerate);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void addToGarge(Vehicle i_Vehicle)
        {
            string clientName = null;
            string clientPhoneNumber = null;

            Console.WriteLine("Please Enter Client name");
            clientName = Console.ReadLine();
            Console.WriteLine("Please Enter Client PhoneNumber");
            clientPhoneNumber = Console.ReadLine();

            m_Garage.AddNewClient(i_Vehicle, clientName, clientPhoneNumber);
        }

        private void getVehicleDetailsToProgress(Vehicle i_Vehicle)
        {
            bool isVaildParmeters = false;
            GarageVehicleUtils vehicleDetails = i_Vehicle.GetDataToInput();
            while (!isVaildParmeters)
            {
                foreach (string dataNeedToInput in vehicleDetails.Details)
                {
                    if (dataNeedToInput.Equals("Wheel Manfactuer: "))
                    {
                        foreach (Wheel wheel in i_Vehicle.Wheels)
                        {
                            Console.WriteLine(dataNeedToInput);
                            wheel.NameOfManufacturer = Console.ReadLine();
                        }

                        continue;
                    }
                    else if (dataNeedToInput.Equals("Wheel current Psi: "))
                    {
                        foreach (Wheel wheel in i_Vehicle.Wheels)
                        {
                            wheel.CurrPsi = getPositiveFloatInput(dataNeedToInput);
                        }

                        continue;
                    }

                    Console.WriteLine(dataNeedToInput);
                    vehicleDetails.UserInput.Add(Console.ReadLine());
                }

                i_Vehicle.SetVehicleData();
                isVaildParmeters = true;
            }
        }

        private GarageVehicleUtils getVehicleDetailsAndGenerate()
        {
            GarageVehicleUtils DetailsAboutVehicle = new GarageVehicleUtils();
            Console.Clear();
            Console.WriteLine("Enter a name of model");
            DetailsAboutVehicle.ModelName = Console.ReadLine();
            DetailsAboutVehicle.LicenseNumber = getVehicleLicenseNumber();
            DetailsAboutVehicle.Energy = getCurrentEnergy();

            return DetailsAboutVehicle;
        }

        private float getCurrentEnergy()
        {
            string msg = string.Empty;
            float numberToConvert = 0;
            bool isVaild = false;

            Console.WriteLine("Please Enter a Energy on precent");
            msg = Console.ReadLine();

            while (!isVaild)
            {
                if (float.TryParse(msg, out numberToConvert))
                {
                    isVaild = numberToConvert >= 0;
                }
                else
                {
                    Console.WriteLine("Wrong Please try again");
                    msg = Console.ReadLine();
                }
            }

            return numberToConvert;
        }

        private void getList()
        {
            Console.Clear();
            List<string> vehiclesString = null;
            Console.WriteLine(@"Hi please enter you choice:
1. Show Typed Vehicles,
2. Show All Vehicles,");
            int userChoice = getAndCheckUserChoice(1, 2);
            switch (userChoice)
            {
                case 1:
                    {
                        eVehicleStatus eVehicleStatus = getVehicleStatus();
                        vehiclesString = m_Garage.GetListVehiclsStatus(eVehicleStatus);
                        showList(vehiclesString);
                        break;
                    }

                case 2:
                    {
                        vehiclesString = m_Garage.GetAllVehiclsStatus();
                        showList(vehiclesString);
                        break;
                    }
            }
        }

        private eVehicleStatus getVehicleStatus()
        {
            Console.WriteLine("Status of Vehicle: ");
            return (eVehicleStatus)getEnumChoice(typeof(eVehicleStatus));
        }

        private Enum getEnumChoice(Type i_CurretnEnumType)
        {
            int userChoice;
            Array enumTypes = Enum.GetValues(i_CurretnEnumType);

            Console.Clear();
            foreach (Enum currentType in enumTypes)
            {
                Console.WriteLine("For {0}, press {1}", currentType, currentType.GetHashCode());
            }

            userChoice = getAndCheckUserChoice(0, enumTypes.Length - 1);

            return (Enum)enumTypes.GetValue(userChoice);
        }

        private void showList(List<string> i_ListOfString)
        {
            Console.Clear();
            Console.WriteLine("Requested List: ");

            foreach (string msg in i_ListOfString)
            {
                Console.WriteLine("Vehicle: {0}", msg);
            }
        }

        private void changeVehicleStatus()
        {
            try
            {
                Console.Clear();
                string licnsenumber = getVehicleLicenseNumber();
                eVehicleStatus eStatus = getVehicleStatus();

                m_Garage.ChangeVehicleStatus(licnsenumber, eStatus);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string getVehicleLicenseNumber()
        {
            string msg = string.Empty;
            Console.WriteLine("Please Enter vehicle license number");
            msg = Console.ReadLine();
            while (!liecensVaildation(msg))
            {
                Console.WriteLine("Please try again");
                msg = Console.ReadLine();
            }

            return msg;
        }

        private bool liecensVaildation(string i_LiescnseNumber)
        {
            bool isVaildToReturn = true;

            if (i_LiescnseNumber.Equals(string.Empty))
            {
                isVaildToReturn = false;
            }

            foreach (char charToCheck in i_LiescnseNumber)
            {
                if (!char.IsLetterOrDigit(charToCheck))
                {
                    isVaildToReturn = false;
                }
            }

            return isVaildToReturn;
        }

        private void fillToMaxWheel()
        {
            try
            {
                Console.Clear();
                string licenseNumber = getVehicleLicenseNumber();
                m_Garage.FillAirToMaxPsi(licenseNumber);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void vehicleFuel()
        {
            try
            {
                Console.Clear();
                string licnsenumber = getVehicleLicenseNumber();
                eFuelType typeFuel = getFuelType();
                float amountOfFuel = getPositiveFloatInput("Enter amount of fuel");
                m_Garage.FillFuelVehicle(licnsenumber, typeFuel, amountOfFuel);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private eFuelType getFuelType()
        {
            Console.WriteLine("Fuel Type: ");
            return (eFuelType)getEnumChoice(typeof(eFuelType));
        }

        private void chargeVehicel()
        {
            try
            {
                Console.Clear();
                string licnsenumber = getVehicleLicenseNumber();
                int amountOfMin = getPositiveIntegerInput("Enter the number of minutes you wish to charge");
                m_Garage.ChargeVehicle(licnsenumber, amountOfMin);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine("{0}", vore.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private int getPositiveIntegerInput(string i_Message)
        {
            int intInput = 0;
            bool isValidInput = false;
            string input;

            while (!isValidInput)
            {
                Console.WriteLine(i_Message);
                input = Console.ReadLine();
                if (int.TryParse(input, out intInput) && intInput >= 0)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Wrong input... try again (only numbers)");
                }
            }

            return intInput;
        }

        private float getPositiveFloatInput(string i_Message)
        {
            float inputAsFloatToReturn = 0;
            bool inputValidation = false;
            string input;

            while (!inputValidation)
            {
                Console.WriteLine(i_Message);
                input = Console.ReadLine();
                if (!float.TryParse(input, out inputAsFloatToReturn) && inputAsFloatToReturn >= 0)
                {
                    Console.WriteLine("Wrong input! Please try again");
                }
                else
                {
                    inputValidation = true;
                }
            }

            return inputAsFloatToReturn;
        }

        private void printVehicleDetails()
        {
            try
            {
                Console.Clear();
                string licnseNumber = getVehicleLicenseNumber();
                Client client = m_Garage.GetClient(licnseNumber);
                Console.Clear();
                Console.WriteLine(client.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private int getAndCheckUserChoice(int i_MinValue, int i_MaxValue)
        {
            bool isVaild = false;
            string msg = string.Empty;
            int numberParsing = 0;

            while (!isVaild)
            {
                Console.WriteLine("please enter a number the range {0} - {1} ...", i_MinValue, i_MaxValue);
                msg = Console.ReadLine();
                if (int.TryParse(msg, out numberParsing))
                {
                    isVaild = numberParsing <= i_MaxValue && numberParsing >= i_MinValue;
                }

                if (!isVaild)
                {
                    Console.WriteLine("Wrong please try again ");
                }
            }

            return numberParsing;
        }

        private void printMenu()
        {
            Console.WriteLine(@"   
----------------------------------------------------------------------
|  Press the number of the operation you wish to do:                 |
|                                                                    |   
|  <1> Add a new vehicle into the garage                             |
|  <2> Show the catalogue of the vehicles in the garage              |
|  <3> Change a vehicle status                                       |
|  <4> Inflate all vehicle wheels to its maximum PSI                 |
|  <5> Refuel a vehicle that has Fuel energy system                  |
|  <6> Charge a vehicle that has elelctrical energy system           |
|  <7> Get details about a specific vehicle                          |
|  <8> Exit the program                                              |
|                                                                    |
----------------------------------------------------------------------
        ");
        }
    }
}  