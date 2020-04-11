using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_02
{
    public class ClaimContent
    {
        public int ClaimID { get; set; }
        public enum ClaimType
        {
            Car=1, House, Theft
        }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal AmountOfDamage { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public ClaimContent(int claimID) { }
        public ClaimContent(int claimID, ClaimType typeOfClaim, string description, decimal amountOfDamage, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            AmountOfDamage = amountOfDamage;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}