﻿using System.Text;
using Cosmos.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    /// <summary>
    /// Hash/HMACMD5 encryption.
    /// Author: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Hash/HMAC/HMACMD5.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class HMACMD5EncryptProvicer : HMAC {
        private HMACMD5EncryptProvicer() { }

        /// <summary>
        /// HMACMD5 encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="key">Encryption key,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, string key, Encoding encoding = null) =>
            Encrypt<System.Security.Cryptography.HMACMD5>(data, key, encoding);
    }
}