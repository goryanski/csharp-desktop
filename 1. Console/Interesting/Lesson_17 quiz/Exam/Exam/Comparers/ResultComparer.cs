using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Models.Victorina;

namespace Exam.Comparers
{
    public class ResultComparer : IEqualityComparer<TestResult>
    {
        public bool Equals(TestResult x, TestResult y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            // если названия тестов совпадают
            return x.TestName.Equals(y.TestName);
        }

        public int GetHashCode(TestResult obj)
        {

            //Check whether the object is null
            if (Object.ReferenceEquals(obj, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashFirstName = obj.TestName == null ? 0 : obj.TestName.GetHashCode();

            //Calculate the hash code for the product.
            return hashFirstName;
        }
    }
}
