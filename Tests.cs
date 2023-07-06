using OTPGenerator;
using System.Diagnostics;

namespace Tests
{
    public class TestClass
    {
        private OTPGeneratorClass otpGenerator = new OTPGeneratorClass();
        string userId = "user123";
        private void Test29Seconds()
        {
            Console.WriteLine("Start Test29Seconds");

            DateTime dateTime = DateTime.Now;
            string otp = otpGenerator.GenerateOTP(userId, dateTime);

            System.Threading.Thread.Sleep(29000);
            bool isValid = otpGenerator.IsOTPValid(userId, dateTime, otp);

            Debug.Assert(isValid == true);
            Console.WriteLine("Test29Seconds finished\n");
        }

        private void Test30Seconds()
        {
            Console.WriteLine("Start Test30Seconds");

            DateTime dateTime = DateTime.Now;
            string otp = otpGenerator.GenerateOTP(userId, dateTime);

            System.Threading.Thread.Sleep(30000);
            bool isValid = otpGenerator.IsOTPValid(userId, dateTime, otp);

            Debug.Assert(isValid == false);

            Console.WriteLine("Test30Seconds finished\n");
        }

        private void Test31Seconds()
        {
            Console.WriteLine("Start Test31Seconds");

            DateTime dateTime = DateTime.Now;
            string otp = otpGenerator.GenerateOTP(userId, dateTime);

            System.Threading.Thread.Sleep(31000);
            bool isValid = otpGenerator.IsOTPValid(userId, dateTime, otp);

            Debug.Assert(isValid == false);

            Console.WriteLine("Test31Seconds finished\n");
        }

        public void RunAllTests()
        {
            Console.WriteLine("Start tests...\n");

            Test29Seconds();
            Test30Seconds();
            Test31Seconds();

            Console.WriteLine("Tests finish...\n");
        }
    }
}
