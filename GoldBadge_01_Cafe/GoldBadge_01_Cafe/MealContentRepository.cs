using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_01_Cafe
{
    class MealContentRepository
    {
        protected List<MealContent> _contentDirectory = new List<MealContent>();

        public bool AddMenuItem(MealContent content)
        {
            int startingCount = _contentDirectory.Count;

            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount);

            return wasAdded;
        }

        public bool DeleteMenuItem(string mealName)
        {
            int startingCount = _contentDirectory.Count;

            int index = -1;

            foreach(MealContent content in _contentDirectory)
            {
                if(content.MealName == mealName)
                {
                    index = _contentDirectory.IndexOf(content);
                }
            }
            if(index > -1)
            {
                _contentDirectory.RemoveAt(index);
            }

            bool wasRemoved = (_contentDirectory.Count < startingCount);
            return wasRemoved;
        }

        public List<MealContent> GetContents()
        {
            return _contentDirectory;
        }
    }
}
