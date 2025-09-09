using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP_Uploader
{
    class SettingsAdapter
    {
        public enum StorageProtocol
        {
            FTP,
        }

        public record StorageConfig(
            string Host,
            int Port,
            string Username,
            string Password,
            StorageProtocol Protocol,
            string RemoteBasePath, // Caminho da pasta que vai enviar as imagens
            string PublicBaseUrl, // URL pública para acessar as imagens
            bool UsePassiveMode, // Modo passivo para FTP
            int TimeoutMs
            );
    }
}
