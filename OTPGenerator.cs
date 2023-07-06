using System;
using System.Security.Cryptography;
using System.Text;

namespace OTPGenerator
{
    public class OTPGeneratorClass
    {
        private const int ExpirySeconds = 30;  // Constant value for the OTP expiry time in seconds

        public string GenerateOTP(string userId, DateTime dateTime)
        {
            // Combine the user ID and date time to create a unique key
            string key = $"{userId}-{dateTime:yyyyMMddHHmmss}";

            // Convert the key to a byte array using ASCII encoding
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);

            using (var hmac = new HMACSHA256(keyBytes))  // Create an instance of HMACSHA256 using the key
            {
                var timestampBytes = BitConverter.GetBytes(dateTime.Ticks);  // Convert the date time to a byte array
                byte[] hashBytes = hmac.ComputeHash(timestampBytes);  // Compute the hash of the byte array
                int numberOfDigits = userId.Length % 10;

                // Take the first numberofDigits bytes of the hash and convert them to a numeric string
                int otpValue = (int)Math.Abs(BitConverter.ToInt32(hashBytes, 0) % Math.Pow(10, numberOfDigits));
                string otp = otpValue.ToString(string.Format("D{0}", numberOfDigits));  // Format the OTP as a numberOfDigits numeric string

                return otp;  // Return the generated OTP
            }
        }

        public bool IsOTPValid(string userId, DateTime dateTime, string otp)
        {
            string generatedOTP = GenerateOTP(userId, dateTime);  // Generate the OTP based on the user ID and date time
            DateTime expiryTime = dateTime.AddSeconds(ExpirySeconds);  // Calculate the OTP expiry time

            return otp == generatedOTP && DateTime.Now <= expiryTime;  // Check if the provided OTP is valid and not expired
        }
    }
}

