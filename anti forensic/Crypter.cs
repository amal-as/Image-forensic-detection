using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

namespace ImageForensic
{
    public class crypter
    {
        string input = "", output = "";
        public string temp;
        int bitStrength = 1024;
        public string pubkey = "", prvkey = "";

        public int s = 0;
        public crypter()
        {
            bitStrength = 1024;
            pubkey = "";
            prvkey = "";
        }

        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public bool saveFile(string title, string filterString, string outputString)
        {
            saveFileDialog.Title = title;
            saveFileDialog.Filter = filterString;
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, false);
                    if (outputString != null)
                    {
                        streamWriter.Write(outputString);
                    }
                    streamWriter.Close();
                    return true;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                    return false;
                }
            }
            return false;
        }

        public bool generate_key_pair(bool save_to_file)
        {
            
            try
            {
                RSACryptoServiceProvider RSAProvider = new RSACryptoServiceProvider(bitStrength);
                string publicAndPrivateKeys = "<BitStrength>" + bitStrength.ToString() + "</BitStrength>" + RSAProvider.ToXmlString(true);
                string justPublicKey = "<BitStrength>" + bitStrength.ToString() + "</BitStrength>" + RSAProvider.ToXmlString(false);
                pubkey = justPublicKey;
                prvkey = publicAndPrivateKeys;
                if (save_to_file == true)
                {
                    //MessageBox.Show("Save private key...");
                    if (MessageBox.Show("Save private key...", "Question", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (saveFile("Save Public/Private Keys As", "Public/Private Keys Document( *.kez )|*.kez", publicAndPrivateKeys))
                        {
                            //MessageBox.Show("Save public key...");
                            if (MessageBox.Show("Save public key...", "Question", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                while (!saveFile("Save Public Key As", "Public Key Document( *.pke )|*.pke", justPublicKey)) ;
                                s = 1;
                            }

                        }
                    }
                }

                return true;


            }
            catch
            {
                MessageBox.Show("error");
                return false;
            }
        }


        public string RSAEncryptString(string inputString, string xmlString_publickey)
        {
            // TODO: Add Proper Exception Handlers
            if (xmlString_publickey != null)
            {
                string bitStrengthString = xmlString_publickey.Substring(0, xmlString_publickey.IndexOf("</BitStrength>") + 14);
                xmlString_publickey = xmlString_publickey.Replace(bitStrengthString, "");
                bitStrength = Convert.ToInt32(bitStrengthString.Replace("<BitStrength>", "").Replace("</BitStrength>", ""));
                int dwKeySize = bitStrength;
                RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
                rsaCryptoServiceProvider.FromXmlString(xmlString_publickey);
                int keySize = dwKeySize / 8;
                byte[] bytes = Encoding.UTF32.GetBytes(inputString);
                // The hash function in use by the .NET RSACryptoServiceProvider here is SHA1
                // int maxLength = ( keySize ) - 2 - ( 2 * SHA1.Create().ComputeHash( rawBytes ).Length );
                int maxLength = keySize - 42;
                int dataLength = bytes.Length;
                int iterations = dataLength / maxLength;
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i <= iterations; i++)
                {
                    byte[] tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                    Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                    byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
                    // Be aware the RSACryptoServiceProvider reverses the order of encrypted bytes after encryption and before decryption.
                    // If you do not require compatibility with Microsoft Cryptographic API (CAPI) and/or other vendors.
                    // Comment out the next line and the corresponding one in the DecryptString function.
                    Array.Reverse(encryptedBytes);
                    // Why convert to base 64?
                    // Because it is the largest power-of-two base printable using only ASCII characters
                    stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
                }
                return stringBuilder.ToString();
            }
            return null;

        }

        public string RSADecryptString(string inputString, string xmlString_privatekey)
        {
            // TODO: Add Proper Exception Handlers
            if (xmlString_privatekey != null)
            {
                string bitStrengthString = xmlString_privatekey.Substring(0, xmlString_privatekey.IndexOf("</BitStrength>") + 14);
                xmlString_privatekey = xmlString_privatekey.Replace(bitStrengthString, "");
                bitStrength = Convert.ToInt32(bitStrengthString.Replace("<BitStrength>", "").Replace("</BitStrength>", ""));

                RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(bitStrength);
                rsaCryptoServiceProvider.FromXmlString(xmlString_privatekey);
                int base64BlockSize = ((bitStrength / 8) % 3 != 0) ? (((bitStrength / 8) / 3) * 4) + 4 : ((bitStrength / 8) / 3) * 4;
                int iterations = inputString.Length / base64BlockSize;
                ArrayList arrayList = new ArrayList();
                for (int i = 0; i < iterations; i++)
                {
                    byte[] encryptedBytes = Convert.FromBase64String(inputString.Substring(base64BlockSize * i, base64BlockSize));
                    // Be aware the RSACryptoServiceProvider reverses the order of encrypted bytes after encryption and before decryption.
                    // If you do not require compatibility with Microsoft Cryptographic API (CAPI) and/or other vendors.
                    // Comment out the next line and the corresponding one in the EncryptString function.
                    Array.Reverse(encryptedBytes);
                    arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedBytes, true));
                }
                return Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
            }
            return null;
        }


        public string openFile(string title, string filterString)
        {
            openFileDialog.FileName = "";
            openFileDialog.Title = title;
            openFileDialog.Filter = filterString;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName, true);
                    string fileString = streamReader.ReadToEnd();
                    streamReader.Close();

                    return fileString;

                }
            }
            return null;
        }










    }

}
