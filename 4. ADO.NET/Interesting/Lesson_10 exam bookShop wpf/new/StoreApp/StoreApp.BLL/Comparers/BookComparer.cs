using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO;

namespace StoreApp.BLL.Comparers
{
    public class BookComparer : IEqualityComparer<BookDTO>
    {

        public bool Equals(BookDTO x, BookDTO y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            // если names совпадают
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(BookDTO obj)
        {

            //Check whether the object is null
            if (Object.ReferenceEquals(obj, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashName = obj.Name == null ? 0 : obj.Name.GetHashCode();            


            //Calculate the hash code for the product.
            return hashName;
        }
    }
}
