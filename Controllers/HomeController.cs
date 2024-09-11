
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAppTestFull.Models;
using WebAppTestFull.Services;

[Authorize]
public class HomeController : Controller
{
    private readonly ExcelService _excelService;
    private readonly EmailService _emailService;

    public HomeController(ExcelService excelService, EmailService emailService)
    {
        _excelService = excelService;
        _emailService = emailService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GerarExcel(int quantidade)
    {
        var clientes = GerarClientesFicticios(quantidade);
        var excelBytes = _excelService.GenerateExcel(clientes);

        var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        var fileName = $"clientes_{quantidade}.xlsx";
        var filePath = Path.Combine(directoryPath, fileName);
        System.IO.File.WriteAllBytes(filePath, excelBytes);

        _emailService.SendEmail(filePath, "sergio.junior@atak.com.br", "https://github.com/YourRepoLink");

        return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }

    private List<Cliente> GerarClientesFicticios(int quantidade)
    {
        var clientes = new List<Cliente>();
        for (int i = 0; i < quantidade; i++)
        {
            clientes.Add(new Cliente
            {
                Nome = $"Cliente {i + 1}",
                Email = $"cliente{i + 1}@email.com",
                Telefone = $"(00) 0000-000{i}",
                DataNascimento = DateTime.Now.AddYears(-20).AddDays(i)
            });
        }
        return clientes;
    }
}
