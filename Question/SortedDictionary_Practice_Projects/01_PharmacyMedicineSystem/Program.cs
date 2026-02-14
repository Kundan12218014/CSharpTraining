using System;
using Services;
using Domain;
using Exceptions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicineUtility service = new MedicineUtility();

            while (true)
            {
                Console.WriteLine("1. Display all medicines");
                Console.WriteLine("2. Update medicine price");
                Console.WriteLine("3. Add medicine");
                Console.WriteLine("4. Exit");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            var medicines = service.GetAllMedicines();
                            foreach (var med in medicines)
                            {
                                Console.WriteLine(med.ToString());
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter Medicine ID and New Price:");
                            string[] updateParts = Console.ReadLine().Split(' ');
                            if (updateParts.Length >= 2)
                            {
                                string id = updateParts[0];
                                int newPrice = int.Parse(updateParts[1]);
                                service.UpdateMedicinePrice(id, newPrice);
                                Console.WriteLine("Price updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input format.");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Medicine Details (Id Name Price ExpiryYear):");
                            string input = Console.ReadLine();
                            string[] parts = input.Split(' ');
                            if (parts.Length == 4)
                            {
                                string id = parts[0];
                                string name = parts[1];
                                int price = int.Parse(parts[2]);
                                int expiryYear = int.Parse(parts[3]);

                                Medicine newMedicine = new Medicine(id, name, price, expiryYear);
                                service.AddMedicine(newMedicine);
                                Console.WriteLine("Medicine added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input format. Expected: Id Name Price ExpiryYear");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (InvalidPriceException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (DuplicateMedicineException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (InvalidExpiryYearException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (MedicineNotFoundException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input format.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }
    }
}

