using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for CryptorEngine
/// </summary>
public class CryptorEngine
{
    /// <summary>
    /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
    /// </summary>
    /// <param name="toEncrypt">string to be encrypted</param>
    /// <param name="useHashing">use hashing? send to for extra secirity</param>
    /// <returns></returns>
    public static string Encrypt(string toEncrypt, bool useHashing)
    {
        if (toEncrypt == "")
            toEncrypt = " ";
        byte[] keyArray;
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
        // Get the key from config file
        //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
        string key = "Padmaraj Thanepatil";
        //System.Windows.Forms.MessageBox.Show(key);
        if (useHashing)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
        }
        else
        {
            keyArray = UTF8Encoding.UTF8.GetBytes(key);
        }
        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateEncryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        tdes.Clear();
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }
    /// <summary>
    /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
    /// </summary>
    /// <param name="cipherString">encrypted string</param>
    /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
    /// <returns></returns>
    /// 
    public static string Decrypt(string cipherString, bool useHashing)
    {

        if (cipherString == "")
        {
            cipherString = " ";
        }
            byte[] keyArray;

            string valueString = FixBase64Length(cipherString);
            byte[] toEncryptArray = Convert.FromBase64String(valueString);   
            //Above line errors comes

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            string key = "Padmaraj Thanepatil";
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
    }

    public static string FixBase64Length(string additionalQueryStringEncoded)
    {
        int length = additionalQueryStringEncoded.Length;
        int remainder = length % 4;
        if (remainder == 0)
        {
            return additionalQueryStringEncoded.Replace(" ", "+");
        }

        remainder = 4 - remainder;
        for (int i = 0; i < remainder; i++)
        {
            additionalQueryStringEncoded += "=";
        }

        return additionalQueryStringEncoded.Replace(" ", "+");
    }
}

