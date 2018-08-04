using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;

public class Encryption
{

	private static string hash = "CirclyFly123@321!";
	
	public static string Encrypt(string original)
	{
		byte[] data = UTF8Encoding.UTF8.GetBytes(original);

		using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
		{
			byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

			using (TripleDESCryptoServiceProvider tDesc = new TripleDESCryptoServiceProvider(){Key = key,Mode = CipherMode.ECB,Padding = PaddingMode.PKCS7})
			{
				ICryptoTransform tr = tDesc.CreateEncryptor();
				byte[] res = tr.TransformFinalBlock(data, 0, data.Length);
				return Convert.ToBase64String(res, 0, res.Length); 

			}
		}

	}
	
	public static string Decrypt(string input)
	{
		byte[] data = Convert.FromBase64String(input);

		using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
		{
			byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

			using (TripleDESCryptoServiceProvider tDesc = new TripleDESCryptoServiceProvider(){Key = key,Mode = CipherMode.ECB,Padding = PaddingMode.PKCS7})
			{
				ICryptoTransform tr = tDesc.CreateDecryptor();
				byte[] res = tr.TransformFinalBlock(data, 0, data.Length);
				return UTF8Encoding.UTF8.GetString(res);

			}
		}

	}
	
}
