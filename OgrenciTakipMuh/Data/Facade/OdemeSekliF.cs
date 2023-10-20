using Dapper;
using OgrenciTakipMuh.Data.Tools;
using System;

namespace OgrenciTakipMuh.Data.Facade
{
    /// <summary>
    /// Ödeme şekilleri sql de tutulmaktadır 4 adet
    /// </summary>
    public class OdemeSekliF
    {
        public static int  IdGetir(string odemeSekliAdi)
        {
            try
            {
                return (int)Connections.cnn.ExecuteScalar($"SELECT Id FROM OdemeSekli WHERE OdemeSekliAdi='{odemeSekliAdi}'");
            }
            catch (Exception)
            {

                return 0;
            }
           
        }
    }
}
