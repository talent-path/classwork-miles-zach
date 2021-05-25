using System;
using System.Numerics;

namespace BigRational
{
    /// <summary>
    /// This class is meant to precisely represent rational fractions and perform
    /// math/comparison operations.
    /// </summary>
    public class BigRational
    {
        public BigInteger Numerator { get; }
        public BigInteger Denominator { get; }

        public BigRational(BigInteger num, BigInteger denom)
        {
            //todo: reduce both by the greatest common denominator
            // (hint: look for Euclid's algorithm)

            if( denom < 0)
            {
                num *= -1;
                denom *= -1;
            }

            Numerator = num;
            Denominator = denom;
        }

        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }

        public static BigRational operator * (BigRational left, BigRational right)
        {
            return new BigRational(left.Numerator * right.Numerator,
                                    left.Denominator * right.Denominator);
        }

        //TODO: add remaining arithmetic operators (-, /, *, %)

        public static bool operator < ( BigRational left, BigRational right)
        {

            //  a     c
            //  -  <  -
            //  b     d

            // ad < bc

            return left.Numerator * right.Denominator < right.Numerator * left.Denominator;
        }

        public static bool operator > (BigRational left, BigRational right)
        {
            //  a     c
            //  -  >  -
            //  b     d

            // ad < bc

            return left.Numerator * right.Denominator > right.Numerator * left.Denominator;
        }

        //TODO: add remaining comparison operators (>=, <=, ==, !=)


    }
}
