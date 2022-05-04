using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RSAzxs
{
    class RSA
    {
        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters PrivateKey;
        private RSAParameters PublicKey;

        public RSA()
        {
            PrivateKey = csp.ExportParameters(true);
            PublicKey = csp.ExportParameters(false);
        }

        public String PublicKeyString()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, PublicKey);

            return sw.ToString();
        }

        public String Encrypt(String plainText)
        {
            csp.ImportParameters(PublicKey);

            var data = Encoding.Unicode.GetBytes(plainText);
            var cypher = csp.Encrypt(data, false);

            return Convert.ToBase64String(cypher);
        }

        public String Decryption(String cypher)
        {
            var dataBytes = Convert.FromBase64String(cypher);
            csp.ImportParameters(PrivateKey);
            var plainText = csp.Decrypt(dataBytes, false);

            return Encoding.Unicode.GetString(plainText);
        }


    }
}
