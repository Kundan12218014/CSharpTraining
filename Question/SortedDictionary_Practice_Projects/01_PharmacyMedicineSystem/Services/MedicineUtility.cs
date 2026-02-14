using System;
using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class MedicineUtility
    {
        private SortedDictionary<int, List<Medicine>> medicinesByYear = new SortedDictionary<int, List<Medicine>>();
        // Optional: helper to check duplicates efficiently, but assuming strict adherence to "store medicines using SortedDictionary"
        // I will iterate to find duplicates to be safe and comply with storage requirement solely.

        public void AddMedicine(Medicine medicine)
        {
            if (medicine.Price <= 0)
            {
                throw new InvalidPriceException("Price must be greater than zero.");
            }
            if (medicine.ExpiryYear < DateTime.Now.Year)
            {
                // Assuming we can't add already expired medicine or invalid year. 
                // Or maybe just check for > 0? 
                // "sorted automatically by Expiry Year (ascending)"
                // Let's assume < 1900 is invalid or something reasonable. 
                // But usually pharmacy inventory implies current/future stock.
                // Let's keep it simple: if ExpiryYear is suspiciously low.
                // However, better safe default: Check strictly format if implied. 
                // I will check > 0. And if user wants strictly future, I might guess.
                // Let's just check > 0 for minimum validity.
                // Re-reading: "InvalidExpiryYearException". I'll throw if <= 0.
            }
            if (medicine.ExpiryYear <= 0)
            {
                 throw new InvalidExpiryYearException("Invalid Expiry Year.");
            }

            // Check duplicate ID
            if (Exists(medicine.Id))
            {
                throw new DuplicateMedicineException($"Medicine with ID {medicine.Id} already exists.");
            }

            if (!medicinesByYear.ContainsKey(medicine.ExpiryYear))
            {
                medicinesByYear[medicine.ExpiryYear] = new List<Medicine>();
            }
            medicinesByYear[medicine.ExpiryYear].Add(medicine);
        }

        private bool Exists(string id)
        {
            foreach (var list in medicinesByYear.Values)
            {
                foreach (var med in list)
                {
                    if (med.Id == id) return true;
                }
            }
            return false;
        }

        public List<Medicine> GetAllMedicines()
        {
            List<Medicine> allMedicines = new List<Medicine>();
            foreach (var key in medicinesByYear.Keys)
            {
                allMedicines.AddRange(medicinesByYear[key]);
            }
            return allMedicines;
        }

        public void UpdateMedicinePrice(string id, int newPrice)
        {
            if (newPrice <= 0)
            {
                throw new InvalidPriceException("Price must be greater than zero.");
            }

            bool found = false;
            foreach (var list in medicinesByYear.Values)
            {
                foreach (var med in list)
                {
                    if (med.Id == id)
                    {
                        med.Price = newPrice;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                throw new MedicineNotFoundException($"Medicine with ID {id} not found.");
            }
        }
    }
}
