﻿using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using MotoRentalApp.Data;
using MotoRentalApp.Data.DTOs;
using MotoRentalApp.Models;

namespace MotoRentalApp.Controllers;
using Microsoft.AspNetCore.Mvc;
    

[ApiController]
[Route("entregadores")]
[Tags("Entregadores")]

public class DeliveryManController : ControllerBase
{
    private readonly DeliveryManContext _context;

    public DeliveryManController(DeliveryManContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Cadastrar um novo entregador
    /// </summary>
    /// <param name="deliveryManDto">Objeto com os campos necessários para cadastrar um novo entregador</param>
    /// <returns>IActionResult</returns>
    /// <response code="201"> Caso o entregador seja cadastrado com sucesso</response>
    /// <response code="400"> Dados inválidos</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)] 
    public IActionResult AddDeliveryMan([FromBody] CreateDeliveryManDto deliveryManDto)
    {
        
        var existingMoto = _context.DeliveryMan.Find(m => m.Identifier == deliveryManDto.Identifier).FirstOrDefault();
        if (existingMoto != null)
        {
            return BadRequest(new { mensagem = "Já existe um entregador cadastrado com este identifier." });
        }
        
        var existingCnpj = _context.DeliveryMan.Find(d => d.cnpj == deliveryManDto.cnpj).FirstOrDefault();

        var existingCnhNumber = _context.DeliveryMan.Find(d => d.cnh_number == deliveryManDto.cnh_number).FirstOrDefault();

        if (existingCnpj != null)
        {
            return BadRequest(new { mensagem = "CNPJ já cadastrado." });
        }
        
        if (existingCnhNumber != null)
        {
            return BadRequest(new { mensagem = "Número da CNH já cadastrado." });
        }
        
        var deliveryMan = new DeliveryMan
        {
            Identifier = deliveryManDto.Identifier,
            Name = deliveryManDto.Name,
            cnpj = deliveryManDto.cnpj,
            birth_date = deliveryManDto.birth_date,
            cnh_number = deliveryManDto.cnh_number,
            cnh_type = deliveryManDto.cnh_type,
            image_cnh = deliveryManDto.image_cnh
        };
        
        _context.DeliveryMan.InsertOne(deliveryMan);

        
        return Created("", deliveryMan);
    }
    
    
    /// <summary>
    /// Enviar a foto da CNH
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso seja enviado a foto com sucesso</response>
    /// <response code="404">Caso não seja válido</response>
    /// <response code="400">Caso não seja válido</response>
    [HttpPost("{id}/cnh")]
    [ProducesResponseType(StatusCodes.Status201Created)] 
    public IActionResult UploadCnh(string id, [FromForm] UpdateDeliveryManDto cnhDto)
    {
        
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest(new { mensagem = "Dados inválidos" });
        }
        
        var deliveryman = _context.DeliveryMan.Find(d => d.Identifier == id).FirstOrDefault();
        if (deliveryman == null)
        {
            return NotFound(new { mensagem = "Entregador não encontrado." });
        }
        
        
        var allowedExtensions = new[] { ".png", ".bmp" };
        var fileExtension = Path.GetExtension(cnhDto.CnhImage.FileName).ToLower();
        if (!allowedExtensions.Contains(fileExtension))
        {
            return BadRequest(new { mensagem = "Formato de arquivo inválido. Apenas .png e .bmp são permitidos." });
        }
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "CnhImages");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var filePath = Path.Combine(folderPath, $"{id}_cnh{fileExtension}");
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            cnhDto.CnhImage.CopyTo(stream);
        }

        var updateDefinition = Builders<DeliveryMan>.Update
            .Set(d => d.image_cnh, filePath);
        
        _context.DeliveryMan.UpdateOne(d => d.Identifier == id, updateDefinition);

       
        return Created("", new { mensagem = "Imagem enviada com sucesso.", caminho = filePath });
    }
    
    
}
