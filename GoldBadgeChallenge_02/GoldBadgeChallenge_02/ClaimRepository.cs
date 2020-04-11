using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge_02
{
    public class ClaimRepository
    {
        protected Queue<ClaimContent> _claimDirectory = new Queue<ClaimContent>();

        public bool AddClaimToDirectory(ClaimContent newClaim)
        {
            int startingCount = _claimDirectory.Count;

            _claimDirectory.Enqueue(newClaim);

            bool wasAdded = (_claimDirectory.Count > startingCount);

            return wasAdded;
        }

        public Queue<ClaimContent> GetContents()
        {
            return _claimDirectory;
        }
    }
}
