using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;
using WinformsDashboard.Models;
using System.Threading.Tasks;
using System;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;

namespace WinformsDashboard.Services
{
    public class ReportExportService
    {
        public ReportExportService()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Student");
        }

        public async Task ExportToExcelAsync(string filePath, List<PowerLossRecord> records, PowerLossAIResponse? aiResponse)
        {
            await Task.Run(() =>
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("PowerLoss_Report");
                    
                    // Add AI Analysis Header
                    worksheet.Cells[1, 1].Value = "Nhận xét AI (Ollama):";
                    worksheet.Cells[1, 1].Style.Font.Bold = true;
                    if (aiResponse != null)
                    {
                        worksheet.Cells[2, 1].Value = $"Mức độ: {aiResponse.WasteLevel}";
                        worksheet.Cells[3, 1].Value = $"Chi phí dự kiến (Tháng): {aiResponse.EstimatedMonthlyLoss} VNĐ";
                        worksheet.Cells[4, 1].Value = $"Đề xuất: {aiResponse.Recommendation}";
                    }

                    // Add Table Headers
                    worksheet.Cells[6, 1].Value = "Thời Gian";
                    worksheet.Cells[6, 2].Value = "Thiết Bị (ID)";
                    worksheet.Cells[6, 3].Value = "Dòng Rò (mA)";
                    worksheet.Cells[6, 4].Value = "Công Suất Thất Thoát (W)";
                    worksheet.Cells[6, 5].Value = "Điện Năng (kWh)";
                    worksheet.Cells[6, 6].Value = "Chi Phí (VNĐ)";
                    using (var range = worksheet.Cells[6, 1, 6, 6])
                    {
                        range.Style.Font.Bold = true;
                    }

                    int row = 7;
                    foreach (var record in records)
                    {
                        worksheet.Cells[row, 1].Value = record.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cells[row, 2].Value = record.DeviceID;
                        worksheet.Cells[row, 3].Value = record.LeakageCurrent;
                        worksheet.Cells[row, 4].Value = record.PowerLoss;
                        worksheet.Cells[row, 5].Value = record.EnergyLoss;
                        worksheet.Cells[row, 6].Value = record.CostLoss;
                        row++;
                    }

                    worksheet.Cells.AutoFitColumns();
                    package.SaveAs(new FileInfo(filePath));
                }
            });
        }

        public async Task ExportToPdfAsync(string filePath, List<PowerLossRecord> records, PowerLossAIResponse? aiResponse)
        {
            await Task.Run(() =>
            {
                using (PdfWriter writer = new PdfWriter(filePath))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf))
                {
                    PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    
                    PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    
                    document.Add(new Paragraph("Bao Cao Phan Tich That Thoat Dien Nang")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(20)
                        .SetFont(boldFont));

                    if (aiResponse != null)
                    {
                        document.Add(new Paragraph("Nhan xet AI (Ollama):").SetFont(boldFont));
                        document.Add(new Paragraph($"Muc do lang phi: {aiResponse.WasteLevel}").SetFont(font));
                        document.Add(new Paragraph($"Chi phi du kien (Thang): {aiResponse.EstimatedMonthlyLoss} VND").SetFont(font));
                        document.Add(new Paragraph($"De xuat: {aiResponse.Recommendation}").SetFont(font));
                        document.Add(new Paragraph("\n"));
                    }

                    Table table = new Table(5, true);
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Thoi Gian").SetFont(boldFont)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Dong Ro (mA)").SetFont(boldFont)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Cong Suat (W)").SetFont(boldFont)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Dien Nang (kWh)").SetFont(boldFont)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Chi Phi (VND)").SetFont(boldFont)));

                    foreach (var record in records)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(record.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"))));
                        table.AddCell(new Cell().Add(new Paragraph(record.LeakageCurrent.ToString("F2"))));
                        table.AddCell(new Cell().Add(new Paragraph(record.PowerLoss.ToString("F2"))));
                        table.AddCell(new Cell().Add(new Paragraph(record.EnergyLoss.ToString("F4"))));
                        table.AddCell(new Cell().Add(new Paragraph(record.CostLoss.ToString("F0"))));
                    }
                    
                    document.Add(table);
                }
            });
        }
    }
}
