using QRCoder;
using System.Buffers.Text;

namespace TwoFactorAuthProject.Services
{
    public class QRCodeService
    {
        public string GenerateQRCode(string url)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new Base64QRCode(qrCodeData);
            return qrCode.GetGraphic(10);
        }
    }
}
