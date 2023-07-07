using System;
using OTPGenerator;
using Tests;

namespace OTPGeneratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /// run tests
            // TestClass tests = new TestClass();
            // tests.RunAllTests();
           
            OTPGeneratorClass otpGenerator = new OTPGeneratorClass();

            Console.WriteLine("Enter a user ID:");
            string userId = Console.ReadLine();
            DateTime dateTime = DateTime.Now;

            string otp = otpGenerator.GenerateOTP(userId, dateTime);
            Console.WriteLine("Generated OTP: " + otp);
        }
    }
}
