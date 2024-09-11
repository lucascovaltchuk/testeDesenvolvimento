
using OfficeOpenXml;
using System.Collections.Generic;
using WebAppTestFull.Models;

namespace WebAppTestFull.Services
{
    public class ExcelService
    {
        public byte[] GenerateExcel(List<Cliente> clientes)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Clientes");

                worksheet.Cells[1, 1].Value = "Nome";
                worksheet.Cells[1, 2].Value = "Email";
                worksheet.Cells[1, 3].Value = "Telefone";
                worksheet.Cells[1, 4].Value = "Data de Nascimento";

                int row = 2;
                foreach (var cliente in clientes)
                {
                    worksheet.Cells[row, 1].Value = cliente.Nome;
                    worksheet.Cells[row, 2].Value = cliente.Email;
                    worksheet.Cells[row, 3].Value = cliente.Telefone;
                    worksheet.Cells[row, 4].Value = cliente.DataNascimento.ToString("dd/MM/yyyy");
                    row++;
                }

                return package.GetAsByteArray();
            }
        }
    }
}
