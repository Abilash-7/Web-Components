using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;

namespace Learning
{
    public partial class QR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Button Click Events for Each Amount
        protected void btnGenerate500_Click(object sender, EventArgs e)
        {
            GenerateQRCodeForAmount("500 Rs");
        }

        protected void btnGenerate1000_Click(object sender, EventArgs e)
        {
            GenerateQRCodeForAmount("1000 Rs");
        }

        protected void btnGenerate2000_Click(object sender, EventArgs e)
        {
            GenerateQRCodeForAmount("2000 Rs");
        }

        // Method to Generate QR Code for a Specific Amount
        private void GenerateQRCodeForAmount(string amount)
        {
            // Generate a random serial number
            string serialNumber = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();

            // Generate QR Code with serial number only
            string qrCodePath = GenerateQRCodeWithText(serialNumber);

            // Save to database
            SaveToDatabase(serialNumber, qrCodePath, amount);

            // Display the QR Code and serial number
            imgQRCode.ImageUrl = qrCodePath;
            lblSerialNumber.Text = $"Serial Number: {serialNumber}";
        }

        // Method to generate QR code with serial number only
        private string GenerateQRCodeWithText(string serialNumber)
        {
            string folderPath = Server.MapPath("~/QRCodes/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string qrCodePath = $"~/QRCodes/{serialNumber}.png";
            string fullPath = Server.MapPath(qrCodePath);

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(serialNumber, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap qrBitmap = qrCode.GetGraphic(20))
                    {
                        int additionalHeight = 30; // Space for the serial number text below the QR code
                        using (Bitmap bitmapWithText = new Bitmap(qrBitmap.Width, qrBitmap.Height + additionalHeight))
                        {
                            using (Graphics graphics = Graphics.FromImage(bitmapWithText))
                            {
                                // Draw the QR code
                                graphics.Clear(Color.White);
                                graphics.DrawImage(qrBitmap, new Point(0, 0));

                                // Draw the serial number below the QR code
                                using (Font font = new Font("Arial", 25, FontStyle.Bold))
                                {
                                    StringFormat stringFormat = new StringFormat
                                    {
                                        Alignment = StringAlignment.Center,
                                        LineAlignment = StringAlignment.Near
                                    };

                                    RectangleF textRectangle = new RectangleF(0, qrBitmap.Height - 30, qrBitmap.Width, additionalHeight);
                                    graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                                    graphics.DrawString(serialNumber, font, Brushes.Black, textRectangle, stringFormat);
                                }
                            }

                            // Save the final image
                            bitmapWithText.Save(fullPath, ImageFormat.Png);
                        }
                    }
                }
            }

            return qrCodePath;
        }

        private void SaveToDatabase(string serialNumber, string qrCodePath, string amount)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conSTR"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO QRCodes (SerialNumber, QRCodePath, Amount) VALUES (@SerialNumber, @QRCodePath, @Amount)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    command.Parameters.AddWithValue("@QRCodePath", qrCodePath);
                    command.Parameters.AddWithValue("@Amount", amount);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}