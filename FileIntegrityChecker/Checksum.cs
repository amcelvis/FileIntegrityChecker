using System;
using System.IO;
using System.Security.Cryptography;

namespace FileIntegrityChecker {
    class Checksum {
        //Global Variable Declaration and Initialization
        static readonly HashAlgorithm MD5 = new MD5CryptoServiceProvider();
        static readonly HashAlgorithm SHA1 = new SHA1Managed();
        static readonly HashAlgorithm SHA256 = new SHA256Managed();
        static readonly HashAlgorithm SHA384 = new SHA384Managed();
        static readonly HashAlgorithm SHA512 = new SHA512Managed();
        static readonly HashAlgorithm RIPEMD160 = new RIPEMD160Managed();

        public static string GetChecksum(string filepath, int choice) {
            using (var stream = new BufferedStream(File.OpenRead(filepath), 100000)) {
                HashAlgorithm algorithm;
                byte[] hash;
                switch (choice){
                    case 1:
                        algorithm = MD5;
                        hash = algorithm.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", string.Empty);
                    case 2:
                        algorithm = SHA1;
                        hash = algorithm.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", string.Empty);
                    case 3:
                        algorithm = SHA256;
                        hash = algorithm.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", string.Empty);
                    case 4:
                        algorithm = SHA384;
                        hash = algorithm.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", string.Empty);
                    case 5:
                        algorithm = SHA512;
                        hash = algorithm.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", string.Empty);
                    case 6:
                        algorithm = RIPEMD160;
                        hash = algorithm.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", string.Empty);
                }
                return "Unable to Compute Hash";
            }
        }
    }
}
